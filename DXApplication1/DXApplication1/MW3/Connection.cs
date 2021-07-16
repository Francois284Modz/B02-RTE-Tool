using DevExpress.XtraEditors;
using PS3Lib;
using System;
using System.Windows.Forms;

namespace DXApplication1
{

    public class Connection
    {

        /// <summary>
        /// Connecter a la PS3
        /// 0 = CCAPI 1= TMAPI
        /// Str = Nom du Tool 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str"></param>
        public static void ConnectPS3(int value, string str)
        {
            switch (value)
            {
                case 0:
                   
                    if (PS3.ConnectTarget(0))
                    {
                        IsConnected = true;
                        CCAPI.RingBuzzer(CCAPI.BuzzerMode.Single);
                        XtraMessageBox.Show("PS3 Connected with Success to " + str, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        IsConnected = false;
                        XtraMessageBox.Show("Something was wrong \n\r Ps3 is not connected ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 1:
        
                    if (PS3.ConnectTarget())
                    {
                        IsConnected = true;
                        CCAPI.RingBuzzer(CCAPI.BuzzerMode.Single);
                        XtraMessageBox.Show("PS3 Connected with Success to " + str, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        IsConnected = false;
                        XtraMessageBox.Show("Something was wrong \n\r Ps3 is not connected ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        /// <summary>
        /// Permet de selectioner lapi
        /// CCAPI = 0 TMAPI = 1 
        /// </summary>
        /// <param name="v"></param>
        public static void SelectControlApi(int v)
        {
            switch (v)
            {
                case 0:
                    PS3.ChangeAPI(SelectAPI.ControlConsole);
                    break;
                case 1:
                    PS3.ChangeAPI(SelectAPI.TargetManager);
                    break;
            }
        }

        /// <summary>
        /// Attacher a la PS3
        /// Str = Nom du Tool
        /// </summary>
        /// <param name="str"></param>
        public static void AttacherPS3(string str)
        {
            if (PS3.AttachProcess())
            {
                IsAttached = true;
                MessageBox.Show("PS3 Attached With success to " + str, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);
                CCAPI.Notify(CCAPI.NotifyIcon.TROPHY4, "PS3 Attached to " + str);
                DialogResult rs = MessageBox.Show("Do you wish to enable RPC\nSome mods require rpc to be enable", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rs == DialogResult.Yes)
                {
                    RPC.Enable();
                    MessageBox.Show("RPC Enabled");
                   RPCEnabled = true;
                }
            }
            else
            {
                IsAttached = false;
               MessageBox.Show("Something was wrong \n\r Ps3 is not Attached ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Deconnecter de la PS3
        /// </summary>
        public static void Disconnect()
        {
            IsConnected = false;
            IsAttached = false;
            IsDeconnected = true;
            RPCEnabled = false;
                PS3.DisconnectTarget();
                MessageBox.Show("PS3 Decconected with success","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
          
        }


        /// <summary>
        ///
        ///Verifier que vous etre bien connecter
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnection()
        {
            bool flag = false;
            try
            {
                flag = PS3.Extension.ReadString(65536U).Contains("ELF");
            }
            catch (Exception)
            {
                flag = false;
            }
            Connection.IsConnected = flag;
            Connection.IsAttached = flag;
            return flag;
        }


        public static bool IsConnected = false;

        public static bool RPCEnabled = false;
        public static bool IsAttached = false;

        public static bool IsDeconnected = false;

        public static PS3API PS3 = new PS3API();
        public static CCAPI CCAPI = new CCAPI();
    }
}
