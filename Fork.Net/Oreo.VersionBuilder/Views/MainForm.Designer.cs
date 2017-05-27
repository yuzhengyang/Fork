namespace Oreo.VersionBuilder.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TbVersionDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbVersionNumber = new System.Windows.Forms.TextBox();
            this.TbCodeName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DgFileList = new System.Windows.Forms.DataGridView();
            this.TbPluginEntry = new System.Windows.Forms.TextBox();
            this.TbPluginName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TbServerPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TbAfterUpdateKillProcess = new System.Windows.Forms.TextBox();
            this.TbAfterUpdateStartProcess = new System.Windows.Forms.TextBox();
            this.TbBeforeUpdateKillProcess = new System.Windows.Forms.TextBox();
            this.TbBeforeUpdateStartProcess = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MsMain = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成配置到指定目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.打开默认配置目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsslRunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.PnMain = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtClear = new System.Windows.Forms.Button();
            this.BtImport = new System.Windows.Forms.Button();
            this.BtAddFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClFileListServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClFileListLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClFileListMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClFileListClean = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgFileList)).BeginInit();
            this.MsMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PnMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbVersionDesc
            // 
            this.TbVersionDesc.Location = new System.Drawing.Point(99, 97);
            this.TbVersionDesc.Multiline = true;
            this.TbVersionDesc.Name = "TbVersionDesc";
            this.TbVersionDesc.Size = new System.Drawing.Size(367, 149);
            this.TbVersionDesc.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "版本描述：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "版本号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "更新代号：";
            // 
            // TbVersionNumber
            // 
            this.TbVersionNumber.Location = new System.Drawing.Point(101, 62);
            this.TbVersionNumber.Name = "TbVersionNumber";
            this.TbVersionNumber.Size = new System.Drawing.Size(215, 21);
            this.TbVersionNumber.TabIndex = 13;
            // 
            // TbCodeName
            // 
            this.TbCodeName.Location = new System.Drawing.Point(101, 27);
            this.TbCodeName.Name = "TbCodeName";
            this.TbCodeName.Size = new System.Drawing.Size(215, 21);
            this.TbCodeName.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "更新文件列表：";
            // 
            // DgFileList
            // 
            this.DgFileList.AllowUserToAddRows = false;
            this.DgFileList.AllowUserToResizeColumns = false;
            this.DgFileList.AllowUserToResizeRows = false;
            this.DgFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgFileList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgFileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClFileListServer,
            this.ClFileListLocal,
            this.ClFileListMD5,
            this.ClFileListClean});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgFileList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgFileList.Location = new System.Drawing.Point(20, 142);
            this.DgFileList.Name = "DgFileList";
            this.DgFileList.RowHeadersVisible = false;
            this.DgFileList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgFileList.RowTemplate.Height = 23;
            this.DgFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgFileList.Size = new System.Drawing.Size(521, 416);
            this.DgFileList.TabIndex = 29;
            // 
            // TbPluginEntry
            // 
            this.TbPluginEntry.Location = new System.Drawing.Point(155, 84);
            this.TbPluginEntry.Name = "TbPluginEntry";
            this.TbPluginEntry.Size = new System.Drawing.Size(213, 21);
            this.TbPluginEntry.TabIndex = 28;
            // 
            // TbPluginName
            // 
            this.TbPluginName.Location = new System.Drawing.Point(155, 56);
            this.TbPluginName.Name = "TbPluginName";
            this.TbPluginName.Size = new System.Drawing.Size(213, 21);
            this.TbPluginName.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "插件入口文件：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "插件名称：";
            // 
            // TbServerPath
            // 
            this.TbServerPath.Location = new System.Drawing.Point(155, 28);
            this.TbServerPath.Name = "TbServerPath";
            this.TbServerPath.Size = new System.Drawing.Size(213, 21);
            this.TbServerPath.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "服务器文件根目录：";
            // 
            // TbAfterUpdateKillProcess
            // 
            this.TbAfterUpdateKillProcess.Location = new System.Drawing.Point(135, 240);
            this.TbAfterUpdateKillProcess.Multiline = true;
            this.TbAfterUpdateKillProcess.Name = "TbAfterUpdateKillProcess";
            this.TbAfterUpdateKillProcess.Size = new System.Drawing.Size(242, 51);
            this.TbAfterUpdateKillProcess.TabIndex = 24;
            // 
            // TbAfterUpdateStartProcess
            // 
            this.TbAfterUpdateStartProcess.Location = new System.Drawing.Point(135, 171);
            this.TbAfterUpdateStartProcess.Multiline = true;
            this.TbAfterUpdateStartProcess.Name = "TbAfterUpdateStartProcess";
            this.TbAfterUpdateStartProcess.Size = new System.Drawing.Size(242, 51);
            this.TbAfterUpdateStartProcess.TabIndex = 23;
            // 
            // TbBeforeUpdateKillProcess
            // 
            this.TbBeforeUpdateKillProcess.Location = new System.Drawing.Point(135, 102);
            this.TbBeforeUpdateKillProcess.Multiline = true;
            this.TbBeforeUpdateKillProcess.Name = "TbBeforeUpdateKillProcess";
            this.TbBeforeUpdateKillProcess.Size = new System.Drawing.Size(242, 51);
            this.TbBeforeUpdateKillProcess.TabIndex = 22;
            // 
            // TbBeforeUpdateStartProcess
            // 
            this.TbBeforeUpdateStartProcess.Location = new System.Drawing.Point(135, 33);
            this.TbBeforeUpdateStartProcess.Multiline = true;
            this.TbBeforeUpdateStartProcess.Name = "TbBeforeUpdateStartProcess";
            this.TbBeforeUpdateStartProcess.Size = new System.Drawing.Size(242, 51);
            this.TbBeforeUpdateStartProcess.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "更新后关闭进程：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "更新后启动进程：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "更新前关闭进程：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "更新前启动进程：";
            // 
            // MsMain
            // 
            this.MsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.生成ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MsMain.Location = new System.Drawing.Point(0, 0);
            this.MsMain.Name = "MsMain";
            this.MsMain.Size = new System.Drawing.Size(584, 25);
            this.MsMain.TabIndex = 24;
            this.MsMain.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成配置ToolStripMenuItem,
            this.生成配置到指定目录ToolStripMenuItem,
            this.toolStripSeparator2,
            this.打开默认配置目录ToolStripMenuItem});
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            this.生成ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.生成ToolStripMenuItem.Text = "生成";
            // 
            // 生成配置ToolStripMenuItem
            // 
            this.生成配置ToolStripMenuItem.Name = "生成配置ToolStripMenuItem";
            this.生成配置ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.生成配置ToolStripMenuItem.Text = "生成配置";
            this.生成配置ToolStripMenuItem.Click += new System.EventHandler(this.生成配置ToolStripMenuItem_Click);
            // 
            // 生成配置到指定目录ToolStripMenuItem
            // 
            this.生成配置到指定目录ToolStripMenuItem.Name = "生成配置到指定目录ToolStripMenuItem";
            this.生成配置到指定目录ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.生成配置到指定目录ToolStripMenuItem.Text = "生成配置到指定目录";
            this.生成配置到指定目录ToolStripMenuItem.Click += new System.EventHandler(this.生成配置到指定目录ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // 打开默认配置目录ToolStripMenuItem
            // 
            this.打开默认配置目录ToolStripMenuItem.Name = "打开默认配置目录ToolStripMenuItem";
            this.打开默认配置目录ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开默认配置目录ToolStripMenuItem.Text = "打开默认配置目录";
            this.打开默认配置目录ToolStripMenuItem.Click += new System.EventHandler(this.打开默认配置目录ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TsslRunStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态：";
            // 
            // TsslRunStatus
            // 
            this.TsslRunStatus.Name = "TsslRunStatus";
            this.TsslRunStatus.Size = new System.Drawing.Size(108, 17);
            this.TsslRunStatus.Text = "ready to building";
            // 
            // PnMain
            // 
            this.PnMain.AutoScroll = true;
            this.PnMain.Controls.Add(this.groupBox3);
            this.PnMain.Controls.Add(this.groupBox2);
            this.PnMain.Controls.Add(this.groupBox1);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnMain.Location = new System.Drawing.Point(0, 25);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(584, 564);
            this.PnMain.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TbBeforeUpdateStartProcess);
            this.groupBox3.Controls.Add(this.TbAfterUpdateKillProcess);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TbAfterUpdateStartProcess);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TbBeforeUpdateKillProcess);
            this.groupBox3.Location = new System.Drawing.Point(3, 901);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 332);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他操作";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtClear);
            this.groupBox2.Controls.Add(this.BtImport);
            this.groupBox2.Controls.Add(this.BtAddFile);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.DgFileList);
            this.groupBox2.Controls.Add(this.TbServerPath);
            this.groupBox2.Controls.Add(this.TbPluginEntry);
            this.groupBox2.Controls.Add(this.TbPluginName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(3, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 577);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件清单";
            // 
            // BtClear
            // 
            this.BtClear.Location = new System.Drawing.Point(466, 115);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(75, 23);
            this.BtClear.TabIndex = 33;
            this.BtClear.Text = "清空";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // BtImport
            // 
            this.BtImport.Location = new System.Drawing.Point(304, 115);
            this.BtImport.Name = "BtImport";
            this.BtImport.Size = new System.Drawing.Size(75, 23);
            this.BtImport.TabIndex = 32;
            this.BtImport.Text = "批量导入";
            this.BtImport.UseVisualStyleBackColor = true;
            this.BtImport.Click += new System.EventHandler(this.BtImport_Click);
            // 
            // BtAddFile
            // 
            this.BtAddFile.Location = new System.Drawing.Point(385, 115);
            this.BtAddFile.Name = "BtAddFile";
            this.BtAddFile.Size = new System.Drawing.Size(75, 23);
            this.BtAddFile.TabIndex = 31;
            this.BtAddFile.Text = "添加文件";
            this.BtAddFile.UseVisualStyleBackColor = true;
            this.BtAddFile.Click += new System.EventHandler(this.BtAddFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbVersionDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TbCodeName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TbVersionNumber);
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 266);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "版本概述";
            // 
            // ClFileListServer
            // 
            this.ClFileListServer.FillWeight = 35F;
            this.ClFileListServer.HeaderText = "服务器路径";
            this.ClFileListServer.Name = "ClFileListServer";
            // 
            // ClFileListLocal
            // 
            this.ClFileListLocal.FillWeight = 35F;
            this.ClFileListLocal.HeaderText = "本地路径";
            this.ClFileListLocal.Name = "ClFileListLocal";
            // 
            // ClFileListMD5
            // 
            this.ClFileListMD5.FillWeight = 20F;
            this.ClFileListMD5.HeaderText = "MD5";
            this.ClFileListMD5.Name = "ClFileListMD5";
            // 
            // ClFileListClean
            // 
            this.ClFileListClean.FillWeight = 10F;
            this.ClFileListClean.HeaderText = "清理";
            this.ClFileListClean.Name = "ClFileListClean";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.PnMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MsMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本生成器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgFileList)).EndInit();
            this.MsMain.ResumeLayout(false);
            this.MsMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PnMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TbVersionDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbVersionNumber;
        private System.Windows.Forms.TextBox TbCodeName;
        private System.Windows.Forms.TextBox TbPluginEntry;
        private System.Windows.Forms.TextBox TbPluginName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TbServerPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbAfterUpdateKillProcess;
        private System.Windows.Forms.TextBox TbAfterUpdateStartProcess;
        private System.Windows.Forms.TextBox TbBeforeUpdateKillProcess;
        private System.Windows.Forms.TextBox TbBeforeUpdateStartProcess;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DgFileList;
        private System.Windows.Forms.MenuStrip MsMain;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成配置到指定目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 打开默认配置目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel PnMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TsslRunStatus;
        private System.Windows.Forms.Button BtImport;
        private System.Windows.Forms.Button BtAddFile;
        private System.Windows.Forms.Button BtClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClFileListServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClFileListLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClFileListMD5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClFileListClean;
    }
}