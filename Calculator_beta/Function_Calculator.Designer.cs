namespace Calculator_beta
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nine = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.BackSpace = new System.Windows.Forms.Button();
            this.pi = new System.Windows.Forms.Button();
            this.factorial = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Button();
            this.AllClear = new System.Windows.Forms.Button();
            this.napiers = new System.Windows.Forms.Button();
            this.root = new System.Windows.Forms.Button();
            this.power_multiplier = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.multi = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
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
            this.Tab.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Tab.ItemSize = new System.Drawing.Size(84, 26);
            this.Tab.Location = new System.Drawing.Point(16, 206);
            this.Tab.Margin = new System.Windows.Forms.Padding(4);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(791, 446);
            this.Tab.TabIndex = 0;
            this.Tab.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nine);
            this.tabPage1.Controls.Add(this.six);
            this.tabPage1.Controls.Add(this.three);
            this.tabPage1.Controls.Add(this.dot);
            this.tabPage1.Controls.Add(this.eight);
            this.tabPage1.Controls.Add(this.five);
            this.tabPage1.Controls.Add(this.two);
            this.tabPage1.Controls.Add(this.zero);
            this.tabPage1.Controls.Add(this.seven);
            this.tabPage1.Controls.Add(this.four);
            this.tabPage1.Controls.Add(this.one);
            this.tabPage1.Controls.Add(this.BackSpace);
            this.tabPage1.Controls.Add(this.pi);
            this.tabPage1.Controls.Add(this.factorial);
            this.tabPage1.Controls.Add(this.percent);
            this.tabPage1.Controls.Add(this.AllClear);
            this.tabPage1.Controls.Add(this.napiers);
            this.tabPage1.Controls.Add(this.root);
            this.tabPage1.Controls.Add(this.power_multiplier);
            this.tabPage1.Controls.Add(this.divide);
            this.tabPage1.Controls.Add(this.multi);
            this.tabPage1.Controls.Add(this.minus);
            this.tabPage1.Controls.Add(this.plus);
            this.tabPage1.Controls.Add(this.equal);
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
            // nine
            // 
            this.nine.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nine.Location = new System.Drawing.Point(531, 25);
            this.nine.Margin = new System.Windows.Forms.Padding(4);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(89, 74);
            this.nine.TabIndex = 28;
            this.nine.TabStop = false;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = true;
            this.nine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.nine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // six
            // 
            this.six.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.six.Location = new System.Drawing.Point(531, 119);
            this.six.Margin = new System.Windows.Forms.Padding(4);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(89, 74);
            this.six.TabIndex = 27;
            this.six.TabStop = false;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = true;
            this.six.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.six.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // three
            // 
            this.three.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.three.Location = new System.Drawing.Point(531, 211);
            this.three.Margin = new System.Windows.Forms.Padding(4);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(89, 74);
            this.three.TabIndex = 26;
            this.three.TabStop = false;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.three.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
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
            this.dot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.dot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Dot);
            // 
            // eight
            // 
            this.eight.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.eight.Location = new System.Drawing.Point(401, 25);
            this.eight.Margin = new System.Windows.Forms.Padding(4);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(89, 74);
            this.eight.TabIndex = 23;
            this.eight.TabStop = false;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = true;
            this.eight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.eight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // five
            // 
            this.five.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.five.Location = new System.Drawing.Point(401, 119);
            this.five.Margin = new System.Windows.Forms.Padding(4);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(89, 74);
            this.five.TabIndex = 22;
            this.five.TabStop = false;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.five.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // two
            // 
            this.two.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.two.Location = new System.Drawing.Point(401, 211);
            this.two.Margin = new System.Windows.Forms.Padding(4);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(89, 74);
            this.two.TabIndex = 21;
            this.two.TabStop = false;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.two.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // zero
            // 
            this.zero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zero.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.zero.Location = new System.Drawing.Point(401, 304);
            this.zero.Margin = new System.Windows.Forms.Padding(4);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(89, 74);
            this.zero.TabIndex = 20;
            this.zero.TabStop = false;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = true;
            this.zero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.zero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // seven
            // 
            this.seven.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.seven.Location = new System.Drawing.Point(275, 25);
            this.seven.Margin = new System.Windows.Forms.Padding(4);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(89, 74);
            this.seven.TabIndex = 18;
            this.seven.TabStop = false;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = true;
            this.seven.Click += new System.EventHandler(this.button17_Click);
            this.seven.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.seven.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // four
            // 
            this.four.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.four.Location = new System.Drawing.Point(275, 119);
            this.four.Margin = new System.Windows.Forms.Padding(4);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(89, 74);
            this.four.TabIndex = 17;
            this.four.TabStop = false;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.four.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
            // 
            // one
            // 
            this.one.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.one.Location = new System.Drawing.Point(275, 211);
            this.one.Margin = new System.Windows.Forms.Padding(4);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(89, 74);
            this.one.TabIndex = 16;
            this.one.TabStop = false;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            this.one.Click += new System.EventHandler(this.button19_Click);
            this.one.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.one.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Number);
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
            this.BackSpace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.BackSpace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_BS);
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
            this.pi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.pi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
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
            this.factorial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.factorial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
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
            this.percent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.percent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
            // 
            // AllClear
            // 
            this.AllClear.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AllClear.Location = new System.Drawing.Point(24, 304);
            this.AllClear.Margin = new System.Windows.Forms.Padding(4);
            this.AllClear.Name = "AllClear";
            this.AllClear.Size = new System.Drawing.Size(89, 74);
            this.AllClear.TabIndex = 9;
            this.AllClear.TabStop = false;
            this.AllClear.Text = "All  Clear";
            this.AllClear.UseVisualStyleBackColor = true;
            this.AllClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.AllClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_AC);
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
            this.napiers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.napiers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
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
            this.root.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.root.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
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
            this.power_multiplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.power_multiplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Special);
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
            this.divide.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.divide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
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
            this.multi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.multi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
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
            this.minus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.minus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
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
            this.plus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.plus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_ope);
            // 
            // equal
            // 
            this.equal.Font = new System.Drawing.Font("游明朝 Demibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.equal.Location = new System.Drawing.Point(531, 304);
            this.equal.Margin = new System.Windows.Forms.Padding(4);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(89, 74);
            this.equal.TabIndex = 0;
            this.equal.TabStop = false;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = true;
            this.equal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.press_Key);
            this.equal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_Eq);
            // 
            // formula
            // 
            this.formula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formula.Font = global::Calculator_beta.Properties.Settings.Default.font_size_test;
            this.formula.Location = new System.Drawing.Point(23, 15);
            this.formula.Margin = new System.Windows.Forms.Padding(4);
            this.formula.Multiline = true;
            this.formula.Name = "formula";
            this.formula.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.formula.Size = new System.Drawing.Size(787, 183);
            this.formula.TabIndex = 1;
            this.formula.TabStop = false;
            this.formula.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // Calculator
            // 
            this.AcceptButton = this.equal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 668);
            this.Controls.Add(this.history);
            this.Controls.Add(this.formula);
            this.Controls.Add(this.Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Calculator";
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
        private System.Windows.Forms.Button equal;
        private System.Windows.Forms.TextBox formula;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button dot;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button BackSpace;
        private System.Windows.Forms.Button pi;
        private System.Windows.Forms.Button factorial;
        private System.Windows.Forms.Button percent;
        private System.Windows.Forms.Button AllClear;
        private System.Windows.Forms.Button napiers;
        private System.Windows.Forms.Button root;
        private System.Windows.Forms.Button power_multiplier;
        private System.Windows.Forms.Button history;
    }
}

