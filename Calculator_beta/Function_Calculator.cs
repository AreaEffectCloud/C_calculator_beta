using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace Calculator_beta
{
    public partial class Calculator : Form
    {
        //キー入力
        [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.Demand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //Enter
            if ((keyData & Keys.KeyCode) == Keys.Enter)
            {
                click_Eq("", null);
            }
            //Escape
            else if ((keyData & Keys.KeyCode) == Keys.Escape)
            {
                click_AC("", null);
            }
            //BackSpace
            else if ((keyData & Keys.KeyCode) == Keys.Back)
            {
                click_BS("", null);
            }
            //Dot
            else if ((keyData & Keys.KeyCode) == Keys.OemPeriod || (keyData & Keys.KeyCode) == Keys.Decimal)
            {
                click_Dot("", null);
            }

            //数字
            //0
            else if (((keyData & Keys.KeyCode) == Keys.NumPad0) || ((keyData & Keys.KeyCode) == Keys.D0))
            {
                click_Number(zero, null);
            }

            //1
            else if (((keyData & Keys.KeyCode) == Keys.NumPad1) || ((keyData & Keys.KeyCode) == Keys.D1))
            {
                click_Number(one, null);
            }

            //2
            else if (((keyData & Keys.KeyCode) == Keys.NumPad2) || ((keyData & Keys.KeyCode) == Keys.D2))
            {
                click_Number(two, null);
            }

            //3
            else if (((keyData & Keys.KeyCode) == Keys.NumPad3) || ((keyData & Keys.KeyCode) == Keys.D3))
            {
                click_Number(three, null);
            }

            //4
            else if (((keyData & Keys.KeyCode) == Keys.NumPad4) || ((keyData & Keys.KeyCode) == Keys.D4))
            {
                click_Number(four, null);
            }

            //5
            else if (((keyData & Keys.KeyCode) == Keys.NumPad5) || ((keyData & Keys.KeyCode) == Keys.D7))
            {
                click_Number(five, null);
            }

            //6
            else if (((keyData & Keys.KeyCode) == Keys.NumPad6) || ((keyData & Keys.KeyCode) == Keys.D6))
            {
                click_Number(six, null);
            }

            //7
            else if (((keyData & Keys.KeyCode) == Keys.NumPad7) || ((keyData & Keys.KeyCode) == Keys.D7))
            {
                click_Number(seven, null);
            }

            //8
            else if (((keyData & Keys.KeyCode) == Keys.NumPad8) || ((keyData & Keys.KeyCode) == Keys.D8))
            {
                click_Number(eight, null);
            }

            //9
            else if (((keyData & Keys.KeyCode) == Keys.NumPad9) || ((keyData & Keys.KeyCode) == Keys.D9))
            {
                click_Number(nine, null);
            }

            //演算子
            //＋
            else if ((keyData & Keys.KeyCode) == Keys.Add)
            {
                click_ope(plus, null);
            }

            //－
            else if (((keyData & Keys.KeyCode) == Keys.Subtract) || ((keyData & Keys.KeyCode) == Keys.OemBackslash))
            {
                click_ope(minus, null);
            }

            //×            
            else if ((keyData & Keys.KeyCode) == Keys.Multiply)
            {
                click_ope(multi, null);
            }

            //÷
            else if (((keyData & Keys.KeyCode) == Keys.Divide) || ((keyData & Keys.KeyCode) == Keys.OemQuestion))
            {
                click_ope(divide, null);
            }

            //その他記号
            //π PI
            else if ((keyData & Keys.KeyCode) == Keys.P)
            {
                click_Special(pi, null);
            }

            //e Napier
            else if ((keyData & Keys.KeyCode) == Keys.E)
            {
                click_Special(napiers, null);
            }

            //√ Root
            else if ((keyData & Keys.KeyCode) == Keys.R)
            {
                click_Special(root, null);
            }

            //^  Caret    
            else if ((keyData & Keys.KeyCode) == Keys.C)
            {
                click_Special(power_multiplier, null);
            }

            //%
            else if ((keyData & Keys.KeyCode) == Keys.T)
            {
                click_Special(percent, null);
            }

            //!
            else if ((keyData & Keys.KeyCode) == Keys.F)
            {
                click_Special(factorial, null);
            }

            return base.ProcessDialogKey(keyData);
        }

        public Calculator()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //最大サイズ、最小サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
        }

        //input_str は 演算子記号が TextBox と同等 (＋－×÷)
        //DataTable では、+-*/ に変換する
        public string input_str = "";

        private bool enzanshi = false;
        public bool eq = true;

        //演算子
        public string operation = "";

        //0から9の数字を "" マウスで "" 押したとき
        private void click_Number(object sender, MouseEventArgs e)
        {
            enzanshi = false;
            bool dot_ = input_str.Contains(".");
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;

            Button btn = (Button)sender;
            string text = btn.Text;

            if (text == "0")
            {
                //0で始まるとき
                if (input_str.StartsWith("0"))
                {
                    //第一項
                    //小数点有
                    if (dot_)
                    {
                        input_str += text;
                        formula.Text = input_str;
                    }
                    //整数
                    else
                        formula.Text = input_str = text;
                }
                //other
                else
                {
                    //第二項以降が0で始まるとき
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
                        if (Regex.IsMatch(input_str, @"[＋－×÷][0]"))
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
        }

        //四則演算を "" マウスで "" 押したとき  ＋－÷×
        private void click_ope(object sender, MouseEventArgs e)
        {
            eq = false;
            bool dot_ = input_str.Contains(".");
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;
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
                catch (NullReferenceException)
                {
                    return;
                }
            }
            else
            {
                input_str += operation;
                formula.Text = input_str;
                enzanshi = true;
            }
        }

        //Dot Click
        private void click_Dot(object sender, MouseEventArgs e)
        {
            bool dot_ = input_str.EndsWith(".");
            bool dot_contains = input_str.Contains(".");
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;

            //Dotを数字の間に挟めば一項に複数入力が可能 -> 仕様
            //Format error になるので、関係ない
            if (input_str != "")
            {
                ////Dotが含まれるかどうか
                if (dot_contains)
                {
                    if (dot_)
                        return;
                }
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

        //特殊文字の入力
        private void click_Special(object sender, MouseEventArgs e)
        {
            eq = false;
            enzanshi = false;
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;
            Button btn = (Button)sender;

            if (input_str != "")
            {
                power_fac_per(btn);
                root_pi_napiers(btn);
            }
            else if (input_str == "")
            {
                root_pi_napiers(btn);
            }
        }

        private void power_fac_per(Button btn)
        {
            //連続した入力は不可
            bool power = formula.Text.EndsWith("^");
            bool fac = formula.Text.EndsWith("!");
            bool per = formula.Text.EndsWith("％");

            //冪乗
            if (btn.Name == "power_multiplier")
            {
                if (power)
                    return;
                else
                {
                    input_str += "^";
                    formula.Text = input_str;
                }
            }
            //階乗
            else if (btn.Name == "factorial")
            {
                if (fac)
                    return;
                else
                {
                    input_str += "!";
                    formula.Text = input_str;
                }
            }
            //パーセント
            else if (btn.Name == "percent")
            {
                if (per)
                    return;
                else
                {
                    input_str += "％";
                    formula.Text = input_str;
                }
            }
        }
        private void root_pi_napiers(Button btn)
        {
            //連続した入力は不可
            bool root = formula.Text.EndsWith("√");
            bool pi = formula.Text.EndsWith("π");
            bool napiers = formula.Text.EndsWith("e");

            //根号
            if (btn.Name == "root")
            {
                if (root)
                    return;
                else
                {
                    input_str += "√";
                    formula.Text = input_str;
                }
            }
            //円周率
            else if (btn.Name == "pi")
            {
                if (pi)
                    return;
                else
                {
                    input_str += "π";
                    formula.Text = input_str;
                }
            }
            //ネピア数
            else if (btn.Name == "napiers")
            {
                if (napiers)
                    return;
                else
                {
                    input_str += "e";
                    formula.Text = input_str;
                }
            }
        }

        // "="をマウスで押したとき
        // このメソッドで全ての式を計算する -> 同時に履歴への追加も
        private void click_Eq(object sender, MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;

            if (input_str == "")
            {
                return;
            }
            else if (input_str != "")
            {
                if (eq)
                {
                    eq = true;
                }
                else if (!eq)
                {
                    //×の省略等は不可　➞ 桁として認識される
                    string input_exp = formula.Text;

                    //π
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
                    while (input_exp.Contains("％"))
                    {
                        input_exp = input_exp.Replace("％", "*0.01");
                        break;
                    }

                    //階乗
                    var pattern = input_exp;
                    //計算式
                    string fact_formula = "";
                    //計算用の数値
                    string fact_cal = "";
                    //階乗した結果
                    double factr_resu = 0;
                    while (input_exp.Contains("!"))
                    {
                        //演算子の抽出
                        //1桁
                        var match_1 = Regex.Matches(pattern, @"^(\d{1})?[!]");
                        foreach (Match match_factr1 in match_1)
                        {
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
                    while (input_exp.Contains("^"))
                    {
                        string first = "";
                        string second = "";
                        string power_cal = "";
                        double pow_result = 0;

                        //
                        //1桁 ^ 数桁(3桁まで)
                        // 1 ^ 1
                        var match_pow1_1 = Regex.Matches(pattern, @"^(\d{1})?[\^](\d{1})$");
                        foreach (Match power_1to1 in match_pow1_1)
                        {
                            first = power_1to1.Value.Substring(0, 1);
                            second = power_1to1.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^](\d{1})$");
                        foreach (Match power_1to1_ope in match_pow1_1_ope)
                        {
                            power_cal = power_1to1_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to1_ope.Value.Substring(1, 1);
                            second = power_1to1_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow1_1_ope_back = Regex.Matches(pattern, @"^(\d{1})[\^]\d[＋－×÷]");
                        foreach (Match power_1to1_ope_back in match_pow1_1_ope_back)
                        {
                            power_cal = power_1to1_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to1_ope_back.Value.Substring(0, 1);
                            second = power_1to1_ope_back.Value.Substring(2, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow1_1_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d[＋－×÷]");
                        foreach (Match power_1to1_ope_both in match_pow1_1_ope_both)
                        {
                            power_cal = power_1to1_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to1_ope_both.Value.Substring(1, 1);
                            second = power_1to1_ope_both.Value.Substring(3, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 1 ^ 11
                        var match_pow1_2 = Regex.Matches(pattern, @"^(\d{1})?[\^](\d{2})$");
                        foreach (Match power_1to2 in match_pow1_2)
                        {
                            first = power_1to2.Value.Substring(0, 1);
                            second = power_1to2.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^](\d{2})$");
                        foreach (Match power_1to2_ope in match_pow1_2_ope)
                        {
                            power_cal = power_1to2_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to2_ope.Value.Substring(1, 1);
                            second = power_1to2_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow1_2_ope_back = Regex.Matches(pattern, @"^(\d{1})[\^]\d\d[＋－×÷]");
                        foreach (Match power_1to2_ope_back in match_pow1_2_ope_back)
                        {
                            power_cal = power_1to2_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to2_ope_back.Value.Substring(0, 1);
                            second = power_1to2_ope_back.Value.Substring(2, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow1_2_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d\d[＋－×÷]");
                        foreach (Match power_1to2_ope_both in match_pow1_2_ope_both)
                        {
                            power_cal = power_1to2_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to2_ope_both.Value.Substring(1, 1);
                            second = power_1to2_ope_both.Value.Substring(3, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 1 ^ 111
                        var match_pow1_3 = Regex.Matches(pattern, @"^(\d{1})?[\^](\d{3})$");
                        foreach (Match power_1to3 in match_pow1_3)
                        {
                            first = power_1to3.Value.Substring(0, 1);
                            second = power_1to3.Value.Substring(2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_1to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow1_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d[\^](\d{3})$");
                        foreach (Match power_1to3_ope in match_pow1_3_ope)
                        {
                            power_cal = power_1to3_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to3_ope.Value.Substring(1, 1);
                            second = power_1to3_ope.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow1_3_ope_back = Regex.Matches(pattern, @"^(\d{1})[\^]\d\d\d[＋－×÷]");
                        foreach (Match power_1to3_ope_back in match_pow1_3_ope_back)
                        {
                            power_cal = power_1to3_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to3_ope_back.Value.Substring(0, 1);
                            second = power_1to3_ope_back.Value.Substring(2, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow1_3_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d[\^]\d\d\d[＋－×÷]");
                        foreach (Match power_1to3_ope_both in match_pow1_3_ope_both)
                        {
                            power_cal = power_1to3_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_1to3_ope_both.Value.Substring(1, 1);
                            second = power_1to3_ope_both.Value.Substring(3, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        //
                        //2桁 ^ 数桁
                        // 11 ^ 1
                        var match_pow2_1 = Regex.Matches(pattern, @"^(\d{2})?[\^](\d{1})$");
                        foreach (Match power_2to1 in match_pow2_1)
                        {
                            first = power_2to1.Value.Substring(0, 2);
                            second = power_2to1.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^](\d{1})$");
                        foreach (Match power_2to1_ope in match_pow2_1_ope)
                        {
                            power_cal = power_2to1_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to1_ope.Value.Substring(1, 2);
                            second = power_2to1_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow2_1_ope_back = Regex.Matches(pattern, @"^(\d{2})[\^]\d[＋－×÷]");
                        foreach (Match power_2to1_ope_back in match_pow2_1_ope_back)
                        {
                            power_cal = power_2to1_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to1_ope_back.Value.Substring(0, 2);
                            second = power_2to1_ope_back.Value.Substring(3, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow2_1_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d[＋－×÷]");
                        foreach (Match power_2to1_ope_both in match_pow2_1_ope_both)
                        {
                            power_cal = power_2to1_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to1_ope_both.Value.Substring(1, 2);
                            second = power_2to1_ope_both.Value.Substring(4, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 11 ^ 11
                        var match_pow2_2 = Regex.Matches(pattern, @"^(\d{2})?[\^](\d{2})$");
                        foreach (Match power_2to2 in match_pow2_2)
                        {
                            first = power_2to2.Value.Substring(0, 2);
                            second = power_2to2.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^](\d{2})$");
                        foreach (Match power_2to2_ope in match_pow2_2_ope)
                        {
                            power_cal = power_2to2_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to2_ope.Value.Substring(1, 2);
                            second = power_2to2_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow2_2_ope_back = Regex.Matches(pattern, @"^(\d{2})[\^]\d\d[＋－×÷]");
                        foreach (Match power_2to2_ope_back in match_pow2_2_ope_back)
                        {
                            power_cal = power_2to2_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to2_ope_back.Value.Substring(0, 2);
                            second = power_2to2_ope_back.Value.Substring(3, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow2_2_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d\d[＋－×÷]");
                        foreach (Match power_2to2_ope_both in match_pow2_2_ope_both)
                        {
                            power_cal = power_2to2_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to2_ope_both.Value.Substring(1, 2);
                            second = power_2to2_ope_both.Value.Substring(4, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        
                        // 11 ^ 111
                        var match_pow2_3 = Regex.Matches(pattern, @"^(\d{2})?[\^](\d{3})$");
                        foreach (Match power_2to3 in match_pow2_3)
                        {
                            first = power_2to3.Value.Substring(0, 2);
                            second = power_2to3.Value.Substring(3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_2to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow2_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^](\d{3})$");
                        foreach (Match power_2to3_ope in match_pow2_3_ope)
                        {
                            power_cal = power_2to3_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to3_ope.Value.Substring(1, 2);
                            second = power_2to3_ope.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow2_3_ope_back = Regex.Matches(pattern, @"^(\d{2})?[\^](\d{3})[＋－×÷]");
                        foreach (Match power_2to3_ope_back in match_pow2_3_ope_back)
                        {
                            power_cal = power_2to3_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to3_ope_back.Value.Substring(0, 2);
                            second = power_2to3_ope_back.Value.Substring(3, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow2_3_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d[\^]\d\d\d[＋－×÷]");
                        foreach (Match power_2to3_ope_both in match_pow2_3_ope_both)
                        {
                            power_cal = power_2to3_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_2to3_ope_both.Value.Substring(1, 2);
                            second = power_2to3_ope_both.Value.Substring(5, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        //
                        //3桁 ^ 数桁
                        // 111 ^ 1
                        var match_pow3_1 = Regex.Matches(pattern, @"^(\d{3})?[\^](\d{1})$");
                        foreach (Match power_3to1 in match_pow3_1)
                        {
                            first = power_3to1.Value.Substring(0, 3);
                            second = power_3to1.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to1.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow3_1_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^](\d{1})$");
                        foreach (Match power_3to1_ope in match_pow3_1_ope)
                        {
                            power_cal = power_3to1_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to1_ope.Value.Substring(1, 3);
                            second = power_3to1_ope.Value.Substring(5, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow3_1_ope_back = Regex.Matches(pattern, @"^(\d{3})[\^]\d[＋－×÷]");
                        foreach (Match power_3to1_ope_back in match_pow3_1_ope_back)
                        {
                            power_cal = power_3to1_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to1_ope_back.Value.Substring(0, 3);
                            second = power_3to1_ope_back.Value.Substring(4, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow3_1_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^]\d[＋－×÷]");
                        foreach (Match power_3to1_ope_both in match_pow3_1_ope_both)
                        {
                            power_cal = power_3to1_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to1_ope_both.Value.Substring(1, 3);
                            second = power_3to1_ope_both.Value.Substring(5, 1);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 111 ^ 11
                        var match_pow3_2 = Regex.Matches(pattern, @"^(\d{3})?[\^](\d{2})$");
                        foreach (Match power_3to2 in match_pow3_2)
                        {
                            first = power_3to2.Value.Substring(0, 3);
                            second = power_3to2.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to2.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow3_2_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^](\d{2})$");
                        foreach (Match power_3to2_ope in match_pow3_2_ope)
                        {
                            power_cal = power_3to2_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to2_ope.Value.Substring(1, 3);
                            second = power_3to2_ope.Value.Substring(5);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow3_2_ope_back = Regex.Matches(pattern, @"^(\d{3})[\^]\d\d[＋－×÷]");
                        foreach (Match power_3to2_ope_back in match_pow3_2_ope_back)
                        {
                            power_cal = power_3to2_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to2_ope_back.Value.Substring(0, 3);
                            second = power_3to2_ope_back.Value.Substring(4, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow3_2_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^]\d\d[＋－×÷]");
                        foreach (Match power_3to2_ope_both in match_pow3_2_ope_both)
                        {
                            power_cal = power_3to2_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to2_ope_both.Value.Substring(1, 1);
                            second = power_3to2_ope_both.Value.Substring(3, 2);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        // 111 ^ 111
                        var match_pow3_3 = Regex.Matches(pattern, @"^(\d{3})?[\^](\d{3})$");
                        foreach (Match power_3to3 in match_pow3_3)
                        {
                            first = power_3to3.Value.Substring(0, 3);
                            second = power_3to3.Value.Substring(4);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_3to3.Value, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //演算子有
                        var match_pow3_3_ope = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^](\d{3})$");
                        foreach (Match power_3to3_ope in match_pow3_3_ope)
                        {
                            power_cal = power_3to3_ope.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to3_ope.Value.Substring(1, 3);
                            second = power_3to3_ope.Value.Substring(5);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //後ろ
                        var match_pow3_3_ope_back = Regex.Matches(pattern, @"^(\d{3})?[\^](\d{3})[＋－×÷]");
                        foreach (Match power_3to3_ope_back in match_pow3_3_ope_back)
                        {
                            power_cal = power_3to3_ope_back.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to3_ope_back.Value.Substring(0, 3);
                            second = power_3to3_ope_back.Value.Substring(4, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }
                        //両方
                        var match_pow3_3_ope_both = Regex.Matches(pattern, @"[＋－×÷]\d\d\d[\^]\d\d\d[＋－×÷]");
                        foreach (Match power_3to3_ope_both in match_pow3_3_ope_both)
                        {
                            power_cal = power_3to3_ope_both.Value.Trim('＋', '－', '×', '÷');
                            first = power_3to3_ope_both.Value.Substring(1, 3);
                            second = power_3to3_ope_both.Value.Substring(5, 3);

                            pow_result = Math.Pow(double.Parse(first), double.Parse(second));
                            pattern = pattern.Replace(power_cal, pow_result.ToString());
                            input_exp = pattern;
                        }

                        break;
                    }

                    //平方根
                    //階乗や冪乗の処理の前に実行したほうが良い
                    while (input_exp.Contains("√"))
                    {
                        //1桁
                        var match_1 = Regex.Matches(pattern, @"[√]\d[＋－×÷]");
                        foreach (Match match_power1 in match_1)
                        {
                            fact_formula = match_power1.ToString().Trim('＋', '－', '×', '÷');
                            fact_cal = match_power1.ToString().Trim('√', '＋', '－', '×', '÷');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(fact_formula.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }
                        //演算子無し
                        var match_1_ope = Regex.Matches(pattern, @"[√](\d{1})$");
                        foreach (Match match_power1_ope in match_1_ope)
                        {
                            fact_cal = match_power1_ope.ToString().Trim('√');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(match_power1_ope.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }

                        //2桁
                        var match_2 = Regex.Matches(pattern, @"[√]\d\d[＋－×÷]");
                        foreach (Match match_power2 in match_2)
                        {
                            fact_formula = match_power2.ToString().Trim('＋', '－', '×', '÷');
                            fact_cal = match_power2.ToString().Trim('√', '＋', '－', '×', '÷');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(fact_formula, factr_resu.ToString());
                            input_exp = pattern;
                        }
                        //演算子無し
                        var match_2_ope = Regex.Matches(pattern, @"[√](\d{2})$");
                        foreach (Match match_power2_ope in match_2_ope)
                        {
                            fact_cal = match_power2_ope.ToString().Trim('√');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(match_power2_ope.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }

                        //3桁
                        var match_3 = Regex.Matches(pattern, @"[√]\d\d\d[＋－×÷]");
                        foreach (Match match_power3 in match_3)
                        {
                            fact_formula = match_power3.ToString().Trim('＋', '－', '×', '÷');
                            fact_cal = match_power3.ToString().Trim('√', '＋', '－', '×', '÷');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(fact_formula, factr_resu.ToString());
                            input_exp = pattern;
                        }
                        //演算子無し
                        var match_3_ope = Regex.Matches(pattern, @"[√](\d{3})$");
                        foreach (Match match_power3_ope in match_3_ope)
                        {
                            fact_cal = match_power3_ope.ToString().Trim('√');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(match_power3_ope.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }

                        //4桁
                        var match_4 = Regex.Matches(pattern, @"[√]\d\d\d\d[＋－×÷]");
                        foreach (Match match_power4 in match_4)
                        {
                            fact_formula = match_power4.ToString().Trim('＋', '－', '×', '÷');
                            fact_cal = match_power4.ToString().Trim('√', '＋', '－', '×', '÷');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(fact_formula, factr_resu.ToString());
                            input_exp = pattern;
                        }
                        //演算子無し
                        var match_4_ope = Regex.Matches(pattern, @"[√](\d{4})$");
                        foreach (Match match_power4_ope in match_4_ope)
                        {
                            fact_cal = match_power4_ope.ToString().Trim('√');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(match_power4_ope.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }

                        //5桁
                        var match_5 = Regex.Matches(pattern, @"[√]\d\d\d\d\d[＋－×÷]");
                        foreach (Match match_power5 in match_5)
                        {
                            fact_formula = match_power5.ToString().Trim('＋', '－', '×', '÷');
                            fact_cal = match_power5.ToString().Trim('√', '＋', '－', '×', '÷');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(fact_formula, factr_resu.ToString());
                            input_exp = pattern;
                        }
                        //演算子無し
                        var match_5_ope = Regex.Matches(pattern, @"[√](\d{5})$");
                        foreach (Match match_power5_ope in match_5_ope)
                        {
                            fact_cal = match_power5_ope.ToString().Trim('√');
                            factr_resu = Math.Sqrt(double.Parse(fact_cal));
                            pattern = pattern.Replace(match_power5_ope.ToString(), factr_resu.ToString());
                            input_exp = pattern;
                        }
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
                        var result = dt.Compute(input_exp, "");

                        if (result.ToString() == "∞")
                        {
                            //ゼロ除算
                            Error("Cant't calculate");
                        }
                        else
                        {
                            //結果のみカンマ区切りを適用
                            try
                            {
                                formula.Text = String.Format("{0:#,0.############################################################}", decimal.Parse(result.ToString()));
                            }
                            catch (FormatException)
                            {
                                formula.Text = result.ToString();
                            }
                        }

                        //履歴に追加
                        History_form.Instance.ListAddItem(input_str, result.ToString());
                        input_str = "";
                    }
                    //ゼロ除算(?)
                    catch (DivideByZeroException)
                    {
                        Error("Cant't calculate");
                    }
                    //オーバーフロー
                    catch (OverflowException)
                    {
                        Error("Value too large");
                    }
                    //計算式の形式に誤り
                    catch (SyntaxErrorException)
                    {
                        eq = false;
                        Error("Format error");
                    }
                    //オーバーフロー???
                    catch (EvaluateException)
                    {
                        Error("Value too large");
                    }
                }
            }
        }

        //All Clearを "" マウスで "" 押したとき
        private void click_AC(object sender, MouseEventArgs e)
        {
            formula.ForeColor = Color.Black;
            formula.ReadOnly = true;
            formula.Text = "";
            input_str = "";
            operation = "";
        }

        //Back Spaceを "" マウスで "" 押したとき
        private void click_BS(object sender, MouseEventArgs e)
        {
            if (formula.Text == null)
                return;
            else
            {
                string bs_text = input_str.Remove(input_str.Length - 1);
                if (bs_text.Length >= 0)
                    formula.Text = input_str = bs_text;
                else
                    return;
            }
        }

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
            formula.ReadOnly = false;
            formula.ForeColor = Color.DarkRed;
            formula.Text = error;
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
            //履歴ボタンだけ有効化
            Control[] history_ctr = this.Controls.Find("History", true);
            if (history_ctr.Length > 0)
            {
                ((Button)history_ctr[0]).Enabled = true;
            }
        }

        //計算履歴のフォームを表示
        private void click_History(object sender, MouseEventArgs e)
        {
            History_form.Instance.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
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
