using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator_beta
{
    public partial class History_form : Form
    {
        public History_form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //最大サイズ、最小サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
        }

        /*
         * ここでインスタンスを生成することで、これを表示する際に、複数のウィンドウが作られなくなる
         * Show() は Function_Calculator で実行
         */

        private static History_form hf_instance;
        public static History_form Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (hf_instance == null || hf_instance.IsDisposed)
                {
                    hf_instance = new History_form();
                }
                return hf_instance;
            }
        }

        public void ListAddItem(string input_str, string result)
        {
            input_str = input_str + " = ";
            string bar = "-------------------------------------------";
            //Barのみ色で差別化
            if (history_box.Text == "")
            {
                history_box.Text += input_str;
            }
            else if (history_box.Text != "")
            {
                history_box.Text += "\n" + input_str;
            }
            history_box.Text += "\n" + result;
            history_box.Text += "\n" + bar;

            int currentSelectionStart = history_box.SelectionStart;
            int currentSelectionLength = history_box.SelectionLength;

            int pos = 0;
            for (; ; )
            {
                pos = history_box.Find(bar, pos, RichTextBoxFinds.None);
                if (pos < 0)
                {
                    break;
                }
                history_box.SelectionColor = Color.Gray;
                pos++;
            }
            history_box.Select(currentSelectionStart, currentSelectionLength);
        }

        private void History_form_Load(object sender, EventArgs e)
        {

        }

        private void list_history_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
