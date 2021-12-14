namespace __AlapRajzolo
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.scrB_X = new System.Windows.Forms.VScrollBar();
            this.scrB_Z = new System.Windows.Forms.VScrollBar();
            this.scrB_Y = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(760, 437);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            this.canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseWheel);
            // 
            // scrB_X
            // 
            this.scrB_X.Location = new System.Drawing.Point(12, 199);
            this.scrB_X.Name = "scrB_X";
            this.scrB_X.Size = new System.Drawing.Size(17, 250);
            this.scrB_X.TabIndex = 1;
            this.scrB_X.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrB_X_Scroll);
            // 
            // scrB_Z
            // 
            this.scrB_Z.Location = new System.Drawing.Point(755, 199);
            this.scrB_Z.Name = "scrB_Z";
            this.scrB_Z.Size = new System.Drawing.Size(17, 250);
            this.scrB_Z.TabIndex = 4;
            this.scrB_Z.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrB_Z_Scroll);
            // 
            // scrB_Y
            // 
            this.scrB_Y.Location = new System.Drawing.Point(245, 432);
            this.scrB_Y.Name = "scrB_Y";
            this.scrB_Y.Size = new System.Drawing.Size(278, 17);
            this.scrB_Y.TabIndex = 5;
            this.scrB_Y.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrB_Y_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.scrB_Y);
            this.Controls.Add(this.scrB_Z);
            this.Controls.Add(this.scrB_X);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.VScrollBar scrB_X;
        private System.Windows.Forms.VScrollBar scrB_Z;
        private System.Windows.Forms.HScrollBar scrB_Y;
    }
}

