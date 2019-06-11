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
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=timetable;Uid=root;Pwd=1234;");
        MySqlDataReader rdr;
        public Login()
        {
            InitializeComponent();
            
        }


        private void bt_login_Click(object sender, EventArgs e)
        {
            
            string id, password;
            
            try
            {
                connection.Open();

                id = tb_id.Text;
                password = tb_password.Text;

                string insertQuery = "select* from user where id = '" + id + "';";
                MessageBox.Show(insertQuery + "");
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rdr = command.ExecuteReader();


                if (!rdr.Read())
                {
                    MessageBox.Show("회원 정보가 일치하지 않습니다");
                }
                else
                {
                    string user_id = (string)rdr["id"];
                    string user_password = (string)rdr["password"];

                    if (password.Equals(user_password))
                    {
                        MessageBox.Show("성공");

                    }
                    else
                    {
                        MessageBox.Show("틀렸습니다");
                    }
                }
                connection.Close();
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
