using System;
using System.Collections.Generic;
using System.Text;

namespace TestsReport.Classes
{
    public class Build
    {
        public string Url { get; set; }        
        public string Name { get; set; }
        public int DefinitionId { get; set; }
        public int Id { get; set; }
        public string BuildNumber { get; set; }

        public Build()
        {            
            Name = string.Empty;
            DefinitionId = 0;
            Id = 0;
            BuildNumber = string.Empty;
            Url = string.Empty;
        }
    }
}
