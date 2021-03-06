﻿using System;
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
 * 
 * 할것
 * 중복 처리 하기
 * select from user where id='id' 널 값이 아닐 경우 취소 / 널값이면 실행
 * 
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
            //칼럼에 추가하는 커리문 insertQuery
            string insertQuery = "INSERT INTO user(id,password, name) VALUES('" + tb_id.Text + "','" + tb_password.Text + "','" + tb_name.Text + "')";
            //string checkQuery = "SELECT * FROM user GROUP BY id HAVING COUNT(id) > 1

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외처리
            {
                if (!tb_id.Text.Equals("") || !tb_password.Equals("") || !tb_name.Equals(""))
                {
                    //만약 내가 처리한 Mysql에 정상적으로 들어가면 메시지 출력
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("들어가지 않았습니다");
                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tb_id;
        }
    }
}