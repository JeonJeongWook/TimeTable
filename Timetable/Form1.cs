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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mon1_Click(object sender, EventArgs e)
        {
            mon1.BackColor = Color.Blue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog();
        }

        private void p_backColor_Click(object sender, EventArgs e)
        {
            ColorDialog backcolor = new ColorDialog();
            if (backcolor.ShowDialog() == DialogResult.OK)
            {
                p_backColor.BackColor = backcolor.Color;
            }
        }

    }
}
/*표
 * 추가하기 - 수업명, 교수명, 장소, 시간
 * 삭제하기 - 해당 시간만 삭제(ex - 1~4교시중 2교시만 지우면 1,3~4교시(독립적))
 * 프레셋 추가하기 - 리스트 박스에 프리셋 저장
 */