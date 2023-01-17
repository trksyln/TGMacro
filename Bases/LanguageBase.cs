namespace TGMacro.Bases
{
    public class LanguageBase
    {
        public virtual string language_name { get; set; }
        #region frmMain

        public virtual string btnChangeLanguage { get; set; }
        public virtual string text_macro_status { get; set; }
        public virtual string btnTopMost { get; set; }

        public virtual string btnFile { get; set; }
        public virtual string info_color_box { get; set; }
        public virtual string btnSaveProject { get; set; }
        public virtual string btnLoadProject { get; set; }
        public virtual string btnImportProject { get; set; }
        public virtual string btnImportScript { get; set; }
        public virtual string btnUpdates { get; set; }

        public virtual string btnEdit { get; set; }

        public virtual string btnHelp { get; set; }
        public virtual string btnAbout { get; set; }

        public virtual string info_no_macro { get; set; }

        public virtual string btnEnable_off { get; set; }
        public virtual string btnEnable_on { get; set; }

        public virtual string btnAdd { get; set; }

        #endregion

        #region frmMacroEditor

        public virtual string text_record { get; set; }
        public virtual string text_mouse_buttons { get; set; }
        public virtual string text_mouse_movements { get; set; }
        public virtual string text_keyboard_keys { get; set; }
        public virtual string text_keys { get; set; }
        public virtual string text_macro_name { get; set; }
        public virtual string text_actions { get; set; }
        public virtual string btnSave { get; set; }
        public virtual string btnTest { get; set; }
        public virtual string btnTest_on { get; set; }
        public virtual string btn_macro_delete { get; set; }
        public virtual string macro_delete_title { get; set; }
        public virtual string edit_macro { get; set; }
        public virtual string enable_disable_macro { get; set; }

        #region actionviewer
        public virtual string text_action { get; set; }
        public virtual string btnClearActions { get; set; }
        public virtual string text_value { get; set; }
        public virtual string btnRecord_off { get; set; }
        public virtual string btn_record_off { get; set; }
        public virtual string btn_record_on { get; set; }
        public virtual string btnAddAction { get; set; }
        public virtual string btnEditActions { get; set; }
        public virtual string btnCloneActions { get; set; }
        public virtual string btnDeleteActions { get; set; }
        public virtual string btnMoveActionUp { get; set; }
        public virtual string btnMoveActionsDown { get; set; }
        public virtual string btnImportActionsFromScript { get; set; }
        #endregion
        public virtual string text_record_settings { get; set; }
        public virtual string text_capture_mouse_pos { get; set; }
        public virtual string text_triggering { get; set; }
        public virtual string text_trigger_action_by { get; set; }
        public virtual string txt_when { get; set; }
        public virtual string txt_keys { get; set; }
        public virtual string text_color_position { get; set; }
        public virtual string text_color { get; set; }

        public virtual string text_click_here_to_set_key { get; set; }
        public virtual string text_press_any_key_to_set { get; set; }



        public virtual string text_key_events { get; set; }
        public virtual string text_pixel_events { get; set; }

        public virtual string text_key_press { get; set; }
        public virtual string text_key_hold { get; set; }
        public virtual string text_key_toggle { get; set; }

        public virtual string text_color_matches { get; set; }
        public virtual string text_color_not_matches { get; set; }

        #endregion

        #region frmActionEditor
        public virtual string text_action_type { get; set; }
        public virtual string text_positioning { get; set; }
        public virtual string text_position { get; set; }
        public virtual string text_key_status { get; set; }
        public virtual string text_wait_amount { get; set; }
        public virtual string info_grab_cursor_position { get; set; }
        public virtual string text_key_status_01 { get; set; }
        public virtual string text_key_status_02 { get; set; }
        public virtual string text_key_status_03 { get; set; }
        public virtual string text_grab_cursor_position { get; set; }

        public virtual string text_mouse_move_method_01_abs { get; set; }
        public virtual string text_mouse_move_method_02_rel { get; set; }
        public virtual string text_action_type_01_mouse_move { get; set; }
        public virtual string text_action_type_02_mouse_button { get; set; }
        public virtual string text_action_type_03_keyboard_button { get; set; }
        public virtual string text_action_type_04_wait { get; set; }
        public virtual string text_action_type_05_text { get; set; }

        public virtual string error_saving_project { get; set; }
        public virtual string error_loding_project { get; set; }
        public virtual string error_importing_project { get; set; }
        public virtual string error_import_script { get; set; }
        public virtual string error_unkown_script { get; set; }
        public virtual string info_nothing_to_save { get; set; }
        public virtual string text_mouse_move_method_info { get; set; }


        public virtual string info_no_key_selected { get; set; }
        public virtual string info_no_action_to_key { get; set; }
        public virtual string info_no_action_to_save { get; set; }
        public virtual string info_enter_macro_name { get; set; }
        public virtual string info_no_text { get; set; }
        public virtual string info_getting_color_and_position { get; set; }
        public virtual string info_clear_all_actions { get; set; }
        public virtual string string_text { get; set; }
        public virtual string text_adjust_time_info { get; set; }
        public virtual string text_adjust_timing { get; set; }
        public virtual string btnMultiAdd { get; set; }
        public virtual string info_keyboard_key_missing { get; set; }
        public virtual string info_mouse_key_missing { get; set; }
        public virtual string info_actions_has_trigger_key { get; set; }


        #endregion

        public override string ToString()
        {
            return language_name;
        }
    }
}
