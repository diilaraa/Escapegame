namespace Escapegame
{
    partial class Skorlar
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
            this.SkorGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SkorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SkorGrid
            // 
            this.SkorGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.SkorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SkorGrid.Location = new System.Drawing.Point(125, 90);
            this.SkorGrid.Name = "SkorGrid";
            this.SkorGrid.RowHeadersWidth = 51;
            this.SkorGrid.RowTemplate.Height = 24;
            this.SkorGrid.Size = new System.Drawing.Size(550, 232);
            this.SkorGrid.TabIndex = 1;
            // 
            // Skorlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Escapegame.Properties.Resources.menuscreen1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SkorGrid);
            this.Name = "Skorlar";
            this.Text = "Skorlar";
            ((System.ComponentModel.ISupportInitialize)(this.SkorGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SkorGrid;
    }
}