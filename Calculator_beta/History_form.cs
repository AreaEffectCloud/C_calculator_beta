using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;


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
        // Ex. History_form.Instance.---();

        /*
         * 一行ごとに色変えられるかも？
         */
        public void ListAddItem(string formula, string result)
        {
            string bar = "-------------------------------------------";
            //途中式と計算結果を色で差別化
            if (history_box.Text == "")
            {
                history_box.Text += formula;
            }
            else if (history_box.Text != "")
            {
                history_box.Text += "\n" + formula;
            }
            history_box.Text += "\n" + result;
            history_box.Text += "\n" + bar;

            //現在の選択状態を覚えておく
            int currentSelectionStart = history_box.SelectionStart;
            int currentSelectionLength = history_box.SelectionLength;

            int pos = 0;

            //Result
            for (; ; )
            {
                //文字列を検索して、選択状態にする
                pos = history_box.Find(result, pos, RichTextBoxFinds.None);
                if (pos < 0)
                {
                    break;
                }
                //字の色を灰色
                history_box.SelectionColor = Color.Gray;
                pos++;
            }
            pos = 0;
            //Bar
            for (; ; )
            {
                //文字列を検索して、選択状態にする
                pos = history_box.Find(bar, pos, RichTextBoxFinds.None);
                if (pos < 0)
                {
                    break;
                }
                //字の色を灰色
                history_box.SelectionColor = Color.Gray;
                pos++;
            }

            //選択状態を元に戻す
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
