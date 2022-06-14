using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

        string input_str = "";
        decimal num1 = 0;
        decimal num2 = 0;
        decimal result = 0;

        //演算子
        string operation = "";
        //第一項
        private decimal Mem1 = 0m;
        //第2項
        private decimal Mem2 = 0m;

        //0から9の数字を "" マウスで "" 押したとき
        private void click_Number(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;
            string text = btn.Text;

            Regex re = new Regex(@"[^0-9]");
            string digit = re.Replace(input_str, "");

            //桁数上限は一旦無しで -> ∞
            bool dot = process.Text.Contains(".");
            if (dot)
            {
                input_str += text;
                process.Text = string.Format("{0:#}", decimal.Parse(input_str));

                if (input_str.Contains(".0"))
                {
                    process.Text = string.Format("{0:#}", decimal.Parse(input_str)) + "." + "0";
                }
            }
            else if (text == "0")//最初に0押したとき
            {
                input_str += text;
                process.Text = String.Format("{0:#,0}", decimal.Parse(input_str));
                return;
            }
            else//0以外の数字押したとき
            {
                input_str += text;
                input_str = input_str.TrimStart('0');
                process.Text = String.Format("{0:#,0}", decimal.Parse(input_str));
            }



            decimal input_num = decimal.Parse(formula.Text + btn.Text);
            string calcu = formula.Text;
            if (0 <= calcu.IndexOf(operation))
            {
                //演算子を含む場合
                
            }
            else
            {
                //演算子を含まない、第1項
                formula.Text += input_num.ToString();
            }
        }

        //四則演算を "" マウスで "" 押したとき
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;

            num1 = result;
            if (input_str != "")
            {
                num2 = decimal.Parse(input_str);
                if (btn.Text == "+")
                {
                    result = num1 + num2;
                }
                else if (btn.Text == "－")
                {
                    result = num1 - num2;
                }
                else if (btn.Text == "÷")
                {
                    result = num1 / num2;
                }
                else if (btn.Text == "✕")
                {
                    result = num1 * num2;
                }
                else if (btn.Text == null)
                {
                    result = num2;
                }
            }

            try
            {
                Mem1 = decimal.Parse(formula.Text);
                formula.Text += operation;
            }
            catch (FormatException ex)
            {
                //第一項を入力せずに演算子を入力することは不可
                return;
            }

        }

        // "="を "" マウスで "" 押したとき
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if (formula.Text != null)
            {
                //計算結果を表示
                string result_process = process.Text.ToString();
                formula.Text = result_process;
            }

        }

        //All Clearを "" マウスで "" 押したとき
        private void click_AC(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //初期化
            formula.Text = null;
            Mem1 = 0m;
            operation = null;
        }

        //Back Spaceを "" マウスで "" 押したとき
        private void click_BS(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        /*
         * 文字打った時に、対応する奴が反応する
         * 
         * 
         */
        private void result_PressKey(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Tab_Changed(object sender, TabControlEventArgs e)
        {
            string tab_name = e.TabPage.Text;

            if (tab_name == "Normal")
            {

            }
            else if (tab_name == "Alphabet")
            {

            }
            else if (tab_name == "Other Symbols")
            {

            }
            else return;
        }

        private void Normal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Key keys = (Key)e.KeyCode;
            //formula.SelectedText = keys.ToString();

            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Down:
                    break;
                case Keys.NumPad0:
                    formula.Text = "0";
                    break;
            }
        }

        //null
        public static void SetButtonClickShortcut(Control control, Keys keys, Button button)
        {
            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == keys)
                {
                    button.PerformClick();
                }
            };
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
