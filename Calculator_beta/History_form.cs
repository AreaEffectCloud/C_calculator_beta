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
            history_box.ForeColor = Color.Red;
            //途中式と計算結果を色で差別化する(出来ない)
            history_box.Text += formula;
            history_box.Text += "\n" + result;
        }

        private void History_form_Load(object sender, EventArgs e)
        {

        }

        private void list_history_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
