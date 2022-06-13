using System;
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

        //演算子
        string operation = null;
        //第一項
        private decimal Mem1 = 0m;

        //0から9の数字を "" マウスで "" 押したとき
        private void click_Number(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;
            decimal input_num = decimal.Parse(formula.Text + btn.Text);

            formula.Text = input_num.ToString();
        }

        //四則演算を "" マウスで "" 押したとき
        private void click_ope(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if(btn.Text == "+")
            {
                operation ="+";
            }
            else if(btn.Text == "-")
            {
                operation = "-";
            }
            else if (btn.Text == "÷")
            {
                operation = "÷";
            }
            else if (btn.Text == "✕")
            {
                operation = "×";
            }

            if (formula.Text == null)
            {
                operation = null;
                return;
            } 
            else
            {
                Mem1 = decimal.Parse(formula.Text);
                formula.SelectedText = operation;
            }

        }

        //イコールを "" マウスで "" 押したとき
        private void click_Eq(object sender, System.Windows.Forms.MouseEventArgs e)
        {

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
