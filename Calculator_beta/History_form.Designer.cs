namespace Calculator_beta
{
    partial class History_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History_form));
            this.history_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // history_box
            // 
            this.history_box.Font = new System.Drawing.Font("游明朝", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.history_box.HideSelection = false;
            this.history_box.Location = new System.Drawing.Point(-3, -3);
            this.history_box.Multiline = true;
            this.history_box.Name = "history_box";
            this.history_box.ReadOnly = true;
            this.history_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.history_box.ShortcutsEnabled = false;
            this.history_box.Size = new System.Drawing.Size(556, 686);
            this.history_box.TabIndex = 1;
            // 
            // History_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 683);
            this.Controls.Add(this.history_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "History_form";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox history_box;
    }
}