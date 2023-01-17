namespace TGMacro.Langs
{
    public class TUR : Bases.LanguageBase
    {
        public override string language_name => "TUR";
        public override string info_color_box => "Rengi soldaki renkli kutuya tıklayarakda değiştirebilirsiniz.";
        public override string info_getting_color_and_position => "•Alt + X İmleç pozisyonu\r\n•Alt + C İmlece göre ekran rengi";
        public override string btnFile => "Dosya";

        public override string btnSaveProject => "Projeyi Kaydet";

        public override string btnLoadProject => "Proje Yükle";

        public override string btnImportProject => "İçe Aktar Proje";

        public override string btnImportScript => "İçe Aktar script";

        public override string btnEdit => "Düzenle";

        public override string btnHelp => "Yardım";

        public override string btnAbout => "Hakkında";

        public override string info_no_macro => "Gösterilecek makro yok.\r\n\"Yeni makro ekle\" ye tıklayıp oluşturun.";

        public override string btnEnable_off => "Etkinleştir {HOME}";

        public override string btnEnable_on => "Etkisizleştir  {HOME}";

        public override string btnAdd => "Yeni Makro Ekle";

        public override string text_action_type => "Aksiyonlar :";

        public override string text_positioning => "Konumlandırma :";

        public override string text_position => "Konum :";

        public override string text_key_status => "Tuş Durumu :";

        public override string text_wait_amount => "Bekleme Süresi :";

        public override string text_key_status_01 => "Bas/Bırak";

        public override string text_key_status_02 => "Bas";

        public override string text_key_status_03 => "Bırak";

        public override string text_macro_name => "Makro Adı";

        public override string text_actions => "Aksiyonlar";

        public override string btnSave => "Kaydet";

        public override string btnTest => "Test et";

        public override string text_action => "Aksiyon";

        public override string text_value => "Değer";

        public override string btnAddAction => "Yeni aksiyon ekle";

        public override string btnEditActions => "Seçili aksiyonu düzenle";

        public override string btnCloneActions => "Seçili aksiyonları çoğalt";

        public override string btnDeleteActions => "Seçili aksiyonları sil";

        public override string btnMoveActionUp => "Seçili aksiyonları üst sıraya al";

        public override string btnMoveActionsDown => "Seçili aksiyonları alt sıraya al";

        public override string btnImportActionsFromScript => "İçe aktar makro script";

        public override string text_triggering => "Tetkikleme";

        public override string text_trigger_action_by => "Şununla tetkikle :";

        public override string txt_when => "Olduğunda :";

        public override string txt_keys => "Tuşlar :";

        public override string text_color_position => "Renk pozisyonu :";

        public override string text_color => "Renk :";

        public override string text_click_here_to_set_key => "Tuş atamak için tıklayın";

        public override string text_press_any_key_to_set => "Herhangi bir tuşa basarak atayın";

        public override string text_key_events => "Tuş Etkinliği";

        public override string text_pixel_events => "Renk Etkinliği";

        public override string text_key_press => "Basıldığında";

        public override string text_key_hold => "Basılı Tutulduğunda";

        public override string text_key_toggle => "Bas aç, Bas Kapat";

        public override string text_color_matches => "Renk Eşitse";

        public override string text_color_not_matches => "Renk Eşit Değilse";

        public override string text_mouse_move_method_01_abs => "Mutlak Değer";

        public override string text_mouse_move_method_02_rel => "Göreceli Değer";

        public override string text_action_type_01_mouse_move => "Fare Hareketi";

        public override string text_action_type_02_mouse_button => "Fare Tuşu";

        public override string text_action_type_03_keyboard_button => "Klavye Tuşu";

        public override string text_action_type_04_wait => "Bekleme";

        public override string info_grab_cursor_position => "(Fare pozisyonu için Alt+X)";
        public override string error_saving_project => "Proje kayıt edilirken hata oluştu.";

        public override string error_loding_project => "Proje yüklenirken hata oluştu.\r\nDosya bozulmuş veya başka bir versiyon için olabilir.";

        public override string error_importing_project => "Proje içe aktarılırken hata oluştu.\r\nDosya bozulmuş veya başka bir versiyon için olabilir.";

        public override string error_import_script => "AMC Script içe aktarılırken hata oluştu.";

        public override string error_unkown_script => "Bilinmeyen script.";

        public override string info_nothing_to_save => "Kaydedecek birşey yok.";

        public override string info_no_key_selected => "Tuş seçilmedi.";

        public override string info_no_action_to_key => "Test edilecek aksiyon yok.";

        public override string info_no_action_to_save => "Kayıt edilecek aksiyon yok.";

        public override string info_enter_macro_name => "Makro için isim girmediniz.";

        public override string btnRecord_off => "Kayıt ve Durdur{Ctrl+F10}";
        public override string btnTest_on => "İptal {ESC}";
        public override string text_record_settings => "Kayıt Ayarları";

        public override string btnClearActions => "Tüm aksiyonları temizle";

        public override string text_capture_mouse_pos => "İşaretçinin şu posizyonunu al :";
        public override string text_mouse_move_method_info => "Mutlak Değer işaretçinin yeni pozisyonunu belirler.\r\nGöreceli Değer işaretçinin pozisyonundan ekleme veya çıkartma yapar.";

        public override string text_grab_cursor_position => "(İşaretçi poz. için Alt + X)";
        public override string btnUpdates => "Güncellemeler";

        public override string text_record => "Şunları Kaydet :";

        public override string text_mouse_buttons => "Fare Tuşları";

        public override string text_mouse_movements => "Fare Hareketleri";

        public override string text_keyboard_keys => "Klavye Tuşları";

        public override string text_keys => "Beklemeleri";
        public override string btnChangeLanguage => "Dil değiştir";

        public override string text_macro_status => "Macro durumu";

        public override string btnTopMost => "Her zaman üstte";
        public override string text_action_type_05_text => "Metin";

        public override string info_no_text => "Metin boş olamaz.";
        public override string info_clear_all_actions => "Bu işlem tüm aksiyon listesini temizleyecek";
        public override string btn_record_off => "Kayıt\r\nCtrl + F10";
        public override string btn_record_on => "Durdur\r\nCtrl + F10";
        public override string string_text => "Metin";
        public override string text_adjust_time_info => "Değeri tüm bekleme işlemlerine ekler veya çıkarır.";
        public override string text_adjust_timing => "Beklemeleri ayarla";
        public override string btnMultiAdd => "Tüm seçili aksiyonların sonuna aksiyon ekle.";
        public override string info_keyboard_key_missing => "Bazı klavye tuş aksiyonlarının basılma veya bırakılma aksiyonları eksik. Aksiyon listesini kontrol edin.";
        public override string info_mouse_key_missing => "Bazı fare tuş aksiyonlarının basılma veya bırakılma aksiyonları eksik. Aksiyon listesini kontrol edin.";
        public override string info_actions_has_trigger_key => "Aksiyonlar tetkikleme için ayarlanmış tuşları gönderemez.";

        public override string btn_macro_delete => "{macroname} silenecek?";

        public override string macro_delete_title => "Makro sil";

        public override string edit_macro => "Makroyu düzenle";

        public override string enable_disable_macro => "Makroyu Etkinleştir/Devre dışı bırak";
    }
}
