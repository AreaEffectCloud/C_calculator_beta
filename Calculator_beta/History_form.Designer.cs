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
            this.history_box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // history_box
            // 
            this.history_box.Font = new System.Drawing.Font("游明朝 Demibold", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.history_box.Location = new System.Drawing.Point(-3, 1);
            this.history_box.Margin = new System.Windows.Forms.Padding(4);
            this.history_box.Name = "history_box";
            this.history_box.ReadOnly = true;
            this.history_box.Size = new System.Drawing.Size(556, 683);
            this.history_box.TabIndex = 2;
            this.history_box.Text = "";
            // 
            // History_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 682);
            this.Controls.Add(this.history_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "History_form";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_form_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox history_box;
    }
}
