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
using _3080ReleaseTool.Models;

//NSOMNIC

namespace _3080ReleaseTool
{
    public partial class Main : Form
    {
        private int OldQuantUK = 5000000;
        private int OldQuantUS = 5000000;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateProductQty();
        }

        private void UpdateProductQty()
        {
            


            RequestTool requestTool = new RequestTool();

            string time = DateTime.Now.ToString("hh:mm:ss");
            RegionQuantities quantities = requestTool.GetStockLevels();

            int ukQty = quantities.UK;
            int usQty = quantities.US;

            if((ukQty > OldQuantUK) || (usQty > OldQuantUS))
            {
                this.browser.Visible = true;
                Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.nvidia.com/en-gb/geforce/graphics-cards/30-series/rtx-3080/");
            }

            OldQuantUK = ukQty;
            OldQuantUS = usQty;


            txtQtyUk.Text = ukQty.ToString();
            txtQtyUs.Text = usQty.ToString();

            lbLogs.Items.Add("[" + time + "]" + "UK Stock: " + ukQty + " " + "US Stock: " + usQty + ".");
        }

        private void btnManualUpdate_Click(object sender, EventArgs e)
        {
            UpdateProductQty();
        }

        private void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            if(cbAutoRefresh.Checked)
            {
                UpdateProductQty();
            }
        }

        private void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if(cbAutoRefresh.Checked)
            {
                tmrAutoRefresh.Start();
                lbLogs.Items.Add("Auto Refresh Started");
            }
            else
            {
                tmrAutoRefresh.Stop();
                lbLogs.Items.Add("Auto Refresh Stopped");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.nvidia.com/en-gb/geforce/graphics-cards/30-series/rtx-3080/");
        }
    }
}
