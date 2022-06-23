using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calculator_beta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(result_PressKey);
        }

        //String
        private string input_str = "";
        private string tab_name = "";

        //Decimal
        private decimal num1 = 0m;
        private decimal num2 = 0m;
        private decimal result = 0m;

        //Bool
        private bool enzanshi = false;

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
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
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
                        operation = null;
                        formula.ForeColor = Color.DarkRed;
                        formula.Text = "Format Error!"; 
                        button_Enable(false);
                        input_str = null;
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
            formula.ForeColor = Color.Black;
            bool dot_ = formula.Text.Contains(".");
            if (dot_)
            {
                return;
            }
            else
            {
                input_str += dot.Text;
                if (formula.Text == "")
                {
                    formula.Text += "0.";
                }
                else
                {
                    formula.Text += ".";
                }
            }
        }

        // "="を "" マウスで "" 押したとき   ->  途中式は表示しない方針
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            bool formula_dot = formula.Text.Contains(".");
            if (operation == "=")
            {
                if (formula_dot)
                {
                    process_null.Text = String.Format("{0:0.############################################################}", result);
                }
            }
        }

        //All Clearを "" マウスで "" 押したとき
        private void click_AC(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            //初期化
            formula.Text = null;
            process_null.Text = null;
            input_str = null;
            operation = null;
            num1 = 0m;
        }

        //Back Spaceを "" マウスで "" 押したとき
        private void click_BS(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.Text = formula.Text.Remove(formula.Text.Length - 1);
            formula.Text = String.Format("{0:#,0}", decimal.Parse(formula.Text));
        }

        /*
         * 文字打った時に、対応する奴が反応する
         * 
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
