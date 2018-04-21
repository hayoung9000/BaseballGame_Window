using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseballGameWindows
{
    public partial class BaseGame : Form
    {
        
        private BaseballEngine bge;
        public BaseGame()
        {
            InitializeComponent();
            //BaseballGameEngine을 생성, 퀴즈 낸다
            bge = new BaseballEngine();
            bge.Init();
        }


        private void bInput_Click(object sender, EventArgs e)
        {
            
            string[] row = { tNumber1.Text, tNumber2.Text, tNumber3.Text };
            var listViewItem = new ListViewItem(row);
            listView.Items.Add(listViewItem);

            try
            {
                int a = int.Parse(tNumber1.Text);
            }
            catch
            {
                MessageBox.Show("첫번째 숫자 이상");
                tNumber1.Text = "";
                return;
            }
            try
            {
                int a = int.Parse(tNumber2.Text);
            }
            catch
            {
                MessageBox.Show("두번째 숫자 이상");
                tNumber2.Text = "";
                return;
            }
            try
            {
                int a = int.Parse(tNumber3.Text);
            }
            catch
            {
                MessageBox.Show("세번째 숫자 이상");
                tNumber3.Text = "";
                return;
            }
            //tNumber 1,2,3에 있는 값을 가져와서
            //String으로 연결하고
            string input = tNumber1.Text + tNumber2.Text + tNumber3.Text;
            //BaseballGameEngine에 준다
            //게임엔지이 strike, ball 판정
            bge.Play(input);
            //startusLabel에 strike, ball 출력하자
            statusLabel.Text = String.Format("Strike : {0}, Ball : {1}", bge.GetStrike(), bge.GetBall());
            //strike와 quiz 길이가 같으면 ㅊㅋㅊㅋ 메시지막스
            if (bge.GetStrike() == bge.getQuizLength())
            {
                MessageBox.Show("ㅊㅋㅊㅋ");
                // Close();
                Clear();
                bge.Init();
            }

           


        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            tNumber1.Text = "";
            tNumber2.Text = "";
            tNumber3.Text = "";
            statusLabel.Text = "Play Ball!";
        }

       
    }
}
