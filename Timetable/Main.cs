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
    public partial class Main : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=timetable;Uid=root;Pwd=1234;");
        MySqlDataReader rdr;
        Panel[,] panels = new Panel[5, 10];
        Label[,] labels = new Label[5, 10];
        Dictionary<int, Panel> dic_panels = new Dictionary<int, Panel>();
        Dictionary<int, Label> dic_labels = new Dictionary<int, Label>();
        ListViewItem lvi = new ListViewItem(new string[] { });
        Color backcolor = Color.White;
        Color fontcolor = Color.Black;
        string classN, professor, place, t_col, t_row;
        int back_R, back_G, back_B, font_R, font_G, font_B;
        string preclassN;
        int[] cell;
        int plus = 0;
        int preback_R = 0, preback_G = 0, preback_B = 0, prefont_R = 0, prefont_G = 0, prefont_B = 0;
        int prekey = 0;
        public Main()
        {
            InitializeComponent();
            lb_name.Text = Login.name;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //패널, 레이블 생성
            string ab;
            

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ab = ("panels[" + i + "," + j + "]").ToString();
                    panels[i, j] = new Panel();
                    panels[i, j].Name = ab;
                    panels[i, j].BackColor = SystemColors.Control;
                    panels[i, j].Dock = DockStyle.Fill;
                    panels[i, j].Margin = new Padding(0, 0, 0, 0);

                    labels[i, j] = new Label();
                    labels[i, j].Margin = new Padding(3, 3, 0, 0);

                    panels[i, j].Controls.Add(labels[i, j]);
                    tableLayoutPanel1.Controls.Add(panels[i, j], i, j);

                    //클릭 이벤트 주기 
                    panels[i, j].MouseClick += new MouseEventHandler(MouseClick);
                    labels[i, j].MouseClick += new MouseEventHandler(MouseClick);
                }
            }

            //패널, 레이블 Dictionary에 넣기
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dic_panels.Add(k, panels[i, j]);      //dic_panels 에 panel넣기
                    dic_labels.Add(k, labels[i, j]);    //dic_labels 에 label넣기

                    k++;
                }
            }

            //메인 열릴 때 class테이블 읽고 listview에 뿌려주기
            try
            {
                string insertQuery = "SELECT * FROM class WHERE id='" + Login.id + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string db_className = (string)rdr["className"];
                        string db_professor = (string)rdr["professor"];
                        string db_place = (string)rdr["place"];

                        lvi = new ListViewItem(new string[] { db_className, db_professor, db_place });
                        listView1.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show("추가된 시간표가 없습니다");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rdr.Close();
            connection.Close();

            //time테이블에 있는 행,열 좌표 넣어주기
            try
            {
                string insertQuery = "SELECT * FROM time WHERE id = '" + Login.id + "' ORDER BY t_col, t_row ASC;";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string db_className = (string)rdr["className"];
                        string db_t_col = (string)rdr["t_col"];
                        string db_t_row = (string)rdr["t_row"];
                        int db_back_R = (int)rdr["back_R"];
                        int db_back_G = (int)rdr["back_G"];
                        int db_back_B = (int)rdr["back_B"];
                        int db_font_R = (int)rdr["font_R"];
                        int db_font_G = (int)rdr["font_G"];
                        int db_font_B = (int)rdr["font_B"];

                        int key = int.Parse(db_t_row)+ int.Parse(db_t_col)*10;
                        //fromRGB 써서 값 전달
                        dic_panels[key].BackColor = Color.FromArgb(db_back_R, db_back_G, db_back_B);

                        //이전 시간이 위에 있으면 텍스트는 빼기 / 위에랑 이름이 같지 않거나, 처음 값이거나, 
                        if (!(preclassN == db_className) || preclassN.Equals("") || key-prekey>1)
                        {
                            dic_panels[key].ForeColor = Color.FromArgb(db_font_R, db_font_G, db_font_B);
                            dic_labels[key].Text = db_className;
                        }
                        preclassN = db_className;
                        prekey = key;
                    }
                }
                else
                {

                }
                rdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //배경색 변경
        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd_backcolor = new ColorDialog();
            if (cd_backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = cd_backcolor.Color;
                backcolor = p_backColor.BackColor;
                checkBox1.Checked = true;
                back_R = backcolor.R;
                back_G = backcolor.G;
                back_B = backcolor.B;
            }
        }

        //폰트색 변경
        private void p_fontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd_fontcolor = new ColorDialog();
            if (cd_fontcolor.ShowDialog() == DialogResult.OK)
            {
                p_fontColor.BackColor = cd_fontcolor.Color;
                fontcolor = p_fontColor.BackColor;
                checkBox1.Checked = true;
                font_R = fontcolor.R;
                font_G = fontcolor.G;
                font_B = fontcolor.B;
            }
        }

        //해당 수업 리스트를 클릭할 시 텍스트 출력
        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                tb_classN.Text = listView1.SelectedItems[0].SubItems[0].Text;
                tb_professor.Text = listView1.SelectedItems[0].SubItems[1].Text;
                tb_place.Text = listView1.SelectedItems[0].SubItems[2].Text;

                classN = tb_classN.Text;
                professor = tb_professor.Text;
                place = tb_place.Text;

                checkBox1.Checked = true;

                //해당 수업 클릭시 rgb값을 패널에 넣어줌
                try
                {
                    string insertQuery = "select * from class WHERE id = '" + Login.id + "' and className = '" + classN + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int db_back_R = (int)rdr["back_R"];
                            int db_back_G = (int)rdr["back_G"];
                            int db_back_B = (int)rdr["back_B"];
                            int db_font_R = (int)rdr["font_R"];
                            int db_font_G = (int)rdr["font_G"];
                            int db_font_B = (int)rdr["font_B"];

                            p_backColor.BackColor = Color.FromArgb(db_back_R, db_back_G, db_back_B);
                            p_fontColor.BackColor = Color.FromArgb(db_font_R, db_font_G, db_font_B);

                            setBackColor(p_backColor.BackColor);
                            setFontColor(p_fontColor.BackColor);
                        }
                    }
                    else
                    {

                    }
                    rdr.Close();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_tbClear_Click(object sender, EventArgs e)
        {
            tb_classN.Text = "";
            tb_professor.Text = "";
            tb_place.Text = "";
            back_R = back_G = back_B = 255;
            font_R = font_G = font_B = 0;
            p_backColor.BackColor = Color.FromArgb(back_R, back_G, back_B);
            p_fontColor.BackColor = Color.FromArgb(font_R, font_G, font_B);
        }



        //[추가하기 버튼] - 수업명, 교수명, 장소, 시간을 리스트 뷰에 추가
        private void button1_Click(object sender, EventArgs e)
        {
            if (!tb_classN.Text.Equals(""))
            {
                classN = tb_classN.Text;
                professor = tb_professor.Text;
                place = tb_place.Text;

                setBackColor(p_backColor.BackColor);
                setFontColor(p_fontColor.BackColor);

                string insertQuery = "INSERT INTO class(id, className, professor, place, back_R, back_G, back_B, font_R, font_G, font_B) " +
                    "VALUES('" + Login.id + "','" + classN + "','" + professor + "','" + place + "'," + back_R + "," + back_G + "," + back_B + "," + font_R + "," + font_G + "," + font_B + ");";
                int result = Query(insertQuery, "추가버튼 작업 중");
                if (result == 1)
                {
                    lvi = new ListViewItem(new string[] { classN, professor, place });
                    listView1.Items.Add(lvi);
                    //값 삽입후 초기화
                    tb_classN.Text = "";
                    tb_professor.Text = "";
                    tb_place.Text = "";
                }
                else
                {
                    MessageBox.Show("추가하기 오류");
                }
            }
            else
            {
                MessageBox.Show("수업명을 적어주세요");
            }
        }

        //[삭제하기 버튼] - 선택된 시간 리스트 뷰에서 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            string insertQuery = "DELETE FROM class WHERE id='" + Login.id + "' and className = '" + classN + "';";
            int result = Query(insertQuery, "삭제하기 버튼");
            if (result == 1)
            {
                int index = listView1.FocusedItem.Index;
                listView1.Items.RemoveAt(index);

                tb_classN.Text = "";
                tb_professor.Text = "";
                tb_place.Text = "";
            }
        }

        private void btn_viewManual_Click(object sender, EventArgs e)
        {
            Form manual = new manual();
            manual.Show();
        }

        private void btn_listClear_Click(object sender, EventArgs e)
        {
            string insertQuery = "DELETE FROM time WHERE id = '" + Login.id + "';";
            int result = Query(insertQuery, "time지우기");
            if(result == 1)
            {
                string insertQuery1 = "DELETE FROM class WHERE id = '" + Login.id + "';";
                int result1 = Query(insertQuery1, "class지우기");
                if(result1 == 1)
                {
                    clearTime_List();
                }
            }
            else
            {
                string insertQuery2 = "DELETE FROM class WHERE id = '" + Login.id + "';";
                int result2 = Query(insertQuery2, "class로 넘어가서 지우기");
                if (result2 == 1)
                {
                    clearTime_List();
                }
            }
        }


        //좌클릭, 우클릭 확인
        new void MouseClick(object sender, MouseEventArgs e)
        {
            var cellpos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            t_row = cell[1].ToString();
            t_col = cell[0].ToString();


            //좌클릭시 내용 넣기(배경, 폰트색)
            if (e.Button == MouseButtons.Left)
            {
                if (!tb_classN.Text.Equals(""))
                {
                    //cell[0] = 열 , cell[1] = 행 , cell[2] = 열+행
                    insertCheck(cell[0], cell[1]);
                }
                else
                {
                    MessageBox.Show("수업리스트에서 수업을 클릭해 주세요");
                }
            }

            //클릭시 색 넣기
            preback_R = p_backColor.BackColor.R;
            preback_G = p_backColor.BackColor.G;
            preback_B = p_backColor.BackColor.B;
            prefont_R = p_fontColor.BackColor.R;
            prefont_G = p_fontColor.BackColor.G;
            prefont_B = p_fontColor.BackColor.B;

            //우클릭시
            if (e.Button == MouseButtons.Right)
            {
                string insertQuery = "DELETE FROM time WHERE id = '" + Login.id + "' and t_col = '" + t_col + "' and t_row = '" + t_row + "'";
                int result = Query(insertQuery, "우클릭 작업 중 ");
                if (result == 1)
                {
                    dic_panels[cell[2]].BackColor = SystemColors.Control;
                    dic_labels[cell[2]].Text = "";
                    checkBox1.Checked = true;
                }
                else
                    MessageBox.Show("삭제할 수업이 없습니다");
            }
        }



        //내용이 들어가있는지 확인
        void insertCheck(int row, int col)
        {
            //패널의 배경색이 기본색일 경우 다른색 변환
            if (dic_panels[cell[2]].BackColor == SystemColors.Control)
            {
                string insertQuery = "INSERT INTO time(id, className, t_col, t_row, back_R, back_G, back_B, font_R, font_G, font_B) " +
                    "VALUES('" + Login.id + "','" + classN + "','" + t_col + "','" + t_row + "'," + back_R + "," + back_G + "," + back_B + "," + font_R + "," + font_G + "," + font_B + ");";
                int result = Query(insertQuery, "시간표에 표시하기");
                if (result == 1)
                    insertContents(cell);
                else
                {
                    MessageBox.Show("수업 넣기 오류");
                }
            }

            //배경색이 있을 경우 배경색 제거
            else
            {
                /*  다른 시간표가 들어가있을 경우 바로 값이 들어가지 않음
                 *  눌럿을때 해당 
                 *  DB문제
                 */ 
                string insertQuery = "SELECT * FROM time WHERE id='"+Login.id+"' and t_col = '" + t_col + "' and t_row = '" + t_row + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        t_col = (string)rdr["t_col"];
                        t_row = (string)rdr["t_row"];
                        preclassN = (string)rdr["className"];
                        preback_R = (int)rdr["back_R"];
                        preback_G = (int)rdr["back_G"];
                        preback_B = (int)rdr["back_B"];
                        prefont_R = (int)rdr["font_R"];
                        prefont_G = (int)rdr["font_G"];
                        prefont_B = (int)rdr["font_B"];
                    }
                }
                connection.Close();

                string insertQuery1 = "UPDATE time SET className = '" + classN + "', back_R = " + p_backColor.BackColor.R + ", back_G = " + p_backColor.BackColor.G + ", back_B = " + p_backColor.BackColor.B + ", font_R = " + p_fontColor.BackColor.R + ", font_G = " + p_fontColor.BackColor.G + ", font_B = " + p_fontColor.BackColor.B + " " +
                    "WHERE id = '" + Login.id + "' and t_col = '" + t_col + "'and t_row = '" + t_row + "' and className = '" + preclassN + "' and back_R = " + preback_R + " and back_G = " + preback_G + " and back_B = " + preback_B + " and font_R = " + prefont_R + " and font_G = " + prefont_G + " and font_B = " + prefont_B + "; ";
                int result = Query(insertQuery1, "행, 열 삭제");
                if (result == 1)
                {
                    dic_panels[cell[2]].BackColor = Color.FromArgb(back_R, back_G, back_B);
                    dic_panels[cell[2]].ForeColor = Color.FromArgb(font_R, font_G, font_B);
                    dic_labels[cell[2]].Text = classN;
                }
                else
                {
                    MessageBox.Show("오류");
                }
            }

        }


        public void insertContents(int[] cell)
        {
            //배경, 글자색 넣기
            setBackColor(p_backColor.BackColor);
            dic_panels[cell[2]].BackColor = backcolor;
            dic_panels[cell[2]].ForeColor = fontcolor;

            //체크된 상태면 한번 클릭후 해제
            if (checkBox1.Checked == true)
            {
                dic_labels[cell[2]].Text = tb_classN.Text;
                checkBox1.Checked = false;
            }


        }


        //해당하는 테이블 레이아웃 클릭시
        //행*10 + 열
        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int row = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];
            int col = i + 1;

            cell = new int[3] { row, col, plus };
            cell[2] = row * 10 + col;
            return new Point(row, col);
        }

        int Query(String insertQuery, String work)
        {
            connection.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                if (command.ExecuteNonQuery() > 0)//적용된 행의 개수라서 초기화 할때 ==1로 하면 오류가 나옴
                {
                    connection.Close();
                    return 1;   //성공
                }
                else
                {
                    connection.Close();
                    return 0;   //실패
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return -1;
            }

        }
        // setBackColor(배경으로 등록할 색)
        void setBackColor(Color backcolor)
        {
            back_R = backcolor.R;
            back_G = backcolor.G;
            back_B = backcolor.B;
            this.backcolor = Color.FromArgb(back_R, back_G, back_B);
        }
        void setFontColor(Color fontcolor)
        {
            font_R = fontcolor.R;
            font_G = fontcolor.G;
            font_B = fontcolor.B;
            this.fontcolor = Color.FromArgb(font_R, font_G, font_B);
        }

        void clearTime_List()
        {
            listView1.Items.Clear();

            for (int i = 0; i < 50; i++)
            {
                dic_panels[i].BackColor = SystemColors.Control;
                dic_labels[i].Text = "";
            }
        }
    }
}
/* 클릭 시간표
 * [추가하기]버튼 - 수업명, 교수명, 장소, 시간을 수업리스트에 추가
 * [삭제하기]버튼 - 선택된 시간 수업리스트에서 삭제
 * [값 비우기]버튼 - 텍스트 박스의 값 지우기, 배경색, 글자색 기본값
 * 
 * [초기화] - 표, 수업리스트의 모든 값을 제거
 * 
 * 표에서 좌클릭 - 수업명 넣기(수업명 텍스트 박스가 채워져 있을경우)
 * 표에서 우클릭 - 내용 지우기
 * ---------------------------
 * user 테이블
 * 
 * 회원가입창에서
 * 아이디, 비밀번호, 이름을 입력 후 회원가입 버튼 누를 시
 * DB에 저장
 * ---------------------------
 * class 테이블
 * 
 * 추가버튼 누르면
 * user 이름으로 아이디를 가져와서
 * 아이디, 수업명, 교수명, 장소, 배경색, 글자색
 * DB에 저장
 * ---------------------------
 * time 테이블
 * 
 * 해당 셀을 클릭하면 행, 열값을 가져와서
 * 아이디, 수업명, 행, 열을 저장
 * ---------------------------
 * 좌클릭시 넣기
 * 우클릭시 값 지우기
 * ---------------------------
 * 리스트 뷰에 DB뿌려주기
 * http://blog.naver.com/PostView.nhn?blogId=gkrtjs2020&logNo=50136001833
 * 
 * 리스트 뷰 사용법
 * https://freeprog.tistory.com/232
 */