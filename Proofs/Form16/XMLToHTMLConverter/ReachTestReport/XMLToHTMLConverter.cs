using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ReachTestReport
{
    public class XMLToHTMLConverter
    {
        static void Main(string[] args)
        {
            var reports = new List<XMLReport>();
            StreamReader reader = null;
            var path = args[0];
            //var path = ConfigurationManager.AppSettings["TestFolderPath"];
            foreach (var file in System.IO.Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories))
            {
                reader = new StreamReader(file);
                XmlSerializer serializer = new XmlSerializer(typeof(TestSuites));
                var testsuites = (TestSuites)serializer.Deserialize(reader);
                reader.Close();
                if (testsuites != null)
                {
                    var report = new XMLReport
                    {
                        TestCaseName = testsuites.name,
                        TimeDuration = testsuites.time,
                        IsPassed = (testsuites).testsuites.Any(x => x.failures != "0") ? false : true,
                        Error = (testsuites).testsuites.Where(e => e.errors != "0").Select(e => e.errors).FirstOrDefault(),
                    };
                    reports.Add(report);
                }
            }

            if (reports.Any())
            {
                new WriteToHtml().HtmlWriter(reports, args[1], args[2], args[3],args[4]);
                //new WriteToHtml().HtmlWriter(reports, null, null, null);
            }
        }
    }


    public class XMLReport
    {
        public string TestCaseName { get; set; }
        public bool IsPassed { get; set; }
        public string TimeDuration { get; set; }
        public string Error { get; set; }
    }

    [XmlRoot("testsuites")]
    public class TestSuites
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("time")]
        public string time { get; set; }
        [XmlElement("testsuite")]
        public List<TestSuite> testsuites { get; set; }
    }
    [XmlRoot("testsuite")]
    public class TestSuite
    {
        [XmlAttribute("failures")]
        public string failures { get; set; }
        [XmlAttribute("errors")]
        public string errors { get; set; }
    }

    public class WriteToHtml
    {
        private string _totalHeader = "<table class=\"table table-md m-0 result-table \"><thead><th> # </th><th class\"testname\">Test Name</th><th>Outcome</th><th>Duration</th></thead><tbody>";
        private string _passHeader = "<table class=\"table table-md m-0 result-table \"><thead><th> # </th><th class\"testname\">Test Name</th><th>Duration</th></thead><tbody>";
        private string _failHeader = "<table class=\"table table-md m-0 result-table \"><thead><th> # </th><th class\"testname\">Test Name</th><th>Error</th><th>Duration</th></thead><tbody>";
        private string _endtable = "</tbody></table>";
        private int totalNum = 0;
        private int passNum = 0;
        private int failNum = 0;
        public void HtmlWriter(List<XMLReport> reports, string GenerateReportPath, string ProjectName, string Testrunname, string baseDirectory)
        {
            var totalBody = "";
            var passBody = "";
            var failBody = "";
            var totalduration = 0.0;
            var sortedReports = reports.OrderBy(r => r.IsPassed);
            foreach (var rep in sortedReports)
            {
                try
                {
                    totalduration += double.Parse(rep.TimeDuration);
                }
                catch (Exception e)
                {
                    totalduration += 0.0;
                }

                if (rep.IsPassed)
                {
                    totalBody += AddTotalRecord(rep.TestCaseName, "Passed", rep.TimeDuration);
                    passBody += AddPassRecord(rep.TestCaseName, rep.TimeDuration);
                }
                else
                {
                    totalBody += AddTotalRecord(rep.TestCaseName, "Failed", rep.TimeDuration);
                    failBody += AddFailRecord(rep.TestCaseName, rep.Error, rep.TimeDuration);
                }
            }
            var totalrecords = reports.Count();
            var passedrecords = reports.Count(c => c.IsPassed);
            var perc = (decimal)passedrecords / (decimal)totalrecords * 100;

            string rname = ProjectName;
            //string rname = ConfigurationManager.AppSettings["ProjectName"];
            //string templateFilePath = Directory.GetCurrentDirectory();
            //Console.WriteLine("Current Directory :"+ templateFilePath);
            //var splitTemplateFilePath = Regex.Split(templateFilePath, "bin");
            string text = File.ReadAllText(baseDirectory + "SampleReport.html");
            text = text.Replace("$ProjectName", rname)
                .Replace("$TotalTests", !string.IsNullOrEmpty(totalBody) ? _totalHeader + totalBody + _endtable : "")
                .Replace("$FailedTests", !string.IsNullOrEmpty(failBody) ? _failHeader + failBody + _endtable : "")
                .Replace("$PassedTests", !string.IsNullOrEmpty(passBody) ? _passHeader + passBody + _endtable : "")
                .Replace("$TestSummary", totalrecords + " / " + passedrecords + " passed, " + (totalrecords - passedrecords) + " failed")
                .Replace("$TotalDuration", Math.Round(totalduration, 2) + " s")
                .Replace("$PassRecords", "" + passedrecords)
                .Replace("$FailedRecords", "" + (totalrecords - passedrecords))
                .Replace("$PassPercent", Math.Round(perc, 2) + "%")
                .Replace("$Testrunname", Testrunname + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var destinationpath = GenerateReportPath;
            // .Replace("$Testrunname", ConfigurationManager.AppSettings["Testrunname"] + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //var destinationpath = ConfigurationManager.AppSettings["GenerateReportPath"];
            if (!Directory.Exists(destinationpath))
            {
                Directory.CreateDirectory(destinationpath);
            }
            File.WriteAllText(destinationpath + rname + ".html", text);
        }
        private string AddPassRecord(string name, string time)
        {
            passNum++;
            return "<tr><td> " + passNum + " </td><td>" + name + "</td><td>" + time + "</td></tr>";
        }

        private string AddFailRecord(string name, string error, string time)
        {
            failNum++;
            return "<tr><td> " + failNum + " <td>" + name + "</td><td>" + error + "</td><td>" + time + "</td></tr>";
        }

        private string AddTotalRecord(string name, string outcome, string time)
        {
            totalNum++;
            return "<tr class=\"" + (outcome.Equals("Failed") ? "failed" : "passed") + "\" ><td> " + totalNum + " <td>" + name + "</td><td>" + outcome + "</td><td>" + time + "</td></tr>";
        }
    }
}
