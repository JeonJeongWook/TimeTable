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
        public Main()
        {
            InitializeComponent();
        }

        private void mon1_Click(object sender, EventArgs e)
        {

            mon1.BackColor = Color.Aquamarine;
        }

        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog backcolor = new ColorDialog();
            if (backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = backcolor.Color;
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
            ListViewItem additem = new ListViewItem();
            string classN, professor, place;
            classN = tb_classN.Text;
            professor = tb_professor.Text;
            place = tb_place.Text;


            additem = new ListViewItem(new string[] { classN, professor, place });
            listView1.Items.Add(additem);
        }
    }
}
/*표
 * 추가하기 - 수업명, 교수명, 장소, 시간
 * 삭제하기 - 해당 시간만 삭제(ex - 1~4교시중 2교시만 지우면 1,3~4교시(독립적))
 * 프레셋 추가하기 - 리스트 박스에 프리셋 저장
 * 
 * 삽입(update) 함수 - 배경색(backGroundColor), 글씨색(FontColor), 글씨포함(insertText)
 */