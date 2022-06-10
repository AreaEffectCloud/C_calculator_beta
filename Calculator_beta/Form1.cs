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


        /*
         * 文字打った時に、対応する奴が反応する
         * 
         * 
         */
        private void result_PressKey(object sender, KeyPressEventArgs e)
        {
            if(ModifierKeys == 0)
            {

            }
            

            if (Keyboard.IsKeyDown(Key.NumPad0 == true))
            {
                formula.SelectedText = "0";
            }
            else return;
            

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
            Key keys = (Key)e.KeyCode;
            formula.SelectedText = keys.ToString();

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
    }
}
