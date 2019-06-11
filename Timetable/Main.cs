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
    public partial class Main : Form
    {
        Panel[,] panels = new Panel[5, 10];
        Label[,] labels = new Label[5, 10];
        Dictionary<int, Panel> dic_panels = new Dictionary<int, Panel>();
        Dictionary<int, Label> dic_labels = new Dictionary<int, Label>();
        ListViewItem lvi = new ListViewItem(new string[] { });
        Color backcolor = Color.LightCyan;
        Color fontcolor = Color.Black;
        String classN, professor, place;
        int celCol = 0;
        int celRow = 0;
        int plus = 0;
        int[] cell;
        //Dictionary<Poi0nt, Color> cellcolors = new Dictionary<Point, Color>();   //색상저장



        public Main()
        {
            InitializeComponent();
        }
        //생성
        private void Main_Load(object sender, EventArgs e)
        {
            int[,] a = new int[5, 10];
            string ab;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //
                    ab = ("panels[" + i + "," + j + "]").ToString();
                    panels[i, j] = new Panel();
                    panels[i, j].Name = ab;
                    panels[i, j].BackColor = BackColor;
                    panels[i, j].Dock = DockStyle.Fill;
                    panels[i, j].Margin = new Padding(0, 0, 0, 0);

                    labels[i, j] = new Label();
                    labels[i, j].Text = i + "_" + j;
                    labels[i, j].Margin = new Padding(3, 3, 0, 0);
                    //마진 넣기 1!

                    panels[i, j].Controls.Add(labels[i, j]);
                    tableLayoutPanel1.Controls.Add(panels[i, j], i, j);
                    
                    //클릭 이벤트 주기 
                    panels[i, j].Click += new System.EventHandler(Click);
                    labels[i, j].Click += new System.EventHandler(Click);
                }
            }

            int k = 0;
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<10; j++)
                {
                    dic_panels.Add(k, panels[i, j]);      //dic_panels 에 panel넣기
                    dic_labels.Add(k, labels[i, j]);    //dic_labels 에 label넣기

                    k++;
                }
            }
            /*
             * k = 0 // panels 0,0
             * k = 1 // panels 0,1
             * k = 10// panels 1,0
             */

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
            else
            {

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
            else
            {

            }
        }

        //해당 행을 클릭할 시 텍스트
        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                tb_classN.Text = listView1.SelectedItems[0].SubItems[0].Text;
                tb_professor.Text = listView1.SelectedItems[0].SubItems[1].Text;
                tb_place.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        //추가하기 버튼 클릭시 입력 정보가 listview1에 추가
        //https://freeprog.tistory.com/232
        private void button1_Click(object sender, EventArgs e)
        {
            classN = tb_classN.Text;
            professor = tb_professor.Text;
            place = tb_place.Text;

            //lvi = new ListViewItem(new string[] { classN, professor, place });
            lvi = new ListViewItem(new string[] { classN, professor, place });
            listView1.Items.Add(lvi);
            tb_classN.Text = "";
            tb_professor.Text = "";
            tb_place.Text = "";
        }

        //listview1에 선택된 행 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            listView1.Items.RemoveAt(index);
            tb_classN.Text = "";
            tb_professor.Text = "";
            tb_place.Text = "";
        }

        //선택된 아이템 복사
        private void button3_Click(object sender, EventArgs e)
        {
            classN = tb_classN.Text;
            professor = tb_professor.Text;
            place = tb_place.Text;
            lvi = new ListViewItem(new string[] { classN, professor, place });
            listView1.Items.Add(lvi);
        }

        //셀을 클릭할 시
        new void Click(object sender, EventArgs e)
        {
            var cellpos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            
            //cell[0] = 행 , cell[1] = 열 , cell[2] = 행+열
            insertContents(cell[0], cell[1]);
        }

        //내용, 배경 넣기
        void insertContents(int row, int col)
        {
            cell[2] = row * 10 + col;

            dic_panels[cell[2]].BackColor = backcolor;
            dic_panels[cell[2]].ForeColor = fontcolor;

            dic_labels[cell[2]].Text = classN;
        }


        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("tablelayoutpanel을 클릭하셨습니다.");
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
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;
            celCol = int.Parse(col + "");
            celRow = int.Parse(row + "");
            cell = new int[3] { celCol, celRow, plus };
            return new Point(col, row);
        }

        //private void p_mon1_Click(object sender, EventArgs e)
        //{
        //    //insertContents();
        //}

        ////테이블 레이아웃패널 클릭 시 좌표 검색
        //private void tableLayoutPanel1_Click(object sender, EventArgs e)
        //{
        //    var cellPos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
        //    //MessageBox.Show(cellPos.Value+"");
        //    MessageBox.Show("tablelayoutPanel : " + cellPos);

        //    //해당 셀 컬러 삭제 후 추가
        //    cellcolors.Remove(new Point(celRow, celCol));
        //    cellcolors.Add(new Point(celRow, celCol), backcolor);
        //    //cell_RePaint(celCol, celRow);
        //}

        ////셀 생성시 그리기
        //private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        //{
        //    if (cellcolors.Keys.Contains(new Point(e.Column, e.Row)))
        //        using (SolidBrush brush = new SolidBrush(cellcolors[new Point(e.Column, e.Row)]))
        //            e.Graphics.FillRectangle(brush, e.CellBounds);
        //    else
        //        using (SolidBrush brush = new SolidBrush(SystemColors.ControlDark))
        //            e.Graphics.FillRectangle(brush, e.CellBounds);
        //}

        ////테이블 기본 배경색 변경
        //private void Main_Load(object sender, EventArgs e)
        //{
        //    for(int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 5; j++)
        //        {
        //            cellcolors.Add(new Point(j, i), SystemColors.Control);
        //        }
        //    }
        //}



    }
}
/*표
 * 추가하기 - 수업명, 교수명, 장소, 시간
 * 삭제하기 - 해당 시간만 삭제(ex - 1~4교시중 2교시만 지우면 1,3~4교시(독립적))
 * 프레셋 추가하기 - 리스트 박스에 프리셋 저장
 * 
 * 삽입(update) 함수 - 배경색(backGroundColor), 글씨색(FontColor), 글씨포함(insertText)
 */