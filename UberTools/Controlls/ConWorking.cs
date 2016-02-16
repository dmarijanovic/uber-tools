using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NTHTools.Controlls
{
    public partial class ConWorking : UserControl
    {
        private delegate void delWorking_thread(bool enabled, object timer);
        private DateTime status_StartTime;
        private string title = "Working...";
        private string description = "";
        public ConWorking()
        {
            InitializeComponent();
        }
        public void Bound()
        {
            Main frm = (Main)this.ParentForm;
            frm.Resize += new EventHandler(FrmParent_Resize);
        }

        void FrmParent_Resize(object sender, EventArgs e)
        {
            Main frm = (Main)sender;
            this.Location = new Point((frm.Width / 2) - (this.Width / 2), (frm.Height / 2) - (this.Height / 2));
        }
        public void StatusChange(bool enabled, object description)
        {
            if (enabled)
            {
                if (description != null)
                {
                    this.description = (string)description;
                    SetDescription();
                }
                if(status_StartTime == DateTime.MinValue)
                {
                    // Prvi ulaz - setira vrijeme, prikazuje pnlWorking, stavlja poruku
                    status_StartTime = DateTime.Now.AddMilliseconds(1000);
                    Thread thr = new Thread(Status_Timer);
                    thr.Start();
                }
            }
            else
            {
                status_StartTime = DateTime.MinValue;
            }
        }
        public void SetDescription()
        {
            lblDescription.Text = this.description;
            Application.DoEvents();
        }
        private void Status_Timer()
        {
            do
            {
                if (status_StartTime <= DateTime.Now)
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new delWorking_thread(Status_Dialog), true, null);
                    }
                    else
                    {
                        Status_Dialog(true, null);
                    }
                    Thread thrAnimate = new Thread(Status_Animate);
                    thrAnimate.Start();
                    break;
                }
                Application.DoEvents();
                Thread.Sleep(200);
            } while (status_StartTime != DateTime.MinValue);
        }
        private void Status_Animate()
        {
            TimeSpan time;
            do
            {
                time = DateTime.Now - status_StartTime;
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new delWorking_thread(Status_Dialog), true, time.TotalSeconds.ToString("##") + "sec");
                }
                Application.DoEvents();
                Thread.Sleep(200);
            } while (status_StartTime != DateTime.MinValue);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new delWorking_thread(Status_Dialog), false, null);
            }
            else
            {
                Status_Dialog(false, null);
            }
        }
        private void Status_Dialog(bool enabled, object timer)
        {
            if (description != null)
            {
                this.SetDescription();
            }
            if (timer != null)
            {
                lblTitle.Text = title + timer;
            }
            this.Visible = enabled;
        }
    }
}
