
namespace TGMacro
{
    partial class frmActionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActionEditor));
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.txtSleepAmount = new System.Windows.Forms.NumericUpDown();
            this.cbKeyStatus = new System.Windows.Forms.ComboBox();
            this.pnlMousePos = new System.Windows.Forms.Panel();
            this.lblGrabCurInfo = new System.Windows.Forms.Label();
            this.mPosY = new System.Windows.Forms.NumericUpDown();
            this.lblPosition = new System.Windows.Forms.Label();
            this.mPosX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSleepAmount = new System.Windows.Forms.Panel();
            this.lblWaitAmount = new System.Windows.Forms.Label();
            this.pnlActionType = new System.Windows.Forms.Panel();
            this.lblActionType = new System.Windows.Forms.Label();
            this.pnlKeyStatus = new System.Windows.Forms.Panel();
            this.lblKeyStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlKeys = new System.Windows.Forms.Panel();
            this.txtKeySetter = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.pnlMouseMoveMethod = new System.Windows.Forms.Panel();
            this.lblPositioning = new System.Windows.Forms.Label();
            this.cbMouseMoveMethod = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtSleepAmount)).BeginInit();
            this.pnlMousePos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPosX)).BeginInit();
            this.pnlSleepAmount.SuspendLayout();
            this.pnlActionType.SuspendLayout();
            this.pnlKeyStatus.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlKeys.SuspendLayout();
            this.pnlMouseMoveMethod.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbActionType
            // 
            this.cbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActionType.FormattingEnabled = true;
            this.cbActionType.Location = new System.Drawing.Point(0, 19);
            this.cbActionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(198, 25);
            this.cbActionType.TabIndex = 4;
            // 
            // txtSleepAmount
            // 
            this.txtSleepAmount.Location = new System.Drawing.Point(0, 19);
            this.txtSleepAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSleepAmount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtSleepAmount.Name = "txtSleepAmount";
            this.txtSleepAmount.Size = new System.Drawing.Size(93, 22);
            this.txtSleepAmount.TabIndex = 23;
            this.txtSleepAmount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // cbKeyStatus
            // 
            this.cbKeyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbKeyStatus.FormattingEnabled = true;
            this.cbKeyStatus.Location = new System.Drawing.Point(0, 19);
            this.cbKeyStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbKeyStatus.Name = "cbKeyStatus";
            this.cbKeyStatus.Size = new System.Drawing.Size(198, 25);
            this.cbKeyStatus.TabIndex = 24;
            // 
            // pnlMousePos
            // 
            this.pnlMousePos.Controls.Add(this.lblGrabCurInfo);
            this.pnlMousePos.Controls.Add(this.mPosY);
            this.pnlMousePos.Controls.Add(this.lblPosition);
            this.pnlMousePos.Controls.Add(this.mPosX);
            this.pnlMousePos.Controls.Add(this.label1);
            this.pnlMousePos.Controls.Add(this.label3);
            this.pnlMousePos.Location = new System.Drawing.Point(0, 285);
            this.pnlMousePos.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMousePos.Name = "pnlMousePos";
            this.pnlMousePos.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlMousePos.Size = new System.Drawing.Size(210, 69);
            this.pnlMousePos.TabIndex = 26;
            this.pnlMousePos.Visible = false;
            // 
            // lblGrabCurInfo
            // 
            this.lblGrabCurInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGrabCurInfo.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblGrabCurInfo.ForeColor = System.Drawing.Color.Crimson;
            this.lblGrabCurInfo.Location = new System.Drawing.Point(0, 49);
            this.lblGrabCurInfo.Name = "lblGrabCurInfo";
            this.lblGrabCurInfo.Size = new System.Drawing.Size(210, 15);
            this.lblGrabCurInfo.TabIndex = 32;
            this.lblGrabCurInfo.Text = "(Alt+X get current cursor position)";
            this.lblGrabCurInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mPosY
            // 
            this.mPosY.Location = new System.Drawing.Point(125, 24);
            this.mPosY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.mPosY.Size = new System.Drawing.Size(75, 22);
            this.mPosY.TabIndex = 31;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(0, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(60, 17);
            this.lblPosition.TabIndex = 27;
            this.lblPosition.Text = "Position :";
            // 
            // mPosX
            // 
            this.mPosX.Location = new System.Drawing.Point(23, 24);
            this.mPosX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.mPosX.Size = new System.Drawing.Size(75, 22);
            this.mPosX.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "X: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Y:";
            // 
            // pnlSleepAmount
            // 
            this.pnlSleepAmount.Controls.Add(this.lblWaitAmount);
            this.pnlSleepAmount.Controls.Add(this.txtSleepAmount);
            this.pnlSleepAmount.Location = new System.Drawing.Point(0, 354);
            this.pnlSleepAmount.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSleepAmount.Name = "pnlSleepAmount";
            this.pnlSleepAmount.Size = new System.Drawing.Size(210, 50);
            this.pnlSleepAmount.TabIndex = 27;
            this.pnlSleepAmount.Visible = false;
            // 
            // lblWaitAmount
            // 
            this.lblWaitAmount.AutoSize = true;
            this.lblWaitAmount.Location = new System.Drawing.Point(0, 0);
            this.lblWaitAmount.Name = "lblWaitAmount";
            this.lblWaitAmount.Size = new System.Drawing.Size(120, 17);
            this.lblWaitAmount.TabIndex = 27;
            this.lblWaitAmount.Text = "Wait amount : (ms)";
            // 
            // pnlActionType
            // 
            this.pnlActionType.Controls.Add(this.lblActionType);
            this.pnlActionType.Controls.Add(this.cbActionType);
            this.pnlActionType.Location = new System.Drawing.Point(0, 0);
            this.pnlActionType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlActionType.Name = "pnlActionType";
            this.pnlActionType.Size = new System.Drawing.Size(210, 57);
            this.pnlActionType.TabIndex = 29;
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Location = new System.Drawing.Point(0, 0);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(84, 17);
            this.lblActionType.TabIndex = 27;
            this.lblActionType.Text = "Action type :";
            // 
            // pnlKeyStatus
            // 
            this.pnlKeyStatus.Controls.Add(this.lblKeyStatus);
            this.pnlKeyStatus.Controls.Add(this.cbKeyStatus);
            this.pnlKeyStatus.Location = new System.Drawing.Point(0, 171);
            this.pnlKeyStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pnlKeyStatus.Name = "pnlKeyStatus";
            this.pnlKeyStatus.Size = new System.Drawing.Size(210, 57);
            this.pnlKeyStatus.TabIndex = 29;
            this.pnlKeyStatus.Visible = false;
            // 
            // lblKeyStatus
            // 
            this.lblKeyStatus.AutoSize = true;
            this.lblKeyStatus.Location = new System.Drawing.Point(0, 0);
            this.lblKeyStatus.Name = "lblKeyStatus";
            this.lblKeyStatus.Size = new System.Drawing.Size(73, 17);
            this.lblKeyStatus.TabIndex = 27;
            this.lblKeyStatus.Text = "Key status :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.pnlActionType);
            this.flowLayoutPanel1.Controls.Add(this.pnlText);
            this.flowLayoutPanel1.Controls.Add(this.pnlKeys);
            this.flowLayoutPanel1.Controls.Add(this.pnlKeyStatus);
            this.flowLayoutPanel1.Controls.Add(this.pnlMouseMoveMethod);
            this.flowLayoutPanel1.Controls.Add(this.pnlMousePos);
            this.flowLayoutPanel1.Controls.Add(this.pnlSleepAmount);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 38);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 449);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.txtText);
            this.pnlText.Controls.Add(this.lblText);
            this.pnlText.Location = new System.Drawing.Point(0, 57);
            this.pnlText.Margin = new System.Windows.Forms.Padding(0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(210, 57);
            this.pnlText.TabIndex = 34;
            this.pnlText.Visible = false;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(6, 20);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(194, 22);
            this.txtText.TabIndex = 28;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(38, 17);
            this.lblText.TabIndex = 27;
            this.lblText.Text = "Text :";
            // 
            // pnlKeys
            // 
            this.pnlKeys.Controls.Add(this.txtKeySetter);
            this.pnlKeys.Controls.Add(this.lblKey);
            this.pnlKeys.Location = new System.Drawing.Point(0, 114);
            this.pnlKeys.Margin = new System.Windows.Forms.Padding(0);
            this.pnlKeys.Name = "pnlKeys";
            this.pnlKeys.Size = new System.Drawing.Size(210, 57);
            this.pnlKeys.TabIndex = 33;
            this.pnlKeys.Visible = false;
            // 
            // txtKeySetter
            // 
            this.txtKeySetter.Location = new System.Drawing.Point(6, 20);
            this.txtKeySetter.Name = "txtKeySetter";
            this.txtKeySetter.ReadOnly = true;
            this.txtKeySetter.Size = new System.Drawing.Size(194, 22);
            this.txtKeySetter.TabIndex = 28;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(0, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(35, 17);
            this.lblKey.TabIndex = 27;
            this.lblKey.Text = "Key :";
            // 
            // pnlMouseMoveMethod
            // 
            this.pnlMouseMoveMethod.Controls.Add(this.lblPositioning);
            this.pnlMouseMoveMethod.Controls.Add(this.cbMouseMoveMethod);
            this.pnlMouseMoveMethod.Location = new System.Drawing.Point(0, 228);
            this.pnlMouseMoveMethod.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMouseMoveMethod.Name = "pnlMouseMoveMethod";
            this.pnlMouseMoveMethod.Size = new System.Drawing.Size(210, 57);
            this.pnlMouseMoveMethod.TabIndex = 31;
            this.pnlMouseMoveMethod.Visible = false;
            // 
            // lblPositioning
            // 
            this.lblPositioning.AutoSize = true;
            this.lblPositioning.Location = new System.Drawing.Point(0, 0);
            this.lblPositioning.Name = "lblPositioning";
            this.lblPositioning.Size = new System.Drawing.Size(78, 17);
            this.lblPositioning.TabIndex = 27;
            this.lblPositioning.Text = "Positioning :";
            // 
            // cbMouseMoveMethod
            // 
            this.cbMouseMoveMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseMoveMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMouseMoveMethod.FormattingEnabled = true;
            this.cbMouseMoveMethod.Location = new System.Drawing.Point(0, 19);
            this.cbMouseMoveMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMouseMoveMethod.Name = "cbMouseMoveMethod";
            this.cbMouseMoveMethod.Size = new System.Drawing.Size(198, 25);
            this.cbMouseMoveMethod.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::TGMacro.Properties.Resources.save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 406);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(206, 41);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.flowLayoutPanel1);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(228, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlMain.Size = new System.Drawing.Size(228, 497);
            this.pnlMain.TabIndex = 33;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ControlLight;
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
            this.pnlTop.Size = new System.Drawing.Size(226, 30);
            this.pnlTop.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::TGMacro.Properties.Resources.close_16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(196, 0);
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
            this.lblTitle.Size = new System.Drawing.Size(90, 30);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Action Editor";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmActionEditor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(228, 411);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmActionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TGM Action Editor";
            ((System.ComponentModel.ISupportInitialize)(this.txtSleepAmount)).EndInit();
            this.pnlMousePos.ResumeLayout(false);
            this.pnlMousePos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPosX)).EndInit();
            this.pnlSleepAmount.ResumeLayout(false);
            this.pnlSleepAmount.PerformLayout();
            this.pnlActionType.ResumeLayout(false);
            this.pnlActionType.PerformLayout();
            this.pnlKeyStatus.ResumeLayout(false);
            this.pnlKeyStatus.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlKeys.ResumeLayout(false);
            this.pnlKeys.PerformLayout();
            this.pnlMouseMoveMethod.ResumeLayout(false);
            this.pnlMouseMoveMethod.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.NumericUpDown txtSleepAmount;
        private System.Windows.Forms.ComboBox cbKeyStatus;
        private System.Windows.Forms.Panel pnlMousePos;
        private System.Windows.Forms.NumericUpDown mPosY;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown mPosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSleepAmount;
        private System.Windows.Forms.Label lblWaitAmount;
        private System.Windows.Forms.Panel pnlActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.Panel pnlKeyStatus;
        private System.Windows.Forms.Label lblKeyStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblGrabCurInfo;
        private System.Windows.Forms.Panel pnlMouseMoveMethod;
        private System.Windows.Forms.Label lblPositioning;
        private System.Windows.Forms.ComboBox cbMouseMoveMethod;
        private System.Windows.Forms.Panel pnlKeys;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtKeySetter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblText;
    }
}