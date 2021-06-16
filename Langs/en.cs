namespace TGMacro.Langs
{
    public class en : Interfaces.ILanguage
    {
        public string info_color_box => "You can set the color manually by clicking the colored box.";
        public string info_getting_color_and_position => "•Alt + X to get current cursor position\r\n•Alt + C to get screen color by cursor";
        public string btnFile => "File";

        public string btnSaveProject => "Save Project";

        public string btnLoadProject => "Load Project";

        public string btnImportProject => "Import Project";

        public string btnImportScript => "Import Script";

        public string btnEdit => "Edit";

        public string btnHelp => "Help";

        public string btnAbout => "About";

        public string info_no_macro => "No macro to show.\r\nClick \"Add New Macro\" to create one";

        public string btnEnable_off => "Enable {HOME}";

        public string btnEnable_on => "Disable {HOME}";

        public string btnAdd => "Add New Macro";

        public string text_action_type => "Action type :";

        public string text_positioning => "Positioning :";

        public string text_position => "Position :";

        public string text_key_status => "Key status :";

        public string text_wait_amount => "Wait amount :";

        public string text_key_status_01 => "Press";

        public string text_key_status_02 => "Down";

        public string text_key_status_03 => "Up";

        public string text_macro_name => "Macro name";

        public string text_actions => "Actions";

        public string btnSave => "Save";

        public string btnTest => "Test";

        public string text_action => "Action";

        public string text_value => "Value";

        public string btnAddAction => "Add new action";

        public string btnEditActions => "Edit selected action";

        public string btnCloneActions => "Clone selected actions";

        public string btnDeleteActions => "Delete selected actions";

        public string btnMoveActionUp => "Move selected actions to up";

        public string btnMoveActionsDown => "Move selected actions to down";

        public string btnImportActionsFromScript => "Import macro script";

        public string text_triggering => "Triggering";

        public string text_trigger_action_by => "Trigger actions by :";

        public string txt_when => "When :";

        public string txt_keys => "Keys :";

        public string text_color_position => "Color Position :";

        public string text_color => "Color :";

        public string text_click_here_to_set_key => "Click here to set key";

        public string text_press_any_key_to_set => "Press any key to set";

        public string text_key_events => "Key events";

        public string text_pixel_events => "Pixel events";

        public string text_key_press => "Key Pressed";

        public string text_key_hold => "Key Hold";

        public string text_key_toggle => "Key Toggle";

        public string text_color_matches => "Color Matches";

        public string text_color_not_matches => "Color Not Matches";

        public string text_mouse_move_method_01_abs => "Absolute";

        public string text_mouse_move_method_02_rel => "Relative";

        public string text_action_type_01_mouse_move => "Mouse Move";

        public string text_action_type_02_mouse_button => "Mouse Key";

        public string text_action_type_03_keyboard_button => "Keyboard Key";

        public string text_action_type_04_wait => "Wait";

        public string info_grab_cursor_position => "(Alt+X get current cursor position)";

        public string error_saving_project => "Error occurred while saving the project.";

        public string error_loding_project => "Error occurred while loading the project.\r\nFile might be corrupted or saved by another version.";

        public string error_importing_project => "Error occurred while importing the project.\r\nFile might be corrupted or saved by another version.";

        public string error_import_script => "Error occurred while importing amc script.";

        public string error_unkown_script => "Unkown script.";

        public string info_nothing_to_save => "Nothing to save.";

        public string info_no_key_selected => "No key selected.";

        public string info_no_action_to_key => "No action to test.";

        public string info_no_action_to_save => "No action to save.";

        public string info_enter_macro_name => "Enter a name.";

        public string btnRecord_off => "Record and Stop{Ctrl+F10}";

        public string btnTest_on => "Cancel {ESC}";

        public string text_record_settings => "Record Settings";
        public string btnClearActions => "Clear all actions";

        public string text_capture_mouse_pos => "Capture mouse's position :";

        public string text_mouse_move_method_info => "Absolute to modify current cursor position.\r\nRelative to add or subtract from current cursor position.";

        public string text_grab_cursor_position => "(Alt + X to get current cursor pos)";
        public string btnUpdates => "Updates";

        public string text_record => "Record :";

        public string text_mouse_buttons => "Mouse Buttons";

        public string text_mouse_movements => "Mouse Movements";

        public string text_keyboard_keys => "Keyboard Keys";

        public string text_keys => "Delays";

        public string btnChangeLanguage => "Türkçe'ye ayarla.";

        public string text_macro_status => "Macro status";

        public string btnTopMost => "Always on top";

        public string text_action_type_05_text => "Text";
        public string info_no_text => "Text can't be empty.";

        public string info_clear_all_actions => "This will clear all actions";

        public string btn_record_off => "Record\r\nCtrl + F10";

        public string btn_record_on => "Stop\r\nCtrl + F10";

        public string string_text => "Text";

        public string text_adjust_time_info => "Adds or subtracts the amount from all wait actions.";

        public string text_adjust_timing => "Adjust timing";

        public string btnMultiAdd => "Add actions after all selected actions.";

        public string info_keyboard_key_missing => "Some keyboard key actions missing key down or up action. Please check action list.";

        public string info_mouse_key_missing => "Some mouse key actions missing key down or up action. Please check action list.";

        public string info_actions_has_trigger_key => "Actions can't contain keys which set to trigger.";
    }
}
