
using TGMacro.UI;

namespace TGMacro
{
    partial class frmMacroEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMacroEditor));
            this.grpTrigger = new System.Windows.Forms.GroupBox();
            this.pnl_colors = new System.Windows.Forms.Panel();
            this.lblGrabInfo2 = new System.Windows.Forms.Label();
            this.mPosY = new System.Windows.Forms.NumericUpDown();
            this.mPosX = new System.Windows.Forms.NumericUpDown();
            this.pnlSelectedColor = new System.Windows.Forms.Panel();
            this.lblColor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColorPos = new System.Windows.Forms.Label();
            this.lblGrabInfo = new System.Windows.Forms.Label();
            this.pnl_keys = new System.Windows.Forms.Panel();
            this.txtKeySetter = new System.Windows.Forms.TextBox();
            this.lblTrgKeys = new System.Windows.Forms.Label();
            this.lblTrgMethod = new System.Windows.Forms.Label();
            this.cbTriggerMethod = new System.Windows.Forms.ComboBox();
            this.lblTrgType = new System.Windows.Forms.Label();
            this.cbTriggerType = new System.Windows.Forms.ComboBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnMultiAction = new System.Windows.Forms.Button();
            this.btnAdjustTiming = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnImportScript = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.dtActions = new DatagridDoubleBuffer();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnEditAction = new System.Windows.Forms.Button();
            this.btnActionMoveUp = new System.Windows.Forms.Button();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.btnActionMoveDown = new System.Windows.Forms.Button();
            this.txtMacroName = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpName = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpRecord = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.cbDelays = new System.Windows.Forms.CheckBox();
            this.cbKeyboardKeys = new System.Windows.Forms.CheckBox();
            this.cbMouseButtons = new System.Windows.Forms.CheckBox();
            this.cbMouseMovements = new System.Windows.Forms.CheckBox();
            this.lblRecordThis = new System.Windows.Forms.Label();
            this.lblMouseCapPos = new System.Windows.Forms.Label();
            this.cbMousePositioning = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpTrigger.SuspendLayout();
            this.pnl_colors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPosX)).BeginInit();
            this.pnl_keys.SuspendLayout();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtActions)).BeginInit();
            this.grpName.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTrigger
            // 
            this.grpTrigger.Controls.Add(this.pnl_colors);
            this.grpTrigger.Controls.Add(this.pnl_keys);
            this.grpTrigger.Controls.Add(this.lblTrgMethod);
            this.grpTrigger.Controls.Add(this.cbTriggerMethod);
            this.grpTrigger.Controls.Add(this.lblTrgType);
            this.grpTrigger.Controls.Add(this.cbTriggerType);
            this.grpTrigger.Location = new System.Drawing.Point(491, 45);
            this.grpTrigger.Name = "grpTrigger";
            this.grpTrigger.Size = new System.Drawing.Size(354, 324);
            this.grpTrigger.TabIndex = 0;
            this.grpTrigger.TabStop = false;
            this.grpTrigger.Text = "Triggering";
            // 
            // pnl_colors
            // 
            this.pnl_colors.Controls.Add(this.lblGrabInfo2);
            this.pnl_colors.Controls.Add(this.mPosY);
            this.pnl_colors.Controls.Add(this.mPosX);
            this.pnl_colors.Controls.Add(this.pnlSelectedColor);
            this.pnl_colors.Controls.Add(this.lblColor);
            this.pnl_colors.Controls.Add(this.label3);
            this.pnl_colors.Controls.Add(this.label1);
            this.pnl_colors.Controls.Add(this.lblColorPos);
            this.pnl_colors.Controls.Add(this.lblGrabInfo);
            this.pnl_colors.Location = new System.Drawing.Point(17, 139);
            this.pnl_colors.Name = "pnl_colors";
            this.pnl_colors.Size = new System.Drawing.Size(331, 178);
            this.pnl_colors.TabIndex = 10;
            // 
            // lblGrabInfo2
            // 
            this.lblGrabInfo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGrabInfo2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGrabInfo2.ForeColor = System.Drawing.Color.Crimson;
            this.lblGrabInfo2.Location = new System.Drawing.Point(16, 127);
            this.lblGrabInfo2.Name = "lblGrabInfo2";
            this.lblGrabInfo2.Size = new System.Drawing.Size(302, 47);
            this.lblGrabInfo2.TabIndex = 19;
            this.lblGrabInfo2.Text = "•Alt + X to get current cursor position\r\n•Alt + C to get screen color by cursor";
            // 
            // mPosY
            // 
            this.mPosY.Location = new System.Drawing.Point(194, 31);
            this.mPosY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mPosY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.mPosY.Name = "mPosY";
            this.mPosY.Size = new System.Drawing.Size(104, 22);
            this.mPosY.TabIndex = 17;
            // 
            // mPosX
            // 
            this.mPosX.Location = new System.Drawing.Point(51, 31);
            this.mPosX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mPosX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.mPosX.Name = "mPosX";
            this.mPosX.Size = new System.Drawing.Size(104, 22);
            this.mPosX.TabIndex = 16;
            // 
            // pnlSelectedColor
            // 
            this.pnlSelectedColor.BackColor = System.Drawing.Color.Red;
            this.pnlSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedColor.Location = new System.Drawing.Point(20, 92);
            this.pnlSelectedColor.Name = "pnlSelectedColor";
            this.pnlSelectedColor.Size = new System.Drawing.Size(30, 30);
            this.pnlSelectedColor.TabIndex = 14;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(3, 63);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(46, 17);
            this.lblColor.TabIndex = 13;
            this.lblColor.Text = "Color :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "X: ";
            // 
            // lblColorPos
            // 
            this.lblColorPos.AutoSize = true;
            this.lblColorPos.Location = new System.Drawing.Point(0, 5);
            this.lblColorPos.Name = "lblColorPos";
            this.lblColorPos.Size = new System.Drawing.Size(96, 17);
            this.lblColorPos.TabIndex = 8;
            this.lblColorPos.Text = "Color position :";
            // 
            // lblGrabInfo
            // 
            this.lblGrabInfo.Location = new System.Drawing.Point(56, 83);
            this.lblGrabInfo.Name = "lblGrabInfo";
            this.lblGrabInfo.Size = new System.Drawing.Size(259, 47);
            this.lblGrabInfo.TabIndex = 18;
            this.lblGrabInfo.Text = "You can set the color manually by clicking the colored box.";
            // 
            // pnl_keys
            // 
            this.pnl_keys.Controls.Add(this.txtKeySetter);
            this.pnl_keys.Controls.Add(this.lblTrgKeys);
            this.pnl_keys.Location = new System.Drawing.Point(17, 139);
            this.pnl_keys.Name = "pnl_keys";
            this.pnl_keys.Size = new System.Drawing.Size(331, 76);
            this.pnl_keys.TabIndex = 9;
            // 
            // txtKeySetter
            // 
            this.txtKeySetter.Location = new System.Drawing.Point(23, 25);
            this.txtKeySetter.Multiline = true;
            this.txtKeySetter.Name = "txtKeySetter";
            this.txtKeySetter.ReadOnly = true;
            this.txtKeySetter.Size = new System.Drawing.Size(278, 25);
            this.txtKeySetter.TabIndex = 10;
            this.txtKeySetter.Text = "Click here to set key";
            this.txtKeySetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTrgKeys
            // 
            this.lblTrgKeys.AutoSize = true;
            this.lblTrgKeys.Location = new System.Drawing.Point(0, 0);
            this.lblTrgKeys.Name = "lblTrgKeys";
            this.lblTrgKeys.Size = new System.Drawing.Size(40, 17);
            this.lblTrgKeys.TabIndex = 7;
            this.lblTrgKeys.Text = "Keys :";
            // 
            // lblTrgMethod
            // 
            this.lblTrgMethod.AutoSize = true;
            this.lblTrgMethod.Location = new System.Drawing.Point(17, 82);
            this.lblTrgMethod.Name = "lblTrgMethod";
            this.lblTrgMethod.Size = new System.Drawing.Size(49, 17);
            this.lblTrgMethod.TabIndex = 5;
            this.lblTrgMethod.Text = "When :";
            // 
            // cbTriggerMethod
            // 
            this.cbTriggerMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTriggerMethod.FormattingEnabled = true;
            this.cbTriggerMethod.Location = new System.Drawing.Point(17, 104);
            this.cbTriggerMethod.Name = "cbTriggerMethod";
            this.cbTriggerMethod.Size = new System.Drawing.Size(321, 25);
            this.cbTriggerMethod.TabIndex = 4;
            // 
            // lblTrgType
            // 
            this.lblTrgType.AutoSize = true;
            this.lblTrgType.Location = new System.Drawing.Point(17, 31);
            this.lblTrgType.Name = "lblTrgType";
            this.lblTrgType.Size = new System.Drawing.Size(118, 17);
            this.lblTrgType.TabIndex = 3;
            this.lblTrgType.Text = "Trigger actions by :";
            // 
            // cbTriggerType
            // 
            this.cbTriggerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTriggerType.FormattingEnabled = true;
            this.cbTriggerType.Location = new System.Drawing.Point(17, 53);
            this.cbTriggerType.Name = "cbTriggerType";
            this.cbTriggerType.Size = new System.Drawing.Size(321, 25);
            this.cbTriggerType.TabIndex = 2;
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnMultiAction);
            this.grpActions.Controls.Add(this.btnAdjustTiming);
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnImportScript);
            this.grpActions.Controls.Add(this.btnClone);
            this.grpActions.Controls.Add(this.dtActions);
            this.grpActions.Controls.Add(this.btnDeleteAction);
            this.grpActions.Controls.Add(this.btnEditAction);
            this.grpActions.Controls.Add(this.btnActionMoveUp);
            this.grpActions.Controls.Add(this.btnAddAction);
            this.grpActions.Controls.Add(this.btnActionMoveDown);
            this.grpActions.Location = new System.Drawing.Point(13, 127);
            this.grpActions.MinimumSize = new System.Drawing.Size(323, 0);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(462, 535);
            this.grpActions.TabIndex = 2;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // btnMultiAction
            // 
            this.btnMultiAction.BackgroundImage = global::TGMacro.Properties.Resources.multi_16;
            this.btnMultiAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMultiAction.FlatAppearance.BorderSize = 0;
            this.btnMultiAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiAction.Location = new System.Drawing.Point(431, 170);
            this.btnMultiAction.Name = "btnMultiAction";
            this.btnMultiAction.Size = new System.Drawing.Size(25, 25);
            this.btnMultiAction.TabIndex = 16;
            this.btnMultiAction.UseVisualStyleBackColor = true;
            // 
            // btnAdjustTiming
            // 
            this.btnAdjustTiming.BackgroundImage = global::TGMacro.Properties.Resources.wait_16;
            this.btnAdjustTiming.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdjustTiming.FlatAppearance.BorderSize = 0;
            this.btnAdjustTiming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjustTiming.Location = new System.Drawing.Point(431, 139);
            this.btnAdjustTiming.Name = "btnAdjustTiming";
            this.btnAdjustTiming.Size = new System.Drawing.Size(25, 25);
            this.btnAdjustTiming.TabIndex = 15;
            this.btnAdjustTiming.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::TGMacro.Properties.Resources.clear_16;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(431, 199);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(25, 25);
            this.btnClear.TabIndex = 14;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnImportScript
            // 
            this.btnImportScript.BackgroundImage = global::TGMacro.Properties.Resources.import_16;
            this.btnImportScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImportScript.FlatAppearance.BorderSize = 0;
            this.btnImportScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportScript.Location = new System.Drawing.Point(431, 504);
            this.btnImportScript.Name = "btnImportScript";
            this.btnImportScript.Size = new System.Drawing.Size(25, 25);
            this.btnImportScript.TabIndex = 12;
            this.btnImportScript.UseVisualStyleBackColor = true;
            // 
            // btnClone
            // 
            this.btnClone.BackgroundImage = global::TGMacro.Properties.Resources.clone_16;
            this.btnClone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClone.FlatAppearance.BorderSize = 0;
            this.btnClone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClone.Location = new System.Drawing.Point(431, 77);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(25, 25);
            this.btnClone.TabIndex = 11;
            this.btnClone.UseVisualStyleBackColor = true;
            // 
            // dtActions
            // 
            this.dtActions.AllowUserToAddRows = false;
            this.dtActions.AllowUserToDeleteRows = false;
            this.dtActions.AllowUserToResizeColumns = false;
            this.dtActions.AllowUserToResizeRows = false;
            this.dtActions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtActions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtActions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtActions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtActions.ColumnHeadersHeight = 30;
            this.dtActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtActions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtActions.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtActions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtActions.EnableHeadersVisualStyles = false;
            this.dtActions.GridColor = System.Drawing.SystemColors.Window;
            this.dtActions.Location = new System.Drawing.Point(3, 18);
            this.dtActions.Name = "dtActions";
            this.dtActions.ReadOnly = true;
            this.dtActions.RowHeadersVisible = false;
            this.dtActions.RowHeadersWidth = 51;
            this.dtActions.RowTemplate.Height = 29;
            this.dtActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtActions.Size = new System.Drawing.Size(422, 514);
            this.dtActions.TabIndex = 8;
            this.dtActions.TabStop = false;
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.BackgroundImage = global::TGMacro.Properties.Resources.del_16;
            this.btnDeleteAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteAction.FlatAppearance.BorderSize = 0;
            this.btnDeleteAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAction.Location = new System.Drawing.Point(431, 108);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteAction.TabIndex = 10;
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            // 
            // btnEditAction
            // 
            this.btnEditAction.BackgroundImage = global::TGMacro.Properties.Resources.edit_16;
            this.btnEditAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditAction.FlatAppearance.BorderSize = 0;
            this.btnEditAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAction.Location = new System.Drawing.Point(431, 48);
            this.btnEditAction.Name = "btnEditAction";
            this.btnEditAction.Size = new System.Drawing.Size(25, 25);
            this.btnEditAction.TabIndex = 9;
            this.btnEditAction.UseVisualStyleBackColor = true;
            // 
            // btnActionMoveUp
            // 
            this.btnActionMoveUp.BackgroundImage = global::TGMacro.Properties.Resources.up_arrow_16;
            this.btnActionMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActionMoveUp.FlatAppearance.BorderSize = 0;
            this.btnActionMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActionMoveUp.Location = new System.Drawing.Point(431, 273);
            this.btnActionMoveUp.Name = "btnActionMoveUp";
            this.btnActionMoveUp.Size = new System.Drawing.Size(20, 23);
            this.btnActionMoveUp.TabIndex = 3;
            this.btnActionMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnAddAction
            // 
            this.btnAddAction.BackgroundImage = global::TGMacro.Properties.Resources.add_16;
            this.btnAddAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAction.FlatAppearance.BorderSize = 0;
            this.btnAddAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAction.Location = new System.Drawing.Point(431, 19);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(25, 25);
            this.btnAddAction.TabIndex = 8;
            this.btnAddAction.UseVisualStyleBackColor = true;
            // 
            // btnActionMoveDown
            // 
            this.btnActionMoveDown.BackgroundImage = global::TGMacro.Properties.Resources.down_arrow_16;
            this.btnActionMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActionMoveDown.FlatAppearance.BorderSize = 0;
            this.btnActionMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActionMoveDown.Location = new System.Drawing.Point(431, 302);
            this.btnActionMoveDown.Name = "btnActionMoveDown";
            this.btnActionMoveDown.Size = new System.Drawing.Size(20, 20);
            this.btnActionMoveDown.TabIndex = 4;
            this.btnActionMoveDown.UseVisualStyleBackColor = true;
            // 
            // txtMacroName
            // 
            this.txtMacroName.Location = new System.Drawing.Point(17, 31);
            this.txtMacroName.Name = "txtMacroName";
            this.txtMacroName.Size = new System.Drawing.Size(169, 22);
            this.txtMacroName.TabIndex = 0;
            this.txtMacroName.Text = "Macro 01";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.txtMacroName);
            this.grpName.Location = new System.Drawing.Point(16, 42);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(459, 79);
            this.grpName.TabIndex = 8;
            this.grpName.TabStop = false;
            this.grpName.Text = "Macro name";
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.grpRecord);
            this.pnlMain.Controls.Add(this.btnTest);
            this.pnlMain.Controls.Add(this.grpName);
            this.pnlMain.Controls.Add(this.grpActions);
            this.pnlMain.Controls.Add(this.grpTrigger);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(862, 674);
            this.pnlMain.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(515, 653);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(135, 5);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTop.Controls.Add(this.btnMin);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.MaximumSize = new System.Drawing.Size(0, 30);
            this.pnlTop.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlTop.Size = new System.Drawing.Size(860, 30);
            this.pnlTop.TabIndex = 13;
            // 
            // btnMin
            // 
            this.btnMin.BackgroundImage = global::TGMacro.Properties.Resources.min_16;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(806, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(20, 30);
            this.btnMin.TabIndex = 10;
            this.btnMin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::TGMacro.Properties.Resources.close_16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(830, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 0);
            this.lblTitle.MaximumSize = new System.Drawing.Size(0, 30);
            this.lblTitle.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblTitle.Size = new System.Drawing.Size(91, 30);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Macro Editor";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRecord
            // 
            this.grpRecord.Controls.Add(this.btnRecord);
            this.grpRecord.Controls.Add(this.cbDelays);
            this.grpRecord.Controls.Add(this.cbKeyboardKeys);
            this.grpRecord.Controls.Add(this.cbMouseButtons);
            this.grpRecord.Controls.Add(this.cbMouseMovements);
            this.grpRecord.Controls.Add(this.lblRecordThis);
            this.grpRecord.Controls.Add(this.lblMouseCapPos);
            this.grpRecord.Controls.Add(this.cbMousePositioning);
            this.grpRecord.Location = new System.Drawing.Point(491, 375);
            this.grpRecord.Name = "grpRecord";
            this.grpRecord.Size = new System.Drawing.Size(348, 237);
            this.grpRecord.TabIndex = 12;
            this.grpRecord.TabStop = false;
            this.grpRecord.Text = "Record Settings";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::TGMacro.Properties.Resources.record_16;
            this.btnRecord.Location = new System.Drawing.Point(217, 150);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(121, 71);
            this.btnRecord.TabIndex = 13;
            this.btnRecord.Text = "Record\r\nCtrl + F10";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRecord.UseVisualStyleBackColor = false;
            // 
            // cbDelays
            // 
            this.cbDelays.AutoSize = true;
            this.cbDelays.Checked = true;
            this.cbDelays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDelays.Location = new System.Drawing.Point(20, 197);
            this.cbDelays.Name = "cbDelays";
            this.cbDelays.Size = new System.Drawing.Size(63, 21);
            this.cbDelays.TabIndex = 12;
            this.cbDelays.Text = "Delays";
            this.cbDelays.UseVisualStyleBackColor = true;
            // 
            // cbKeyboardKeys
            // 
            this.cbKeyboardKeys.AutoSize = true;
            this.cbKeyboardKeys.Checked = true;
            this.cbKeyboardKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeyboardKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbKeyboardKeys.Location = new System.Drawing.Point(20, 167);
            this.cbKeyboardKeys.Name = "cbKeyboardKeys";
            this.cbKeyboardKeys.Size = new System.Drawing.Size(110, 21);
            this.cbKeyboardKeys.TabIndex = 11;
            this.cbKeyboardKeys.Text = "Keyboard Keys";
            this.cbKeyboardKeys.UseVisualStyleBackColor = true;
            // 
            // cbMouseButtons
            // 
            this.cbMouseButtons.AutoSize = true;
            this.cbMouseButtons.Checked = true;
            this.cbMouseButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMouseButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMouseButtons.Location = new System.Drawing.Point(21, 138);
            this.cbMouseButtons.Name = "cbMouseButtons";
            this.cbMouseButtons.Size = new System.Drawing.Size(110, 21);
            this.cbMouseButtons.TabIndex = 10;
            this.cbMouseButtons.Text = "Mouse Buttons";
            this.cbMouseButtons.UseVisualStyleBackColor = true;
            // 
            // cbMouseMovements
            // 
            this.cbMouseMovements.AutoSize = true;
            this.cbMouseMovements.Checked = true;
            this.cbMouseMovements.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMouseMovements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMouseMovements.Location = new System.Drawing.Point(20, 111);
            this.cbMouseMovements.Name = "cbMouseMovements";
            this.cbMouseMovements.Size = new System.Drawing.Size(137, 21);
            this.cbMouseMovements.TabIndex = 9;
            this.cbMouseMovements.Text = "Mouse Movements";
            this.cbMouseMovements.UseVisualStyleBackColor = true;
            // 
            // lblRecordThis
            // 
            this.lblRecordThis.AutoSize = true;
            this.lblRecordThis.Location = new System.Drawing.Point(16, 88);
            this.lblRecordThis.Name = "lblRecordThis";
            this.lblRecordThis.Size = new System.Drawing.Size(57, 17);
            this.lblRecordThis.TabIndex = 8;
            this.lblRecordThis.Text = "Record :";
            // 
            // lblMouseCapPos
            // 
            this.lblMouseCapPos.AutoSize = true;
            this.lblMouseCapPos.Location = new System.Drawing.Point(14, 25);
            this.lblMouseCapPos.Name = "lblMouseCapPos";
            this.lblMouseCapPos.Size = new System.Drawing.Size(128, 17);
            this.lblMouseCapPos.TabIndex = 7;
            this.lblMouseCapPos.Text = "Mouse\'s positioning :";
            // 
            // cbMousePositioning
            // 
            this.cbMousePositioning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMousePositioning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMousePositioning.FormattingEnabled = true;
            this.cbMousePositioning.Location = new System.Drawing.Point(14, 47);
            this.cbMousePositioning.Name = "cbMousePositioning";
            this.cbMousePositioning.Size = new System.Drawing.Size(321, 25);
            this.cbMousePositioning.TabIndex = 6;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Image = global::TGMacro.Properties.Resources.start_32;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(514, 618);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(137, 41);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "Test";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::TGMacro.Properties.Resources.save_32;
            this.btnSave.Location = new System.Drawing.Point(708, 618);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 41);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // frmMacroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 674);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMacroEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TGM Editor";
            this.grpTrigger.ResumeLayout(false);
            this.grpTrigger.PerformLayout();
            this.pnl_colors.ResumeLayout(false);
            this.pnl_colors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPosX)).EndInit();
            this.pnl_keys.ResumeLayout(false);
            this.pnl_keys.PerformLayout();
            this.grpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtActions)).EndInit();
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpRecord.ResumeLayout(false);
            this.grpRecord.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTrigger;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnActionMoveUp;
        private System.Windows.Forms.Button btnActionMoveDown;
        private System.Windows.Forms.TextBox txtMacroName;
        private System.Windows.Forms.ComboBox cbTriggerType;
        private System.Windows.Forms.Label lblTrgKeys;
        private System.Windows.Forms.Label lblTrgMethod;
        private System.Windows.Forms.ComboBox cbTriggerMethod;
        private System.Windows.Forms.Label lblTrgType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnl_keys;
        private System.Windows.Forms.Panel pnl_colors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblColorPos;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pnlSelectedColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.NumericUpDown mPosY;
        private System.Windows.Forms.NumericUpDown mPosX;
        private System.Windows.Forms.Label lblGrabInfo;
        private DatagridDoubleBuffer dtActions;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Button btnEditAction;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnImportScript;
        private System.Windows.Forms.TextBox txtKeySetter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpRecord;
        private System.Windows.Forms.Label lblMouseCapPos;
        private System.Windows.Forms.ComboBox cbMousePositioning;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox cbDelays;
        private System.Windows.Forms.CheckBox cbKeyboardKeys;
        private System.Windows.Forms.CheckBox cbMouseButtons;
        private System.Windows.Forms.CheckBox cbMouseMovements;
        private System.Windows.Forms.Label lblRecordThis;
        private System.Windows.Forms.Label lblGrabInfo2;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnAdjustTiming;
        private System.Windows.Forms.Button btnMultiAction;
        public System.Windows.Forms.Button btnMin;
    }
}