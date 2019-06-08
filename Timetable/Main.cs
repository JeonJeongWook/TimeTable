﻿using System;
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
        ListViewItem lvi = new ListViewItem();
        Color color;
        int celCol = 0;
        int celRow = 0;
        int[] cell;
        public Main()
        {
            InitializeComponent();
        }

        private void mon1_Click(object sender, EventArgs e)
        {

            p_mon1.BackColor = color;
        }

        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog backcolor = new ColorDialog();
            if (backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = backcolor.Color;
                color = p_backColor.BackColor;
            }
            else
            {
                MessageBox.Show("asd");
            }
        }

        private void p_fontColor_Click(object sender, EventArgs e)
        {
            ColorDialog fontcolor = new ColorDialog();
            if (fontcolor.ShowDialog() == DialogResult.OK)
            {
                p_fontColor.BackColor = fontcolor.Color;
            }
        }

        //추가하기 버튼 클릭시 입력 정보가 listview1에 추가
        //https://freeprog.tistory.com/232
        private void button1_Click(object sender, EventArgs e)
        {
            string classN, professor, place;
            classN = tb_classN.Text;
            professor = tb_professor.Text;
            place = tb_place.Text;

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
            int index = listView1.FocusedItem.Index;
            ListViewItem copyitem = new ListViewItem();
            string classN, professor, place;

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

        //private void tableLayoutPanel1_Click(object sender, EventArgs e)
        //{
        //    var cellPos = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
        //    MessageBox.Show("tablelayoutPanel : " + celCol + " / " + celRow + " / " + cell[0] +"," + cell[1]);
           
        //}

        ////해당하는 테이블 레이아웃 클릭시
        //int[] GetRowColIndex(TableLayoutPanel tlp, Point point)
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
        //    return cell;
        //}

        //private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        //{
        //    if (e.Row == e.Column)
        //        using (SolidBrush brush = new SolidBrush(Color.AliceBlue))
        //            e.Graphics.FillRectangle(brush, e.CellBounds);
        //    else
        //        using (SolidBrush brush = new SolidBrush(Color.FromArgb(123, 234, 0)))
        //            e.Graphics.FillRectangle(brush, e.CellBounds);
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