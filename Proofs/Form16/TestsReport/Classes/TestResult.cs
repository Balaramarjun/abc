using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestsReport.Classes
{
    public class TestResult
    {        
        public string Name { get; set; }        
        public bool Pass { get; set; }
        public string Duration { get; set; }
        public string User { get; set; }
        public string StartedOn { get; set; }
        public string CompletedOn { get; set; }
        public double OrderedTests { get; set; }
        public double TotalTests { get; set; }
        public double Passed { get; set; }
        public double PassedOrderedTest { get; set; }
        public double FailedOrderedTest { get; set; }
        public double Failed { get; set; }
        public double Skipped { get; set; }
        public double PassPercentage { get; set; }
        
        public List<TestResultAggregation> FailedTests { get; set; }
        public List<TestResultAggregation> PassedTests { get; set; }
        public List<TestResultAggregation> SkippedTests { get; set; }        

        public TestResult()
        {
            Name = string.Empty;
            Pass = false;
            Duration = string.Empty;
            User = string.Empty;
            StartedOn = string.Empty;
            CompletedOn = string.Empty;
            OrderedTests = 0;
            TotalTests = 0;
            
            Passed = 0;
            Failed = 0;
            Skipped = 0;
            PassPercentage = 0;            
            FailedTests = new List<TestResultAggregation>();
            PassedTests = new List<TestResultAggregation>();
            SkippedTests = new List<TestResultAggregation>();
        }
    }
}
