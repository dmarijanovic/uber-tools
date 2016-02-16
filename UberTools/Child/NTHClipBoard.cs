using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using System.Threading;
using System.Web;

namespace NTHTools
{
    public partial class NTHClipBoard : ChildBase
    {
        private const string constSubservice_SaveCB = "SaveData";
        private NTHTools.Child.NTHClipBoardFlyWindow clipBoardFlyForm;
        private DateTime lastClipBoardCatch = DateTime.MinValue;
        public NTHClipBoard()
        {
            InitializeComponent();
            HookManager.KeyDown += new KeyEventHandler(HookManager_KeyDown);
            HookManager.KeyUp += new KeyEventHandler(HookManager_KeyUp);
            clipBoardFlyForm = new NTHTools.Child.NTHClipBoardFlyWindow();
            clipBoardFlyForm.Items.Added += new ClipBoardData.OnAddEventHandler(Items_Added);
            this.LoadData();
        }

        private void Items_Added(ClipBoardData.ClipBoardStruct data)
        {
            tbxLog.AppendText(string.Format(" - {0} -\r\n {1} \r\n\r\n", DateTime.Now.ToLocalTime(), data.GetStringFromData()));
        }
        /// <summary>
        /// Prikazi FlyWindows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if ((!e.Control || e.KeyCode == Keys.Oemtilde) && clipBoardFlyForm.Visible)
            {
                clipBoardFlyForm.Visible = false;
            }
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Control  && e.KeyCode == Keys.Oemtilde) && !clipBoardFlyForm.Visible)
            {
                clipBoardFlyForm.Refresh_Names();
                clipBoardFlyForm.SelectActive();
                clipBoardFlyForm.TopMost = true;
                clipBoardFlyForm.Show();
                
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Thread.Sleep(500);
                //if (this.lastClipBoardCatch.AddMilliseconds(500) < DateTime.Now)
                //{
                    this.lastClipBoardCatch = DateTime.Now;
                    clipBoardFlyForm.Work();
                //}
            }
        }

        private void NTHClipBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            HookManager.KeyDown -= HookManager_KeyDown;
            this.SaveData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void SaveData()
        {
            MySettings mySettings = new MySettings(this.Name, Static.constSettingFileName);
            // Uklanja prijasnje postavke
            mySettings.DeleteSubservice(constSubservice_SaveCB);
            foreach (ClipBoardData.ClipBoardStruct data in clipBoardFlyForm.Items)
            {
                if (data.save)
                {
                    mySettings.Write("", HttpUtility.UrlEncode(data.GetStringFromData()), constSubservice_SaveCB);
                    mySettings.Save();
                }
            }
        }
        private void LoadData()
        {
            MySettings mySettings = new MySettings(this.Name, Static.constSettingFileName);

            //foreach (string item in mySettings.GetEnumerator())
            //{
                
            //}
        }
    }
}
