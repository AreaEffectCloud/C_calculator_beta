using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calculator_beta
{
    public partial class Function_Calculator : Form
    {
        public Function_Calculator()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //最大サイズ、最小サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(result_PressKey);
        }

        //String
        public string input_str = "";
        private string tab_name = "";

        //Decimal
        private decimal num1 = 0m;
        private decimal num2 = 0m;
        public decimal result = 0m;

        //Bool
        private bool enzanshi = false;
        public bool eq = false;

        //演算子
        public string operation = "";

        //0から9の数字を "" マウスで "" 押したとき
        private void click_Number(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            enzanshi = false;

            Button btn = (Button)sender;
            string text = btn.Text;

            
            {
                if (text == "0")//最初に0押したとき
                {
                    input_str += text;
                    formula.Text = String.Format("{0:#,0}", input_str);
                    return;
                }
                else//0以外の数字押したとき
                {
                    input_str += text;
                    input_str = input_str.TrimStart('0');
                    formula.Text = String.Format("{0:#,0}", input_str);
                }
            }
        }

        //四則演算を "" マウスで "" 押したとき
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            if (input_str != "")
            {
                if (btn.Text == "＋")
                {
                    result = num1 + num2;
                }
                else if (btn.Text == "－")
                {
                    result = num1 - num2;
                }
                else if (btn.Text == "÷")
                {
                    try
                    {
                        result = num1 / num2;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Format_Error();
                    }
                }
                else if (btn.Text == "×")
                {
                    result = num1 * num2;
                }
                else if (btn.Text == null)
                {
                    result = num2;
                }
            }

            //input_str = "";

            if (enzanshi)//演算子ボタンが連続で押されたときに置換する (enzanshi == true)
            {
                bool dot_ = input_str.Contains(".");
                if (dot_)
                {
                    string keisan = formula.Text = formula.Text.Remove(formula.Text.Length - 1);
                    formula.Text = keisan + operation;
                    formula.Text += ".";
                }
                else
                {
                    string keisan = formula.Text = formula.Text.Remove(formula.Text.Length - 1);
                    formula.Text = keisan + operation;
                }
                
            }
            else//first
            {
                formula.Text += operation;
                enzanshi = true;
            }
        }

        //Dot Click
        private void click_Dot(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            if (formula.Text != null)
            {
                bool dot_ = input_str.Contains(".");
                if (dot_)
                {
                    return;
                }
                else
                {
                    input_str += dot.Text;
                    formula.Text += ".";
                }
            }
            else
            {
                formula.Text += "0.";
            }
        }

        //
        // Normal Type
        //
        private void click_Special(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;

            //数字がないとエラーになる特殊文字
            if (formula.Text != "")
            {
                power_fac_per(btn);
                root_pi_nepiers(btn);
            }
            else if (formula.Text == "")
            {
                root_pi_nepiers(btn);
            }
        }
        //特殊文字の入力
        private void power_fac_per(Button btn)
        {
            //連続した入力は不可
            bool power = formula.Text.Contains("^");
            bool fac = formula.Text.Contains("!");
            bool per = formula.Text.Contains("％");

            //冪乗
            if (btn.Name == "power_multiplier")
            {
                if (power)
                {
                    return;
                }
                else
                {
                    formula.Text += "^";
                }
            }
            //階乗
            else if (btn.Name == "factorial")
            {
                if (fac)
                {
                    return;
                }
                else
                {
                    formula.Text += "!";
                }
            }
            //パーセント
            else if (btn.Name == "percent")
            {
                if (per)
                {
                    return;
                }
                else
                {
                    formula.Text += "％";
                }
            }
        }
        private void root_pi_nepiers(Button btn)
        {
            // これらは連続で打っても計算可  ->  √ は例外
            //根号
            if (btn.Name == "root")
            {
                formula.Text += "√";
            }
            //円周率
            else if (btn.Name == "pi")
            {
                formula.Text += "π";
            }
            //ネピア数
            else if (btn.Name == "napiers")
            {
                formula.Text += "e";
            }
        }

        // "="を "" マウスで "" 押したとき   ->  途中式は表示しない方針 = 途中で計算をしない
        //
        // このメソッドで全ての式を計算する
        //
        //    ＋ ,   －,   ÷,   ×  ->   ＋－÷×
        //
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            bool formula_dot = formula.Text.Contains(".");

            //Dotの検討中  
            if (formula_dot)
            {
                formula.Text = String.Format("{0:0.############################################################}", result);
            }

            if (formula.Text == "")
            {
                return;
            }
            else if (formula.Text != "")
            {
                if (eq)
                {
                    return;
                }
                else if (!eq)
                {
                //
                //和と差
                //
                    if (!(formula.Text.Contains("×") && formula.Text.Contains("÷")))
                    {
                        string phrase = input_str;

                        char[] delimiterChars = { '＋', '－' };
                        string[] plus_minus = phrase.Split(delimiterChars);

                        foreach (var word in plus_minus)
                        {
                            formula.Text = $"<{word}>";
                            eq = true;
                        }
                    }
                }
            }
        }

        //All Clearを "" マウスで "" 押したとき
        private void click_AC(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            //初期化
            formula.Text = null;
            input_str = null;
            operation = null;
            num1 = 0m;
        }

        //Back Spaceを "" マウスで "" 押したとき
        private void click_BS(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (formula.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    string bs_text = formula.Text.Remove(formula.Text.Length - 1);
                    input_str = bs_text;

                    if (bs_text.Length > 0)
                    {
                        try // 小数点有りでエラー
                        {
                            //数字の末尾がドットかどうか
                            bool dot_end = input_str.EndsWith(".");
                            if (dot_end)
                            {
                                formula.Text = formula.Text.Remove(int.Parse("."));
                            }
                            else
                            //カンマ区切り付き
                            formula.Text = String.Format("{0:#,0.############################################################}", decimal.Parse(bs_text));
                        }
                        catch (FormatException ex)
                        {
                            formula.Text = String.Format("{0:#,0.############################################################}", bs_text);
                        }
                    }
                    else
                    {
                        formula.Text = "";
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
        }

        /*
         * 文字打った時に、対応する奴が反応する
         * 
         */
        private void result_PressKey(object sender, KeyPressEventArgs e)
        {
            Key key = (Key)e.KeyChar;

            if (tab_name == "Normal")
            {
                //null
            }
            else if (tab_name == "Alphabet")
            {
                //delete this tab soon
            }
            else if (tab_name == "Other Symbols")
            {
                //add a bit
            }
        }
        private void Tab_Changed(object sender, TabControlEventArgs e)
        {
            //現在のTabがどれかを取得する
            tab_name = e.TabPage.Text;
        }

        
        private void Normal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //null
            Key key_ = (Key)e.KeyData;

            if (key_.Equals("0"))
            {
                formula.Text += "0";
            }
        }


        //
        //   基本的なエラー
        //
        //Format error
        public void Format_Error()
        {
            operation = null;
            formula.ForeColor = Color.DarkRed;
            formula.Text = "Format error!";

            button_Enable(false);
            input_str = null;
        }
        //
        //ボタンの無効化
        //
        private void button_Enable(bool use)
        {
            Control.ControlCollection controls = Controls;
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Enabled = use;
                }
            }
        }

        // 
        //   計算履歴
        //
        private void click_History(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            History_form.Instance.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void click_Operation(object sender, EventArgs e)
        {

        }

        private void plus_Click(object sender, EventArgs e)
        {

        }

        private void multi_Click(object sender, EventArgs e)
        {

        }

        private void minus_Click(object sender, EventArgs e)
        {

        }

        private void divide_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
