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
            this.history = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Font = new System.Drawing.Font("游明朝", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.history.FormattingEnabled = true;
            this.history.ItemHeight = 27;
            this.history.Items.AddRange(new object[] {
            "履歴"});
            this.history.Location = new System.Drawing.Point(-2, 0);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(418, 544);
            this.history.TabIndex = 0;
            // 
            // History_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 554);
            this.Controls.Add(this.history);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "History_form";
            this.Text = "History_form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox history;
    }
}