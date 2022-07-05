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
            this.list_history = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // list_history
            // 
            this.list_history.Font = new System.Drawing.Font("游明朝", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.list_history.FormattingEnabled = true;
            this.list_history.ItemHeight = 34;
            this.list_history.Location = new System.Drawing.Point(-3, 0);
            this.list_history.Margin = new System.Windows.Forms.Padding(4);
            this.list_history.Name = "list_history";
            this.list_history.Size = new System.Drawing.Size(556, 684);
            this.list_history.TabIndex = 0;
            this.list_history.SelectedIndexChanged += new System.EventHandler(this.list_history_SelectedIndexChanged);
            // 
            // History_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 683);
            this.Controls.Add(this.list_history);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "History_form";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_history;
    }
}