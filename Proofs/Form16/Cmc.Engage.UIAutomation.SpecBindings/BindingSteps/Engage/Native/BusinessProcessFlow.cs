using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class BusinessProcessFlow : BindingStepBase
    {
        public BusinessProcessFlow(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {

        }
        [When(@"I complete (.*) stage  in BPF")]
        [Given(@"I complete (.*) stage  in BPF")]
        [Then(@"I complete (.*) stage  in BPF")]
        public void WhenICompleteBPFStage(string stage)
        {
            XrmApp.BusinessProcessFlow.NextStage(stage);
            XrmApp.ThinkTime(2000);
        }
        [When(@"I select (.*) stage  in BPF")]
        [Given(@"I select (.*) stage  in BPF")]
        [Then(@"I select (.*) stage  in BPF")]
        public void WhenISelectBPFStage(string stage)
        {
            XrmApp.BusinessProcessFlow.SelectStage(stage);
            XrmApp.ThinkTime(2000);
        }
        [Given(@"I have set (.*) option in BPF")]
        [When(@"I have set (.*) option in BPF")]
        [Then(@"I have set (.*) option in BPF")]
        public void WhenIHaveSetValueToBooleanItemInBPF(string fieldName)
        {
            XrmApp.BusinessProcessFlow.SetValue(new BooleanItem { Name = fieldName });
            XrmApp.ThinkTime(2000);

        }
        [Given(@"I complete (.*) stage and set Fields in BPF")]
        [When(@"I complete (.*) stage and set Fields in BPF")]
        [Then(@"I complete (.*) stage and set Fields in BPF")]
        public void WhenIcompletestageAndSetFieldsinBPF(string Stage, string fieldName, string fieldValue)
        {

            XrmApp.BusinessProcessFlow.NextStage(Stage, new Field { Name = fieldName, Value = fieldValue });
            XrmApp.ThinkTime(1000);
        }
        [Given(@"I enter the below data in the BPF")]
        public void GivenIEnterTheBelowDataInTheForm(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var fieldType = tableRow["Type"];
                var Stage = tableRow["Stage"];
                var fieldName = tableRow["FieldName"];
                var fieldValue = tableRow["FieldValue"];
               
                switch (fieldType)
                {

                    case "BooleanItem":
                        WhenIHaveSetValueToBooleanItemInBPF(fieldName);
                        break;
                    case "Field":
                        WhenIcompletestageAndSetFieldsinBPF(Stage, fieldName, fieldValue);
                        break;
                }
            }
        }
     

    }
}

