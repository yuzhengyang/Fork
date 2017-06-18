/*
 *   Mentalis.org Packet Monitor
 * 
 *     Copyright ?2003, The KPD-Team
 *     All rights reserved.
 *     http://www.mentalis.org/
 *
 *   Redistribution and use in source and binary forms, with or without
 *   modification, are permitted provided that the following conditions
 *   are met:
 *
 *     - Redistributions of source code must retain the above copyright
 *        notice, this list of conditions and the following disclaimer. 
 *
 *     - Neither the name of the KPD-Team, nor the names of its contributors
 *        may be used to endorse or promote products derived from this
 *        software without specific prior written permission. 
 *
 *   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 *   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 *   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
 *   THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 *   INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *   (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 *   SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 *   HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 *   STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 *   ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 *   OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Org.Mentalis.Network.PacketMonitor {
	public class PacketForm : System.Windows.Forms.Form {
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox RawText;
		private System.Windows.Forms.ColumnHeader InfoHeader;
		private System.Windows.Forms.ColumnHeader ValueHeader;
		private System.Windows.Forms.ListView InfoList;
		private System.ComponentModel.Container components = null;
		public PacketForm(Packet p) {
			if (p == null)
				throw new ArgumentNullException();
			// Required for Windows Form Designer support
			InitializeComponent();
			m_Packet = p;
		}
		protected override void Dispose( bool disposing ) {
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoList = new System.Windows.Forms.ListView();
            this.InfoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.RawText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InfoList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 224);
            this.panel1.TabIndex = 2;
            // 
            // InfoList
            // 
            this.InfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoHeader,
            this.ValueHeader});
            this.InfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoList.FullRowSelect = true;
            this.InfoList.GridLines = true;
            this.InfoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.InfoList.Location = new System.Drawing.Point(0, 0);
            this.InfoList.Name = "InfoList";
            this.InfoList.Size = new System.Drawing.Size(480, 224);
            this.InfoList.TabIndex = 0;
            this.InfoList.UseCompatibleStateImageBehavior = false;
            this.InfoList.View = System.Windows.Forms.View.Details;
            // 
            // InfoHeader
            // 
            this.InfoHeader.Text = "Information Type";
            this.InfoHeader.Width = 237;
            // 
            // ValueHeader
            // 
            this.ValueHeader.Text = "Value";
            this.ValueHeader.Width = 210;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 224);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(480, 9);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // RawText
            // 
            this.RawText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawText.Location = new System.Drawing.Point(0, 233);
            this.RawText.Multiline = true;
            this.RawText.Name = "RawText";
            this.RawText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RawText.Size = new System.Drawing.Size(480, 215);
            this.RawText.TabIndex = 4;
            // 
            // PacketForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(480, 448);
            this.Controls.Add(this.RawText);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PacketForm";
            this.Text = "Detailed Packet Information";
            this.Load += new System.EventHandler(this.PacketForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void PacketForm_Load(object sender, System.EventArgs e) {
			RawText.Text = m_Packet.ToString();
			InfoList.Items.Add(new ListViewItem(new string[] {"Time", m_Packet.Time.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Source", m_Packet.Source}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Destination", m_Packet.Destination}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Protocol", m_Packet.Protocol.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Time To Live", m_Packet.TimeToLive.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Version", m_Packet.Version.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Header Length", m_Packet.HeaderLength.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Precedence", m_Packet.Precedence.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Delay", m_Packet.Delay.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Throughput", m_Packet.Throughput.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Reliability", m_Packet.Reliability.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Total Length", m_Packet.TotalLength.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Identification", m_Packet.Identification.ToString()}));
			InfoList.Items.Add(new ListViewItem(new string[] {"Checksum", m_Packet.Checksum[0].ToString("X2") + m_Packet.Checksum[1].ToString("X2")}));
		}
		private Packet m_Packet;
	}
}