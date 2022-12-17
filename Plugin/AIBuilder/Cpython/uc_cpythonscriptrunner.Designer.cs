
namespace AIBuilder.Cpython
{
    partial class uc_cpythonscriptrunner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.process1 = new System.Diagnostics.Process();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.TextArea = new ScintillaNET.Scintilla();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Hoverpanel = new System.Windows.Forms.Panel();
            this.QtConsolebutton = new System.Windows.Forms.PictureBox();
            this.Jupiterbutton = new System.Windows.Forms.PictureBox();
            this.Runbutton = new System.Windows.Forms.PictureBox();
            this.Savebutton = new System.Windows.Forms.PictureBox();
            this.SaveAsbutton = new System.Windows.Forms.PictureBox();
            this.LoadScriptbutton = new System.Windows.Forms.PictureBox();
            this.Insertlocaldbpathbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LocalDBcomboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Filenamelabel = new System.Windows.Forms.Label();
            this.currentfileloadedlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.OutputdataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputtextBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Clearoutputbutton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtConsolebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jupiterbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Runbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveAsbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadScriptbutton)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputdataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // process1
            // 
            this.process1.EnableRaisingEvents = true;
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.ErrorDialog = true;
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PanelSearch);
            this.splitContainer1.Panel1.Controls.Add(this.TextArea);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.Hoverpanel);
            this.splitContainer1.Panel1.Controls.Add(this.QtConsolebutton);
            this.splitContainer1.Panel1.Controls.Add(this.Jupiterbutton);
            this.splitContainer1.Panel1.Controls.Add(this.Runbutton);
            this.splitContainer1.Panel1.Controls.Add(this.Savebutton);
            this.splitContainer1.Panel1.Controls.Add(this.SaveAsbutton);
            this.splitContainer1.Panel1.Controls.Add(this.LoadScriptbutton);
            this.splitContainer1.Panel1.Controls.Add(this.Insertlocaldbpathbutton);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.LocalDBcomboBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1204, 649);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.TabIndex = 4;
            // 
            // PanelSearch
            // 
            this.PanelSearch.Controls.Add(this.TxtSearch);
            this.PanelSearch.Location = new System.Drawing.Point(863, 37);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(196, 64);
            this.PanelSearch.TabIndex = 33;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(71, 24);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(100, 20);
            this.TxtSearch.TabIndex = 32;
            // 
            // TextArea
            // 
            this.TextArea.AutoCMaxHeight = 9;
            this.TextArea.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.TextArea.CaretLineBackColor = System.Drawing.Color.Black;
            this.TextArea.CaretLineVisible = true;
            this.TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextArea.Lexer = ScintillaNET.Lexer.Python;
            this.TextArea.LexerName = "python";
            this.TextArea.Location = new System.Drawing.Point(0, 141);
            this.TextArea.Name = "TextArea";
            this.TextArea.ScrollWidth = 110;
            this.TextArea.Size = new System.Drawing.Size(1202, 306);
            this.TextArea.TabIndents = true;
            this.TextArea.TabIndex = 31;
            this.TextArea.UseRightToLeftReadingLayout = false;
            this.TextArea.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(599, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Qt Console";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(493, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Jupyter";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Run";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Save";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Save As";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Load";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hoverpanel
            // 
            this.Hoverpanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Hoverpanel.Location = new System.Drawing.Point(663, 32);
            this.Hoverpanel.Name = "Hoverpanel";
            this.Hoverpanel.Size = new System.Drawing.Size(5, 50);
            this.Hoverpanel.TabIndex = 25;
            // 
            // QtConsolebutton
            // 
            this.QtConsolebutton.Location = new System.Drawing.Point(593, 32);
            this.QtConsolebutton.Name = "QtConsolebutton";
            this.QtConsolebutton.Size = new System.Drawing.Size(64, 50);
            this.QtConsolebutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QtConsolebutton.TabIndex = 24;
            this.QtConsolebutton.TabStop = false;
            // 
            // Jupiterbutton
            // 
            this.Jupiterbutton.Location = new System.Drawing.Point(478, 32);
            this.Jupiterbutton.Name = "Jupiterbutton";
            this.Jupiterbutton.Size = new System.Drawing.Size(64, 50);
            this.Jupiterbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Jupiterbutton.TabIndex = 23;
            this.Jupiterbutton.TabStop = false;
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(360, 32);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(64, 50);
            this.Runbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Runbutton.TabIndex = 22;
            this.Runbutton.TabStop = false;
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(244, 32);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(64, 50);
            this.Savebutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Savebutton.TabIndex = 21;
            this.Savebutton.TabStop = false;
            // 
            // SaveAsbutton
            // 
            this.SaveAsbutton.Location = new System.Drawing.Point(128, 32);
            this.SaveAsbutton.Name = "SaveAsbutton";
            this.SaveAsbutton.Size = new System.Drawing.Size(64, 50);
            this.SaveAsbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SaveAsbutton.TabIndex = 20;
            this.SaveAsbutton.TabStop = false;
            // 
            // LoadScriptbutton
            // 
            this.LoadScriptbutton.Location = new System.Drawing.Point(13, 32);
            this.LoadScriptbutton.Name = "LoadScriptbutton";
            this.LoadScriptbutton.Size = new System.Drawing.Size(64, 50);
            this.LoadScriptbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadScriptbutton.TabIndex = 19;
            this.LoadScriptbutton.TabStop = false;
            // 
            // Insertlocaldbpathbutton
            // 
            this.Insertlocaldbpathbutton.Location = new System.Drawing.Point(702, 68);
            this.Insertlocaldbpathbutton.Name = "Insertlocaldbpathbutton";
            this.Insertlocaldbpathbutton.Size = new System.Drawing.Size(121, 23);
            this.Insertlocaldbpathbutton.TabIndex = 17;
            this.Insertlocaldbpathbutton.Text = "Copy Path";
            this.Insertlocaldbpathbutton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(713, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Local DataSources";
            // 
            // LocalDBcomboBox
            // 
            this.LocalDBcomboBox.FormattingEnabled = true;
            this.LocalDBcomboBox.Location = new System.Drawing.Point(702, 47);
            this.LocalDBcomboBox.Name = "LocalDBcomboBox";
            this.LocalDBcomboBox.Size = new System.Drawing.Size(121, 21);
            this.LocalDBcomboBox.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Filenamelabel);
            this.panel1.Controls.Add(this.currentfileloadedlabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1202, 34);
            this.panel1.TabIndex = 13;
            // 
            // Filenamelabel
            // 
            this.Filenamelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filenamelabel.BackColor = System.Drawing.Color.White;
            this.Filenamelabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Filenamelabel.Location = new System.Drawing.Point(127, 6);
            this.Filenamelabel.Name = "Filenamelabel";
            this.Filenamelabel.Size = new System.Drawing.Size(1070, 20);
            this.Filenamelabel.TabIndex = 11;
            // 
            // currentfileloadedlabel
            // 
            this.currentfileloadedlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentfileloadedlabel.Location = new System.Drawing.Point(9, 6);
            this.currentfileloadedlabel.Name = "currentfileloadedlabel";
            this.currentfileloadedlabel.Size = new System.Drawing.Size(112, 20);
            this.currentfileloadedlabel.TabIndex = 10;
            this.currentfileloadedlabel.Text = "Current File Loaded :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1202, 83);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.packagesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1202, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.runToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // packagesToolStripMenuItem
            // 
            this.packagesToolStripMenuItem.Name = "packagesToolStripMenuItem";
            this.packagesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.packagesToolStripMenuItem.Text = "Packages";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.OutputdataGridView);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1Collapsed = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.OutputtextBox);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(1202, 194);
            this.splitContainer2.SplitterDistance = 1170;
            this.splitContainer2.TabIndex = 2;
            // 
            // OutputdataGridView
            // 
            this.OutputdataGridView.AllowUserToAddRows = false;
            this.OutputdataGridView.AllowUserToDeleteRows = false;
            this.OutputdataGridView.BackgroundColor = System.Drawing.Color.Black;
            this.OutputdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OutputdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OutputdataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.OutputdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputdataGridView.GridColor = System.Drawing.Color.Black;
            this.OutputdataGridView.Location = new System.Drawing.Point(0, 23);
            this.OutputdataGridView.Name = "OutputdataGridView";
            this.OutputdataGridView.ReadOnly = true;
            this.OutputdataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.OutputdataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OutputdataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.OutputdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OutputdataGridView.Size = new System.Drawing.Size(1170, 77);
            this.OutputdataGridView.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1170, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Output";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputtextBox
            // 
            this.OutputtextBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.OutputtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputtextBox.ForeColor = System.Drawing.Color.Gold;
            this.OutputtextBox.Location = new System.Drawing.Point(0, 30);
            this.OutputtextBox.Name = "OutputtextBox";
            this.OutputtextBox.Size = new System.Drawing.Size(1202, 164);
            this.OutputtextBox.TabIndex = 3;
            this.OutputtextBox.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Clearoutputbutton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1202, 30);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(570, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clearoutputbutton
            // 
            this.Clearoutputbutton.BackColor = System.Drawing.Color.Transparent;
            this.Clearoutputbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Clearoutputbutton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Clearoutputbutton.FlatAppearance.BorderSize = 0;
            this.Clearoutputbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.Clearoutputbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Clearoutputbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clearoutputbutton.Location = new System.Drawing.Point(6, 3);
            this.Clearoutputbutton.Name = "Clearoutputbutton";
            this.Clearoutputbutton.Size = new System.Drawing.Size(27, 20);
            this.Clearoutputbutton.TabIndex = 4;
            this.Clearoutputbutton.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // uc_cpythonscriptrunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uc_cpythonscriptrunner";
            this.Size = new System.Drawing.Size(1204, 649);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtConsolebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jupiterbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Runbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveAsbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadScriptbutton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutputdataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Diagnostics.Process process1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packagesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView OutputdataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Filenamelabel;
        private System.Windows.Forms.Label currentfileloadedlabel;
        private System.Windows.Forms.RichTextBox OutputtextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Insertlocaldbpathbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LocalDBcomboBox;
        private System.Windows.Forms.PictureBox QtConsolebutton;
        private System.Windows.Forms.PictureBox Jupiterbutton;
        private System.Windows.Forms.PictureBox Runbutton;
        private System.Windows.Forms.PictureBox Savebutton;
        private System.Windows.Forms.PictureBox SaveAsbutton;
        private System.Windows.Forms.PictureBox LoadScriptbutton;
        private System.Windows.Forms.Panel Hoverpanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Clearoutputbutton;
        private System.Windows.Forms.Panel panel2;
        private ScintillaNET.Scintilla TextArea;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.TextBox TxtSearch;
    }
}
