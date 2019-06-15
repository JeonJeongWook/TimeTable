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
        Panel[,] panels = new Panel[5, 10];
        Label[,] labels = new Label[5, 10];
        Dictionary<int, Panel> dic_panels = new Dictionary<int, Panel>();
        Dictionary<int, Label> dic_labels = new Dictionary<int, Label>();
        ListViewItem lvi = new ListViewItem(new string[] { });
        Color backcolor = Color.LightCyan;
        Color fontcolor = Color.Black;
        String classN, professor, place;
        int plus = 0;
        int[] cell;
        //Dictionary<Poi0nt, Color> cellcolors = new Dictionary<Point, Color>();   //색상저장

        public Main()
        {
            InitializeComponent();
            lb_name.Text = Login.name;
        }

        //생성
        private void Main_Load(object sender, EventArgs e)
        {
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

        }

        //배경색 변경
        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd_backcolor = new ColorDialog();
            if (cd_backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = cd_backcolor.Color;
                backcolor = p_backColor.BackColor;
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
                checkBox1.Checked = true;
            }
        }

        //[추가하기 버튼] - 수업명, 교수명, 장소, 시간을 리스트 뷰에 추가
        //https://freeprog.tistory.com/232
        private void button1_Click(object sender, EventArgs e)
        {
            if (!tb_classN.Text.Equals(""))
            {
                classN = tb_classN.Text;
                professor = tb_professor.Text;
                place = tb_place.Text;

                lvi = new ListViewItem(new string[] { classN, professor, place });
                listView1.Items.Add(lvi);
                tb_classN.Text = "";
                tb_professor.Text = "";
                tb_place.Text = "";

                //string insertQuery = "INSERT INTO time(id, className, professor, place, backColor, fontColor, timeRow, timeCol)" +
                //    "VALUES('" + Login.id + "','" + classN + "','" + professor+ "','" + place + "','" + backcolor + "','" + fontcolor + "','" +  + "','" + asdf"';)"; //쿼리 
            }
            else
            {
                MessageBox.Show("수업명을 적어주세요");
            }
        }

        //[삭제하기 버튼] - 선택된 시간 리스트 뷰에서 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            listView1.Items.RemoveAt(index);
            tb_classN.Text = "";
            tb_professor.Text = "";
            tb_place.Text = "";
        }

        //[복사하기 버튼] - 복사할 시 수업명, 교수명, 장소명 텍스트 박스는 삭제되지 않음
        private void button3_Click(object sender, EventArgs e)
        {
            classN = tb_classN.Text;
            professor = tb_professor.Text;
            place = tb_place.Text;
            lvi = new ListViewItem(new string[] { classN, professor, place });
            listView1.Items.Add(lvi);
        }

        //셀을 클릭할 시 해당 색을 칠함
        //new void Click(object sender, EventArgs e)
        //{
        //    if (!tb_classN.Text.Equals(""))
        //    {
        //        var cellpos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));

        //        //cell[0] = 행 , cell[1] = 열 , cell[2] = 행+열
        //        insertContents(cell[0], cell[1]);
        //    }
        //    else
        //        MessageBox.Show("수업리스트에서 수업을 클릭해 주세요");
        //}

        //좌클릭, 우클릭 확인
        new void MouseClick(object sender, MouseEventArgs e)
        {
            var cellpos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            MessageBox.Show(cellpos + "");
            //좌클릭시 색깔 적용
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("좌클릭 했습니다.");
                if (!tb_classN.Text.Equals(""))
                {
                    //cell[0] = 행 , cell[1] = 열 , cell[2] = 행+열
                    MessageBox.Show("행 : " + cell[0] + "열 : " + cell[1]);
                    insertCheck(cell[0], cell[1]);
                }
                else
                    MessageBox.Show("수업리스트에서 수업을 클릭해 주세요");
            }

            //우클릭시
            if (e.Button == MouseButtons.Right)
            {
                dic_panels[cell[2]].BackColor = SystemColors.Control;
                dic_labels[cell[2]].Text = "";
                checkBox1.Checked = true;
            }
        }

        //내용이 들어가있는지 확인
        void insertCheck(int row, int col)
        {


            MessageBox.Show("행 : " + cell[0] + "/열 : " + cell[1] + "/합 : " + cell[2]);
            //패널의 배경색이 기본색일 경우 다른색 변환
            if (dic_panels[cell[2]].BackColor == SystemColors.Control)
            {
                insertContents(cell);
            }

            //배경색이 있을 경우 배경색 제거
            else
            {
                dic_panels[cell[2]].BackColor = SystemColors.Control;
                dic_labels[cell[2]].Text = "";
                checkBox1.Checked = true;
            }

        }

        public void insertContents(int[] cell)
        {
            //배경, 글자색 넣기
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
            MessageBox.Show("GetRowColIndex : row " + row);
            MessageBox.Show("GetRowColIndex : col " + col);

            cell = new int[3] { row, col, plus };
            cell[2] = row * 10 + col;
            return new Point(col, row);
        }
    }
}
/* 클릭 시간표
 * [추가하기 버튼] - 수업명, 교수명, 장소, 시간을 리스트 뷰에 추가
 * [삭제하기 버튼] - 선택된 시간 리스트 뷰에서 삭제
 * [복사하기 버튼] - 복사할 시 수업명, 교수명, 장소명 텍스트 박스는 삭제되지 않음
 * 
 * [표 초기화] - 색칠한 모든 표의 색을 기본색으로 변경
 * [리스트 초기화] - 수업 리스트를 모두 삭제
 * 
 * 표에서 좌클릭 - 수업명 넣기(수업명 텍스트 박스가 채워져 있을경우)
 * 표에서 우클릭 - 내용 지우기
 * 
 * 
 */
