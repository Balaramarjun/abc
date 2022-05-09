using Cmc.Engage.UIAutomation.Framework;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class Entity : BindingStepBase
    {
        public Entity(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have set (.*) to (.*) text field in the Form")]
        [When(@"I have set (.*) to (.*) text field in the Form")]
        public void GivenIHaveSetValueToTextFieldInTheForm(string fieldValue, string fieldName)
        {
            XrmApp.Entity.SetValue(fieldName, "");
            XrmApp.ThinkTime(4000);
            XrmApp.Entity.SetValue(fieldName, fieldValue);
        }

        [Given(@"I have set (.*) to (.*) text field uniquely in the Form")]
        [When(@"I have set (.*) to (.*) text field uniquely in the Form")]
        public void GivenIHaveSetValueToTextFieldUniquelyInTheForm(string fieldValue, string fieldName)
        {
            //XrmApp.ThinkTime(2000);
          //  XrmApp.Entity.SetValue(fieldName, "");
            var value = fieldValue + TestSettings.GetRandomString(4, 5);
            XrmApp.Entity.SetValue(fieldName, value);
          //  XrmApp.ThinkTime(1000);
           // AddFieldValueToFeatureContext(fieldName, fieldValue);
          //  XrmApp.Entity.PressTab();

        }

        [Given(@"I have set (.*) to (.*) numeric field in the Form")]
        [When(@"I have set (.*) to (.*) numeric field in the Form")]
        public void GivenIHaveSetValueToNumericFieldInTheForm(string fieldValue, string fieldName)
        {
            XrmApp.Entity.SetValue(fieldName, fieldValue);
        }

        [Given(@"I have set (.*) to (.*) optionset field in the Form")]
        [When(@"I have set (.*) to (.*) optionset field in the Form")]
        public void GivenIHaveSetValueToOptionsetFieldInTheForm(string fieldValue, string fieldName)
        {
            XrmApp.Entity.SetValue(new OptionSet { Name = fieldName, Value = fieldValue });
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I have set (.*) to (.*) lookup field in the Form")]
        [When(@"I have set (.*) to (.*) lookup field in the Form")]
        public void GivenIHaveSetValueToLookupFieldInTheForm(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };
            XrmApp.Entity.SetValue(new LookupItem[] { lookupItem });
            XrmApp.ThinkTime(2000);
        }
        [Given(@"I have set (.*) to (.*) lookup item in the Form")]
        [When(@"I have set (.*) to (.*) lookup item in the Form")]
        public void GivenIHaveSetValueToLookupItemInTheForm(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };
            //  XrmApp.Entity.HighlightElement(lookupItem);
            XrmApp.ThinkTime(2000);
            XrmApp.Entity.SetValue(lookupItem);
            
          XrmApp.ThinkTime(4000);
        }

        [Given(@"I Verify lookup Value (.*) is not available in (.*) lookup item in the Form")]
        [When(@"I Verify lookup Value (.*) is not available in (.*) lookup item in the Form")]
        [Then(@"I Verify lookup Value (.*) is not available in (.*) lookup item in the Form")]
        public void IVerifyLookupValueIsNotPresent(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };
            XrmApp.ThinkTime(2000);
            try
            {
                XrmApp.Entity.SetValue(lookupItem);
                XrmApp.ThinkTime(4000);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No Results Matching " + fieldValue + " Were Found."))
                    Console.WriteLine("Data not found");
            }
        }
        [Given(@"I have set (.*) to (.*) datetime field in the Form")]
        [When(@"I have set (.*) to (.*) datetime field in the Form")]
        public void GivenIHaveSetValueToDatetimeFieldInTheForm(DateTime fieldValue, string fieldName)
        {
            try 
            { 
            XrmApp.Entity.SetValue(fieldName, fieldValue);
                XrmApp.ThinkTime(3000);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no such element"))

                    Console.WriteLine("Date Error handled");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <param name="fieldName"></param>
        [Given(@"I have set (.*) to (.*) date field in the Form")]
        [When(@"I have set (.*) to (.*) date field in the Form")]
        public void GivenIHaveSetValueToDateFieldInTheForm(DateTime fieldValue, string fieldName)
        {
            try
            {
                //    var DateControl = new DateTimeControl(fieldName){Value = fieldValue.AddDays(1)};
                
                //XrmApp.Entity.SetValue(fieldName, fieldValue, "MM/dd/yyyy");
                XrmApp.Entity.SetValue(fieldName, fieldValue, "M/d/yyyy");
                XrmApp.ThinkTime(3000);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no such element"))
                {
                    Console.WriteLine("Date Error handled");
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }

        }
        [Given(@"I have set date value (.*) to (.*) field in the Form")]
        [When(@"I have set date value (.*) to (.*) field in the Form")]
        public void GivenIHaveSetFutureToDateFieldInTheForm(string fieldValue, string fieldName)
        {
            
                //   var DateControl = new DateTimeControl(fieldName){Value = fieldValue.AddDays(2)};

                XrmApp.Entity.SetDateValue(fieldValue, fieldName);
                XrmApp.ThinkTime(3000);

            

        }

        [Given(@"I enter date time value (.*) to (.*) field in the Form")]
        [When(@"I enter date time value (.*) to (.*) field in the Form")]
        public void GivenIsetDateTimetoFieldInTheForm(string fieldValue, string fieldName)
        {

            //   var DateControl = new DateTimeControl(fieldName){Value = fieldValue.AddDays(2)};

            XrmApp.Entity.SetDateTimeValue(fieldValue, fieldName);
            XrmApp.ThinkTime(3000);
        }

        [Given(@"I set future date time value to (.*) field in the Form")]
        [When(@"I set future date time value to (.*) field in the Form")]
        public void GivenIsetfutureDateTimetoFieldInTheForm(string fieldName)
        {
          
            string fieldValue = DateTime.Today.AddDays(1).ToShortDateString();
            Console.WriteLine("fieldValue" + fieldValue);
                       XrmApp.Entity.SetDateTimeValue(fieldValue, fieldName);
            XrmApp.ThinkTime(3000);
        }


        [Given(@"I have set next day to current date to (.*) field in the Form")]
        [When(@"I have set next day to current date to (.*) field in the Form")]
        public void GivenIHaveSetCurrentDateFieldInTheForm(string fieldName)
        {
            try
            {

                DateTime fieldValue;
                // var DateControl = new DateTimeControl(fieldName){Value = DateTime.Today};
                fieldValue = DateTime.Today.AddDays(1);
              
                XrmApp.Entity.SetValue(fieldName, fieldValue, "MM/dd/yyyy");
               
                XrmApp.ThinkTime(3000);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no such element"))

                    Console.WriteLine("Date Error handled");

            }
            //   var DateControl = new DateTimeControl(fieldName){Value = fieldValue.AddDays(2)};

        }

        [When(@"I press Save in the form")]
        [Given(@"I press Save in the form")]
        [Then(@"I press Save in the form")]
        public void WhenIPressSaveInTheForm()
        {
            //XrmApp.Entity.Save();
           XrmApp.Entity.SaveNew();


            XrmApp.ThinkTime(2000);
        }

        [Then(@"the Entity should be saved")]
        public void ThenTheEntityShouldBeSaved()
        {
            XrmApp.ThinkTime(5000);
        }

        [Given(@"After Form Loads")]
        public void GivenAfterFormLoads()
        {
        }

        [When(@"I press Delete in the form")]
        public void WhenIPressDeleteInTheForm()
        {
            XrmApp.Entity.Delete();
        }
        [Given(@"I select the tab (.*) in the form")]
        [When(@"I select the tab (.*) in the form")]
        [Then(@"I select the tab (.*) in the form")]
        public void GivenISelectTheTabInTheForm(string tabName)
        {
            XrmApp.Entity.SelectTab(tabName);
            XrmApp.ThinkTime(3000);

        }

        [Given(@"I select the sub tab (.*) of tab (.*) in the form")]
        [When(@"I select the sub tab (.*) of tab (.*) in the form")]
        [Then(@"I select the sub tab (.*) of tab (.*) in the form")]
        public void GivenISelectTheSubTabInTheForm(string subTabName, string tabName)
        {
            XrmApp.Entity.SelectTab(tabName, subTabName);
        }
        [Given(@"I navigate to sub tab (.*) of available tab (.*) in the form")]
        [When(@"I navigate to sub tab (.*) of available tab (.*) in the form")]
        [Then(@"I navigate to sub tab (.*) of available tab (.*) in the form")]
        public void GivenINavigateToSubTabInTheForm(string subTabName, string tabName)
        {
            try
            {
                XrmApp.Entity.SelectTab(tabName, subTabName);
            }
            //catch (StaleElementReferenceException)
            //{

            //    Console.WriteLine("Ignored stale element exception if any");
            //}
            catch (Exception ex)
                {
                if (ex !=null) 
                {            
                    try
                    {

                        XrmApp.Entity.SelectTab("Related", subTabName);
                        
                    }
                    catch (StaleElementReferenceException)
                    {

                        Console.WriteLine("Ignored stale element exception if any");
                    }
                }
             
            }

            
        }
        [Then(@"(.*) field value should not be empty")]
        public void ThenFieldValueShouldNotBeEmpty(string fieldName)
        {
            var querytext = XrmApp.Entity.GetValue(fieldName);
            Console.WriteLine(querytext);
            Assert.IsTrue(!String.IsNullOrEmpty(querytext));
          
        }

                [Then(@"The (.*) field value should be equal to (.*)")]
        public void ThenTheFieldValueShouldBe(string Fieldname, string ExpectedFieldValue)
        {
            XrmApp.ThinkTime(3000);
            var querytext = XrmApp.Entity.GetValue(Fieldname);
            System.Console.WriteLine(querytext);
            Assert.AreEqual(ExpectedFieldValue, querytext);
            //  Assert.IsTrue(querytext.StartsWith(ExpectedFieldValue));

        }

        [Given(@"The optionset (.*) value should be equal to (.*)")]
        [When(@"The optionset (.*) value should be equal to (.*)")]
        [Then(@"The optionset (.*) value should be equal to (.*)")]
        public void ThenOptionSetValueShouldBe(string Fieldname, string ExpectedFieldValue)
        {

            var OptionSet = new OptionSet

            {
                Name = Fieldname,
                
            };
           var querytext = XrmApp.Entity.GetValue(OptionSet);
           
            System.Console.WriteLine(querytext);
          
            Assert.AreEqual(ExpectedFieldValue, querytext);
          

        }
        [Given(@"The optionset value (.*) should not be empty")]
        [When(@"The optionset value (.*) should not be empty")]
        [Then(@"The optionset value (.*) should not be empty")]
        public void ThenOptionSetValueShouldNotBeEmpty(string Fieldname)
        {

            var OptionSet = new OptionSet

            {
                Name = Fieldname,

            };
            var querytext = XrmApp.Entity.GetValue(OptionSet);

            System.Console.WriteLine(querytext);

            Assert.IsTrue(!String.IsNullOrEmpty(querytext));


        }
        [Given(@"The lookup (.*) field value should be equal to (.*)")]
        [When(@"The lookup (.*) field value should be equal to (.*)")]
        public void WhenLookupFieldValueShouldBe(string Fieldname, string ExpectedFieldValue)
        {
            var lookupItem = new LookupItem
            {
                Name = Fieldname,

            };
            var querytext = XrmApp.Entity.GetValue(new LookupItem[] { lookupItem });
            for (int i = 0; i < querytext.Length; i++)
            {
                try
                {
                    if (querytext[i].Equals(ExpectedFieldValue))
                    {
                        break;
                    }
                    throw new Exception($"Lookup field values are not equal");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Lookup field values are not equal")
                        throw new Exception($"Lookup field values are not equal");

                }
                System.Console.WriteLine(querytext[i]);

                //else
                //    throw new Exception ($"Actual value is not equal to {ExpectedFieldValue}");
            }
        }

        [When(@"The lookup field (.*) value should not be empty")]
        public void WhenLookupFieldValueShouldNotBeEmpty(string Fieldname)
        {
            var lookupItem = new LookupItem
            {
                Name = Fieldname,
            };
            var querytext = XrmApp.Entity.GetValue(new LookupItem[] { lookupItem });
            for (int i = 0; i < querytext.Length; i++)
            {
                try
                {
                   
                    if (!String.IsNullOrEmpty(querytext[i]))
                    {
                        
                        break;
                    }
                    throw new Exception($"Lookup field values are empty");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Lookup field values are empty")
                        throw new Exception("Lookup field values are empty");

                }
                System.Console.WriteLine(querytext[i]);

                //else
                //    throw new Exception ($"Actual value is not equal to {ExpectedFieldValue}");
            }
        }



        [Then(@"The (.*) field ID value should be equal to (.*)")]
        public void ThenTheFieldIDShouldBe(string Fieldname, string ExpectedFieldValue)
        {
            Field querytext = XrmApp.Entity.GetField(Fieldname);
            System.Console.WriteLine(querytext.Name);
            Assert.AreEqual(ExpectedFieldValue, querytext.Name);

        }
        [Given(@"I enter the below data in the Form")]
        public void GivenIEnterTheBelowDataInTheForm(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var fieldType = tableRow["Type"];
                var sectionLabel = tableRow["sectionLabel"];
                var fieldName = tableRow["FieldName"];
                var fieldValue = tableRow["FieldValue"];

                switch (fieldType)
                {
                    case "string":
                        GivenIHaveSetValueToTextFieldInTheForm(fieldValue, fieldName);
                        break;
                    case "numeric":
                        GivenIHaveSetValueToNumericFieldInTheForm(fieldValue, fieldName);
                        break;
                    case "lookup":
                        GivenIHaveSetValueToLookupFieldInTheForm(fieldValue, fieldName);
                        break;
                    case "optionset":
                        GivenIHaveSetValueToOptionsetFieldInTheForm(fieldValue, fieldName);
                        break;
                    case "date":
                        GivenIHaveSetValueToDateFieldInTheForm(DateTime.ParseExact(fieldValue, "M/d/yyyy", null), fieldName);
                        break;
                    case "datetime":
                        GivenIHaveSetValueToDatetimeFieldInTheForm(DateTime.Parse(fieldValue), fieldName);
                        break;
                    case "Field":
                        GivenFieldsarePresentInSection(sectionLabel, fieldName);
                        break;
                }
            }
        }
        [Given(@"I verify below fields")]
        [When(@"I verify below fields")]
        [Then(@"I verify below fields")]
        public void GivenIVerifyBelowFields(Table table)
        {
            foreach (var tableRow in table.Rows) 
            {
                var fieldType = tableRow["Type"];
                var sectionLabel = tableRow["sectionLabel"];
                var fieldName = tableRow["FieldName"];
                var fieldValue = tableRow["FieldValue"];

                switch (fieldType)
                {

                    case "Field":
                        GivenFieldsarePresentInSection(sectionLabel, fieldName);
                        break;
                    case "Locked Field":
                        GivenFieldsInSectionAreLocked(sectionLabel, fieldName);
                        break;
                }
            }
        }
        [Then(@"I verify below (.*) (.*) in Review tab in ApplicationReview")]
        public void GivenIVerifyBelowReviewDetails(string reviewsbybundle, string reviewmethod)
        {
            XrmApp.Entity.VerifyReviewBundleMethod(reviewsbybundle, reviewmethod);
        }

        [Given(@"I click new button for (.*) lookup field")]
        public void GivenClickNewLookup(string lookupName)
        {

            XrmApp.Entity.SelectLookup(new LookupItem { Name = lookupName });
            XrmApp.ThinkTime(1000);
            XrmApp.Lookup.New();

            XrmApp.ThinkTime(2000);
        }
        [Given(@"I have set (.*) to (.*) field in the lookup dialog")]
        [When(@"I have set (.*) to (.*) field in the lookup dialog")]
        [Then(@"I have set (.*) to (.*) field in the lookup dialog")]
        public void GivenIHaveSetLookupDialog(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,

                Value = fieldValue,
                Index = 0
            };
            // XrmApp.Entity.SetLookupDialog(lookupItem);
            XrmApp.Entity.SetLookupDialogEx(lookupItem);
        }
        [Given(@"I click (.*) button in the lookup dialog")]
        [When(@"I click (.*) button in the lookup dialog")]
        [Then(@"I click (.*) button in the lookup dialog")]

        public void GivenIClickActionButtonInLookupDialog(bool clickButton)
        {

            XrmApp.Entity.LookupDialogAction(clickButton);


        }

        [Given(@"I click (.*) locked lookup field in (.*) section")]
        [When(@"I click (.*) locked lookup field in (.*) section")]
        [Then(@"I click (.*) locked lookup field in (.*) section")]
        public void GivenIClickLockedLookupField(string fieldName, string sectionLabel)
        {
            XrmApp.Entity.ClickLockedLookupField(fieldName, sectionLabel);
        }

        [Given(@"I open (.*) list item in (.*) section only if available")]
        [When(@"I open (.*) list item in (.*) section only if available")]
        [Then(@"I open (.*) list item in (.*) section only if available")]
        public void GivenIOpenFirstListItem(string fieldName, string sectionLabel)
        {


            try
            {
                XrmApp.Entity.ClickLockedLookupField(fieldName, sectionLabel);
                XrmApp.ThinkTime(2000);
            }
            catch (Exception)
            {

                Console.WriteLine("section is not present in list view");
            }

           
        }

        [Given(@"I verify in (.*) section (.*) field is present")]
        [When(@"I verify in (.*) section (.*) field is present")]
        [Then(@"I verify in (.*) section (.*) field is present")]
        public void GivenFieldsarePresentInSection(string sectionLabel, string fieldName)
        {
            XrmApp.Entity.VerifyFieldIsPresentInSection(sectionLabel, new Field { Name = fieldName });

        }
        [Given(@"I verify in (.*) section (.*) field is locked")]
        [When(@"I verify in (.*) section (.*) field is locked")]
        [Then(@"I verify in (.*) section (.*) field is locked")]
        public void GivenFieldsInSectionAreLocked(string sectionLabel, string fieldName)
        {


            XrmApp.Entity.VerifyFieldsInSectionAreLocked(sectionLabel, new Field { Name = fieldName });

        }
        [Given(@"I browse (.*) File in (.*) section")]
        [When(@"I browse (.*) File in (.*) section")]
        [Then(@"I browse (.*) File in (.*) section")]
        public void WhenIBrowseAttachmentIcon(string File, string sectionLabel)
        {
            XrmApp.Entity.BrowseAttachment(File, sectionLabel);

        }
        [Given(@"I click (.*) button in Note section")]
        [When(@"I click (.*) button in Note section")]
        [Then(@"I click (.*) button in Note section")]
        public void WhenIClickActionButtonForNote(string buttonClicked)
        {
            if (buttonClicked.Equals("Add"))
                XrmApp.Entity.CreateNoteAction(true);
            else if (buttonClicked.Equals("Cancel"))
            {
                XrmApp.Entity.CreateNoteAction(false);
            }
            else
                System.Console.WriteLine("Enter correct button label");
        }


        [Then(@"I update the (.*) field with input as (.*) in the form")]
        public void ThenIClickedOnFieldInTheForm(string field,string input)
        {
            XrmApp.Entity.ClickFieldToUpdate(field, input);

        }

        [When(@"I switch to current window")]
        public void ThenISwitchToCurrentWindowPopup()
        {

            XrmApp.Entity.SwitchToCurrentWindow();

        }



        [Then(@"I close current window pop-up")]
        public void ThenICloseWindowPopup()
        {
            XrmApp.Entity.CloseCurrentWindow();

        }


        [Then(@"I switch to (.*) window")]
        public void ThenISwitchToSpecificWindowPopup(string title)
        {
            XrmApp.Entity.SwitchToSpecificWindow(title);

        }
        [Then(@"I have set (.*) to (.*) Kendo text field in dialog window")]
        public void ThenISetKendoTextfield(string FieldValue, string FieldName)
        {
            XrmApp.Entity.SetKendoTextFieldInDialog(FieldValue, FieldName);

        }
        [Then(@"I have set day as (.*) to (.*) Kendo date field in dialog window")]
        public void SetKendoDateFieldInDialog(string FieldValue, string FieldName)
        {
            XrmApp.Entity.SetKendoDateFieldInDialog(FieldValue, FieldName);

        }
        [Then(@"I switch to (.*) frame")]
        public void ThenISwitchToSpecificFrame(string frameName)
        {
            XrmApp.Entity.SwitchToSpecificFrame(frameName);

        }

        [Then(@"I search for (.*) dynamic frame")]
        public void ThenISwitchToDynamicFrame(string frameID)
        {
            XrmApp.Entity.SwitchToDynamicFrame(frameID);

        }
        [Then(@"I switch back to default frame")]
        public void ThenISwitchToDefaultFrame()
        {
            XrmApp.Entity.SwitchToDefaultFrame();

        }
        [Then(@"I switch back to main window")]
        public void ThenISwitchBackToMainWindow()
        {
            XrmApp.SwitchToMainWindow();

        }
        [Then(@"I click (.*) button in the window")]
        public void ThenIClickActionButtoninWIndow(string ButtonLabel)
        {
            XrmApp.Entity.ClickActionButtoninWIndow(ButtonLabel);

        }

        [When(@"I select (.*) Form")]
        [Then(@"I select (.*) Form")]
        public void ThenISelectSpecificForm(string FormName)
        {
            XrmApp.Entity.SelectForm(FormName);
            XrmApp.ThinkTime(2000);

        }

        [Then(@"I validate (.*) notification/s in the form")]
        public void ThenIValidateGroupOfNotification(string Message)
        {
            XrmApp.Entity.ValidateNotification(Message);
            XrmApp.ThinkTime(2000);

        }

        //  ValidateNotifications
        [Then(@"I select (.*) options in (.*) multivalue optionset by removing existing selections")]
        public void ThenISelectValuesMlutiValueOptionsetRemoveExisting(string FieldValue, string FieldName)
        {
            var MultiValueOptionSet = new MultiValueOptionSet
            {
                Name = FieldName,
                Values = new string[] { FieldValue }
            };
            XrmApp.Entity.SetValue(MultiValueOptionSet, true);
            XrmApp.ThinkTime(3000);

        }
        [Then(@"I select (.*) options in (.*) multivalue optionset")]
        [When(@"I select (.*) options in (.*) multivalue optionset")]
        public void ThenISelectValuesMlutiValueOptionset(string FieldValue, string FieldName)
        {
            var MultiValueOptionSet = new MultiValueOptionSet
            {
                Name = FieldName,
                Values = new string[] { FieldValue }
            };
            XrmApp.Entity.SetValue(MultiValueOptionSet);
            XrmApp.ThinkTime(3000);

        }

        [Given(@"I have set (.*) to (.*) field in the lookup SearchBox")]
        [When(@"I have set (.*) to (.*) field in the lookup SearchBox")]
        [Then(@"I have set (.*) to (.*) field in the lookup SearchBox")]
        public void GivenIHaveSetLookupSearchBox(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };

            XrmApp.Entity.SetLookupSearcBox(lookupItem);


        }

        [Given(@"I search (.*) in the (.*) lookup SearchBox")]
        [When(@"I search (.*) in the (.*) lookup SearchBox")]
        [Then(@"I search (.*) in the (.*) lookup SearchBox")]
        public void GivenISearchInLookupSearchBox(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };

            XrmApp.Entity.SetLookupSearcBox(lookupItem, 0, false);

        }



        [Given(@"I click (.*) option in (.*) section of Manage Members window")]
        [When(@"I click (.*) option in (.*) section of Manage Members window")]
        [Then(@"I click (.*) option in (.*) section of Manage Members window")]
        public void WhenISelectOptioninManageMemebers(String buttonName, String sectionLabel)
        {

            XrmApp.Entity.ManageMembersAdd(buttonName, sectionLabel);

        }
        [When(@"I set (.*) and (.*) in row (.*) of Manage Members window")]
        [Then(@"I set(.*) and (.*)  in row (.*) of Manage Members window")]
        public void WhenISetFieldinManageMembers(string FieldName, string InputValue, int RowNo)
        {

            XrmApp.Entity.ManageMemberTextFields(FieldName, InputValue, RowNo);

        }
        [Then(@"I switch to active element")]
        public void ThenISwitchtoActiveElement()
        {
            XrmApp.Entity.SwitchToActiveElement();
            XrmApp.ThinkTime(2000);

        }
        [Given(@"I have set (.*) to (.*) in the kendo time field in (.*) section")]
        [When(@"I have set (.*) to (.*) in the kendo time field in (.*) section")]
        public void GivenIHaveSetInTheKendoTimeField(string fieldValue, string fieldName, int fieldNo)
        {
            XrmApp.Entity.TimePicker(fieldValue, fieldName, fieldNo);
        }

        [Then(@"I select (.*) under Day of Week section")]
        [When(@"I select (.*) under Day of Week section")]
        public void ThenISelectDayofWeek(string fieldValue)
        {
            XrmApp.Entity.SelectWeekDay(fieldValue);
        }

        [Then(@"I click on (.*) Button")]
        [When(@"I click on (.*) Button")]
        public void ThenIClickOnButton(string fieldValue)
        {
            XrmApp.Entity.BookAppointmentBtn(fieldValue);
        }

        [Then(@"I select value as (.*) in field (.*)")]
        [When(@"I select value as (.*) in field (.*)")]
        public void ThenISelect(string FieldValue, string FieldType)
        {
            XrmApp.Entity.SelectFieldValue(FieldValue, FieldType, true);
        }

        [Then(@"I select (.*) in (.*) related optional field")]
        [When(@"I select (.*) in (.*) related optional field")]
        public void ThenISelectOptionLabelFieldValue(string FieldValue, string FieldType)
        {
            // XrmApp.Entity.SelectFieldValue(FieldValue,FieldType);

             XrmApp.Entity.SelectRelatedOptionField(FieldValue,FieldType);
            
        }

        [Then(@"I select (.*) Button under schedule appointment grid")]
        [When(@"I select (.*) Button under schedule appointment grid")]
        public void ThenIClickOnButtonToScheduleAppointment(string FieldValue)
        {
            XrmApp.Entity.ShowAvailability(FieldValue);
        }

        [Then(@"I click on available day (.*)")]
        [When(@"I click on available day (.*)")]
        public void ThenIClickOnAvailableDay(string FieldValue)
        {
            XrmApp.Entity.ClickOnAvailableDay(FieldValue);
        }

        [Then(@"I click on available (.*) slot")]
        [When(@"I click on available (.*) slot")]
        public void ThenIClickOnAvailableSlot(string FieldValue)
        {
            XrmApp.Entity.ClickOnAvailableSlot(FieldValue);
        }

        [Then(@"I clcik on (.*) View of the Staff Calendar")]
        [When(@"I clcik on (.*) View of the Staff Calendar")]
        public void ThenIClickOnStaffCalendarView(string FieldValue)
        {
            XrmApp.Entity.ClickOnCalendarView(FieldValue);
        }

        [Then(@"I locate the appointment (.*) in the Staff Calendar")]
        [When(@"I locate the appointment (.*) in the Staff Calendar")]
        public void ThenILocateAppointment(string AppointmentName)
        {
            XrmApp.Entity.LocateAppointment(AppointmentName);
        }

        [Then(@"I cancel the appointment (.*) in the Staff Calendar")]
        [When(@"I cancel the appointment (.*) in the Staff Calendar")]
        public void ThenICancelAppointment(string AppointmentName)
        {
            XrmApp.Entity.CancelAppointment(AppointmentName);
        }

        [Then(@"I select (.*) report")]
        [When(@"I select (.*) report")]
        public void ThenISelectReport(string ReportName)
        {
            XrmApp.Entity.SelectReport(ReportName);
        }

        [Then(@"I select option (.*) in (.*) field")]
        [When(@"I select option (.*) in (.*) field")]
        public void ThenISelectOptionInField(string option, string FieldName)
        {
            XrmApp.Entity.SelectFieldOption(option, FieldName);
        }

        [Then(@"I clear existing values in (.*) lookup field")]
        [When(@"I clear existing values in (.*) lookup field")]
        public void ThenIClearLookupValue(string FieldName)
        {
            var lookup = new LookupItem { Name = FieldName };
            XrmApp.Entity.ClearValueEx(lookup);
            XrmApp.ThinkTime(2000);
        }

        [Then(@"I scroll in to view of (.*) section")]
        [When(@"I scroll in to view of (.*) section")]
        public void ThenIScrollViewSection(string sectionLabel)
        {

            XrmApp.Entity.ScrollFocusSection(sectionLabel);
            XrmApp.ThinkTime(2000);
        }

        [Then(@"I scrolldown to End of (.*) section")]
        [When(@"I scrolldown to End of (.*) section")]
        public void ScrollToEndOfSection(string sectionLabel)
        {

            XrmApp.Entity.ScrollToEndOfSection(sectionLabel);
            XrmApp.ThinkTime(2000);
        }
        [Then(@"I scroll to (.*) section having (.*) field")]
        [When(@"I scroll to (.*) section having (.*) field")]
        public void ScrollToBottomOfPage(string sectionLabel, string fieldLabel)
        {

            XrmApp.Entity.ScrollToBottomOfPage(sectionLabel, fieldLabel);
            XrmApp.ThinkTime(2000);
        }

        //[Then(@"I navigate to top of (.*) section")]
        //[When(@"I navigate to top of (.*) section")]
        //public void ThenINavigateTopOfSection(string sectionLabel)
        //{

        //    XrmApp.Entity.ScrollFocusSection(sectionLabel);
        //    XrmApp.ThinkTime(2000);
        //}

        //[Then(@"I scroll to (.*) lookup in (.*) section")]
        //[When(@"I scroll to (.*) lookup in (.*) section")]
        //public void ThenIScrollViewLookup(string Fieldname, string sectionLabel)
        //{

        //    XrmApp.Entity.ScrollFocusLookup(Fieldname, sectionLabel);
        //    XrmApp.ThinkTime(2000);
        //}

        [Given(@"I select (.*) question and provide (.*) to question field and provide (.*) to option field in the form")]
        [Then(@"I select (.*) question and provide (.*) to question field and provide (.*) to option field in the form")]

        public void GivenISelectQuestionTypeAndFillQuestionInTheForm(string QuestionType, string QuestionValue, string OptionValue)
        {
            XrmApp.Entity.SelectQuestionType(QuestionType, QuestionValue, OptionValue);
        }


        [Then(@"I click on (.*) Button in the questions section in the form")]
        public void ThenIClickOnButtonInTheQuestionsSection(string ButtonLabel)
        {
            XrmApp.Entity.ClickButtonInQuestionSection(ButtonLabel);
        }

        [Given(@"I have set (.*) view/Entity to (.*) Picker in (.*) section")]
        [When(@"I have set (.*) view/Entity to (.*) Picker in (.*) section")]
        [Then(@"I have set (.*) view/Entity to (.*) Picker in (.*) section")]
        public void GivenIHaveSetActiveCampusesViewToUseExistingViewPicker(string viewName, string FieldName, string sectionName)
        {
            XrmApp.Entity.SelectExistingView(viewName, FieldName, sectionName);
        }

        [Given(@"I set (.*) option to (.*) PCF control field in (.*) section")]
        [When(@"I set (.*) option to (.*) PCF control field in (.*) section")]
        [Then(@"I set (.*) option to (.*) PCF control field in (.*) section")]
        public void GivenISetOptioninPCFControl(string viewName, string FieldName, string sectionName)
        {
            XrmApp.Entity.SelectPCFControlOption(viewName, FieldName, sectionName);
        }

        [Given(@"I have clicked (.*) button in (.*) section")]
        [When(@"I have clicked (.*) button in (.*) section")]
        [Then(@"I have clicked (.*) button in (.*) section")]
        public void ThenIHaveClickedButtonInSection(string sectionButtonName, string sectionName)
        {
            XrmApp.Entity.ClickButtonInSection(sectionButtonName, sectionName); ;
        }


        [When(@"I verify the (.*) field is not present in the (.*) section of the form")]
        public void WhenIVerifyTheFieldIsNotPresentInTheForm(string fieldName, string sectionName)
        {

            XrmApp.Entity.FieldNotPresentInForm(fieldName, sectionName);

        }

        [Given(@"I select (.*) option in (.*) field tree section")]
        [When(@"I select (.*) option in (.*) field tree section")]
        [Then(@"I select (.*) option in (.*) field tree section")]
        public void ThenIelectOptionFronTreeSection(string option, string FieldName)
        {
            XrmApp.Entity.MultiSelectTreeSection(option, FieldName);

        }
        [Given(@"I set (.*) to (.*) field in (.*) dialog")]
        [When(@"I set (.*) to (.*) field in (.*) dialog")]
        [Then(@"I set (.*) to (.*) field in (.*) dialog")]
        public void ThenISetFieldInDialog(string FieldValue, string FieldName, string sectionName)
        {
            XrmApp.Entity.SetFieldsInDialog (FieldValue, FieldName, sectionName);
        }
        [Given(@"I select (.*) radio button in the dialog window")]
        [When(@"I select (.*) radio button in the dialog window")]
        [Then(@"I select (.*) radio button in the dialog window")]
        public void ThenISelectRadioButton(string ButtonToselect)
        {
            XrmApp.Entity.SelectRadioButton(ButtonToselect);

        }

        [Then(@"I click on (.*) schedule  grid")]
        [When(@"I click on (.*) schedule grid")]
        public void CLickSlot(string FieldValue)
        {
            XrmApp.Entity.ClickAppointmentSlot(FieldValue);
        }

        [Then(@"I cancel (.*) Appointment")]
        [When(@"I cancel (.*) Appointment")]
        public void ClickOnCancel(string FieldValue)
        {
            XrmApp.Entity.ClickOnCancelIcon(FieldValue);
        }

        [Then (@"I validate Required Message (.*) notification in the dialog")]
        public void validateRequiredFieldMessage(string Message)
        {
            XrmApp.Entity.ValidateRequiredString(Message);
            XrmApp.ThinkTime(2000);

        }

        [Then(@"I select Marked as Block checkbox")]
        public void clickOnBlock()
        {
            XrmApp.Entity.ClickBlockCheckbox();
            XrmApp.ThinkTime(2000);
        }
        
        [Then(@"I provide the reason (.*) and click on (.*) button")]
        public void InputReason (string Message, string button)
        {
            XrmApp.Entity.InputReason(Message,button);
            XrmApp.ThinkTime(2000);
        }

        [Then(@"I close cancel appointment pop-up")]
        public void CloseCancelAppointmentWindow()
        {
            XrmApp.Entity.CloseCancelAppointmentWindow();

        }

        [Then(@"I Verify Appointment with (.*) should not avaialable")]
        public void VerifyNobookedAppointment(string FieldValue)
        {
            XrmApp.Entity.NoAppointment(FieldValue);
        }

        [Then(@"I Verify Appoointment (.*) should be avaialable in (.*) Page")]
        public void VerifyBlockAppointment(string FieldValue,string PageName)
        {
            XrmApp.Entity.VerifyBlockCount(FieldValue, PageName);
        }

        [Given(@"I click (.*) action button in Quick Create pop-up")]
        [When(@"I click (.*) action button in Quick Create pop-up")]
        [Then(@"I click (.*) action button in Quick Create pop-up")]
        public void ACtionButtonInQuickCrete(string buttonName)
        {
            XrmApp.Entity.ClickButtonQuickCreate(buttonName);
        }

        [Then(@"I select matching Address to (.*) in the field (.*)")]
        [When(@"I select matching Address to (.*) in the field (.*)")]
        [Given(@"I select matching Address to (.*) in the field (.*)")]
        public void EnterMatchingAddress(string AddressLine1, string fieldName)

        {
            XrmApp.Entity.AddressTypeAhead(AddressLine1, fieldName);
        }

        [Then(@"The field (.*) value should be same as (.*) in section (.*)")]
        [When(@"The field (.*) value should be same as (.*) in section (.*)")]
        [Given(@"The field (.*) value should be same as (.*) in section (.*)")]
        //public void ThenTheFieldValueShouldBeSAme(string AddressLine1, string fieldName, string sectionLabel)
        public void ThenTheFieldValueShouldBeSAme(string fieldName, string AddressLine1, string sectionLabel)
        {
                     XrmApp.Entity.CompareValue(fieldName,AddressLine1, sectionLabel);
          }

        [Then(@"The handle live assist pop-up only if available")]
        [When(@"The handle live assist pop-up only if available")]
        [Given(@"The handle live assist pop-up only if available")]
        public void IhandleLiveAssist()
        {

            try
            {
                XrmApp.Entity.LiveAssist();
                XrmApp.ThinkTime(2000);
            }
            catch (Exception ex)
            {
                
                    Console.WriteLine("live assist not found");
            }

          
        }


        [Given(@"I select (.*) field as (.*) option in the dialog")]
        [When(@"I select (.*) field as (.*) option in the dialog")]
        [Then(@"I select (.*) field as (.*) option in the dialog")]
        public void SelectOptionFromCloseAppointmentDialog(string fieldName, string optionName)
        {
            XrmApp.Entity.SelectOptionFromDialog(fieldName,optionName);
        }

        //Wave2
        [Given(@"I switch to browser tab (.*) if available")]
        [When(@"I switch to browser tab (.*) if available")]
        [Then(@"I switch to browser tab (.*) if available")]
        public void ThenISwitchToBrowserTabIfAvailable(int tabname)
        {
            XrmApp.Entity.switchtotab(tabname);
        }

        [Given(@"I switched the Systemview to (.*)")]
        [Then(@"I switched the Systemview to (.*)")]
        [When(@"I switched the Systemview to (.*)")]
        public void WhenISwitchedTheSystemviewTo(String viewName)
        {
            XrmApp.Entity.SwitchSystemview(viewName);
        }

        [Then(@"I switch to (.*) iframe")]
        [When(@"I switch to (.*) iframe")]
        public void ThenISwitchToiFrame(int frameIndex)
        {
            XrmApp.Entity.ThenISwitchToSpecificFrame(frameIndex);

        }

        [Given(@"I browse (.*) in a File section")]
        [When(@"I browse (.*) in a File section")]
        [Then(@"I browse (.*) in a File section")]
        public void AppAttachment(string File)
        {
            XrmApp.Entity.Attachment(File);

        }

        [Given(@"I select (.*) field as (.*) option in dialog")]
        [When(@"I select (.*) field as (.*) option in dialog")]
        [Then(@"I select (.*) field as (.*) option in dialog")]
        public void SelectOptionFromDialog(string fieldName, string optionName)
        {
            XrmApp.Entity.SelectOptioninDialog(fieldName, optionName);
        }

        [Given(@"I have set  future date to (.*) field in the Form")]
        [When(@"I have set  future date to (.*) field in the Form")]
        public void GivenIHaveSetFutureDateFieldInTheForm(string fieldName)
        {
            try
            {

                DateTime fieldValue;
                // var DateControl = new DateTimeControl(fieldName){Value = DateTime.Today};
                fieldValue = DateTime.Today.AddDays(10);
                XrmApp.Entity.SetValue(fieldName, fieldValue, "MM/dd/yyyy");

                XrmApp.ThinkTime(3000);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no such element"))

                    Console.WriteLine("Date Error handled");

            }
        }
        [Then(@"I have clear text in (.*) Kendo text field in dialog window")]
        public void ThenIClearKendoTextfield(string FieldName)
        {
            XrmApp.Entity.CLearKendoTextFieldInDialog(FieldName);



        }

        [Then(@"I set (.*) in the dialog window drop down")]
        public void dropdown(string value)
        {
            XrmApp.Entity.SelectKdropdown(value);
            XrmApp.ThinkTime(2000);
        }

    }

}



