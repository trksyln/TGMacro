
namespace TGMacro
{
    partial class ucMacroItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMacroItem));
            this.picTriggerType = new System.Windows.Forms.PictureBox();
            this.lblMacroName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlEnable = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblKeyInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTriggerType)).BeginInit();
            this.SuspendLayout();
            // 
            // picTriggerType
            // 
            this.picTriggerType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picTriggerType.BackgroundImage = global::TGMacro.Properties.Resources.mouse_16px;
            this.picTriggerType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTriggerType.Location = new System.Drawing.Point(23, 42);
            this.picTriggerType.Name = "picTriggerType";
            this.picTriggerType.Size = new System.Drawing.Size(20, 20);
            this.picTriggerType.TabIndex = 0;
            this.picTriggerType.TabStop = false;
            // 
            // lblMacroName
            // 
            this.lblMacroName.AutoEllipsis = true;
            this.lblMacroName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblMacroName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMacroName.Location = new System.Drawing.Point(20, 0);
            this.lblMacroName.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblMacroName.Name = "lblMacroName";
            this.lblMacroName.Size = new System.Drawing.Size(247, 40);
            this.lblMacroName.TabIndex = 1;
            this.lblMacroName.Text = "Macro 0001";
            this.lblMacroName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(218, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(20, 20);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(244, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(20, 20);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // pnlEnable
            // 
            this.pnlEnable.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEnable.Location = new System.Drawing.Point(0, 0);
            this.pnlEnable.Name = "pnlEnable";
            this.pnlEnable.Size = new System.Drawing.Size(20, 65);
            this.pnlEnable.TabIndex = 17;
            // 
            // lblKeyInfo
            // 
            this.lblKeyInfo.AutoEllipsis = true;
            this.lblKeyInfo.BackColor = System.Drawing.Color.White;
            this.lblKeyInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKeyInfo.Location = new System.Drawing.Point(20, 40);
            this.lblKeyInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lblKeyInfo.Name = "lblKeyInfo";
            this.lblKeyInfo.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.lblKeyInfo.Size = new System.Drawing.Size(247, 25);
            this.lblKeyInfo.TabIndex = 18;
            this.lblKeyInfo.Text = "Control + W";
            this.lblKeyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMacroItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picTriggerType);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblMacroName);
            this.Controls.Add(this.lblKeyInfo);
            this.Controls.Add(this.pnlEnable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Name = "ucMacroItem";
            this.Size = new System.Drawing.Size(267, 65);
            ((System.ComponentModel.ISupportInitialize)(this.picTriggerType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTriggerType;
        private System.Windows.Forms.Label lblMacroName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlEnable;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblKeyInfo;
    }
}
