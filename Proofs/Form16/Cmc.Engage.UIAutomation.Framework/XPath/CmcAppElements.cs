using System.Collections.Generic;

namespace Cmc.Engage.UIAutomation.Framework.XPath
{
    public static class CmcAppElements
    {
        public static Dictionary<string, string> Xpath = new Dictionary<string, string>
        {
            //Entity
            {"Entity_LookupDialogResultContainer", "//ul[contains(@id,'LookupResults')]"},

            {"Entity_LookupDialogResultContainer1", "//ul[contains(@id,'LookupResultsPopup')]"},

            {"Entity_LookupDialogMenu", "//div[@role='tabpanel' and contains(@data-id,'tabContainer')]"},
            {"Entity_LookupDialogResultListItem", "//li[contains(@data-id,'resultsContainer') and contains(@role,'treeitem')]"},
            {"Entity_LookupFieldDialogContainer", "//div[contains(@id,'[NAME]')]"},
            //div[contains(@id,\"[NAME]\")]
            {"Entity_LookupFooterContainer", "//div[@id='lookupDialogFooterContainer']"},
            {"Entity_LookupAdd", "//button[@id='lookupDialogSaveBtn']"},
            {"Entity_LookupCancel", "//button[@id='Cancel']"},
            {"Entity_LookupResultsDropdown", "//*[contains(@data-id, \'[NAME].fieldControl-LookupResultsDropdown_[NAME]_tab')]" },
            {"Entity_LookupFieldResultListItem", "//*[contains(@data-id, '[NAME].fieldControl-LookupResultsDropdown_[NAME]_resultsContainer')]" },
            {"Entity_RelatedEntityPopup", "//ul[contains(@data-id,'[NAME].fieldControl-LookupResultsDropdown_[NAME]_tab')]" },
            {"Entity_GridListContainer","//ul[contains(@aria-label,\"[NAME]\")]" },
            {"Entity_GridListItem","//div[contains(@id,ListItemContainer) and contains(@aria-label,\"[NAME]\")]" },
            {"Entity_FieldContainer","//*[contains(@id, \'[NAME]-FieldSectionItemContainer\')]"},
            {"Entity_sectionContainer","//section[contains(@aria-label, \"[NAME]\")]"},
            {"Entity_sectionItem","//input[contains(@aria-label, \"[NAME]\")]"},
            {"Entity_divLockedFieldContainer","//div[contains(@id, 'locked-iconWrapper') and contains(@data-id, 'locked-iconWrapper') ]"},
            {"Entity_fieldLabel","//label[contains(@id, 'field-label')]"},
           // {"Entity_AttachmentIcon","//div[contains(@id, 'create_note_action_attachement')]"},
           {"Entity_AttachmentIcon","//button[contains(@id, 'actionsattachment')]"},
            {"Entity_NoteContainer","//div[contains(@id, \"create_note_container\")]"},
            {"Entity_NoteAddButton",".//button[contains(@id,'notescontrol-undefinedsave_button')]"},
            {"Entity_NoteCancelButton",".//button[contains(@id,'undefinedcancel_button')]" },
            {"Entity_WindowActionButton","//button[contains(@aria-label,\"[NAME]\")]"},
            //  {"Entity_attachmentItem", "//div[@id, \"attachment_item\"]"},
            {"Entity_ClickableField","//div[contains(@id,'[NAME].fieldControl-checkbox-container')]" },
            {"Entity_GroupNotificationWrapper","//div[contains(@id,'notificationWrapper') and contains(@data-id, 'notificationWrapper')]" },
            {"Entity_SingleNotificationWrapper","//div[contains(@id, 'notificationMessageAndButtons')]" },
            {"Entity_NotificationFlyout","//div[contains(@data-id,'notificationFlyout')]" },
             { "Entity_TextFieldLookupContainer", "//*[contains(@id, \'[NAME]-FieldSectionItemContainer\')]" },
            {"Entity_SubgridDiv", "//div[contains(@aria-label,'[NAME]')]"},
            {"Entity_CommandsList",".//ul//li" },
            {"Entity_DivDialog","//div[contains(@class,'[NAME]')]"},
            {"Entity_DivDatePicker", "//div[contains(@class, 'ms-DatePicker')]" },
             {"Entity_InputDateField", "//input[contains(@id,'DatePicker') and contains(@aria-label,'[NAME]')]" },
            //Dialogs
            {"Dialog_DialogButtonContainer", "//div[contains(@id,\"modalDialogView\")]"},
             {"Dialog_DialogFooterContainer", " //div[contains(@id,'dialogFooterContainer')]"},
            {"Dialog_mscrmRefreshDialogButton", "//div[contains(@id,\"tdDialogFooter\")]"},
             
            
            //BPF
              {"BPF_Finish", "//button[@aria-label = 'Finish']"},
            {"BPF_FinishedLabel", "//div[@class=\"finishLabelContainer\"]"},

//CommandBar
{"CommandBar_FlyoutNode","//div[contains(@id, 'action_bar_add_options_flyout')]"},
{"CommandBar_ActivityList","//*[@id=\"action_bar_Activity_menu_List\"]"},
 {"CommandBar_Container","//ul[contains(@data-lp-id,'commandbar-Global')]" },
  {"CommandBar_ContainerGrid","//ul[contains(@data-lp-id,\"commandbar-crm_header_global_static\")]" },


//Grid
   { "Grid_Container", ".//div[@data-type=\"Grid\"]"},
            
//Advanced Find
   {"AdvancedFind_SelectContainerByID","//select[contains(@id, '[NAME]')]"},
   {"AdvancedFind_SelectContainerByClass","//select[contains(@class, '[NAME]')]"},
     
//Navigation
   { "Navigation_NextButton", "//*[@type=\"submit\"]"},
            {"Navigation_NavBar","//div[contains(@id,'navTabGroupDiv')]" },

   };

        public static Dictionary<string, string> CssClass = new Dictionary<string, string>()
        {
            //SetValue
            {"SetValue_MultiSelectPicklistDelete", "msos-quick-delete" },
        };
    }
}