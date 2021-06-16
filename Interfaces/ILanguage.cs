namespace TGMacro.Interfaces
{
    public interface ILanguage
    {

        #region frmMain
        string btnChangeLanguage { get; }
        string text_macro_status { get; }
        string btnTopMost { get; }

        string btnFile { get; }
        string info_color_box { get; }
        string btnSaveProject { get; }
        string btnLoadProject { get; }
        string btnImportProject { get; }
        string btnImportScript { get; }
        string btnUpdates { get; }

        string btnEdit { get; }

        string btnHelp { get; }
        string btnAbout { get; }

        string info_no_macro { get; }

        string btnEnable_off { get; }
        string btnEnable_on { get; }

        string btnAdd { get; }

        #endregion

        #region frmMacroEditr

        string text_record { get; }
        string text_mouse_buttons { get; }
        string text_mouse_movements { get; }
        string text_keyboard_keys { get; }
        string text_keys { get; }
        string text_macro_name { get; }
        string text_actions { get; }
        string btnSave { get; }
        string btnTest { get; }
        string btnTest_on { get; }

        #region actionviewer
        string text_action { get; }
        string btnClearActions { get; }
        string text_value { get; }
        string btnRecord_off { get; }
        string btn_record_off { get; }
        string btn_record_on { get; }
        string btnAddAction { get; }
        string btnEditActions { get; }
        string btnCloneActions { get; }
        string btnDeleteActions { get; }
        string btnMoveActionUp { get; }
        string btnMoveActionsDown { get; }
        string btnImportActionsFromScript { get; }
        #endregion
        string text_record_settings { get; }
        string text_capture_mouse_pos { get; }
        string text_triggering { get; }
        string text_trigger_action_by { get; }
        string txt_when { get; }
        string txt_keys { get; }
        string text_color_position { get; }
        string text_color { get; }

        string text_click_here_to_set_key { get; }
        string text_press_any_key_to_set { get; }



        string text_key_events { get; }
        string text_pixel_events { get; }

        string text_key_press { get; }
        string text_key_hold { get; }
        string text_key_toggle { get; }

        string text_color_matches { get; }
        string text_color_not_matches { get; }

        #endregion

        #region frmActionEditor
        string text_action_type { get; }
        string text_positioning { get; }
        string text_position { get; }
        string text_key_status { get; }
        string text_wait_amount { get; }
        string info_grab_cursor_position { get; }
        string text_key_status_01 { get; }
        string text_key_status_02 { get; }
        string text_key_status_03 { get; }
        string text_grab_cursor_position { get; }

        string text_mouse_move_method_01_abs { get; }
        string text_mouse_move_method_02_rel { get; }
        string text_action_type_01_mouse_move { get; }
        string text_action_type_02_mouse_button { get; }
        string text_action_type_03_keyboard_button { get; }
        string text_action_type_04_wait { get; }
        string text_action_type_05_text { get; }

        string error_saving_project { get; }
        string error_loding_project { get; }
        string error_importing_project { get; }
        string error_import_script { get; }
        string error_unkown_script { get; }
        string info_nothing_to_save { get; }
        string text_mouse_move_method_info { get; }


        string info_no_key_selected { get; }
        string info_no_action_to_key { get; }
        string info_no_action_to_save { get; }
        string info_enter_macro_name { get; }
        string info_no_text { get; }
        string info_getting_color_and_position { get; }
        string info_clear_all_actions { get; }
        string string_text { get; }
        string text_adjust_time_info { get; }
        string text_adjust_timing { get; }
        string btnMultiAdd { get; }
        string info_keyboard_key_missing { get; }
        string info_mouse_key_missing { get; }
        string info_actions_has_trigger_key { get; }


        #endregion
    }
}
