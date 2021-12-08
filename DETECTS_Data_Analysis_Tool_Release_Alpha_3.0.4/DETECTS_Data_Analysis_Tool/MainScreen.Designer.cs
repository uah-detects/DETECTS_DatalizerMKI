namespace DETECTS_Data_Analysis_Tool
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.graphButton = new System.Windows.Forms.Button();
            this.instructionButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ascButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(498, 272);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(186, 77);
            this.graphButton.TabIndex = 0;
            this.graphButton.Text = "Graph";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // instructionButton
            // 
            this.instructionButton.Location = new System.Drawing.Point(498, 106);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(186, 77);
            this.instructionButton.TabIndex = 1;
            this.instructionButton.Text = "Instructions";
            this.instructionButton.UseVisualStyleBackColor = true;
            this.instructionButton.Click += new System.EventHandler(this.instructionButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 374);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "DETECTS Datalizer Release alpha 3.0.4";
            // 
            // ascButton
            // 
            this.ascButton.Location = new System.Drawing.Point(498, 189);
            this.ascButton.Name = "ascButton";
            this.ascButton.Size = new System.Drawing.Size(186, 77);
            this.ascButton.TabIndex = 5;
            this.ascButton.Text = "Calculate Ascent Rate";
            this.ascButton.UseVisualStyleBackColor = true;
            this.ascButton.Click += new System.EventHandler(this.ascButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 450);
            this.Controls.Add(this.ascButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.graphButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.Text = "DETECTS Datalizer";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.Button instructionButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ascButton;
    }
}

