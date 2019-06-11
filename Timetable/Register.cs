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
/*
 * DB연동 하기
 * https://marine1188.tistory.com/77
 */

namespace Timetable
{
    public partial class Register : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=timetable;Uid=root;Pwd=1234;");

        public Register()
        {
            InitializeComponent();
        }

        private void bt_register_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("아직 개발중 입니다.");
            //칼럼에 추가하는 커리문 insertQuery
            string insertQuery = "INSERT INTO user(id,password, name) VALUES('" + tb_id.Text + "','" + tb_password.Text + "','" + tb_name.Text + "')";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외처리
            {
                //만약 내가 처리한 Mysql에 정상적으로 들어가면 메시지 출력
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("정상적으로 들어갔습니다");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("들어가지 않았습니다");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}