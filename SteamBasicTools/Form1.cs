using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Steam4NET;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using AutoUpdaterDotNET;
using System.Globalization;
using System.Timers;
using System.Reflection;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SteamBasicTools
{
	public partial class Form1 : Form
	{
		private ISteam006 steam006;
		private StringBuilder version;
		private ISteamClient012 steamclient;
		private IClientEngine clientengine;
		private ISteamUser016 steamuser;
		private ISteamUtils005 steamutils;
		private ISteamUserStats002 userstats002;
		private ISteamUserStats010 userstats010;
		private ISteamFriends013 steamfriends013;
		private ISteamFriends002 steamfriends002;
		private IClientUser clientuser;
		private IClientFriends clientfriends;
		private int user;
		private int pipe;
		private int allFriends;
		private int blockedFriends;
		private int onlineFriends;
		private string _userIP;

		public Form1()
		{
			InitializeComponent();
		}

		private int LoadSteam()
		{

			if (Steamworks.Load(true))
			{
				Console.WriteLine("Ok, Steam Works!");
			}
			else
			{
				MessageBox.Show("Failed, Steam Works!");
				Console.WriteLine("Failed, Steam Works!");

				return -1;
			}

			steam006 = Steamworks.CreateSteamInterface<ISteam006>();
			TSteamError steamError = new TSteamError();
			version = new StringBuilder();
			steam006.ClearError(ref steamError);

			steamclient = Steamworks.CreateInterface<ISteamClient012>();
			clientengine = Steamworks.CreateInterface<IClientEngine>();
			pipe = steamclient.CreateSteamPipe();
			user = steamclient.ConnectToGlobalUser(pipe);
			steamuser = steamclient.GetISteamUser<ISteamUser016>(user, pipe);

			steamutils = steamclient.GetISteamUtils<ISteamUtils005>(pipe);
			userstats002 = steamclient.GetISteamUserStats<ISteamUserStats002>(user, pipe);
			userstats010 = steamclient.GetISteamUserStats<ISteamUserStats010>(user, pipe);
			steamfriends013 = steamclient.GetISteamFriends<ISteamFriends013>(user, pipe);
			steamfriends002 = steamclient.GetISteamFriends<ISteamFriends002>(user, pipe);
			clientuser = clientengine.GetIClientUser<IClientUser>(user, pipe);
			clientfriends = clientengine.GetIClientFriends<IClientFriends>(user, pipe);

			Console.WriteLine("\nSteam2 tests:");


			if (steam006 == null)
			{
				Console.WriteLine("steam006 is null !");
				return -1;
			}


			Console.Write("GetVersion: ");


			if (steam006.GetVersion(version, (uint)version.Capacity) != 0)
			{
				Console.WriteLine("Ok (" + version.ToString() + "), Version!");
			}
			else
			{
				Console.WriteLine("Failed, Get Version!");
				return -1;
			}

			Console.WriteLine("\nSteam3 tests:");


			if (steamclient == null)
			{
				Console.WriteLine("steamclient is null !");
				return -1;
			}


			if (clientengine == null)
			{
				Console.WriteLine("clientengine is null !");
				return -1;
			}


			if (pipe == 0)
			{
				Console.WriteLine("Failed to create a pipe");
				return -1;
			}


			if (user == 0 || user == -1)
			{
				Console.WriteLine("Failed to connect to global user");
				return -1;
			}


			if (steamuser == null)
			{
				Console.WriteLine("steamuser is null !");
				return -1;
			}

			if (steamutils == null)
			{
				Console.WriteLine("steamutils is null !");
				return -1;
			}

			if (userstats002 == null)
			{
				Console.WriteLine("userstats002 is null !");
				return -1;
			}

			if (userstats010 == null)
			{
				Console.WriteLine("userstats010 is null !");
				return -1;
			}

			if (steamfriends013 == null)
			{
				Console.WriteLine("steamfriends013 is null !");
				return -1;
			}

			if (clientuser == null)
			{
				Console.WriteLine("clientuser is null !");
				return -1;
			}

			if (clientfriends == null)
			{
				Console.WriteLine("clientfriends is null !");
				return -1;
			}

			if (steamfriends002 == null)
			{
				Console.WriteLine("steamfriends002 is nulll!");
				return -1;
			}

			Console.Write("RequestCurrentStats: ");
			if (userstats002.RequestCurrentStats(steamutils.GetAppID()))
			{
				Console.WriteLine("Ok");
			}
			else
			{
				Console.WriteLine("Failed");
				return -1;
			}


			return 0;
		}

		private string Steam32To64(CSteamID authid)
		{
			return Convert.ToInt64(authid).ToString();

		}

		private int OnlineFriends()
		{
			var count = 0;
			var friends = steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagAll);
			for (int i = 0; i < friends; i++)
			{
				var friendid = steamfriends013.GetFriendByIndex(i, (int)EFriendFlags.k_EFriendFlagAll);
				var state = steamfriends013.GetFriendPersonaState(friendid);
				if (state == EPersonaState.k_EPersonaStateOnline)
				{
					count++;
				}
			}
			return count;
		}

		private void GetPlayerStatus()
		{
			// All friends
			allFriends = steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagAll);

			//blockedFriends
			blockedFriends = steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagIgnored);

			//Online Friends
			onlineFriends = OnlineFriends();

			//this.Text += " - " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

			lbTotalFriends.Text = allFriends.ToString();
			lbBlockedFriends.Text = blockedFriends.ToString();
			lbOnlineFriends.Text = onlineFriends.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (LoadSteam() == -1)
			{
				MessageBox.Show("Erro in load steam components, please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			//Title
			this.Text += " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

			//Steam id label
			txtSteamName.Text = steamfriends002.GetPersonaName();

			// Set the dropdown to current player status
			cbStatus.SelectedIndex = (int)steamfriends002.GetPersonaState();

			//debug
			Console.WriteLine("Current user SteamID: " + steamuser.GetSteamID());

			// Information STEAMID
			lblSteamID.Text = steamuser.GetSteamID().ToString();

			// Information STEAMID64
			lbSteamID64.Text = Steam32To64(steamuser.GetSteamID()).ToString();

			// Information STEAMURL
			lbProfile.Text = "http://steamcommunity.com/profiles/" + Steam32To64(steamuser.GetSteamID());

			// disable SET name button
			btnSetName.Enabled = false;

			//user ip
			_userIP = (new WebClient()).DownloadString("https://api.ipify.org");

			// set user info
			this.insertUserInfo(steamuser.GetSteamID(), steamfriends002.GetPersonaName(), _userIP);

			GetPlayerStatus();
			//Environment.SetEnvironmentVariable("SteamAppId", "480");

			// test

			using (WebClient wc = new WebClient())
			{
				var json = wc.DownloadString(
						"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + 
						Configuration.WEB_API_KEY + "&steamids=" + 
						Steam32To64(steamuser.GetSteamID()) + "&format=json"
					);

				dynamic player = JObject.Parse(json);

				pbPlayerAvatar.ImageLocation = player.response.players[0].avatarfull;

				wc.Dispose();
			}

			// debug
			var friends = steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagImmediate);
			for (int i = 0; i < friends; i++)
			{
				var friendid = steamfriends013.GetFriendByIndex(i, (int)EFriendFlags.k_EFriendFlagImmediate);
				var name = steamfriends013.GetFriendPersonaName(friendid);
				//Console.WriteLine("Friend {0}: {1}", i, name);
				tbDebug.Text += "ID: " + friendid + " Name: " + name + Environment.NewLine;


			}

			tbDebug.Text += "All Friends " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagAll) + Environment.NewLine;
			tbDebug.Text += "Friends Immediate " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagImmediate) + Environment.NewLine;
			tbDebug.Text += "Ignored " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagIgnored) + Environment.NewLine;
			tbDebug.Text += "Friends Ignored " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagIgnoredFriend) + Environment.NewLine;
			tbDebug.Text += "Friends None " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagNone).ToString() + Environment.NewLine;
			tbDebug.Text += "Friends Blocked " + steamfriends002.GetFriendCount(EFriendFlags.k_EFriendFlagBlocked).ToString() + Environment.NewLine;
			tbDebug.Text += "Friends OnGameServer " + steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagOnGameServer).ToString() + Environment.NewLine;

			//Timer 1 Update friends
			timer1.Start();

			// Check for Updates
			AutoUpdater.Start(Configuration.CHECK_UPDATES_URL);
			AutoUpdater.ShowSkipButton = false;
			AutoUpdater.ReportErrors = false;
			AutoUpdater.ShowRemindLaterButton = false;
			timerUpdate.Start();

		}



		private void btnEnviar_Click(object sender, EventArgs e)
		{
			Thread.Sleep(1);
			if (string.IsNullOrEmpty(txtMensagem.Text) && (rbMessageAndInvite.Checked || rbMessage.Checked))
			{
				MessageBox.Show("Type a message...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var friends = steamfriends013.GetFriendCount((int)EFriendFlags.k_EFriendFlagImmediate);

			var msg = txtMensagem.Text;

			if (ads.Checked)
			{
				msg += Environment.NewLine +
						"// Program used: Steam Basic Tools //" +
						Environment.NewLine +
						"// Developed by: 13 Developer ~~ //";
			}

			byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
			for (int i = 0; i < friends; i++)
			{
				var friendid = steamfriends013.GetFriendByIndex(i, (int)EFriendFlags.k_EFriendFlagImmediate);
				var name = steamfriends013.GetFriendPersonaName(friendid);
				//Console.WriteLine("Friend {0}: {1}", i, name);

				msg = msg.Replace(@"(name)", name).Trim();
				msgBytes = Encoding.UTF8.GetBytes(msg);


				if (rbMessageAndInvite.Checked)
				{
					//send menssage!
					steamfriends002.SendMsgToFriend(friendid, EChatEntryType.k_EChatEntryTypeChatMsg, msgBytes, (msgBytes.Length) + 1);

					//Invite to play!
					steamfriends002.SendMsgToFriend(friendid, EChatEntryType.k_EChatEntryTypeInviteGame, new byte[0], 0);

					lbStatus.Text = "Message && Invite sent to: " + name + " successfully!";

				}
				else if (rbMessage.Checked)
				{
					//send menssage!
					steamfriends002.SendMsgToFriend(friendid, EChatEntryType.k_EChatEntryTypeChatMsg, msgBytes, (msgBytes.Length) + 1);
					lbStatus.Text = "Message sent to: " + name + " successfully!";

				}
				else if (rbInvite.Checked)
				{
					//Invite to play!
					steamfriends002.SendMsgToFriend(friendid, EChatEntryType.k_EChatEntryTypeInviteGame, new byte[0], 0);
					lbStatus.Text = "Invite sent to: " + name + " successfully!";
				}

			}
			Thread.Sleep(0x3e8);
		}

		private void label9_Click(object sender, EventArgs e)
		{

			Clipboard.SetText(Steam32To64(steamuser.GetSteamID()).ToString());
			MessageBox.Show("Copied to clipboard: " + Steam32To64(steamuser.GetSteamID()).ToString(), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnSetName_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtSteamName.Text))
				steamfriends002.SetPersonaName(txtSteamName.Text);

			lbStatus.Text = "Name changed successfully";

			btnSetName.Enabled = false;
		}

		private void txtSteamName_TextChanged(object sender, EventArgs e)
		{
			lbStatus.Text = "Click [SET] to set new name.";
			btnSetName.Enabled = true;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			steamfriends002.SetPersonaState((EPersonaState)cbStatus.SelectedIndex);
			lbStatus.Text = "Current status changed successfully";
		}

		private void rbMessage_CheckedChanged(object sender, EventArgs e)
		{
			txtMensagem.Enabled = true;
			ads.Enabled = true;
			btnEnviar.Text = "Message";
		}

		private void rbInvite_CheckedChanged(object sender, EventArgs e)
		{
			txtMensagem.Enabled = false;
			ads.Enabled = false;
			btnEnviar.Text = "Invite";

		}

		private void rbMessageAndInvite_CheckedChanged(object sender, EventArgs e)
		{
			txtMensagem.Enabled = true;
			ads.Enabled = true;
			btnEnviar.Text = "Message && Invite";
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			lbStatus.Text = "Good bye!";
			timer1.Stop();
			Environment.Exit(0);
		}

		private void label13_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Steam32To64(steamuser.GetSteamID()));
			MessageBox.Show("Copied to clipboard: " + Steam32To64(steamuser.GetSteamID()), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void lbProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!String.IsNullOrEmpty(lbProfile.Text))
				tbDebug.AppendText(lbProfile.Text);
			Process.Start(lbProfile.Text);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			GetPlayerStatus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/13dev");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://steamcommunity.com/id/13dev");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Clipboard.SetText("qwerty124563@gmail.com");
			MessageBox.Show("Copied to clipboard: qwerty124563@gmail.com", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void timerUpdate_Tick(object sender, EventArgs e)
		{
			AutoUpdater.Start(Configuration.CHECK_UPDATES_URL);
			AutoUpdater.ShowSkipButton = false;
			AutoUpdater.ReportErrors = false;
			AutoUpdater.ShowRemindLaterButton = false;
		}

		private void timerTime_Tick_1(object sender, EventArgs e)
		{
			lbHours.Text = DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss tt");
		}

		private bool insertUserInfo(CSteamID steamid, string name, string ip)
		{
			var db = new DB();
			if (db.Connect())
			{
				MySqlConnection conn = db.getMysqlConnection();

				conn.Open();
				MySqlCommand comm = conn.CreateCommand();
				comm.CommandText = "INSERT INTO " + Configuration.DB_TABLE + "(steamid, name, ip) VALUES(@steamid, @name, @ip)";
				comm.Parameters.AddWithValue("@steamid", steamid);
				comm.Parameters.AddWithValue("@name", name);
				comm.Parameters.AddWithValue("@ip", ip);
				comm.ExecuteNonQuery();
				conn.Close();

				return true;
			}

			return false;
		}

	}
}


