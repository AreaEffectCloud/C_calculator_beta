using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Input;
using Antlr.Runtime;
using NCalc;

namespace Calculator_beta
{
    public partial class Function_Calculator : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Function_Calculator()
        {
            InitializeComponent();
            //output to Cmd
            AllocConsole();

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

        // String List
        List<string> num_list = new List<string>();

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
                    formula.Text = input_str;
                    return;
                }
                else//0以外の数字押したとき
                {
                    input_str += text;
                    input_str = input_str.TrimStart('0');
                    formula.Text = String.Format("{0:#,0.############################################################}", input_str);
                }
            }
        }

        //四則演算を "" マウスで "" 押したとき  ＋－÷×
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            /*
            if (input_str != "")
            {
                if (btn.Name == "plus")
                {
                    input_str += "＋";
                }
                else if (btn.Name == "minus")
                {
                    input_str += "－";
                }
                else if (btn.Name == "divide")
                {
                    input_str += "÷";

                    //0で割ったときのError
                    try
                    {
                        num1 -= input_str.Length - 1;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Format_Error();
                        Console.WriteLine(ex);
                    }
                }
                else if (btn.Name == "multi")
                {
                    input_str += "×";
                }
            }
            */

            if (enzanshi)//演算子ボタンが連続で押されたときに置換する (enzanshi == true)
            {
                //NullReferenceException
                try
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
                catch (NullReferenceException nrex)
                {
                    Console.WriteLine(nrex);
                    return;
                }
            }
            else//first
            {
                formula.Text += operation;
                enzanshi = true;
            }
        }

        //Dot Click
        // 若干の修正必要
        private void click_Dot(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            eq = false;
            formula.ForeColor = Color.Black;
            if (input_str != "")
            {
                bool dot_ = input_str.Contains(".");
                if (dot_)
                {
                    return;
                }
                else
                {
                    input_str += dot.Text;
                    formula.Text += "0.";
                }
            }
            else
            {
                input_str += "0.";
                formula.Text = input_str;
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

            formula.Text = input_str.Remove(input_str.Length - 1);
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
                    input_str += "^";
                }
            }
            //階乗
            else if (btn.Name== "factorial")
            {
                if (fac)
                {
                    return;
                }
                else
                {
                    input_str += "!";
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
                    input_str += "％";
                }
            }
        }
        private void root_pi_nepiers(Button btn)
        {
            // これらは連続で打っても計算可  ->  √ は例外
            //根号
            if (btn.Name == "root")
            {
                input_str += "√";
            }
            //円周率
            else if (btn.Name == "pi")
            {
                input_str += "π";
            }
            //ネピア数
            else if (btn.Name == "napiers")
            {
                input_str += "e";
            }
        }

        // "="を "" マウスで "" 押したとき   ->  途中式は表示しない方針 = 途中で計算をしない
        //
        // このメソッドで全ての式を計算する -> 同時に履歴への追加も
        //
        //    ＋ ,   －,   ÷,   ×  ->   ＋－÷×
        //
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            //参照
            //https://www.codeproject.com/Articles/18880/State-of-the-Art-Expression-Evaluation
            //
            //不適切な式の場合
            NCalcLexer lexer = new NCalcLexer(new ANTLRStringStream("3*(5+2"));
            NCalcParser parser = new NCalcParser(new CommonTokenStream(lexer));

            //null
            try
            {
                parser.GetExpression();
                //Assert.Fail();
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Parser exception: " + exception.Message);
            }

            //DataTable.Compute
            //計算式
            string exp = "(8+96)*25";
            //式を計算する
            DataTable dt = new DataTable();
            try
            {
                double result = (double)dt.Compute(exp, "");
            } catch (InvalidCastException icex)
            {
                Console.WriteLine(icex);
                return;
            }
            

            Console.WriteLine(result);


            bool formula_dot = formula.Text.Contains(".");

            //Dotの検討中  
            if (formula_dot)
            {
                formula.Text = String.Format("{0:#,0.############################################################}", result);
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
            formula.Text = "";
            input_str = "";
            operation = "";
            num_list.Clear();
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
                                formula.Text = bs_text;
                                // input_str = bs_text; ここに入れる希ガス
                            }
                            else
                                //カンマ区切り付き
                                formula.Text = String.Format("{0:#,0.############################################################}", bs_text);
                        }
                        catch (FormatException ex)
                        {
                            formula.Text = bs_text;
                            Console.WriteLine(ex);
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
                    if (ctrl.Controls == History_form.Instance.Controls)
                    {
                        History_form.Instance.Enabled = true;
                        return;
                    }
                    ctrl.Enabled = use;
                }
            }

            //only History Form is Enable
            //History_form his_form = new History_form();
            //his_form.Enabled = true;
        }

        // 
        //   計算履歴
        //
        private void click_History(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Calculator_beta.csproj に変更加える必要有
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
