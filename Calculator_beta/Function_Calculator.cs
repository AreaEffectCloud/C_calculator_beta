using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calculator_beta
{
    public partial class Function_Calculator : Form
    {
        public Function_Calculator()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(result_PressKey);
        }

        /*
         * 数値を入力したら、途中で答えを表示せずに、＝(Enter Key)を押したら、計算結果を表示する
         *    ---> Process TextBox の 廃止
         * 
         * 
         */

        //String
        private string input_str = "";
        private string tab_name = "";

        //Decimal
        private decimal num1 = 0m;
        private decimal num2 = 0m;
        private decimal result = 0m;

        //Bool
        private bool enzanshi = false;
        private bool eq = false;

        //演算子
        private string operation = null;

        //0から9の数字を "" マウスで "" 押したとき
        private void click_Number(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            enzanshi = false;

            Button btn = (Button)sender;
            string text = btn.Text;

            //桁数 は ∞, 小数点以下は60桁まで
            bool dot = formula.Text.Contains(".");
            if (dot)
            {
                input_str += text;
                formula.Text = string.Format("{0:0.############################################################}", decimal.Parse(input_str));

                if (input_str.Contains(".0"))
                {
                    formula.Text = string.Format("{0:0.############################################################}", decimal.Parse(input_str)) + "." + "0";
                }
            }
            else if (text == "0")//最初に0押したとき
            {
                input_str += text;
                formula.Text = String.Format("{0:#,0}", decimal.Parse(input_str));
                return;
            }
            else//0以外の数字押したとき
            {
                input_str += text;
                input_str = input_str.TrimStart('0');
                formula.Text = String.Format("{0:#,0}", decimal.Parse(input_str));
            }
        }

        //四則演算を "" マウスで "" 押したとき
        //
        // 直接計算することはほぼないに等しい  -> 変数の代入のみも有り  
        //
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            num1 = result;
            if (input_str != "")
            {
                num2 = decimal.Parse(input_str);
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
                    } catch (DivideByZeroException ex)
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

            input_str = "";

            if (enzanshi)//演算子ボタンが連続で押されたときに置換する (enzanshi == true)
            {
                string keisan = formula.Text = formula.Text.Remove(formula.Text.Length - 1);
                formula.Text = keisan + operation;
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
                bool dot_ = formula.Text.Contains(".");
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
            //bool root_ = formula.Text.Contains("√");
            //bool pi_ = formula.Text.Contains("π");
            //bool nepiers_ = formula.Text.Contains("e");

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

        // "="を "" マウスで "" 押したとき   ->  途中式は表示しない方針
        //
        // 演算子を抽出して計算する。 String.Split を使用して文字列を分割
        //
        // Alphabet 要る？
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
            if(formula.Text == null)
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
                            //カンマ区切り付き
                            formula.Text = String.Format("{0:#,0}", decimal.Parse(bs_text));
                        }
                        catch (FormatException ex)
                        {
                            formula.Text = String.Format("{0:#,0}", bs_text);
                        }
                    }
                    else
                    {
                        formula.Text = "";
                    }

                } catch (ArgumentOutOfRangeException)
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
                switch (key)
                {
                    case Key.NumPad0:
                        formula.Text += 0;
                        break;
                    case Key.NumPad1:
                        formula.Text += 1;
                        break;
                    case Key.NumPad2:
                        formula.Text += 2;
                        break;
                    case Key.NumPad3:
                        formula.Text += 3;
                        break;
                    case Key.NumPad4:
                        formula.Text += 4;
                        break;
                    case Key.NumPad5:
                        formula.Text += 5;
                        break;
                    case Key.NumPad6:
                        formula.Text += 6;
                        break;
                    case Key.NumPad7:
                        formula.Text += 7;
                        break;
                    case Key.NumPad8:
                        formula.Text += 8;
                        break;
                    case Key.NumPad9:
                        formula.Text += 9;
                        break;
                }
            }
            else if (tab_name == "Alphabet")
            {

            }
            else if (tab_name == "Other Symbols")
            {

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
        }


        //
        //   基本的なエラー
        //

        //Format error
        private void Format_Error()
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
    }
}
