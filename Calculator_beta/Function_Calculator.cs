using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data;
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


        // "="をマウスで押したとき
        // ＋－×÷
        // このメソッドで全ての式を計算する -> 同時に履歴への追加も
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            //入力された計算式
            //×の省略は不可　➞ 桁として認識される
            //string input_exp = formula.Text;
            string input_exp = "5^9";

            /*
             * 三角関数や対数、円周率など、compute で扱うことのできない記号を数値に変換する
             */

            //据え置き
            //π 三角関数と共に使う場合は、そちらを優先
            while (input_exp.Contains("π"))
            {
                //三角関数の中に含まれているかも重要か？
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

            //階乗
            var pattern = input_exp;
            while (input_exp.Contains("!"))
            {
                //計算用の数値
                string fact_cal = "";
                //階乗した結果
                double factr_resu = 0;

                //演算子の抽出
                //1桁
                var match_1 = Regex.Matches(pattern, @"^(\d{1})?[!]");
                foreach (Match match_factr1 in match_1)
                {
                    //match_factr1 -> 抽出した文字
                    fact_cal = match_factr1.ToString().TrimEnd('!');
                    factr_resu = factr(double.Parse(fact_cal));
                    pattern = pattern.Replace(match_factr1.ToString(), factr_resu.ToString());
                    input_exp = pattern;
                    //Reset
                    fact_cal = "";
                }
                //演算子有
                var match_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d[!]");
                foreach (Match match_factr1_ope in match_1_ope)
                {
                    fact_cal = match_factr1_ope.Value.Trim('＋', '－', '×', '÷', '!');
                    factr_resu = factr(double.Parse(fact_cal));
                    pattern = pattern.Replace(match_factr1_ope.Value.Trim('＋', '－', '×', '÷'), factr_resu.ToString());
                    input_exp = pattern;
                    fact_cal = "";
                }

                //2桁
                var match_2 = Regex.Matches(pattern, @"^(\d{2})?[!]");
                foreach (Match match_factr2 in match_2)
                {
                    fact_cal = match_factr2.ToString().TrimEnd('!');
                    factr_resu = factr(double.Parse(fact_cal));
                    pattern = pattern.Replace(match_factr2.ToString(), factr_resu.ToString());
                    input_exp = pattern;
                    fact_cal = "";
                }
                //演算子有
                var match_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[!]");
                foreach (Match match_factr2_ope in match_2_ope)
                {
                    fact_cal = match_factr2_ope.ToString().Trim('＋', '－', '×', '÷', '!');
                    factr_resu = factr(double.Parse(fact_cal));
                    pattern = pattern.Replace(match_factr2_ope.Value.Trim('＋', '－', '×', '÷'), factr_resu.ToString());
                    input_exp = pattern;
                    fact_cal = "";
                }

                //3桁 (演算子も含む)
                var match_3 = Regex.Matches(pattern, @"\d\d\d[!]");
                foreach (Match match_factr3 in match_3)
                {
                    fact_cal = match_factr3.ToString().Trim('＋', '－', '×', '÷', '!');

                    //170! まで計算可能
                    if (double.Parse(fact_cal) > 170)
                    {
                        Error("Value too large");
                        return;
                    }
                    else
                    {
                        factr_resu = factr(double.Parse(fact_cal));
                        pattern = pattern.Replace(match_factr3.Value.Trim('＋', '－', '×', '÷'), factr_resu.ToString());
                    }
                    input_exp = pattern;
                    fact_cal = "";
                }
                break;
            }

            //
            //冪乗
            //BigInteger を使うと、全て数値で表示 (E＋は使われない)
            double power_resu = Math.Pow(9, 5);
            Console.WriteLine("冪乗 Math.Pow のテスト : " + power_resu);

            while (input_exp.Contains("^"))
            {
                //1桁 ^ 数桁(3桁まで)
                // 1 ^ 1
                var match_pow1_1 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{1})?");
                foreach (Match power_1to1 in match_pow1_1)
                {
                    string first = power_1to1.Value.Substring(0, 1);
                    Console.WriteLine(first);
                    break;
                }
                // 1 ^ 11
                var match_pow1_2 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_1to2 in match_pow1_2)
                {

                    break;
                }
                // 1 ^ 111
                var match_pow1_3 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_1to3 in match_pow1_3)
                {

                    break;
                }

                //2桁 ^ 数桁
                // 1 ^ 1
                var match_pow2_1 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{1})?");
                foreach (Match power_2to1 in match_pow2_1)
                {

                    break;
                }
                // 1 ^ 11
                var match_pow2_2 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_2to2 in match_pow2_2)
                {

                    break;
                }
                // 1 ^ 111
                var match_pow2_3 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_2to3 in match_pow2_3)
                {

                    break;
                }

                //2桁 ^ 数桁
                // 1 ^ 1
                var match_pow3_1 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{1})?");
                foreach (Match power_3to1 in match_pow3_1)
                {

                    break;
                }
                // 1 ^ 11
                var match_pow3_2 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_3to2 in match_pow3_2)
                {

                    break;
                }
                // 1 ^ 111
                var match_pow3_3 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{2})?");
                foreach (Math power_3to3 in match_pow3_3)
                {

                    break;
                }

                // メッセージ・キューにあるWindowsメッセージをすべて処理する
                //Windows Form がフリーズするのを回避
                Application.DoEvents();
            }

            this.Enabled = true;

            string exp = input_exp;
            try
            {
                //計算用の記号に変換
                while (Regex.IsMatch(input_exp, "[＋－×÷]", RegexOptions.Compiled))
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
                Console.WriteLine("結果" + result);
                formula.Text = result.ToString();

                //記号表現に変換
                exp = exp.Replace(Math.PI.ToString(), "π");
                exp = exp.Replace(Math.E.ToString(), "e");
                exp = exp.Replace("*0.01", "%");
                //履歴に追加
                History_form.Instance.ListAddItem(exp, result.ToString());

            }
            catch (OverflowException overflow)
            {
                Error("Over flow");
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

        /*
         * 特定のキーを押したときに、ボタンを押したときと同様の動作をする
         */
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
        private static double factr(double num)
        {
            if (num <= 1)
                return 1;
            else return num * factr(num - 1);
        }

        //
        //   基本的なエラー
        //

        //Error
        public void Error(string error)
        {
            operation = "";
            formula.ForeColor = Color.DarkRed;
            //エラーの表示
            formula.Text += "\n" + error;

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
                        ctrl.Enabled = true;
                        Console.WriteLine("History form button is now enable. ");
                    }
                    ctrl.Enabled = use;
                }
            }
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
