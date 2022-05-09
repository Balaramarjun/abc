using System;
using System.Collections.Generic;
using System.Text;

namespace TestsReport.Classes
{    
    public class TestResultAggregation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public bool Outcome { get; set; }
        public string ExecutionResult { get; set; }
        public int RowCount { get; set; }
        public int UnitTestCount { get; set; }
        public List<TestResultAggregation> UnitTests { get; set; }
        public TestResultAggregation()
        {
            Id = string.Empty;
            Name = string.Empty;
            Time = string.Empty;
            Outcome = false;
            ExecutionResult = string.Empty;
            RowCount = 1;
            UnitTests = new List<TestResultAggregation>();
            UnitTestCount = 0;
        }       
    }
}
