namespace Calculator_beta
{
    partial class Function_Calculator
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Function_Calculator));
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button09 = new System.Windows.Forms.Button();
            this.button06 = new System.Windows.Forms.Button();
            this.button03 = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.button08 = new System.Windows.Forms.Button();
            this.button05 = new System.Windows.Forms.Button();
            this.button02 = new System.Windows.Forms.Button();
            this.button00 = new System.Windows.Forms.Button();
            this.button07 = new System.Windows.Forms.Button();
            this.button04 = new System.Windows.Forms.Button();
            this.button01 = new System.Windows.Forms.Button();
            this.BackSpace = new System.Windows.Forms.Button();
            this.pi = new System.Windows.Forms.Button();
            this.factorial = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.napiers = new System.Windows.Forms.Button();
            this.root = new System.Windows.Forms.Button();
            this.power_multiplier = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.multi = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.formula = new System.Windows.Forms.TextBox();
            this.history = new System.Windows.Forms.Button();
            this.Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.AccessibleName = "";
            this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab.Controls.Add(this.tabPage1);
            this.Tab.Controls.Add(this.tabPage3);
            this.Tab.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Tab.ItemSize = new System.Drawing.Size(84, 26);
            this.Tab.Location = new System.Drawing.Point(16, 206);
            this.Tab.Margin = new System.Windows.Forms.Padding(4);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(791, 446);
            this.Tab.TabIndex = 0;
            this.Tab.TabStop = false;
            this.Tab.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tab_Changed);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button09);
            this.tabPage1.Controls.Add(this.button06);
            this.tabPage1.Controls.Add(this.button03);
            this.tabPage1.Controls.Add(this.dot);
            this.tabPage1.Controls.Add(this.button08);
            this.tabPage1.Controls.Add(this.button05);
            this.tabPage1.Controls.Add(this.button02);
            this.tabPage1.Controls.Add(this.button00);
            this.tabPage1.Controls.Add(this.button07);
            this.tabPage1.Controls.Add(this.button04);
            this.tabPage1.Controls.Add(this.button01);
            this.tabPage1.Controls.Add(this.BackSpace);
            this.tabPage1.Controls.Add(this.pi);
            this.tabPage1.Controls.Add(this.factorial);
            this.tabPage1.Controls.Add(this.percent);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.napiers);
            this.tabPage1.Controls.Add(this.root);
            this.tabPage1.Controls.Add(this.power_multiplier);
            this.tabPage1.Controls.Add(this.divide);
            this.tabPage1.Controls.Add(this.multi);
            this.tabPage1.Controls.Add(this.minus);
            this.tabPage1.Controls.Add(this.plus);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(783, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "main";
            this.tabPage1.Text = "Normal";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button09
            // 
            this.button09.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button09.Location = new System.Drawing.Point(531, 25);
            this.button09.Margin = new System.Windows.Forms.Padding(4);
            this.button09.Name = "button09";
            this.button09.Size = new System.Drawing.Size(89, 74);
            this.button09.TabIndex = 28;
            this.button09.TabStop = false;
            this.button09.Text = "9";
            this.button09.UseVisualStyleBackColor = true;
            this.button09.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button09.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button06
            // 
            this.button06.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button06.Location = new System.Drawing.Point(531, 119);
            this.button06.Margin = new System.Windows.Forms.Padding(4);
            this.button06.Name = "button06";
            this.button06.Size = new System.Drawing.Size(89, 74);
            this.button06.TabIndex = 27;
            this.button06.TabStop = false;
            this.button06.Text = "6";
            this.button06.UseVisualStyleBackColor = true;
            this.button06.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button06.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button03
            // 
            this.button03.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button03.Location = new System.Drawing.Point(531, 211);
            this.button03.Margin = new System.Windows.Forms.Padding(4);
            this.button03.Name = "button03";
            this.button03.Size = new System.Drawing.Size(89, 74);
            this.button03.TabIndex = 26;
            this.button03.TabStop = false;
            this.button03.Text = "3";
            this.button03.UseVisualStyleBackColor = true;
            this.button03.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button03.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // dot
            // 
            this.dot.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dot.Location = new System.Drawing.Point(275, 304);
            this.dot.Margin = new System.Windows.Forms.Padding(4);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(89, 74);
            this.dot.TabIndex = 25;
            this.dot.TabStop = false;
            this.dot.Text = ".";
            this.dot.UseVisualStyleBackColor = true;
            this.dot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.dot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Dot);
            this.dot.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button08
            // 
            this.button08.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button08.Location = new System.Drawing.Point(401, 25);
            this.button08.Margin = new System.Windows.Forms.Padding(4);
            this.button08.Name = "button08";
            this.button08.Size = new System.Drawing.Size(89, 74);
            this.button08.TabIndex = 23;
            this.button08.TabStop = false;
            this.button08.Text = "8";
            this.button08.UseVisualStyleBackColor = true;
            this.button08.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button08.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button05
            // 
            this.button05.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button05.Location = new System.Drawing.Point(401, 119);
            this.button05.Margin = new System.Windows.Forms.Padding(4);
            this.button05.Name = "button05";
            this.button05.Size = new System.Drawing.Size(89, 74);
            this.button05.TabIndex = 22;
            this.button05.TabStop = false;
            this.button05.Text = "5";
            this.button05.UseVisualStyleBackColor = true;
            this.button05.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button05.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button02
            // 
            this.button02.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button02.Location = new System.Drawing.Point(401, 211);
            this.button02.Margin = new System.Windows.Forms.Padding(4);
            this.button02.Name = "button02";
            this.button02.Size = new System.Drawing.Size(89, 74);
            this.button02.TabIndex = 21;
            this.button02.TabStop = false;
            this.button02.Text = "2";
            this.button02.UseVisualStyleBackColor = true;
            this.button02.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button02.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button00
            // 
            this.button00.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button00.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button00.Location = new System.Drawing.Point(401, 304);
            this.button00.Margin = new System.Windows.Forms.Padding(4);
            this.button00.Name = "button00";
            this.button00.Size = new System.Drawing.Size(89, 74);
            this.button00.TabIndex = 20;
            this.button00.TabStop = false;
            this.button00.Text = "0";
            this.button00.UseVisualStyleBackColor = true;
            this.button00.Click += new System.EventHandler(this.button25_Click);
            this.button00.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button00.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button07
            // 
            this.button07.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button07.Location = new System.Drawing.Point(275, 25);
            this.button07.Margin = new System.Windows.Forms.Padding(4);
            this.button07.Name = "button07";
            this.button07.Size = new System.Drawing.Size(89, 74);
            this.button07.TabIndex = 18;
            this.button07.TabStop = false;
            this.button07.Text = "7";
            this.button07.UseVisualStyleBackColor = true;
            this.button07.Click += new System.EventHandler(this.button17_Click);
            this.button07.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button07.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button04
            // 
            this.button04.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button04.Location = new System.Drawing.Point(275, 119);
            this.button04.Margin = new System.Windows.Forms.Padding(4);
            this.button04.Name = "button04";
            this.button04.Size = new System.Drawing.Size(89, 74);
            this.button04.TabIndex = 17;
            this.button04.TabStop = false;
            this.button04.Text = "4";
            this.button04.UseVisualStyleBackColor = true;
            this.button04.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button04.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button01
            // 
            this.button01.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button01.Location = new System.Drawing.Point(275, 211);
            this.button01.Margin = new System.Windows.Forms.Padding(4);
            this.button01.Name = "button01";
            this.button01.Size = new System.Drawing.Size(89, 74);
            this.button01.TabIndex = 16;
            this.button01.TabStop = false;
            this.button01.Text = "1";
            this.button01.UseVisualStyleBackColor = true;
            this.button01.Click += new System.EventHandler(this.button19_Click);
            this.button01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            this.button01.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // BackSpace
            // 
            this.BackSpace.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BackSpace.Location = new System.Drawing.Point(147, 304);
            this.BackSpace.Margin = new System.Windows.Forms.Padding(4);
            this.BackSpace.Name = "BackSpace";
            this.BackSpace.Size = new System.Drawing.Size(89, 74);
            this.BackSpace.TabIndex = 15;
            this.BackSpace.TabStop = false;
            this.BackSpace.Text = "Back\r\nspace";
            this.BackSpace.UseVisualStyleBackColor = true;
            this.BackSpace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.BackSpace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_BS);
            this.BackSpace.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // pi
            // 
            this.pi.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pi.Location = new System.Drawing.Point(147, 25);
            this.pi.Margin = new System.Windows.Forms.Padding(4);
            this.pi.Name = "pi";
            this.pi.Size = new System.Drawing.Size(89, 74);
            this.pi.TabIndex = 12;
            this.pi.TabStop = false;
            this.pi.Text = "π";
            this.pi.UseVisualStyleBackColor = true;
            this.pi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.pi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.pi.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // factorial
            // 
            this.factorial.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.factorial.Location = new System.Drawing.Point(147, 118);
            this.factorial.Margin = new System.Windows.Forms.Padding(4);
            this.factorial.Name = "factorial";
            this.factorial.Size = new System.Drawing.Size(89, 74);
            this.factorial.TabIndex = 11;
            this.factorial.TabStop = false;
            this.factorial.Text = "!";
            this.factorial.UseVisualStyleBackColor = true;
            this.factorial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.factorial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.factorial.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // percent
            // 
            this.percent.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.percent.Location = new System.Drawing.Point(147, 210);
            this.percent.Margin = new System.Windows.Forms.Padding(4);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(89, 74);
            this.percent.TabIndex = 10;
            this.percent.TabStop = false;
            this.percent.Text = "％";
            this.percent.UseVisualStyleBackColor = true;
            this.percent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.percent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.percent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(24, 304);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 74);
            this.button6.TabIndex = 9;
            this.button6.TabStop = false;
            this.button6.Text = "All  Clear";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_AC);
            this.button6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // napiers
            // 
            this.napiers.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.napiers.Location = new System.Drawing.Point(24, 25);
            this.napiers.Margin = new System.Windows.Forms.Padding(4);
            this.napiers.Name = "napiers";
            this.napiers.Size = new System.Drawing.Size(89, 74);
            this.napiers.TabIndex = 7;
            this.napiers.TabStop = false;
            this.napiers.Text = "e";
            this.napiers.UseVisualStyleBackColor = true;
            this.napiers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.napiers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.napiers.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // root
            // 
            this.root.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.root.Location = new System.Drawing.Point(24, 118);
            this.root.Margin = new System.Windows.Forms.Padding(4);
            this.root.Name = "root";
            this.root.Size = new System.Drawing.Size(89, 74);
            this.root.TabIndex = 6;
            this.root.TabStop = false;
            this.root.Text = "√";
            this.root.UseVisualStyleBackColor = true;
            this.root.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.root.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.root.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // power_multiplier
            // 
            this.power_multiplier.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.power_multiplier.Location = new System.Drawing.Point(24, 210);
            this.power_multiplier.Margin = new System.Windows.Forms.Padding(4);
            this.power_multiplier.Name = "power_multiplier";
            this.power_multiplier.Size = new System.Drawing.Size(89, 74);
            this.power_multiplier.TabIndex = 5;
            this.power_multiplier.TabStop = false;
            this.power_multiplier.Text = "^";
            this.power_multiplier.UseVisualStyleBackColor = true;
            this.power_multiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.power_multiplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            this.power_multiplier.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // divide
            // 
            this.divide.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.divide.Location = new System.Drawing.Point(659, 25);
            this.divide.Margin = new System.Windows.Forms.Padding(4);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(89, 74);
            this.divide.TabIndex = 4;
            this.divide.TabStop = false;
            this.divide.Text = "÷";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.divide_Click);
            this.divide.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.click_Operation);
            this.divide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
            this.divide.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // multi
            // 
            this.multi.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.multi.Location = new System.Drawing.Point(659, 118);
            this.multi.Margin = new System.Windows.Forms.Padding(4);
            this.multi.Name = "multi";
            this.multi.Size = new System.Drawing.Size(89, 74);
            this.multi.TabIndex = 3;
            this.multi.TabStop = false;
            this.multi.Text = "×";
            this.multi.UseVisualStyleBackColor = true;
            this.multi.Click += new System.EventHandler(this.multi_Click);
            this.multi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.click_Operation);
            this.multi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
            this.multi.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // minus
            // 
            this.minus.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minus.Location = new System.Drawing.Point(659, 211);
            this.minus.Margin = new System.Windows.Forms.Padding(4);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(89, 74);
            this.minus.TabIndex = 2;
            this.minus.TabStop = false;
            this.minus.Text = "－";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            this.minus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.click_Operation);
            this.minus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
            this.minus.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // plus
            // 
            this.plus.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.plus.Location = new System.Drawing.Point(659, 304);
            this.plus.Margin = new System.Windows.Forms.Padding(4);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(89, 74);
            this.plus.TabIndex = 1;
            this.plus.TabStop = false;
            this.plus.Text = "＋";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            this.plus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.click_Operation);
            this.plus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
            this.plus.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(531, 304);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 74);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Eq);
            this.button1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Normal_PreviewKeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(783, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "symbol";
            this.tabPage3.Text = "Other Symbols";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // formula
            // 
            this.formula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formula.Font = global::Calculator_beta.Properties.Settings.Default.font_size_test;
            this.formula.Location = new System.Drawing.Point(16, 15);
            this.formula.Margin = new System.Windows.Forms.Padding(4);
            this.formula.Multiline = true;
            this.formula.Name = "formula";
            this.formula.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.formula.Size = new System.Drawing.Size(787, 183);
            this.formula.TabIndex = 1;
            this.formula.TabStop = false;
            this.formula.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.formula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.result_PressKey);
            // 
            // history
            // 
            this.history.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.history.BackColor = System.Drawing.Color.Transparent;
            this.history.Font = new System.Drawing.Font("游明朝", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.history.Location = new System.Drawing.Point(619, 202);
            this.history.Margin = new System.Windows.Forms.Padding(4, 4, 4, 5);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(184, 38);
            this.history.TabIndex = 29;
            this.history.Text = "History";
            this.history.UseVisualStyleBackColor = false;
            this.history.Click += new System.EventHandler(this.button2_Click);
            this.history.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_History);
            // 
            // Function_Calculator
            // 
            this.AcceptButton = this.button02;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 668);
            this.Controls.Add(this.history);
            this.Controls.Add(this.formula);
            this.Controls.Add(this.Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Function_Calculator";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button multi;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox formula;
        private System.Windows.Forms.Button button09;
        private System.Windows.Forms.Button button06;
        private System.Windows.Forms.Button button03;
        private System.Windows.Forms.Button dot;
        private System.Windows.Forms.Button button08;
        private System.Windows.Forms.Button button05;
        private System.Windows.Forms.Button button02;
        private System.Windows.Forms.Button button00;
        private System.Windows.Forms.Button button07;
        private System.Windows.Forms.Button button04;
        private System.Windows.Forms.Button button01;
        private System.Windows.Forms.Button BackSpace;
        private System.Windows.Forms.Button pi;
        private System.Windows.Forms.Button factorial;
        private System.Windows.Forms.Button percent;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button napiers;
        private System.Windows.Forms.Button root;
        private System.Windows.Forms.Button power_multiplier;
        private System.Windows.Forms.Button history;
    }
}

