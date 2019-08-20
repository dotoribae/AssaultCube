using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Diagnostics.Runtime.Interop;
using ProcessMemoryReaderLib;

namespace AssaultHack
{
    public partial class Form1 : Form
    {
        Process[] MyProcess; // 프로세스 목록을 저장할 장소
        ProcessMemoryReader mem = new ProcessMemoryReader();
        Process attachProc;
        bool healthHack = false;
        bool ammoHack = false;
        bool attach = false;
        bool wallHack = false;
        OverlayForm overlayForm = new OverlayForm();
        Playerdata mainPlayer;
        Playerdata[] enemyPlayer = new Playerdata[30];
        
        


        public Form1()
        {
            InitializeComponent();
        }

        private void ExitBT_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("종료하시겠습니까?", "종료메시지", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Abort;
                Application.Exit();
            }
        }

        // 클릭했을 때 프로세스 목록이 보이도록(Form1.Designer.cs 186)
        private void ComboBox1_Click(object sender, EventArgs e)
        {
            Combobox1.Items.Clear(); // 기존 프로세스 목록 초기화
            MyProcess = Process.GetProcesses(); // 프로세스 목록을 불러온다

            for (int i = 0; i < MyProcess.Length; i++)
            {
                string text = MyProcess[i].ProcessName + "-" + MyProcess[i].Id;
                Combobox1.Items.Add(text);
            }
        }
        // 콤보박스 메뉴 중에 어떤 항목을 클릭했을 때 동작할 내용
        // 프로세스를 선택했을 때 어떤 행동을 할지 정하는 애
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 해당 프로세스에 대한 권한을 가져야한다
                if (Combobox1.SelectedIndex != -1) // 목록을 선택했다면
                {
                    string selectedItem = Combobox1.SelectedItem.ToString();
                    int pid = int.Parse(selectedItem.Split('-')[selectedItem.Split('-').Length - 1]);
                    // 문자열을 -로 나눈 후 가장 마지막 문자열을 가져온다, pid는 문자열 근데 안에서 찾는건 string 그래서 int를 string으로 바꿔주기 위해 int.Parse를 쓴다
                    attachProc = Process.GetProcessById(pid);

                    // 이제 프로세스를 열어야 한다 (권한을 주자)

                    mem.ReadProcess = attachProc; // 프로세스를 연다
                    mem.OpenProcess();
                    

                    MessageBox.Show("프로세스 열기 성공 " + attachProc.ProcessName);
                    int base_ptr = attachProc.MainModule.BaseAddress.ToInt32() + 0x00168A28;
                    int player_base = mem.ReadInt(base_ptr);
                    mainPlayer = new Playerdata(player_base);
                    attach = true;

                }
            }
            catch (Exception ex) // 시도했을 때 예외 처리
            {
                attach = false;
                MessageBox.Show("프로세스 열기 실패" + ex.Message);
            }


        }

        private void Timer1_Tick(object sender, EventArgs e) // 0.1초마다 동작
        {
            if (attach)
            {
                try
                {
                    mainPlayer.SetPlayerData(mem); // 데이터 모니터링
                    if (healthHack)
                    {
                        mainPlayer.hackHealth(mem);
                    }
                    if (ammoHack)
                    {
                        mainPlayer.hackAmmo(mem);
                    }

                    int hotkey = ProcessMemoryReaderApi.GetKeyState(0x02);

                    if (wallHack || (hotkey & 0x8000) != 0)
                    {
                        GetEnemyState(mem);
                        // 원래 에임핵을 쏠 때 쓰려고 하는건데 월핵에서 이걸 받아야하기 때문에 에임핵에 있던 걸 바깥으로 빼준다, 위에 핫키도 마찬가지
                    }

                    if (wallHack)
                    {
                        overlayForm.hackWall(mainPlayer, enemyPlayer);
                    }
                    
                    // 마우스 오른쪽키에 대한 상태를 확인
                    // int hotkey = ProcessMemoryReaderApi.GetKeyState(0x02);
                    if ((hotkey & 0x8000) != 0) // 키가 눌려있다면
                    {
                        // GetEnemyState(mem);  적들에 대한 정보 습득

                        float min_err = 100000; // 에러를 큰 값으로 초기화 시켜준다
                        float err = 0;
                        double min_x_angle = 0;
                        double min_y_angle = 0;
                                                

                        for (int i = 0; i < 30; i++)
                        {
                            // aim hack algorithm

                            err = mainPlayer.getAimErr(mem, enemyPlayer[i].head_x_angle, enemyPlayer[i].head_y_angle);
                            if (min_err > err)
                            {
                                min_err = err;
                                min_x_angle = enemyPlayer[i].head_x_angle;
                                min_y_angle = enemyPlayer[i].head_y_angle;
                            }
                            
                        }
                        
                        mainPlayer.hackAim(mem, min_x_angle, min_y_angle);
                    }
                    
                    HealthLBL.Text = "Health : " + mainPlayer.health;
                    AmmoLBL.Text = "Ammo : " + mainPlayer.ammo;
                    BulletProofLBL.Text = "BulletProof : " + mainPlayer.bullet_proof;
                    AngleLBL.Text = "Angle : " + mainPlayer.x_angle + " | " + mainPlayer.y_angle;
                    PosLBL.Text = "Position : " + mainPlayer.x_pos + " | " + mainPlayer.y_pos + " | " + mainPlayer.z_pos;
                }
                catch { }
            }
        }

        private double GetYDegree(Playerdata mainPlayer, Playerdata enemyPlayer)
        {
            double xz_distance = Math.Sqrt(Math.Pow(mainPlayer.x_pos - enemyPlayer.x_pos, 2) + Math.Pow(mainPlayer.z_pos - enemyPlayer.z_pos, 2));
            double y = mainPlayer.y_pos - enemyPlayer.y_pos;
            double correction = 1;

            if (y > 0)
            {
                correction = -1;
            }

            return correction * Math.Abs(Math.Atan(y / xz_distance) * 180 / Math.PI);
        }

        private double Get2DDegree(Playerdata mainPlayer, Playerdata enemyPlayer)
        {
            double x = mainPlayer.x_pos - enemyPlayer.x_pos;
            double z = mainPlayer.z_pos - enemyPlayer.z_pos;
            double correction = 270;

            if (x < 0) correction = 90;

            return correction + Math.Atan(z / x) * 180 / Math.PI;
            
            //Abs 절대값, Atan 탄젠트 역함수, PI 각도
        }

        private double GetDistance(Playerdata mainPlayer, Playerdata enemyPlayer)
        {
            // 피타고라스의 정리를 사용해 xz_distance를 먼저 구한다 (2D 상태)
            double xz_distance = Math.Sqrt(Math.Pow(mainPlayer.x_pos - enemyPlayer.x_pos, 2) + Math.Pow(mainPlayer.z_pos - enemyPlayer.z_pos, 2)); // Pow 제곱 Sqrt 루트
            // 피타고라스의 정리를 사용해 distance 를 구한다 (3D)
            double distance = Math.Sqrt(Math.Pow(xz_distance, 2) + Math.Pow(mainPlayer.y_pos - enemyPlayer.y_pos, 2));
            return distance;
        }

        private void GetEnemyState(ProcessMemoryReader mem)
        {
            int base_ptr = attachProc.MainModule.BaseAddress.ToInt32() + 0x00175BC4;

            for (int i = 0; i < 30; i++)
            {
                int[] offsetArray = { i * 4 , 0 }; // 0, 4, 8, 12 총 30명의 플레이어 데이터를 불러온다
                int player_base = mem.ReadMultiLevelPointer(base_ptr, 4, offsetArray);
                enemyPlayer[i] = new Playerdata(player_base);
                enemyPlayer[i].SetPlayerData(mem);
                enemyPlayer[i].distance = GetDistance(mainPlayer, enemyPlayer[i]);
                enemyPlayer[i].head_x_angle = Get2DDegree(mainPlayer, enemyPlayer[i]);
                enemyPlayer[i].head_y_angle = GetYDegree(mainPlayer, enemyPlayer[i]);
            }

            
        }

        private void HealthBT_Click(object sender, EventArgs e)
        {
            
            if (healthHack)
            {
                healthHack = false;
                HealthHLBL.Text = "동작 안함";
            }
            else
            {
                healthHack = true;
                HealthHLBL.Text = "동작중";
            }

        }

        private void AmmoBT_Click(object sender, EventArgs e)
        {
            if (ammoHack)
            {
                ammoHack = false;
                AmmoHLBL.Text = "동작 안함";
            }
            else
            {
                ammoHack = true;
                AmmoHLBL.Text = "동작중";
            }
        }

        private void WallHackCHB_CheckedChanged(object sender, EventArgs e)
        {
            if (WallHackCHB.Checked ==  true)
            {
                overlayForm.Show();
                wallHack = true;
            }
            else
            {
                overlayForm.Hide();
                wallHack = false;
            }
        }
    }
}