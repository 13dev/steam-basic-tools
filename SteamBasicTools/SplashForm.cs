using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamBasicTools
{
	public partial class SplashForm : Form
	{
		public Form1 form;

		public SplashForm()
		{
			InitializeComponent();
		}

		private void SplashForm_Load(object sender, EventArgs e)
		{
		}

		private void timerLoad_Tick(object sender, EventArgs e)
		{
			if (form == null)
			{
				form = new Form1();
				form.ShowDialog();

			}else
			{
				this.Visible = false;
				timerLoad.Stop();
			}
			
		}
	}
}
