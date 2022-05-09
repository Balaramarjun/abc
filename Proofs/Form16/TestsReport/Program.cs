using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestsReport.Classes;
using TestsReport.Helpers;

namespace TestsReport
{
    class Program
    {
        private static Build build;
        private static string pipeline;
        private static string filePath;
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 3)
                {
                    Console.WriteLine("TestReport.exe <FILE_PATH> <PIPELINE_NAME> <BUILD_ID> <BUILD_NUMBER> <BASE_ADDRESS>");
                    return;
                }
                string trxFilePath = args[0];
                pipeline = args[1];
                int buildId = Int32.Parse(args[2]);
                string buildNumber = args[3];
                string baseAdress = args[4];
                GetBuildInformaiton(pipeline, buildId, buildNumber, baseAdress);
                getTestResult(pipeline, trxFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static async void GetBuildInformaiton(string pipeline, int buildId, string buildNumber, string baseAddress)
        {
            try
            {
                build = await RestAPI.GetBuildInformation(pipeline, buildId, buildNumber, baseAddress);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        private static void getTestResult(string pipeline, string path)
        {            
            if(Directory.Exists(path))
            {
                string[] files = System.IO.Directory.GetFiles(path, "*.trx");
                if(files.Length < 1)
                {
                    Console.WriteLine("trx file does not exist");
                    return;
                }
                XML xml = new XML(files[0]);
                //for loop if file needs to be created for every trx file in the folder
                TestResult result = xml.GetTestRunResult();
                string res = testHandleBars(result, pipeline);
                generateReport(res);
            }
            else
            {
                Console.WriteLine("trx file path is incorrect");
                return;
            }
        }       
        private static string testHandleBars(TestResult result, string pipeline)
        {
            string templateFilePath = Assembly.GetExecutingAssembly().Location;
            var splitTemplateFilePath = Regex.Split(templateFilePath, "bin");

            string src = File.ReadAllText(splitTemplateFilePath[0] + "template//template-default.hbs");
            string srcUnitTest = File.ReadAllText(splitTemplateFilePath[0] + "template//template-UnitTest.hbs");
            string srcUnitTest2 = File.ReadAllText(splitTemplateFilePath[0] + "template//template-UnitTest2.hbs");
            string srcPassTest = File.ReadAllText(splitTemplateFilePath[0] + "template//template-PassTest.hbs");
            string srcFailTest = File.ReadAllText(splitTemplateFilePath[0] + "template//template-FailTest.hbs");
            string srcSkippedTest = File.ReadAllText(splitTemplateFilePath[0] + "template//template-SkippedTest.hbs");

            //string src = File.ReadAllText(@"../../../template/template-default.hbs");            
            //string srcUnitTest = File.ReadAllText(@"../../../template/template-UnitTest.hbs");
            //string srcUnitTest2 = File.ReadAllText(@"../../../template/template-UnitTest2.hbs");
            //string srcPassTest = File.ReadAllText(@"../../../template/template-PassTest.hbs");
            //string srcFailTest = File.ReadAllText(@"../../../template/template-FailTest.hbs");
            //string srcSkippedTest = File.ReadAllText(@"../../../template/template-SkippedTest.hbs");

            //Handlebars.RegisterTemplate("OrderedTest", srcOrderedTest);
            Handlebars.RegisterTemplate("UnitTest", srcUnitTest);
            Handlebars.RegisterTemplate("UnitTest2", srcUnitTest2);
            Handlebars.RegisterHelper("ifCheckLength", (output, options, context, arguments) =>
            {                               
                if (arguments[0].Equals(0))
                {
                    options.Template(output, context);
                }
                else
                {
                    options.Template(output, context);
                    options.Inverse(output, context);
                }

            });
            Handlebars.RegisterTemplate("FailedTest", srcFailTest);
            Handlebars.RegisterTemplate("PassedTest", srcPassTest);
            Handlebars.RegisterTemplate("SkippedTest", srcSkippedTest);

          
            var template = Handlebars.Compile(src);
            var data = new
            {          
                build,
                pipeline,
                result,
                FailedTests = result.FailedTests,
                PassedTests = result.PassedTests,
                SkippedTests = result.SkippedTests
            };

            var res = template(data);            
            return res;
        }
        
        private static void generateReport(string src)
        {
            // Generate the Test Result File path based on executing assembly for command line execution
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            var splitassemblyPath = Regex.Split(assemblyPath, "TestsReport.dll");
            string testsResultFile = splitassemblyPath[0]  + build.BuildNumber + "_TestResult.html"; // "TestResult.html";

            if (File.Exists(testsResultFile))
            {
                File.Delete(testsResultFile);
            }

            using (FileStream fs = new FileStream(testsResultFile, FileMode.Append))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(src);                
                }
            }
        }
              
    }
}
