namespace Escapegame
{
    partial class Menu
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
            this.panelmenu = new System.Windows.Forms.Panel();
            this.skorlar = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.btn_options = new System.Windows.Forms.PictureBox();
            this.btn_start = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.oyuncuText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skorlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelmenu
            // 
            this.panelmenu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelmenu.BackColor = System.Drawing.Color.Transparent;
            this.panelmenu.Controls.Add(this.label2);
            this.panelmenu.Controls.Add(this.skorlar);
            this.panelmenu.Controls.Add(this.panel1);
            this.panelmenu.Controls.Add(this.btn_exit);
            this.panelmenu.Controls.Add(this.btn_start);
            this.panelmenu.Controls.Add(this.btn_options);
            this.panelmenu.Controls.Add(this.button1);
            this.panelmenu.Location = new System.Drawing.Point(206, 104);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(795, 516);
            this.panelmenu.TabIndex = 1;
            // 
            // skorlar
            // 
            this.skorlar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skorlar.Image = global::Escapegame.Properties.Resources.score1;
            this.skorlar.Location = new System.Drawing.Point(80, 393);
            this.skorlar.Name = "skorlar";
            this.skorlar.Size = new System.Drawing.Size(160, 102);
            this.skorlar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skorlar.TabIndex = 3;
            this.skorlar.TabStop = false;
            this.skorlar.Click += new System.EventHandler(this.skorlar_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_exit.Image = global::Escapegame.Properties.Resources.exit;
            this.btn_exit.Location = new System.Drawing.Point(57, 265);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(200, 102);
            this.btn_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_exit.TabIndex = 2;
            this.btn_exit.TabStop = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_options
            // 
            this.btn_options.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_options.Image = global::Escapegame.Properties.Resources.options;
            this.btn_options.Location = new System.Drawing.Point(57, 133);
            this.btn_options.Name = "btn_options";
            this.btn_options.Size = new System.Drawing.Size(200, 102);
            this.btn_options.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_options.TabIndex = 1;
            this.btn_options.TabStop = false;
            this.btn_options.Click += new System.EventHandler(this.btn_options_Click);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_start.Image = global::Escapegame.Properties.Resources.play;
            this.btn_start.Location = new System.Drawing.Point(57, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(200, 102);
            this.btn_start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_start.TabIndex = 0;
            this.btn_start.TabStop = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oyuncu Adı:\r\n";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.oyuncuText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(529, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 137);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oyuna Baslamak icin ENTER tusuna basin";
            // 
            // oyuncuText
            // 
            this.oyuncuText.Location = new System.Drawing.Point(56, 57);
            this.oyuncuText.Name = "oyuncuText";
            this.oyuncuText.Size = new System.Drawing.Size(100, 22);
            this.oyuncuText.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Escapegame.Properties.Resources.menuscreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1212, 598);
            this.Controls.Add(this.panelmenu);
            this.Name = "Menu";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            this.panelmenu.ResumeLayout(false);
            this.panelmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skorlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.PictureBox skorlar;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.PictureBox btn_options;
        private System.Windows.Forms.PictureBox btn_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oyuncuText;
        private System.Windows.Forms.Button button1;
    }
}

