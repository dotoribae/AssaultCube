using System;

namespace AssaultHack
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitleLBL = new System.Windows.Forms.Label();
            this.HealthBT = new System.Windows.Forms.Button();
            this.ExitBT = new System.Windows.Forms.Button();
            this.AmmoBT = new System.Windows.Forms.Button();
            this.HealthHLBL = new System.Windows.Forms.Label();
            this.AmmoHLBL = new System.Windows.Forms.Label();
            this.ProcessLBL = new System.Windows.Forms.Label();
            this.HealthLBL = new System.Windows.Forms.Label();
            this.PlayerDataGB = new System.Windows.Forms.GroupBox();
            this.BulletProofLBL = new System.Windows.Forms.Label();
            this.AmmoLBL = new System.Windows.Forms.Label();
            this.PosLBL = new System.Windows.Forms.Label();
            this.AngleLBL = new System.Windows.Forms.Label();
            this.Combobox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WallHackCHB = new System.Windows.Forms.CheckBox();
            this.PlayerDataGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLBL
            // 
            this.TitleLBL.AutoSize = true;
            this.TitleLBL.Font = new System.Drawing.Font("나눔명조 ExtraBold", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TitleLBL.Location = new System.Drawing.Point(130, 32);
            this.TitleLBL.Name = "TitleLBL";
            this.TitleLBL.Size = new System.Drawing.Size(553, 55);
            this.TitleLBL.TabIndex = 0;
            this.TitleLBL.Text = "AssaultCube Game Hack";
            this.TitleLBL.Click += new System.EventHandler(this.Label1_Click);
            // 
            // HealthBT
            // 
            this.HealthBT.Location = new System.Drawing.Point(81, 231);
            this.HealthBT.Name = "HealthBT";
            this.HealthBT.Size = new System.Drawing.Size(157, 32);
            this.HealthBT.TabIndex = 1;
            this.HealthBT.Text = "Health Hack";
            this.HealthBT.UseVisualStyleBackColor = true;
            this.HealthBT.Click += new System.EventHandler(this.HealthBT_Click);
            // 
            // ExitBT
            // 
            this.ExitBT.Location = new System.Drawing.Point(648, 372);
            this.ExitBT.Name = "ExitBT";
            this.ExitBT.Size = new System.Drawing.Size(140, 34);
            this.ExitBT.TabIndex = 1;
            this.ExitBT.Text = "닫기";
            this.ExitBT.UseVisualStyleBackColor = true;
            this.ExitBT.Click += new System.EventHandler(this.ExitBT_Click);
            // 
            // AmmoBT
            // 
            this.AmmoBT.Location = new System.Drawing.Point(81, 286);
            this.AmmoBT.Name = "AmmoBT";
            this.AmmoBT.Size = new System.Drawing.Size(157, 32);
            this.AmmoBT.TabIndex = 1;
            this.AmmoBT.Text = "Ammo Hack";
            this.AmmoBT.UseVisualStyleBackColor = true;
            this.AmmoBT.Click += new System.EventHandler(this.AmmoBT_Click);
            // 
            // HealthHLBL
            // 
            this.HealthHLBL.AutoSize = true;
            this.HealthHLBL.Location = new System.Drawing.Point(283, 241);
            this.HealthHLBL.Name = "HealthHLBL";
            this.HealthHLBL.Size = new System.Drawing.Size(57, 12);
            this.HealthHLBL.TabIndex = 2;
            this.HealthHLBL.Text = "동작 안함";
            // 
            // AmmoHLBL
            // 
            this.AmmoHLBL.AutoSize = true;
            this.AmmoHLBL.Location = new System.Drawing.Point(283, 296);
            this.AmmoHLBL.Name = "AmmoHLBL";
            this.AmmoHLBL.Size = new System.Drawing.Size(57, 12);
            this.AmmoHLBL.TabIndex = 2;
            this.AmmoHLBL.Text = "동작 안함";
            // 
            // ProcessLBL
            // 
            this.ProcessLBL.AutoSize = true;
            this.ProcessLBL.Location = new System.Drawing.Point(79, 138);
            this.ProcessLBL.Name = "ProcessLBL";
            this.ProcessLBL.Size = new System.Drawing.Size(129, 12);
            this.ProcessLBL.TabIndex = 3;
            this.ProcessLBL.Text = "프로세스를 선택하세요";
            // 
            // HealthLBL
            // 
            this.HealthLBL.AutoSize = true;
            this.HealthLBL.Location = new System.Drawing.Point(18, 28);
            this.HealthLBL.Name = "HealthLBL";
            this.HealthLBL.Size = new System.Drawing.Size(52, 12);
            this.HealthLBL.TabIndex = 4;
            this.HealthLBL.Text = "Health : ";
            this.HealthLBL.Click += new System.EventHandler(this.HealthLBL_Click);
            // 
            // PlayerDataGB
            // 
            this.PlayerDataGB.Controls.Add(this.BulletProofLBL);
            this.PlayerDataGB.Controls.Add(this.AmmoLBL);
            this.PlayerDataGB.Controls.Add(this.PosLBL);
            this.PlayerDataGB.Controls.Add(this.AngleLBL);
            this.PlayerDataGB.Controls.Add(this.HealthLBL);
            this.PlayerDataGB.Location = new System.Drawing.Point(432, 138);
            this.PlayerDataGB.Name = "PlayerDataGB";
            this.PlayerDataGB.Size = new System.Drawing.Size(356, 214);
            this.PlayerDataGB.TabIndex = 5;
            this.PlayerDataGB.TabStop = false;
            this.PlayerDataGB.Text = "Player Data";
            // 
            // BulletProofLBL
            // 
            this.BulletProofLBL.AutoSize = true;
            this.BulletProofLBL.Location = new System.Drawing.Point(18, 158);
            this.BulletProofLBL.Name = "BulletProofLBL";
            this.BulletProofLBL.Size = new System.Drawing.Size(77, 12);
            this.BulletProofLBL.TabIndex = 4;
            this.BulletProofLBL.Text = "BulletProof : ";
            // 
            // AmmoLBL
            // 
            this.AmmoLBL.AutoSize = true;
            this.AmmoLBL.Location = new System.Drawing.Point(18, 93);
            this.AmmoLBL.Name = "AmmoLBL";
            this.AmmoLBL.Size = new System.Drawing.Size(54, 12);
            this.AmmoLBL.TabIndex = 4;
            this.AmmoLBL.Text = "Ammo : ";
            // 
            // PosLBL
            // 
            this.PosLBL.AutoSize = true;
            this.PosLBL.Location = new System.Drawing.Point(119, 93);
            this.PosLBL.Name = "PosLBL";
            this.PosLBL.Size = new System.Drawing.Size(39, 12);
            this.PosLBL.TabIndex = 4;
            this.PosLBL.Text = "Pos : ";
            this.PosLBL.Click += new System.EventHandler(this.HealthLBL_Click);
            // 
            // AngleLBL
            // 
            this.AngleLBL.AutoSize = true;
            this.AngleLBL.Location = new System.Drawing.Point(119, 28);
            this.AngleLBL.Name = "AngleLBL";
            this.AngleLBL.Size = new System.Drawing.Size(49, 12);
            this.AngleLBL.TabIndex = 4;
            this.AngleLBL.Text = "Angle : ";
            this.AngleLBL.Click += new System.EventHandler(this.HealthLBL_Click);
            // 
            // Combobox1
            // 
            this.Combobox1.FormattingEnabled = true;
            this.Combobox1.Location = new System.Drawing.Point(81, 166);
            this.Combobox1.Name = "Combobox1";
            this.Combobox1.Size = new System.Drawing.Size(308, 20);
            this.Combobox1.TabIndex = 6;
            this.Combobox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.Combobox1.Click += new System.EventHandler(this.ComboBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // WallHackCHB
            // 
            this.WallHackCHB.AutoSize = true;
            this.WallHackCHB.Location = new System.Drawing.Point(81, 349);
            this.WallHackCHB.Name = "WallHackCHB";
            this.WallHackCHB.Size = new System.Drawing.Size(79, 16);
            this.WallHackCHB.TabIndex = 7;
            this.WallHackCHB.Text = "Wall Hack";
            this.WallHackCHB.UseVisualStyleBackColor = true;
            this.WallHackCHB.CheckedChanged += new System.EventHandler(this.WallHackCHB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WallHackCHB);
            this.Controls.Add(this.Combobox1);
            this.Controls.Add(this.PlayerDataGB);
            this.Controls.Add(this.ProcessLBL);
            this.Controls.Add(this.AmmoHLBL);
            this.Controls.Add(this.HealthHLBL);
            this.Controls.Add(this.ExitBT);
            this.Controls.Add(this.AmmoBT);
            this.Controls.Add(this.HealthBT);
            this.Controls.Add(this.TitleLBL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PlayerDataGB.ResumeLayout(false);
            this.PlayerDataGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void HealthLBL_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label TitleLBL;
        private System.Windows.Forms.Button HealthBT;
        private System.Windows.Forms.Button ExitBT;
        private System.Windows.Forms.Button AmmoBT;
        private System.Windows.Forms.Label HealthHLBL;
        private System.Windows.Forms.Label AmmoHLBL;
        private System.Windows.Forms.Label ProcessLBL;
        private System.Windows.Forms.Label HealthLBL;
        private System.Windows.Forms.GroupBox PlayerDataGB;
        private System.Windows.Forms.Label BulletProofLBL;
        private System.Windows.Forms.Label AmmoLBL;
        private System.Windows.Forms.Label PosLBL;
        private System.Windows.Forms.Label AngleLBL;
        private System.Windows.Forms.ComboBox Combobox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox WallHackCHB;
    }
}

