
namespace DETECTS_Data_Analysis_Tool
{
    partial class AscentRateCalculatorPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AscentRateCalculatorPage));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.clearTextboxButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.xComboBox = new System.Windows.Forms.ComboBox();
            this.yComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(31, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(235, 176);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(31, 216);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(102, 33);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // clearTextboxButton
            // 
            this.clearTextboxButton.Location = new System.Drawing.Point(164, 216);
            this.clearTextboxButton.Name = "clearTextboxButton";
            this.clearTextboxButton.Size = new System.Drawing.Size(102, 33);
            this.clearTextboxButton.TabIndex = 2;
            this.clearTextboxButton.Text = "Clear Textbox";
            this.clearTextboxButton.UseVisualStyleBackColor = true;
            this.clearTextboxButton.Click += new System.EventHandler(this.clearTextboxButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(291, 216);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(102, 33);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // xComboBox
            // 
            this.xComboBox.FormattingEnabled = true;
            this.xComboBox.Location = new System.Drawing.Point(272, 89);
            this.xComboBox.Name = "xComboBox";
            this.xComboBox.Size = new System.Drawing.Size(121, 24);
            this.xComboBox.TabIndex = 5;
            // 
            // yComboBox
            // 
            this.yComboBox.FormattingEnabled = true;
            this.yComboBox.Location = new System.Drawing.Point(272, 145);
            this.yComboBox.Name = "yComboBox";
            this.yComboBox.Size = new System.Drawing.Size(121, 24);
            this.yComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "X Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Drag and Drop Your CSV File Below:";
            // 
            // AscentRateCalculatorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 271);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yComboBox);
            this.Controls.Add(this.xComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.clearTextboxButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AscentRateCalculatorPage";
            this.Text = "DETECTS Datalizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AscentRateCalcPage_FormClosed);
            this.Load += new System.EventHandler(this.AltitudeCalculatorPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button clearTextboxButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox xComboBox;
        private System.Windows.Forms.ComboBox yComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}