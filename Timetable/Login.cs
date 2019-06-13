using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Timetable
{
    public partial class Login : Form
    {
        public static string name, id;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=timetable;Uid=root;Pwd=1234;");
        MySqlDataReader rdr;
        public Login()
        {
            InitializeComponent();
            
        }


        private void bt_login_Click(object sender, EventArgs e)
        {
            //텍스트 박스에 있는 값을 넣는 필드
            string id, password;
            try
            {
                connection.Open();

                id = tb_id.Text;
                password = tb_password.Text;
                
                string insertQuery = "select* from user where id = '" + id + "';";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rdr = command.ExecuteReader();

                if (!rdr.Read())
                {
                    MessageBox.Show("회원 정보가 존재하지 않습니다.");
                }
                else
                {
                    string user_id = (string)rdr["id"];
                    string user_password = (string)rdr["password"];
                    name = (string)rdr["name"];
                    id = (string)rdr["id"];

                    if (password.Equals(user_password))
                    {
                        MessageBox.Show(name + "님이 접속 하셨습니다.","로그인 성공");
                        Form main = new Main();
                        main.Show();
                        Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("아이디와 패스워드를 다시 확인해주세요!","로그인 실패");
                    }
                }
                connection.Close();
                this.tb_id.Text = "";
                this.tb_password.Text = "";
                this.ActiveControl = tb_id;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void bt_goRegister_Click(object sender, EventArgs e)
        {
            Form register = new Register();
            register.ShowDialog();
        }

    }
}
