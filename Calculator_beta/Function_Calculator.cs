using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator_beta
{
    public partial class Function_Calculator : Form
    {
        //Display Console
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
        //input_str は 演算子記号が TextBox と同等 (＋－×÷)
        //DataTable では、+-*/ に変換する
        public string input_str = "";
        private string tab_name = "";

        //Bool
        private bool enzanshi = false;
        public bool eq = false;

        //演算子
        public string operation = "";

        //0から9の数字を "" マウスで "" 押したとき
        //カンマ区切り表現は廃止
        private void click_Number(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool dot_ = input_str.Contains(".");
            formula.ForeColor = Color.Black;
            enzanshi = false;

            Button btn = (Button)sender;
            string text = btn.Text;

            //input_str = "";
            {
                if (text == "0")//最初に0押したとき
                {
                    input_str += text;
                    formula.Text += input_str;

                    Console.WriteLine(input_str);
                }
                else if (text != "0")//0以外の数字押したとき
                {
                    if (dot_)
                    {
                        if (input_str.StartsWith("0."))
                        {
                            input_str += text;
                            formula.Text += input_str;
                        }
                        else
                        {
                            input_str += text;
                            formula.Text += input_str;
                        }
                    }
                    else if (!dot_)
                    {
                        if (input_str.StartsWith("0"))
                        {
                            input_str = text;
                            formula.Text = input_str;
                        }
                        else
                        {
                            if (Regex.IsMatch(input_str, "[＋－×÷]"))
                            {
                                input_str += text;
                                formula.Text += text;
                                Console.WriteLine(" ^ q ^  : GG");
                            }
                            else
                            {
                                input_str += text;
                                formula.Text += input_str;
                            }
                        }
                    }
                }
            }
        }

        //四則演算を "" マウスで "" 押したとき  ＋－÷×
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool dot_ = input_str.Contains(".");
            eq = false;
            input_str = "";
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            if (enzanshi)//演算子ボタンが連続で押されたときに置換
            {
                try
                {
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
            else
            {
                input_str += operation;
                formula.Text += operation;
                enzanshi = true;
            }
        }

        //Dot Click
        // 若干の修正必要
        private void click_Dot(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool dot_ = input_str.Contains(".");
            eq = false;
            formula.ForeColor = Color.Black;
            if (input_str != "")
            {
                if (dot_)
                {
                    return;
                }
                else if (!dot_)
                {
                    input_str += dot.Text;
                    formula.Text += ".";
                }
            }
            else
            {
                input_str = "0.";
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
            enzanshi = false;
            Button btn = (Button)sender;

            //数字がないとエラーになる特殊文字
            if (formula.Text != "")
            {
                power_fac_per(btn);
                root_pi_nepiers(btn);

                formula.Text = input_str;
            }
            else if (formula.Text == "")
            {
                root_pi_nepiers(btn);
                formula.Text = input_str;
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
                    input_str += "^";
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

        

        // "="を "" マウスで "" 押したとき
        // ＋－×÷
        // このメソッドで全ての式を計算する -> 同時に履歴への追加も
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            //入力された計算式
            //×の省略は不可
            //string input_exp = formula.Text;
            string input_exp = "548!×4!－98!＋31!÷587!";

            /*
             * 三角関数や対数、円周率など、compute で扱うことのできない記号を数値に変換する
             */

            //据え置き
            //π 三角関数と共に使う場合は、そちらを優先
            while (input_exp.Contains("π"))
            {
                input_exp = input_exp.Replace("π", Math.PI.ToString());
                break;
            }

            //e ネピア数
            while (input_exp.Contains("e"))
            {
                input_exp = input_exp.Replace("e", Math.E.ToString());
                break;
            }

            // % (剰余を求めるものではない ≠ mod)
            while (input_exp.Contains("%"))
            {
                input_exp = input_exp.Replace("%", "*0.01");
                break;
            }

            //Regex.IsMatch(input_str, "[＋－×÷]"))
            //Regex "[!]"

            //階乗
            //正規表現用の式
            var pattern = input_exp;
            while (input_exp.Contains("!"))
            {

                //間の文字を抽出
                //正規表現を使ってパターン化した文字列を抽出

                //1桁
                var match_1 = Regex.Matches(pattern, @"\W\d[!]");
                foreach (Match match_factr1 in match_1)
                {
                    Console.WriteLine("正規表現 1 : " + match_factr1.Value);
                }
                //演算子有
                var match_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d[!]");
                foreach (Match match_factr1_ope in match_1_ope)
                {
                    Console.WriteLine("正規表現 1 a: " + match_factr1_ope.Value);
                }

                //2桁
                var match_2 = Regex.Matches(pattern, @"\W\d\d[!]");
                foreach (Match match_factr2 in match_2)
                {
                    Console.WriteLine("正規表現 2 : " + match_factr2.Value);
                }
                //演算子有
                var match_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[!]");
                foreach (Match match_factr2_ope in match_2_ope)
                {
                    Console.WriteLine("正規表現 2 a : " + match_factr2_ope.Value);
                }

                //3桁
                var match_3 = Regex.Matches(pattern, @"\W\d\d\d[!]");
                foreach (Match match_factr3 in match_3)
                {
                    Console.WriteLine("正規表現 3 : " + match_factr3.Value);
                }
                //演算子有
                var match_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[!]");
                foreach (Match match_factr3_ope in match_3_ope)
                {
                    Console.WriteLine("正規表現 3 a : " + match_factr3_ope.Value);
                }


                //正規表現の例
                var str = "ABC123DEF456GHI";
                var match_ = Regex.Match(str, @"[A-Za-z][0-9]");
                Console.WriteLine("Test : " + match_.Value);

                var str_ = "ABC123DEF456GHI";
                var matchs = Regex.Matches(str, @"\d");
                //一致した文字列の表示
                foreach (Match match__ in matchs)
                {
                    Console.WriteLine("数値 : " + match__.Value);
                }

                break;
            }

            string exp = input_exp;
            try
            {
                //計算用の記号に変換する
                while (Regex.IsMatch(input_exp, "[＋－×÷]"))
                {
                    exp = exp.Replace("＋", "+");
                    exp = exp.Replace("－", "-");
                    exp = exp.Replace("×", "*");
                    exp = exp.Replace("÷", "/");
                    break;
                }

                //計算
                DataTable dt = new DataTable();
                //Debug
                Console.WriteLine("計算式" + input_exp);
                Console.WriteLine("計算式 Compute用" + exp);

                var result = dt.Compute(exp, "");

                Console.WriteLine(result);
                //記号表現に変換
                exp = exp.Replace(Math.PI.ToString(), "π");
                exp = exp.Replace(Math.E.ToString(), "e");
                exp = exp.Replace("*0.01", "%");
                //履歴に追加
                History_form.Instance.ListAddItem(exp, result.ToString());

            }
            catch (OverflowException overflow)
            {
                OverFlow();
                Console.WriteLine(overflow);
            }
            catch (SyntaxErrorException syntaxerror)
            {
                Console.WriteLine(syntaxerror);
            }
            //can't Cast (for Debug)
            catch (InvalidCastException icex)
            {
                Console.WriteLine(icex);
            }
            //ゼロ除算
            catch (DivideByZeroException dbzex)
            {
                Console.WriteLine(dbzex);
            }


            bool formula_dot = formula.Text.Contains(".");

            //Dotの検討中  
            if (formula_dot)
            {
                formula.Text = String.Format("{0:#,0.############################################################}", input_str);
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
                    //Code Here
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
                    string bs_text = input_str.Remove(input_str.Length - 1);
                    if (bs_text.Length >= 0)
                    {
                        try // 小数点有りでエラー
                        {
                            //
                            if (bs_text.Length == 0)
                            {
                                formula.Text = input_str = bs_text;
                            }
                            else
                            {
                                //数字の末尾がドットかどうか
                                bool dot_end = bs_text.EndsWith(".");
                                if (dot_end)
                                {
                                    formula.Text = input_str = bs_text;
                                    Console.WriteLine("^q^" + input_str);
                                    formula.Text += ".";
                                }
                                else if (!dot_end)
                                {
                                    formula.Text = input_str = bs_text;
                                }
                            }
                        }
                        catch (FormatException ex)
                        {
                            formula.Text = bs_text;
                            Console.WriteLine(ex);
                        }
                    }

                }
                catch (ArgumentOutOfRangeException argumentoutofrange)
                {
                    Console.WriteLine(argumentoutofrange);
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
                //四則演算
            }
            else if (tab_name == "Other Symbols")
            {
                //関数
            }
        }
        private void Tab_Changed(object sender, TabControlEventArgs e)
        {
            //現在のTabがどれかを取得する
            tab_name = e.TabPage.Text;
        }

        //null
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
        //計算Method
        //
        //階乗 num!
        private static int factr(int num)
        {
            if (num <= 1)
                return 1;
            else return num * factr(num - 1);
        }

        //
        //   基本的なエラー
        //
        //Format error
        public void Format_Error()
        {
            operation = "";
            formula.ForeColor = Color.DarkRed;
            formula.Text = "Format error!";

            button_Enable(false);
            input_str = "";
        }
        //Over Flow
        public void OverFlow()
        {
            operation = "";
            formula.ForeColor = Color.DarkRed;
            formula.Text = "Over Flow!";

            button_Enable(false);
            input_str = "";
        }
        //ボタンの無効化
        private void button_Enable(bool use)
        {
            Control.ControlCollection controls = Controls;
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button)
                {
                    if (ctrl.Controls == History_form.Instance.Controls)
                    {
                        return;
                    }
                    ctrl.Enabled = use;
                }
            }
            History_form.Instance.Enabled = true;
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
