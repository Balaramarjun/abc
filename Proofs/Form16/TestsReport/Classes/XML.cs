using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace TestsReport.Classes
{
    public class XML
    {
        private static XmlDocument xmlDoc { get; set; }
        private static TestResult result { get; set; }
        public XML(string fileName)
        {
            // Read the trx file
            result = new TestResult();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
        }

        public TestResult GetTestRunResult()
        {
            GetTestResultSummary();
            XmlRead(result); //tra and unit tests
            return result;
        }

        private void XmlRead(TestResult result)
        {
            XmlNodeList listTestResults = xmlDoc.GetElementsByTagName("Results");
            XmlNode results = listTestResults.Count > 0 ? listTestResults[0] : null;

            if (results != null)
            {
                XmlNodeList listTestResultAggregation = results.ChildNodes;

                // Sort the list in alphabetical order to display the report in the order of test execution
                var varTestResultAggregation = listTestResultAggregation.Cast<XmlNode>().OrderBy(r => r.Attributes[2].Value);

                foreach (XmlNode node in varTestResultAggregation)
                {
                    TestResultAggregation tra = GetTestResultAggregation(node);

                    if (tra.ExecutionResult == "Passed")
                    {
                        result.PassedTests.Add(tra);
                    }
                    else if (tra.ExecutionResult == "Failed")
                    {
                        result.FailedTests.Add(tra);
                        if (tra.UnitTests.Any(x => x.ExecutionResult.Equals("NotExecuted")))
                        {
                            result.SkippedTests.Add(tra);
                        }
                    }
                    tra.UnitTestCount = tra.UnitTests.Count;
                }
                result.OrderedTests = result.PassedTests.Count + result.FailedTests.Count;
                result.PassedOrderedTest = result.PassedTests.Count;
                result.FailedOrderedTest = result.FailedTests.Count;
            }
        }

        private static TestResultAggregation GetTestResultAggregation(XmlNode node)
        {
            TestResultAggregation tra = new TestResultAggregation();
            tra.Name = node.Attributes["testName"].Value;
            tra.Id = "acc" + node.Attributes["executionId"].Value.Replace("-", "");
            tra.Time = node.Attributes["duration"] == null ? "00:00:00.00" : node.Attributes["duration"].Value;
            tra.Outcome = node.Attributes["outcome"].Value == "Passed"
               ? true : false;
            tra.ExecutionResult = node.Attributes["outcome"].Value;
            if (node.Name.Equals("TestResultAggregation"))
            {
                try
                {
                    //find utr and tra children
                    XmlNodeList childNodes = node.FirstChild.ChildNodes;

                    int count = 1;
                    foreach (XmlNode childNode in childNodes)
                    {
                        TestResultAggregation childTRA = GetTestResultAggregation(childNode);
                        childTRA.RowCount = count++;
                        tra.UnitTests.Add(childTRA);
                    }
                }
                catch
                {

                }
            }
            return tra;
        }
        private static void GetTestResultSummary()
        {
            XmlNodeList listTestRun = xmlDoc.GetElementsByTagName("TestRun");
            XmlNodeList listTestResultSummary = xmlDoc.GetElementsByTagName("ResultSummary");

            XmlNode testRun = listTestRun.Count > 0 ? listTestRun[0] : null;
            XmlNode resultSummary = listTestResultSummary.Count > 0 ? listTestResultSummary[0] : null;

            XmlNode childTestResultSummary = resultSummary.FirstChild;

            // Get the Times node
            XmlNode times = testRun.FirstChild;

            if (testRun != null && resultSummary != null)
            {
                try
                {
                    result.Name = testRun.Attributes["name"].Value;
                    result.User = testRun.Attributes["runUser"].Value;
                    result.Pass = resultSummary.Attributes["outcome"].Value.Equals("Failed") ? false : true;
                    result.TotalTests = int.Parse(childTestResultSummary.Attributes["total"].Value);
                    result.Passed = int.Parse(childTestResultSummary.Attributes["passed"].Value);
                    result.Failed = int.Parse(childTestResultSummary.Attributes["failed"].Value);
                    result.Skipped = result.TotalTests - int.Parse(childTestResultSummary.Attributes["executed"].Value);
                    result.PassPercentage = result.TotalTests != 0 ? Math.Round((result.Passed * 100) / result.TotalTests, 2) : 0;

                    // Get the start time and convert it to dd-mm-yyyy HH:mm:ss format
                    string startTime = times.Attributes["start"].Value;
                    string utcTime = startTime.Substring(startTime.Length - 6);
                    // Get the UTC time zone value (i.e. last 6 characters)
                    DateTime startTimeConverted = ConvertDate(startTime);
                    result.StartedOn = startTimeConverted.ToString() + " (UTC" + utcTime + ")";

                    // Get the created time and convert it to dd-mm-yyyy HH:mm:ss format
                    string creationTime = times.Attributes["creation"].Value;
                    creationTime = creationTime.Replace("T", " ").Remove(creationTime.IndexOf("."));
                    DateTime creationTimeConverted = DateTime.ParseExact(creationTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    //result.StartedOn = creationTimeConverted.ToString();                    

                    // Get the finish time and convert it to dd-mm-yyyy HH:mm:ss format
                    string finishTime = times.Attributes["finish"].Value;
                    DateTime finishTimeConverted = ConvertDate(finishTime);
                    result.CompletedOn = finishTimeConverted.ToString() + " (UTC" + utcTime + ")";

                    // Get the time difference between finish and start time
                    TimeSpan timediff = finishTimeConverted - startTimeConverted;

                    // Split the timediff to get hours and minutes
                    var duration = timediff.ToString("hh\\:mm\\:ss").Split(":");

                    // Get the hours part from timediff 
                    int totalhours = timediff.Hours;

                    // Get the minutes part from timediff
                    int totalMinutes = timediff.Minutes;

                    // display hours and minute if hours count is greater than zero else display minutes and seconds
                    if (totalhours > 0)
                    {
                        // Concatenate the duration values with suffixing text 'h' for hour and text 'm' for minute with truncating any leading zero in hour 
                        result.Duration = (duration[0] + "h " + duration[1] + "m ").TrimStart('0');
                    }
                    else if (totalhours == 0 && totalMinutes > 0)
                    {
                        // Concatenate the duration values with suffixing text 'm' for minutes and text 's' for seconds with truncating any leading zero in minute 
                        result.Duration = (duration[1] + "m " + duration[2] + "s ").TrimStart('0');
                    }
                    else if (totalhours == 0 && totalMinutes == 0)
                    {
                        // Concatenate the duration values with suffixing text 's' for seconds with truncating any leading zero in second 
                        result.Duration = (duration[2] + "s ").TrimStart('0');
                    }
                }
                catch
                {
                    //handle exception
                }
            }
        }
        private static DateTime ConvertDate(string startTime)
        {
            startTime = startTime.Replace("T", " ").Remove(startTime.IndexOf("."));
            DateTime startTimeConverted = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return startTimeConverted;
        }
    }
}
