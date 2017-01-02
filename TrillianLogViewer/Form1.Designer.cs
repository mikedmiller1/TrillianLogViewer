namespace TrillianLogViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BuddyNameCombo = new System.Windows.Forms.ComboBox();
            this.HistoryText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BuddyNameCombo
            // 
            this.BuddyNameCombo.FormattingEnabled = true;
            this.BuddyNameCombo.Location = new System.Drawing.Point(12, 12);
            this.BuddyNameCombo.Name = "BuddyNameCombo";
            this.BuddyNameCombo.Size = new System.Drawing.Size(273, 21);
            this.BuddyNameCombo.TabIndex = 0;
            this.BuddyNameCombo.SelectedIndexChanged += new System.EventHandler(this.BuddyNameCombo_SelectedIndexChanged);
            // 
            // HistoryText
            // 
            this.HistoryText.Location = new System.Drawing.Point(12, 39);
            this.HistoryText.Multiline = true;
            this.HistoryText.Name = "HistoryText";
            this.HistoryText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HistoryText.Size = new System.Drawing.Size(785, 649);
            this.HistoryText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 700);
            this.Controls.Add(this.HistoryText);
            this.Controls.Add(this.BuddyNameCombo);
            this.Name = "Form1";
            this.Text = "Trillian History Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BuddyNameCombo;
        private System.Windows.Forms.TextBox HistoryText;
    }
}

