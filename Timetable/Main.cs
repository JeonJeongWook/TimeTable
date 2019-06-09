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
        //ListViewItem lvi = new ListViewItem();
        ListViewItem lvi = new ListViewItem(new string[] {});
        Color backcolor = Color.Black;
        Color fontcolor = Color.White;
        String classN, professor, place;
        //int celCol = 0;
        //int celRow = 0;
        //int[] cell;
        //Dictionary<Point, Color> cellcolors = new Dictionary<Point, Color>();   //색상저장






        public Main()
        {
            InitializeComponent();
        }

        private void mon1_Click(object sender, EventArgs e)
        {

            p_mon1.BackColor = backcolor;
        }

        //배경색 변경
        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog backcolor = new ColorDialog();
            if (backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = backcolor.Color;
                this.backcolor = p_backColor.BackColor;
            }
            else
            {
            }
        }

        //폰트색 변경
        private void p_fontColor_Click(object sender, EventArgs e)
        {
            ColorDialog fontcolor = new ColorDialog();
            if (fontcolor.ShowDialog() == DialogResult.OK)
            {
                p_fontColor.BackColor = fontcolor.Color;
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




        private void p_mon1_Click(object sender, EventArgs e)
        {
            //lb_mon1.Text = tb_classN.Text;
            //p_mon1.BackColor = backcolor;
            insertContents();
        }

        void insertContents(/*Label label*/) {
            lb_mon1.Text = classN;
            lb_mon1.ForeColor = fontcolor;
            p_mon1.BackColor = backcolor;

        }



        ////해당하는 테이블 레이아웃 클릭시
        //Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        //{
        //    if (point.X > tlp.Width || point.Y > tlp.Height)
        //        return null;
            
        //    int w = tlp.Width;
        //    int h = tlp.Height;
        //    int[] widths = tlp.GetColumnWidths();

        //    int i;
        //    for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
        //        w -= widths[i];
        //    int col = i + 1;

        //    int[] heights = tlp.GetRowHeights();
        //    for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
        //        h -= heights[i];

        //    int row = i + 1;
        //    this.celCol = int.Parse(col + "");
        //    this.celRow = int.Parse(row + "");
        //    cell = new int[2] { celCol, celRow };
        //    return new Point(col, row);
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