namespace TGMacro.Langs
{
    public class ENG : Bases.LanguageBase
    {
        public override string language_name => "ENG";
        public override string info_color_box => "You can set the color manually by clicking the colored box.";
        public override string info_getting_color_and_position => "•Alt + X to get current cursor position\r\n•Alt + C to get screen color by cursor";
        public override string btnFile => "File";

        public override string btnSaveProject => "Save Project";

        public override string btnLoadProject => "Load Project";

        public override string btnImportProject => "Import Project";

        public override string btnImportScript => "Import Script";

        public override string btnEdit => "Edit";

        public override string btnHelp => "Help";

        public override string btnAbout => "About";

        public override string info_no_macro => "No macro to show.\r\nClick \"Add New Macro\" to create one";

        public override string btnEnable_off => "Enable {HOME}";

        public override string btnEnable_on => "Disable {HOME}";

        public override string btnAdd => "Add New Macro";

        public override string text_action_type => "Action type :";

        public override string text_positioning => "Positioning :";

        public override string text_position => "Position :";

        public override string text_key_status => "Key status :";

        public override string text_wait_amount => "Wait amount :";

        public override string text_key_status_01 => "Press";

        public override string text_key_status_02 => "Down";

        public override string text_key_status_03 => "Up";

        public override string text_macro_name => "Macro name";

        public override string text_actions => "Actions";

        public override string btnSave => "Save";

        public override string btnTest => "Test";

        public override string text_action => "Action";

        public override string text_value => "Value";

        public override string btnAddAction => "Add new action";

        public override string btnEditActions => "Edit selected action";

        public override string btnCloneActions => "Clone selected actions";

        public override string btnDeleteActions => "Delete selected actions";

        public override string btnMoveActionUp => "Move selected actions to up";

        public override string btnMoveActionsDown => "Move selected actions to down";

        public override string btnImportActionsFromScript => "Import macro script";

        public override string text_triggering => "Triggering";

        public override string text_trigger_action_by => "Trigger actions by :";

        public override string txt_when => "When :";

        public override string txt_keys => "Keys :";

        public override string text_color_position => "Color Position :";

        public override string text_color => "Color :";

        public override string text_click_here_to_set_key => "Click here to set key";

        public override string text_press_any_key_to_set => "Press any key to set";

        public override string text_key_events => "Key events";

        public override string text_pixel_events => "Pixel events";

        public override string text_key_press => "Key Pressed";

        public override string text_key_hold => "Key Hold";

        public override string text_key_toggle => "Key Toggle";

        public override string text_color_matches => "Color Matches";

        public override string text_color_not_matches => "Color Not Matches";

        public override string text_mouse_move_method_01_abs => "Absolute";

        public override string text_mouse_move_method_02_rel => "Relative";

        public override string text_action_type_01_mouse_move => "Mouse Move";

        public override string text_action_type_02_mouse_button => "Mouse Key";

        public override string text_action_type_03_keyboard_button => "Keyboard Key";

        public override string text_action_type_04_wait => "Wait";

        public override string info_grab_cursor_position => "(Alt+X get current cursor position)";

        public override string error_saving_project => "Error occurred while saving the project.";

        public override string error_loding_project => "Error occurred while loading the project.\r\nFile might be corrupted or saved by another version.";

        public override string error_importing_project => "Error occurred while importing the project.\r\nFile might be corrupted or saved by another version.";

        public override string error_import_script => "Error occurred while importing amc script.";

        public override string error_unkown_script => "Unkown script.";

        public override string info_nothing_to_save => "Nothing to save.";

        public override string info_no_key_selected => "No key selected.";

        public override string info_no_action_to_key => "No action to test.";

        public override string info_no_action_to_save => "No action to save.";

        public override string info_enter_macro_name => "Enter a name.";

        public override string btnRecord_off => "Record and Stop{Ctrl+F10}";

        public override string btnTest_on => "Cancel {ESC}";

        public override string text_record_settings => "Record Settings";
        public override string btnClearActions => "Clear all actions";

        public override string text_capture_mouse_pos => "Capture mouse's position :";

        public override string text_mouse_move_method_info => "Absolute to modify current cursor position.\r\nRelative to add or subtract from current cursor position.";

        public override string text_grab_cursor_position => "(Alt + X to get current cursor pos)";
        public override string btnUpdates => "Updates";

        public override string text_record => "Record :";

        public override string text_mouse_buttons => "Mouse Buttons";

        public override string text_mouse_movements => "Mouse Movements";

        public override string text_keyboard_keys => "Keyboard Keys";

        public override string text_keys => "Delays";

        public override string btnChangeLanguage => "Change language";

        public override string text_macro_status => "Macro status";

        public override string btnTopMost => "Always on top";

        public override string text_action_type_05_text => "Text";
        public override string info_no_text => "Text can't be empty.";

        public override string info_clear_all_actions => "This will clear all actions";

        public override string btn_record_off => "Record\r\nCtrl + F10";

        public override string btn_record_on => "Stop\r\nCtrl + F10";

        public override string string_text => "Text";

        public override string text_adjust_time_info => "Adds or subtracts the amount from all wait actions.";

        public override string text_adjust_timing => "Adjust timing";

        public override string btnMultiAdd => "Add actions after all selected actions.";

        public override string info_keyboard_key_missing => "Some keyboard key actions missing key down or up action. Please check action list.";

        public override string info_mouse_key_missing => "Some mouse key actions missing key down or up action. Please check action list.";

        public override string info_actions_has_trigger_key => "Actions can't contain keys which set to trigger.";
        public override string btn_macro_delete => "{macroname} will be deleted?";

        public override string macro_delete_title => "Delete macro";

        public override string edit_macro => "Edit Macro";

        public override string enable_disable_macro => "Enable/Disable Macro";
    }
}
