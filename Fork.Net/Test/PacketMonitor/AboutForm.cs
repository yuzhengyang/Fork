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
using System.Reflection;

namespace Org.Mentalis.Network.PacketMonitor {
	public class AboutForm : System.Windows.Forms.Form {
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.Label InfoLabel;
		private System.Windows.Forms.Label ImageLabel;
		private System.ComponentModel.Container components = null;

		public AboutForm() {
			// Required for Windows Form Designer support
			InitializeComponent();
		}
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
			this.TitleLabel = new System.Windows.Forms.Label();
			this.VersionLabel = new System.Windows.Forms.Label();
			this.InfoLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ImageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TitleLabel.Location = new System.Drawing.Point(88, 24);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(216, 32);
			this.TitleLabel.TabIndex = 1;
			this.TitleLabel.Text = "Packet Monitor";
			// 
			// VersionLabel
			// 
			this.VersionLabel.Location = new System.Drawing.Point(96, 56);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(176, 16);
			this.VersionLabel.TabIndex = 2;
			this.VersionLabel.Text = "Version x.y";
			this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// InfoLabel
			// 
			this.InfoLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.InfoLabel.Location = new System.Drawing.Point(40, 80);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(320, 72);
			this.InfoLabel.TabIndex = 3;
			this.InfoLabel.Text = "- Mentalis.org Packet Monitor -";
			this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(280, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			// 
			// ImageLabel
			// 
			this.ImageLabel.Image = ((System.Drawing.Bitmap)(resources.GetObject("ImageLabel.Image")));
			this.ImageLabel.Location = new System.Drawing.Point(16, 16);
			this.ImageLabel.Name = "ImageLabel";
			this.ImageLabel.Size = new System.Drawing.Size(48, 64);
			this.ImageLabel.TabIndex = 5;
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(378, 216);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ImageLabel,
																		  this.button1,
																		  this.InfoLabel,
																		  this.VersionLabel,
																		  this.TitleLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Mentalis.org Packet Monitor...";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.ResumeLayout(false);

		}
		#endregion
		private void AboutForm_Load(object sender, System.EventArgs e) {
			VersionLabel.Text = "Version " + Assembly.GetCallingAssembly().GetName().Version.ToString(3);
			InfoLabel.Text = "- Mentalis.org Packet Monitor -\r\n-written by the Mentalis.org Team, ?2003 -\r\n- visit our website at http://www.mentalis.org/ -\r\n- or email us at info@mentalis.org -";
		}
	}
}