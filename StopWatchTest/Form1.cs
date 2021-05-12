using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatchTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBeginWatch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(textBox1.Text.Trim());
                Func<DateTime> func = () =>
                {
                    System.Threading.Thread.Sleep(1500);//模拟网络耗时
                    return dateTime;
                };
                TimeWatch.GetInstance(func,TimeSpan.FromSeconds(3));

                Timer timer = new Timer();
                timer.Enabled = true;
                timer.Interval = 100;
                timer.Start();
                timer.Tick += (s, ee) =>
                {
                    this.labelNowTime.Text = TimeWatch.DateTimeNow.ToString("yyyy-MM-dd HH:mm:ss fff");
                };
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }
    }
}
