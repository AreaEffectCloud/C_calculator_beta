using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
