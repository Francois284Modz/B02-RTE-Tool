using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DXApplication1.MW3;
using PS3Lib.NET;
using PS3Lib;
using static DXApplication1.MW3.FunctionsMethods;

namespace DXApplication1
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        public frmMain()
        {
            InitializeComponent();
            base.Width = 1013;
            base.Height = 506;
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        // ccapi connection
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            //ccapi
            if (toggleSwitch1.IsOn)
            {
                Connection.SelectControlApi(0);
                toggleSwitch2.IsOn = false;
            }
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            //tmapi
            if (toggleSwitch2.IsOn)
            {
                toggleSwitch1.IsOn = false;
                Connection.SelectControlApi(1);
            }
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            //connecter 
            Connection.ConnectPS3(0, "RTM Tool by Francois284Modz");

            if (Connection.IsConnected)
            {
                barStaticItem1.Caption = "PS3 Connecte : OUI";
            }
            else
            {
                barStaticItem1.Caption = "PS3 Connecte : NON";
            }

        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            //attacher
            Connection.AttacherPS3("RTM Tool by Francois284Modz");
            if (Connection.IsAttached)
            {
                barStaticItem2.Caption = "PS3 Attacher : OUI";
                if (Connection.RPCEnabled)
                {
                    barStaticItem3.Caption = "RPC Enabled : OUI";
                }
            }
            else
            {
                barStaticItem2.Caption = "PS3 Attacher : NON";
                barStaticItem3.Caption = "RPC Enabled : NON";
            }
 
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            // deconnection de la ps3
            Connection.Disconnect();
            barStaticItem2.Caption = "PS3 Attacher : NON";
            barStaticItem1.Caption = "PS3 Connecte : NON";
            barStaticItem3.Caption = "RPC Enabled : NON";
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            //menu stast

            xtraTabControl1.SelectedTabPage = xtraTabPage1;

        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;

        }


        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            //tout sellectioner
            if (checkEdit4.Checked) // si le checkbox tout selectionner est egale a true = vraix
            {
                //alor execute tout 
                PrestigeCheck.Checked = true;
                ExperienceCheck.Checked = true;
                AccuracyCheck.Checked = true;
                KillsCheck.Checked = true;
                DeathsCheck.Checked = true;
                AssistsCheck.Checked = true;
                HeadshotsCheck.Checked = true;
                TokenCheck.Checked = true;
                WinCheck.Checked = true;
                WinstreakCheck.Checked = true;
                LossesCheck.Checked = true;
                TiesCheck.Checked = true;
                HitsCheck.Checked = true;
                MissesCheck.Checked = true;
                RatioCheck.Checked = true;
            }
            else // sinon 
            {
                PrestigeCheck.Checked = false;
                ExperienceCheck.Checked = false;
                AccuracyCheck.Checked = false;
                KillsCheck.Checked = false;
                DeathsCheck.Checked = false;
                AssistsCheck.Checked = false;
                HeadshotsCheck.Checked = false;
                TokenCheck.Checked = false;
                WinCheck.Checked = false;
                WinstreakCheck.Checked = false;
                LossesCheck.Checked = false;
                TiesCheck.Checked = false;
                HitsCheck.Checked = false;
                MissesCheck.Checked = false;
                RatioCheck.Checked = false;
            }
        }

        private void PrestigeCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown1.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Prestige, buffer);
        }

        private void ExperienceCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown2.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Exprerience, buffer);
        }

        private void AccuracyCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown3.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Accuracy, buffer);
        }

        private void KillsCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown4.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Kills, buffer);
        }

        private void DeathsCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown5.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Deaths, buffer);
        }

        private void WinCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown14.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Win, buffer);
        }

        private void LossesCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown15.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Losses, buffer);
        }

        private void AssistsCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown6.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Assists, buffer);
        }

        private void HeadshotsCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown7.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Headshot, buffer);
        }

        private void TokenCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown8.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Token, buffer);
        }

        private void TiesCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown9.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Ties, buffer);
        }

        private void WinstreakCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown10.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.WinStreak, buffer);
        }

        private void HitsCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown11.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Hits, buffer);
        }

        private void MissesCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown12.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Misses, buffer);
        }

        private void RatioCheck_CheckedChanged(object sender, EventArgs e)
        {
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown13.Value.ToString()));
            Connection.PS3.SetMemory(StatsOffsett.Ratio, buffer);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //legit stats

            numericUpDown1.Value = 10;



        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            UnlockAll.Unlock_All();
            UnlockAll.UnlockChallenge();
            MessageBox.Show("Please close mw3 and open it back again", "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            UnlockAll.UnlockAllTrophys();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (Connection.RPCEnabled)
            {
                RPC.ExecuteCMD(0, "statsReset");
            }
            else
            {

                MessageBox.Show("RPC Need to be enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FunctionsMethods.AllWeaponlvl31();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            UnlockAll.UnlockEliteCamo();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            RPC.ExecuteCMD(0, "prestigeReset");
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Prestige20Lvl80();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            ModdedClass();
        }
    }
}
