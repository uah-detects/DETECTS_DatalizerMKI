namespace DETECTS_Data_Analysis_Tool
{
    partial class GraphPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphPage));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.clearGraphButton = new System.Windows.Forms.Button();
            this.screenShotButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.xComboBox = new System.Windows.Forms.ComboBox();
            this.yComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(804, 342);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(252, 504);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(86, 42);
            this.graphButton.TabIndex = 1;
            this.graphButton.Text = "Graph";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 385);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 161);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(344, 504);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(86, 42);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear Textbox";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // clearGraphButton
            // 
            this.clearGraphButton.Location = new System.Drawing.Point(436, 504);
            this.clearGraphButton.Name = "clearGraphButton";
            this.clearGraphButton.Size = new System.Drawing.Size(86, 42);
            this.clearGraphButton.TabIndex = 5;
            this.clearGraphButton.Text = "Clear Graph";
            this.clearGraphButton.UseVisualStyleBackColor = true;
            this.clearGraphButton.Click += new System.EventHandler(this.clearGraphButton_Click);
            // 
            // screenShotButton
            // 
            this.screenShotButton.Location = new System.Drawing.Point(528, 504);
            this.screenShotButton.Name = "screenShotButton";
            this.screenShotButton.Size = new System.Drawing.Size(96, 42);
            this.screenShotButton.TabIndex = 7;
            this.screenShotButton.Text = "Take a Screenshot";
            this.screenShotButton.UseVisualStyleBackColor = true;
            this.screenShotButton.Click += new System.EventHandler(this.screenShotButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drag and Drop Your CSV File Below:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(716, 507);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(96, 42);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // xComboBox
            // 
            this.xComboBox.FormattingEnabled = true;
            this.xComboBox.Location = new System.Drawing.Point(249, 415);
            this.xComboBox.Name = "xComboBox";
            this.xComboBox.Size = new System.Drawing.Size(143, 24);
            this.xComboBox.TabIndex = 11;
            // 
            // yComboBox
            // 
            this.yComboBox.FormattingEnabled = true;
            this.yComboBox.Location = new System.Drawing.Point(249, 462);
            this.yComboBox.Name = "yComboBox";
            this.yComboBox.Size = new System.Drawing.Size(143, 24);
            this.yComboBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "X Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y Data:";
            // 
            // GraphPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yComboBox);
            this.Controls.Add(this.xComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screenShotButton);
            this.Controls.Add(this.clearGraphButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphPage";
            this.Text = "DETECTS Datalizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphPage_FormClosed);
            this.Load += new System.EventHandler(this.GraphPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button clearGraphButton;
        private System.Windows.Forms.Button screenShotButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox xComboBox;
        private System.Windows.Forms.ComboBox yComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}