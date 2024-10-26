namespace Minesweeper
{
    partial class Minesweeper
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
            this.components = new System.ComponentModel.Container();
            this.btnstart = new System.Windows.Forms.Button();
            this.pbMineSweeper = new System.Windows.Forms.PictureBox();
            this.txtFlagCounter = new System.Windows.Forms.TextBox();
            this.lblFlagCounter = new System.Windows.Forms.Label();
            this.tmMineSweeperTimer = new System.Windows.Forms.Timer(this.components);
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMineSweeper)).BeginInit();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(69, 481);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(156, 33);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // pbMineSweeper
            // 
            this.pbMineSweeper.Location = new System.Drawing.Point(12, 12);
            this.pbMineSweeper.Name = "pbMineSweeper";
            this.pbMineSweeper.Size = new System.Drawing.Size(450, 450);
            this.pbMineSweeper.TabIndex = 2;
            this.pbMineSweeper.TabStop = false;
            this.pbMineSweeper.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMineSweeper_Paint);
            this.pbMineSweeper.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMineSweeper_MouseClick);
            // 
            // txtFlagCounter
            // 
            this.txtFlagCounter.Location = new System.Drawing.Point(319, 489);
            this.txtFlagCounter.Name = "txtFlagCounter";
            this.txtFlagCounter.ReadOnly = true;
            this.txtFlagCounter.Size = new System.Drawing.Size(115, 20);
            this.txtFlagCounter.TabIndex = 2;
            this.txtFlagCounter.TabStop = false;
            // 
            // lblFlagCounter
            // 
            this.lblFlagCounter.AutoSize = true;
            this.lblFlagCounter.Location = new System.Drawing.Point(316, 473);
            this.lblFlagCounter.Name = "lblFlagCounter";
            this.lblFlagCounter.Size = new System.Drawing.Size(67, 13);
            this.lblFlagCounter.TabIndex = 4;
            this.lblFlagCounter.Text = "Flag Counter";
            // 
            // tmMineSweeperTimer
            // 
            this.tmMineSweeperTimer.Interval = 1000;
            this.tmMineSweeperTimer.Tick += new System.EventHandler(this.tmMineSweeperTimer_Tick);
            // 
            // txtTimer
            // 
            this.txtTimer.Location = new System.Drawing.Point(319, 529);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.ReadOnly = true;
            this.txtTimer.Size = new System.Drawing.Size(45, 20);
            this.txtTimer.TabIndex = 3;
            this.txtTimer.TabStop = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(316, 513);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "Timer";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(69, 520);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(156, 36);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button1_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 578);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtTimer);
            this.Controls.Add(this.lblFlagCounter);
            this.Controls.Add(this.txtFlagCounter);
            this.Controls.Add(this.pbMineSweeper);
            this.Controls.Add(this.btnstart);
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbMineSweeper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.PictureBox pbMineSweeper;
        private System.Windows.Forms.TextBox txtFlagCounter;
        private System.Windows.Forms.Label lblFlagCounter;
        private System.Windows.Forms.Timer tmMineSweeperTimer;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnHelp;
    }
}

