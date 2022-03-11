namespace CH8Emu
{
    partial class MainGameWindow
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setONPixelColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOFFPixelColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bheavioursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useNewShiftBehaviourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useNewLoadstoreBehaviourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer60Hz = new System.Windows.Forms.Timer(this.components);
            this.CPUTimer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 320);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Enabled = false;
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.cPUToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.bheavioursToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setONPixelColorToolStripMenuItem,
            this.setOFFPixelColorToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // setONPixelColorToolStripMenuItem
            // 
            this.setONPixelColorToolStripMenuItem.Name = "setONPixelColorToolStripMenuItem";
            this.setONPixelColorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.setONPixelColorToolStripMenuItem.Text = "Set ON Pixel Color";
            this.setONPixelColorToolStripMenuItem.Click += new System.EventHandler(this.setONPixelColorToolStripMenuItem_Click);
            // 
            // setOFFPixelColorToolStripMenuItem
            // 
            this.setOFFPixelColorToolStripMenuItem.Name = "setOFFPixelColorToolStripMenuItem";
            this.setOFFPixelColorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.setOFFPixelColorToolStripMenuItem.Text = "Set OFF Pixel Color";
            this.setOFFPixelColorToolStripMenuItem.Click += new System.EventHandler(this.setOFFPixelColorToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.audioToolStripMenuItem.Text = "Audio";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.audioToolStripMenuItem_Click);
            // 
            // cPUToolStripMenuItem
            // 
            this.cPUToolStripMenuItem.Name = "cPUToolStripMenuItem";
            this.cPUToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cPUToolStripMenuItem.Text = "CPU";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // bheavioursToolStripMenuItem
            // 
            this.bheavioursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useNewShiftBehaviourToolStripMenuItem,
            this.useNewLoadstoreBehaviourToolStripMenuItem,
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem});
            this.bheavioursToolStripMenuItem.Name = "bheavioursToolStripMenuItem";
            this.bheavioursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bheavioursToolStripMenuItem.Text = "Behaviours";
            this.bheavioursToolStripMenuItem.Click += new System.EventHandler(this.bheavioursToolStripMenuItem_Click);
            // 
            // useNewShiftBehaviourToolStripMenuItem
            // 
            this.useNewShiftBehaviourToolStripMenuItem.Checked = true;
            this.useNewShiftBehaviourToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNewShiftBehaviourToolStripMenuItem.Name = "useNewShiftBehaviourToolStripMenuItem";
            this.useNewShiftBehaviourToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.useNewShiftBehaviourToolStripMenuItem.Text = "Use CHIP-48 shift instruction behaviour";
            this.useNewShiftBehaviourToolStripMenuItem.Click += new System.EventHandler(this.useNewShiftBehaviourToolStripMenuItem_Click);
            // 
            // useNewLoadstoreBehaviourToolStripMenuItem
            // 
            this.useNewLoadstoreBehaviourToolStripMenuItem.Checked = true;
            this.useNewLoadstoreBehaviourToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNewLoadstoreBehaviourToolStripMenuItem.Name = "useNewLoadstoreBehaviourToolStripMenuItem";
            this.useNewLoadstoreBehaviourToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.useNewLoadstoreBehaviourToolStripMenuItem.Text = "Use CHIP-48 load/store instructions behaviour";
            this.useNewLoadstoreBehaviourToolStripMenuItem.Click += new System.EventHandler(this.useNewLoadstoreBehaviourToolStripMenuItem_Click);
            // 
            // useNewJumpBehaviourCHIP48ToolStripMenuItem
            // 
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.Checked = true;
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.Name = "useNewJumpBehaviourCHIP48ToolStripMenuItem";
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.Text = "Use CHIP-48 jump instruction behaviour";
            this.useNewJumpBehaviourCHIP48ToolStripMenuItem.Click += new System.EventHandler(this.useNewJumpBehaviourCHIP48ToolStripMenuItem_Click);
            // 
            // Timer60Hz
            // 
            this.Timer60Hz.Enabled = true;
            this.Timer60Hz.Interval = 17;
            this.Timer60Hz.Tick += new System.EventHandler(this.Timer60Hz_Tick);
            // 
            // CPUTimer
            // 
            this.CPUTimer.Enabled = true;
            this.CPUTimer.Interval = 1;
            this.CPUTimer.Tick += new System.EventHandler(this.CPUTimer_Tick);
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // MainGameWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 346);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainGameWindow";
            this.Text = "CH8Emu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainGameWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainGameWindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer Timer60Hz;
        private System.Windows.Forms.Timer CPUTimer;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem setONPixelColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOFFPixelColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bheavioursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useNewShiftBehaviourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useNewLoadstoreBehaviourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useNewJumpBehaviourCHIP48ToolStripMenuItem;
    }
}

