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
        //Display Console -> Delete soon
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Function_Calculator()
        {
            InitializeComponent();
            //output to Cmd -> Delete soon
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

        //input_str は 演算子記号が TextBox と同等 (＋－×÷)
        //DataTable では、+-*/ に変換する
        public string input_str = "";
        private string tab_name = "";

        private bool enzanshi = false;
        public bool eq = true;

        //演算子
        public string operation = "";

        //0から9の数字を "" マウスで "" 押したとき
        //カンマ区切り表現は廃止
        //Console.WriteLine(input_str); -> Delete soon
        private void click_Number(object sender, MouseEventArgs e)
        {
            enzanshi = false;
            bool dot_ = input_str.Contains(".");
            formula.ForeColor = Color.Black;

            Button btn = (Button)sender;
            string text = btn.Text;

            if (text == "0")//最初に0を押したとき
            {
                if (input_str.StartsWith("0"))
                {
                    formula.Text = input_str = text;
                }
                else
                {
                    if (Regex.IsMatch(input_str, @"[＋－×÷][0]"))
                        return;
                    else
                    {
                        input_str += text;
                        formula.Text = input_str;
                    }
                }
            }
            else if (text != "0")//0以外の数字押したとき
            {
                if (dot_)
                {
                    input_str += text;
                    formula.Text = input_str;
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
                        if (Regex.IsMatch(input_str, @"[＋－×÷]\d"))
                        {
                            input_str = input_str.TrimEnd('0');
                            input_str += text;
                            formula.Text = input_str;
                        }
                        else
                        {
                            input_str += text;
                            formula.Text = input_str;
                        }
                    }
                }
            }
            // -> Delete soon
            Console.WriteLine("入力 : " + input_str);
        }

        //四則演算を "" マウスで "" 押したとき  ＋－÷×
        private void click_ope(object sender, MouseEventArgs e)
        {
            eq = false;
            bool dot_ = input_str.Contains(".");
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;
            operation = btn.Text;

            // -> Delete soon
            Console.WriteLine("色々な処理をする前 : " + input_str);

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
                // -> Delete soon
                Console.WriteLine("演算子 Before : " + input_str);

                input_str += operation;

                // -> Delete soon
                Console.WriteLine("演算子 After : " + input_str);

                formula.Text = input_str;

                // -> Delete soon
                Console.WriteLine("計算式に代入後 : " + input_str);

                enzanshi = true;
            }
        }

        //Dot Click
        private void click_Dot(object sender, MouseEventArgs e)
        {
            bool dot_ = input_str.EndsWith(".");
            formula.ForeColor = Color.Black;
            if (input_str != "")
            {
                if (dot_)
                    return;
                else
                {
                    input_str += dot.Text;
                    formula.Text = input_str;
                }
            }
            else
            {
                formula.Text = input_str = "0.";
            }
        }

        //
        // Normal Type
        //
        private void click_Special(object sender, MouseEventArgs e)
        {
            eq = false;
            enzanshi = false;
            formula.ForeColor = Color.Black;
            Button btn = (Button)sender;

            //数字がないとエラーになる特殊文字
            //Designer.cs も変更しないと Name が反映されない
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
                    return;
                else
                    formula.Text = input_str += "^";
            }
            //階乗
            else if (btn.Name == "factorial")
            {
                if (fac)
                    return;
                else
                    formula.Text = input_str += "!";
            }
            //パーセント
            else if (btn.Name == "percent")
            {
                if (per)
                    return;
                else
                    formula.Text = input_str += "％";
            }
        }
        private void root_pi_nepiers(Button btn)
        {
            // これらは連続で打っても計算可  ->  √ は例外
            //根号
            if (btn.Name == "root")
            {
                formula.Text = input_str += "√";
                Console.WriteLine(" +Root : " + input_str);
            }
            //円周率
            else if (btn.Name == "pi")
            {
                formula.Text = input_str += "π";
            }
            //ネピア数
            else if (btn.Name == "napiers")
            {
                formula.Text = input_str += "e";
            }
        }


        // "="をマウスで押したとき
        // ＋－×÷
        // このメソッドで全ての式を計算する -> 同時に履歴への追加も
        private void click_Eq(object sender, MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;

            if (formula.Text == "")
            {
                return;
            }
            else if (formula.Text != "")
            {
                if (eq)
                {
                    eq = true;
                }
                else if (!eq)
                {
                    //×の省略等は不可　➞ 桁として認識される
                    string input_exp = formula.Text;

                    /*
                     * 三角関数や対数、円周率など、compute で扱うことのできない記号を数値に変換する
                     */
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

                    //冪乗
                    //BigInteger を使うと、全て数値で表示 (E＋は使われない)
                    while (input_exp.Contains("^"))
                    {
                        string first = "";
                        string second = "";
                        string power_cal = "";
                        double pow_result = 0;

                        //
                        //1桁 ^ 数桁(3桁まで)
                        // 1 ^ 1
                        var match_pow1_1 = Regex.Matches(pattern, @"^(\d{1})?[\^](\d{1})");
                        foreach (Match power_1to1 in match_pow1_1)
                        {
                            first = power_1to1.Value.Substring(0, 1);
                            second = power_1to1.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d");
                        foreach (Match power_1to1_ope in match_pow1_1_ope)
                        {
                            power_cal = power_1to1_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to1_ope.Value.Substring(1, 1);
                            second = power_1to1_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 1 ^ 11
                        var match_pow1_2 = Regex.Matches(pattern, @"^(\d{1})?[\^](\d{2})");
                        foreach (Match power_1to2 in match_pow1_2)
                        {
                            first = power_1to2.Value.Substring(0, 1);
                            second = power_1to2.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d");
                        foreach (Match power_1to2_ope in match_pow1_2_ope)
                        {
                            power_cal = power_1to2_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to2_ope.Value.Substring(1, 1);
                            second = power_1to2_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 1 ^ 111
                        var match_pow1_3 = Regex.Matches(pattern, @"^(\d{1})?[\^]^(\d{3})?");
                        foreach (Match power_1to3 in match_pow1_3)
                        {
                            first = power_1to3.Value.Substring(0, 1);
                            second = power_1to3.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d");
                        foreach (Match power_1to3_ope in match_pow1_3_ope)
                        {
                            power_cal = power_1to3_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to3_ope.Value.Substring(1, 1);
                            second = power_1to3_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        //
                        //2桁 ^ 数桁
                        // 11 ^ 1
                        var match_pow2_1 = Regex.Matches(pattern, @"^(\d{2})?[\^]^(\d{1})?");
                        foreach (Match power_2to1 in match_pow2_1)
                        {
                            first = power_2to1.Value.Substring(0, 2);
                            second = power_2to1.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d");
                        foreach (Match power_2to1_ope in match_pow2_1_ope)
                        {
                            power_cal = power_2to1_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to1_ope.Value.Substring(1, 2);
                            second = power_2to1_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 11 ^ 11
                        var match_pow2_2 = Regex.Matches(pattern, @"^(\d{2})?[\^]^(\d{2})?");
                        foreach (Match power_2to2 in match_pow2_2)
                        {
                            first = power_2to2.Value.Substring(0, 2);
                            second = power_2to2.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d\d");
                        foreach (Match power_2to2_ope in match_pow2_2_ope)
                        {
                            power_cal = power_2to2_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to2_ope.Value.Substring(1, 2);
                            second = power_2to2_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 11 ^ 111
                        var match_pow2_3 = Regex.Matches(pattern, @"^(\d{2})?[\^]^(\d{3})?");
                        foreach (Match power_2to3 in match_pow2_3)
                        {
                            first = power_2to3.Value.Substring(0, 2);
                            second = power_2to3.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d\d\d");
                        foreach (Match power_2to3_ope in match_pow2_3_ope)
                        {
                            power_cal = power_2to3_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to3_ope.Value.Substring(1, 2);
                            second = power_2to3_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        //
                        //3桁 ^ 数桁
                        // 111 ^ 1
                        var match_pow3_1 = Regex.Matches(pattern, @"\d\d\d[\^]\d");
                        foreach (Match power_3to1 in match_pow3_1)
                        {
                            first = power_3to1.Value.Substring(0, 3);
                            second = power_3to1.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 111 ^ 11
                        var match_pow3_2 = Regex.Matches(pattern, @"\d\d\d[\^]\d\d");
                        foreach (Match power_3to2 in match_pow3_2)
                        {
                            first = power_3to2.Value.Substring(0, 3);
                            second = power_3to2.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        // 111 ^ 111
                        var match_pow3_3 = Regex.Matches(pattern, @"\d\d\d[\^]\d\d\d");
                        foreach (Match power_3to3 in match_pow3_3)
                        {
                            first = power_3to3.Value.Substring(0, 3);
                            second = power_3to3.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }

                        break;
                    }

                    //根号
                    while (input_exp.Contains("√"))
                    {
                        break;
                    }

                    //計算用に変換 + 履歴に追加
                    try
                    {
                        //計算用の記号に変換
                        while (Regex.IsMatch(input_exp, "[＋－×÷]", RegexOptions.Compiled))
                        {
                            input_exp = input_exp.Replace("＋", "+");
                            input_exp = input_exp.Replace("－", "-");
                            input_exp = input_exp.Replace("×", "*");
                            input_exp = input_exp.Replace("÷", "/");
                            break;
                        }

                        //計算
                        DataTable dt = new DataTable();

                        //Debug
                        Console.WriteLine("計算式 Compute用 : " + input_exp);

                        var result = dt.Compute(input_exp, "");
                        Console.WriteLine("結果 : " + result);
                        formula.Text = result.ToString();

                        //履歴に追加
                        History_form.Instance.ListAddItem(input_str, result.ToString());
                        input_str = "";

                    }
                    //ゼロ除算
                    catch (DivideByZeroException dbzex)
                    {
                        Error("Cant't Calculate");
                        Console.WriteLine(dbzex);
                    }
                    catch (OverflowException overflow)
                    {
                        Error("Value too large");
                        Console.WriteLine(overflow);
                    }
                    catch (SyntaxErrorException syntaxerror)
                    {
                        eq = false;
                        Console.WriteLine(syntaxerror);
                    }
                    //can't Cast (for Debug)
                    catch (InvalidCastException icex)
                    {
                        Console.WriteLine(icex);
                    }
                }
            }
        }

        //All Clearを "" マウスで "" 押したとき
        private void click_AC(object sender, MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            //初期化
            formula.Text = "";
            input_str = "";
            operation = "";
        }

        //Back Spaceを "" マウスで "" 押したとき
        private void click_BS(object sender, MouseEventArgs e)
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
                                    formula.Text = input_str;
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


        /*
         *  変数メソッド
         */
        //階乗 num!
        private static double factr(double num)
        {
            if (num <= 1)
                return 1;
            else return num * factr(num - 1);
        }

        //Error
        public void Error(string error)
        {
            formula.ForeColor = Color.DarkRed;
            //エラーの表示
            formula.Text = "\n" + error;

            button_Enable(false);
            input_str = "";
            operation = "";
        }

        //ボタンの無効化
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

            Control[] history_ctr = this.Controls.Find("History", true);
            if (history_ctr.Length > 0)
            {
                ((Button)history_ctr[0]).Enabled = true;
            }
        }

        //計算履歴
        private void click_History(object sender, MouseEventArgs e)
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
