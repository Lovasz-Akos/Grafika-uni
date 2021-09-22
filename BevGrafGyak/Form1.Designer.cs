namespace BevGrafGyak
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grassDensitySlider = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.housePositionSlider = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.treePositionSlider = new System.Windows.Forms.HScrollBar();
            this.treeHeightSlider = new System.Windows.Forms.HScrollBar();
            this.treeHeightLabel = new System.Windows.Forms.Label();
            this.windowSizeSlider = new System.Windows.Forms.HScrollBar();
            this.windowSizeLabel = new System.Windows.Forms.Label();
            this.roofHeightSlider = new System.Windows.Forms.HScrollBar();
            this.roofHeightLabel = new System.Windows.Forms.Label();
            this.houseWidthLabel = new System.Windows.Forms.Label();
            this.houseWidthslider = new System.Windows.Forms.HScrollBar();
            this.randomiserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Transparent;
            this.canvas.Location = new System.Drawing.Point(12, 30);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1006, 603);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomiserButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.grassDensitySlider);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.housePositionSlider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.treePositionSlider);
            this.groupBox1.Controls.Add(this.treeHeightSlider);
            this.groupBox1.Controls.Add(this.treeHeightLabel);
            this.groupBox1.Controls.Add(this.windowSizeSlider);
            this.groupBox1.Controls.Add(this.windowSizeLabel);
            this.groupBox1.Controls.Add(this.roofHeightSlider);
            this.groupBox1.Controls.Add(this.roofHeightLabel);
            this.groupBox1.Controls.Add(this.houseWidthLabel);
            this.groupBox1.Controls.Add(this.houseWidthslider);
            this.groupBox1.Location = new System.Drawing.Point(1025, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 603);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fű Sűrűsége";
            // 
            // grassDensitySlider
            // 
            this.grassDensitySlider.Location = new System.Drawing.Point(3, 521);
            this.grassDensitySlider.Maximum = 50000;
            this.grassDensitySlider.Minimum = 500;
            this.grassDensitySlider.Name = "grassDensitySlider";
            this.grassDensitySlider.Size = new System.Drawing.Size(246, 18);
            this.grassDensitySlider.TabIndex = 12;
            this.grassDensitySlider.Value = 10000;
            this.grassDensitySlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grassDensitySlider_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ház Pozíciója";
            // 
            // housePositionSlider
            // 
            this.housePositionSlider.Location = new System.Drawing.Point(3, 41);
            this.housePositionSlider.Maximum = 800;
            this.housePositionSlider.Minimum = 100;
            this.housePositionSlider.Name = "housePositionSlider";
            this.housePositionSlider.Size = new System.Drawing.Size(246, 18);
            this.housePositionSlider.TabIndex = 10;
            this.housePositionSlider.Value = 250;
            this.housePositionSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.housePositionSlider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fa pozíciója";
            // 
            // treePositionSlider
            // 
            this.treePositionSlider.Location = new System.Drawing.Point(3, 361);
            this.treePositionSlider.Maximum = 800;
            this.treePositionSlider.Minimum = 50;
            this.treePositionSlider.Name = "treePositionSlider";
            this.treePositionSlider.Size = new System.Drawing.Size(246, 18);
            this.treePositionSlider.TabIndex = 8;
            this.treePositionSlider.Value = 600;
            this.treePositionSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.treePositionSlider_Scroll);
            // 
            // treeHeightSlider
            // 
            this.treeHeightSlider.Location = new System.Drawing.Point(0, 441);
            this.treeHeightSlider.Maximum = 500;
            this.treeHeightSlider.Minimum = 50;
            this.treeHeightSlider.Name = "treeHeightSlider";
            this.treeHeightSlider.Size = new System.Drawing.Size(246, 18);
            this.treeHeightSlider.TabIndex = 7;
            this.treeHeightSlider.Value = 200;
            this.treeHeightSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.treeHeightSlider_Scroll);
            // 
            // treeHeightLabel
            // 
            this.treeHeightLabel.AutoSize = true;
            this.treeHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeHeightLabel.ForeColor = System.Drawing.Color.White;
            this.treeHeightLabel.Location = new System.Drawing.Point(6, 421);
            this.treeHeightLabel.Name = "treeHeightLabel";
            this.treeHeightLabel.Size = new System.Drawing.Size(115, 20);
            this.treeHeightLabel.TabIndex = 6;
            this.treeHeightLabel.Text = "Fa magassága";
            // 
            // windowSizeSlider
            // 
            this.windowSizeSlider.Location = new System.Drawing.Point(3, 281);
            this.windowSizeSlider.Maximum = 200;
            this.windowSizeSlider.Minimum = 50;
            this.windowSizeSlider.Name = "windowSizeSlider";
            this.windowSizeSlider.Size = new System.Drawing.Size(246, 18);
            this.windowSizeSlider.TabIndex = 5;
            this.windowSizeSlider.Value = 120;
            this.windowSizeSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // windowSizeLabel
            // 
            this.windowSizeLabel.AutoSize = true;
            this.windowSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeLabel.ForeColor = System.Drawing.Color.White;
            this.windowSizeLabel.Location = new System.Drawing.Point(6, 261);
            this.windowSizeLabel.Name = "windowSizeLabel";
            this.windowSizeLabel.Size = new System.Drawing.Size(120, 20);
            this.windowSizeLabel.TabIndex = 4;
            this.windowSizeLabel.Text = "Ablakok mérete";
            // 
            // roofHeightSlider
            // 
            this.roofHeightSlider.Location = new System.Drawing.Point(3, 201);
            this.roofHeightSlider.Maximum = 300;
            this.roofHeightSlider.Minimum = 50;
            this.roofHeightSlider.Name = "roofHeightSlider";
            this.roofHeightSlider.Size = new System.Drawing.Size(246, 18);
            this.roofHeightSlider.TabIndex = 3;
            this.roofHeightSlider.Value = 100;
            this.roofHeightSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.roofHeightSlider_Scroll);
            // 
            // roofHeightLabel
            // 
            this.roofHeightLabel.AutoSize = true;
            this.roofHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roofHeightLabel.ForeColor = System.Drawing.Color.White;
            this.roofHeightLabel.Location = new System.Drawing.Point(6, 181);
            this.roofHeightLabel.Name = "roofHeightLabel";
            this.roofHeightLabel.Size = new System.Drawing.Size(128, 20);
            this.roofHeightLabel.TabIndex = 2;
            this.roofHeightLabel.Text = "Tető magassága";
            // 
            // houseWidthLabel
            // 
            this.houseWidthLabel.AutoSize = true;
            this.houseWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.houseWidthLabel.ForeColor = System.Drawing.Color.White;
            this.houseWidthLabel.Location = new System.Drawing.Point(6, 101);
            this.houseWidthLabel.Name = "houseWidthLabel";
            this.houseWidthLabel.Size = new System.Drawing.Size(122, 20);
            this.houseWidthLabel.TabIndex = 1;
            this.houseWidthLabel.Text = "Ház szélessége";
            // 
            // houseWidthslider
            // 
            this.houseWidthslider.Location = new System.Drawing.Point(3, 121);
            this.houseWidthslider.Maximum = 1200;
            this.houseWidthslider.Minimum = 100;
            this.houseWidthslider.Name = "houseWidthslider";
            this.houseWidthslider.Size = new System.Drawing.Size(246, 18);
            this.houseWidthslider.TabIndex = 0;
            this.houseWidthslider.Value = 320;
            this.houseWidthslider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.houseWidthBar_Scroll);
            // 
            // randomiserButton
            // 
            this.randomiserButton.Location = new System.Drawing.Point(77, 563);
            this.randomiserButton.Name = "randomiserButton";
            this.randomiserButton.Size = new System.Drawing.Size(91, 34);
            this.randomiserButton.TabIndex = 14;
            this.randomiserButton.Text = "Random";
            this.randomiserButton.UseVisualStyleBackColor = true;
            this.randomiserButton.Click += new System.EventHandler(this.randomiserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1289, 645);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.HScrollBar houseWidthslider;
        private System.Windows.Forms.Label houseWidthLabel;
        private System.Windows.Forms.HScrollBar roofHeightSlider;
        private System.Windows.Forms.Label roofHeightLabel;
        private System.Windows.Forms.HScrollBar windowSizeSlider;
        private System.Windows.Forms.Label windowSizeLabel;
        private System.Windows.Forms.HScrollBar treeHeightSlider;
        private System.Windows.Forms.Label treeHeightLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar treePositionSlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar housePositionSlider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar grassDensitySlider;
        private System.Windows.Forms.Button randomiserButton;
    }
}

