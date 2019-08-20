// 기존에 만들었던 OverlayForm을 카피 앤 페이스트

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssaultHack

{
    public partial class OverlayForm : Form
    {
        Graphics g;
        Pen myPen = new Pen(Color.Red);
        IntPtr hAssaultCube;
        PosEnemy[] posEnemy = new PosEnemy[30];

        public const string WINDOWNAME = "AssaultCube";
        RECT rect;
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        } // RECT 선언, 이거 안해주면 밑에 GetWindowRECT 에서 오류가 뜬다

        public struct PosEnemy
        {
            public float x;
            public float y;
            public float size;
        }


        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);


        public OverlayForm()
        {
            InitializeComponent();
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat; // 배경 색 없음
            this.TransparencyKey = Color.Wheat; // 투명한 영역에 이미지 업데이트
            this.TopMost = true; // 가장 상단에 노출
            this.FormBorderStyle = FormBorderStyle.None; // 창의 틀이 완전히 삭제

            int presentStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, presentStyle | 0x80000 | 0x20); // 마우스 이벤트 뒤로 전달 속성 추가
            hAssaultCube = FindWindow(null, WINDOWNAME); // AssaultCube 창을 찾아 핸들을 저장
            GetWindowRect(hAssaultCube, out rect);

            // 창의 사이즈
            int height = rect.Bottom - rect.Top;
            int width = rect.Right - rect.Left;
            this.Size = new Size(width, height);

            // 창의 위치
            this.Top = rect.Top;
            this.Left = rect.Left;

            timer1.Enabled = true;
        }

        

        // 모든 창이 초기화된 뒤에 사용되도록 로드되는 마지막에 타이머 온
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 창의 사이즈(바뀔 일이 거의 없지만 혹시 모르니까)
            int height = rect.Bottom - rect.Top;
            int width = rect.Right - rect.Left;
            this.Size = new Size(width, height);

            // 창의 위치
            this.Top = rect.Top;
            this.Left = rect.Left;
            GetWindowRect(hAssaultCube, out rect);
        }

        private void OverlayForm_Paint(object sender, PaintEventArgs e) // [디자인] 속성 탭에 이벤트(번개모양) 모양에 Paint
        {
            g = e.Graphics;
            // g.DrawRectangle(myPen, 100, 100, 150, 150);

            for (int i = 0; i < 10; i++)
            {
                if (posEnemy[i].x != 1234) ; // -1234 라는건 아래에서 보면 내 시야 밖에 있다는 소리다
                {
                    g.DrawRectangle(myPen, posEnemy[i].x - posEnemy[i].size/2, posEnemy[i].y - posEnemy[i].size/2, posEnemy[i].size, posEnemy[i].size * 2);
                }
            }

        }

        internal void hackWall(Playerdata mainPlayer, Playerdata[] enemyPlayer)
        {
            for (int i = 0; i < 10; i++) // 10명의 플레이어를 검사
            {
                float x_angle_pos = mainPlayer.x_angle - Double2Float(enemyPlayer[i].head_x_angle);
                float y_angle_pos = mainPlayer.y_angle - Double2Float(enemyPlayer[i].head_y_angle);

                // 실제 각도와 다르게 측정되는 경어, 실제 각도로 보정
                if (360 - 45 <= Math.Abs(x_angle_pos) && Math.Abs(x_angle_pos) <= 360)
                {
                    if (x_angle_pos > 0) // 360 - 0
                        x_angle_pos -= 360; // ex) 359 - 1 = 358-- > 2도
                    else
                        x_angle_pos += 360; // ex) 1 -359 = -358 --> 2도
                }

                if ((Math.Abs(x_angle_pos) <= 45) && enemyPlayer[i].health > 0) // 길이가 총 90도
                {
                    float x_corr = (rect.Right - rect.Left) / 90 * x_angle_pos;
                    float y_corr = (rect.Bottom - rect.Top) / 60 * y_angle_pos;

                    posEnemy[i].x = (((rect.Right - rect.Left) / 2) - x_corr); // 더하고 나눠야되나.. 아닌가.. ----> 뺀 게 맞다
                    posEnemy[i].y = (((rect.Bottom - rect.Top) / 2) + y_corr);
                    posEnemy[i].size = Double2Float(1800 / enemyPlayer[i].distance); // 적의 거리가 멀 수록 적을 표시하는 네모의 크기가 작아진다
                }

                else
                {
                    posEnemy[i].x = -1234;
                    posEnemy[i].y = -1234;
                }

                this.Invalidate(); // 페인트 초기화
            }
        }

        private float Double2Float(double input)
        {
            float result = (float)input;
            if (float.IsPositiveInfinity(result))
            {
                result = float.MaxValue;
            }
            else if (float.IsNegativeInfinity(result))
            {
                result = float.MinValue;
            }
            return result;
        }
    }
}
