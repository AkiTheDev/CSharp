namespace Brejkaut
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.igrac = new System.Windows.Forms.PictureBox();
            this.lopta = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.igrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopta)).BeginInit();
            this.SuspendLayout();
            // 
            // igrac
            // 
            this.igrac.BackColor = System.Drawing.Color.Transparent;
            this.igrac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("igrac.BackgroundImage")));
            this.igrac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.igrac.Location = new System.Drawing.Point(332, 380);
            this.igrac.Name = "igrac";
            this.igrac.Size = new System.Drawing.Size(134, 20);
            this.igrac.TabIndex = 0;
            this.igrac.TabStop = false;
            // 
            // lopta
            // 
            this.lopta.BackColor = System.Drawing.Color.Transparent;
            this.lopta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lopta.BackgroundImage")));
            this.lopta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lopta.Location = new System.Drawing.Point(386, 292);
            this.lopta.Name = "lopta";
            this.lopta.Size = new System.Drawing.Size(20, 20);
            this.lopta.TabIndex = 1;
            this.lopta.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 412);
            this.Controls.Add(this.lopta);
            this.Controls.Add(this.igrac);
            this.Name = "Form1";
            this.Text = "Breakout";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.igrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox igrac;
        private System.Windows.Forms.PictureBox lopta;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer2;
    }
}

