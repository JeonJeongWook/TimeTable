using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //아이디와 패스워드가 일치하면 Main실행
        //일치하지 않으면 메시지 박스 표시
        private void button2_Click(object sender, EventArgs e)
        {
            if(tb_id.Text.Equals("admin") && tb_passwd.Text.Equals("1234"))
            {
                this.Visible = false;
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("회원정보가 일치하지 않습니다.");
            }
        }

        //회원가입 클릭시 회원가입 화면으로 이동
        private void button1_Click(object sender, EventArgs e)
        {
            Form register = new Register();
            register.Show();
        }
    }
}
