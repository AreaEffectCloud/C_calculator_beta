using System;
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

        /*
         * 文字打った時に、対応する奴が反応する (null)
         * 
         */
        private void result_PressKey(object sender, KeyPressEventArgs e)
        {

            SetButtonClickShortcut(this, Keys.NumPad0, button00);
            textBox1.SelectedText = "0";
        }

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
    }
}
