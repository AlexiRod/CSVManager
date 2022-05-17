namespace CSVManager
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiAnalys = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScale5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 30);
            this.chart.Margin = new System.Windows.Forms.Padding(4);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1172, 686);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart";
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAnalys,
            this.tsmiScale,
            this.tsmiSaveImage});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1172, 30);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip";
            // 
            // tsmiAnalys
            // 
            this.tsmiAnalys.Name = "tsmiAnalys";
            this.tsmiAnalys.Size = new System.Drawing.Size(130, 26);
            this.tsmiAnalys.Text = "Анализ данных";
            this.tsmiAnalys.Click += new System.EventHandler(this.tsmiAnalys_Click);
            // 
            // tsmiScale
            // 
            this.tsmiScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiScale1,
            this.tsmiScale2,
            this.tsmiScale3,
            this.tsmiScale4,
            this.tsmiScale5});
            this.tsmiScale.Name = "tsmiScale";
            this.tsmiScale.Size = new System.Drawing.Size(280, 26);
            this.tsmiScale.Text = "Изменение охватываемых значений";
            // 
            // tsmiScale1
            // 
            this.tsmiScale1.BackColor = System.Drawing.Color.Lime;
            this.tsmiScale1.Name = "tsmiScale1";
            this.tsmiScale1.Size = new System.Drawing.Size(252, 26);
            this.tsmiScale1.Text = "1 значение на столбец";
            this.tsmiScale1.Click += new System.EventHandler(this.tsmiScaleN_Click);
            // 
            // tsmiScale2
            // 
            this.tsmiScale2.BackColor = System.Drawing.Color.White;
            this.tsmiScale2.Name = "tsmiScale2";
            this.tsmiScale2.Size = new System.Drawing.Size(252, 26);
            this.tsmiScale2.Text = "2 значения на столбец";
            this.tsmiScale2.Click += new System.EventHandler(this.tsmiScaleN_Click);
            // 
            // tsmiScale3
            // 
            this.tsmiScale3.BackColor = System.Drawing.Color.White;
            this.tsmiScale3.Name = "tsmiScale3";
            this.tsmiScale3.Size = new System.Drawing.Size(252, 26);
            this.tsmiScale3.Text = "3 значения на столбец";
            this.tsmiScale3.Click += new System.EventHandler(this.tsmiScaleN_Click);
            // 
            // tsmiScale4
            // 
            this.tsmiScale4.BackColor = System.Drawing.Color.White;
            this.tsmiScale4.Name = "tsmiScale4";
            this.tsmiScale4.Size = new System.Drawing.Size(252, 26);
            this.tsmiScale4.Text = "4 значения на столбец";
            this.tsmiScale4.Click += new System.EventHandler(this.tsmiScaleN_Click);
            // 
            // tsmiScale5
            // 
            this.tsmiScale5.BackColor = System.Drawing.Color.White;
            this.tsmiScale5.Name = "tsmiScale5";
            this.tsmiScale5.Size = new System.Drawing.Size(252, 26);
            this.tsmiScale5.Text = "5 значений на столбец";
            this.tsmiScale5.Click += new System.EventHandler(this.tsmiScaleN_Click);
            // 
            // tsmiSaveImage
            // 
            this.tsmiSaveImage.Name = "tsmiSaveImage";
            this.tsmiSaveImage.Size = new System.Drawing.Size(223, 26);
            this.tsmiSaveImage.Text = "Сохранить как изображение";
            this.tsmiSaveImage.Click += new System.EventHandler(this.tsmiSaveImage_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 716);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Georgia", 10.2F);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChartForm";
            this.Text = "HistForm";
            this.Load += new System.EventHandler(this.HistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalys;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale1;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale2;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale3;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale4;
        private System.Windows.Forms.ToolStripMenuItem tsmiScale5;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveImage;
    }
}