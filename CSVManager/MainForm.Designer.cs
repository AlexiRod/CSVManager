namespace CSVManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cBoxSelectedColumn = new System.Windows.Forms.ComboBox();
            this.lblSelectedColumn = new System.Windows.Forms.Label();
            this.panelOneHist = new System.Windows.Forms.Panel();
            this.btnOneHist = new System.Windows.Forms.Button();
            this.lblOneHistHeader = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.lblSelectedColumn2 = new System.Windows.Forms.Label();
            this.cBoxSelectedColumn2 = new System.Windows.Forms.ComboBox();
            this.btnGraph = new System.Windows.Forms.Button();
            this.lblGraph = new System.Windows.Forms.Label();
            this.lblSelectedColumn1 = new System.Windows.Forms.Label();
            this.cBoxSelectedColumn1 = new System.Windows.Forms.ComboBox();
            this.panelRange = new System.Windows.Forms.Panel();
            this.btnRange = new System.Windows.Forms.Button();
            this.labelRange = new System.Windows.Forms.Label();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panelOneHist.SuspendLayout();
            this.panelGraph.SuspendLayout();
            this.panelRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(18, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(740, 647);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Text = "dataGridView1";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1260, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(59, 24);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(216, 26);
            this.tsmiOpen.Text = "Открыть (Ctrl + O)";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(18, 32);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1230, 43);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxSelectedColumn
            // 
            this.cBoxSelectedColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSelectedColumn.FormattingEnabled = true;
            this.cBoxSelectedColumn.Location = new System.Drawing.Point(219, 74);
            this.cBoxSelectedColumn.Name = "cBoxSelectedColumn";
            this.cBoxSelectedColumn.Size = new System.Drawing.Size(249, 28);
            this.cBoxSelectedColumn.TabIndex = 3;
            // 
            // lblSelectedColumn
            // 
            this.lblSelectedColumn.AutoSize = true;
            this.lblSelectedColumn.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedColumn.Location = new System.Drawing.Point(7, 76);
            this.lblSelectedColumn.Name = "lblSelectedColumn";
            this.lblSelectedColumn.Size = new System.Drawing.Size(206, 23);
            this.lblSelectedColumn.TabIndex = 4;
            this.lblSelectedColumn.Text = "Выделенный столбец:";
            // 
            // panelOneHist
            // 
            this.panelOneHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOneHist.Controls.Add(this.btnOneHist);
            this.panelOneHist.Controls.Add(this.lblOneHistHeader);
            this.panelOneHist.Controls.Add(this.lblSelectedColumn);
            this.panelOneHist.Controls.Add(this.cBoxSelectedColumn);
            this.panelOneHist.Location = new System.Drawing.Point(764, 78);
            this.panelOneHist.Name = "panelOneHist";
            this.panelOneHist.Size = new System.Drawing.Size(484, 216);
            this.panelOneHist.TabIndex = 5;
            // 
            // btnOneHist
            // 
            this.btnOneHist.Font = new System.Drawing.Font("Georgia", 12F);
            this.btnOneHist.Location = new System.Drawing.Point(11, 124);
            this.btnOneHist.Name = "btnOneHist";
            this.btnOneHist.Size = new System.Drawing.Size(457, 74);
            this.btnOneHist.TabIndex = 6;
            this.btnOneHist.Text = "Построить количественную гистограмму";
            this.btnOneHist.UseVisualStyleBackColor = true;
            this.btnOneHist.Click += new System.EventHandler(this.btnOneHist_Click);
            // 
            // lblOneHistHeader
            // 
            this.lblOneHistHeader.AutoSize = true;
            this.lblOneHistHeader.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblOneHistHeader.Location = new System.Drawing.Point(58, 24);
            this.lblOneHistHeader.Name = "lblOneHistHeader";
            this.lblOneHistHeader.Size = new System.Drawing.Size(366, 32);
            this.lblOneHistHeader.TabIndex = 5;
            this.lblOneHistHeader.Text = "Частота встречаемости";
            // 
            // panelGraph
            // 
            this.panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraph.Controls.Add(this.lblSelectedColumn2);
            this.panelGraph.Controls.Add(this.cBoxSelectedColumn2);
            this.panelGraph.Controls.Add(this.btnGraph);
            this.panelGraph.Controls.Add(this.lblGraph);
            this.panelGraph.Controls.Add(this.lblSelectedColumn1);
            this.panelGraph.Controls.Add(this.cBoxSelectedColumn1);
            this.panelGraph.Location = new System.Drawing.Point(764, 300);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(484, 262);
            this.panelGraph.TabIndex = 7;
            // 
            // lblSelectedColumn2
            // 
            this.lblSelectedColumn2.AutoSize = true;
            this.lblSelectedColumn2.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedColumn2.Location = new System.Drawing.Point(11, 116);
            this.lblSelectedColumn2.Name = "lblSelectedColumn2";
            this.lblSelectedColumn2.Size = new System.Drawing.Size(222, 23);
            this.lblSelectedColumn2.TabIndex = 8;
            this.lblSelectedColumn2.Text = "Выделенный столбец 2:";
            // 
            // cBoxSelectedColumn2
            // 
            this.cBoxSelectedColumn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSelectedColumn2.FormattingEnabled = true;
            this.cBoxSelectedColumn2.Location = new System.Drawing.Point(233, 114);
            this.cBoxSelectedColumn2.Name = "cBoxSelectedColumn2";
            this.cBoxSelectedColumn2.Size = new System.Drawing.Size(236, 28);
            this.cBoxSelectedColumn2.TabIndex = 7;
            // 
            // btnGraph
            // 
            this.btnGraph.Font = new System.Drawing.Font("Georgia", 12F);
            this.btnGraph.Location = new System.Drawing.Point(12, 164);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(457, 74);
            this.btnGraph.TabIndex = 6;
            this.btnGraph.Text = "Построить график зависимости";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // lblGraph
            // 
            this.lblGraph.AutoSize = true;
            this.lblGraph.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblGraph.Location = new System.Drawing.Point(81, 16);
            this.lblGraph.Name = "lblGraph";
            this.lblGraph.Size = new System.Drawing.Size(332, 32);
            this.lblGraph.TabIndex = 5;
            this.lblGraph.Text = "График зависимости";
            // 
            // lblSelectedColumn1
            // 
            this.lblSelectedColumn1.AutoSize = true;
            this.lblSelectedColumn1.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedColumn1.Location = new System.Drawing.Point(8, 76);
            this.lblSelectedColumn1.Name = "lblSelectedColumn1";
            this.lblSelectedColumn1.Size = new System.Drawing.Size(219, 23);
            this.lblSelectedColumn1.TabIndex = 4;
            this.lblSelectedColumn1.Text = "Выделенный столбец 1:";
            // 
            // cBoxSelectedColumn1
            // 
            this.cBoxSelectedColumn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSelectedColumn1.FormattingEnabled = true;
            this.cBoxSelectedColumn1.Location = new System.Drawing.Point(233, 74);
            this.cBoxSelectedColumn1.Name = "cBoxSelectedColumn1";
            this.cBoxSelectedColumn1.Size = new System.Drawing.Size(236, 28);
            this.cBoxSelectedColumn1.TabIndex = 3;
            // 
            // panelRange
            // 
            this.panelRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRange.Controls.Add(this.btnRange);
            this.panelRange.Controls.Add(this.labelRange);
            this.panelRange.Location = new System.Drawing.Point(764, 577);
            this.panelRange.Name = "panelRange";
            this.panelRange.Size = new System.Drawing.Size(484, 148);
            this.panelRange.TabIndex = 7;
            // 
            // btnRange
            // 
            this.btnRange.Font = new System.Drawing.Font("Georgia", 12F);
            this.btnRange.Location = new System.Drawing.Point(12, 56);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(457, 74);
            this.btnRange.TabIndex = 6;
            this.btnRange.Text = "Построить диаграмму выделенной области";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelRange.Location = new System.Drawing.Point(90, 11);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(312, 32);
            this.labelRange.TabIndex = 5;
            this.labelRange.Text = "Диаграмма области";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(81, 24);
            this.tsmiHelp.Text = "Справка";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1260, 734);
            this.Controls.Add(this.panelRange);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.panelOneHist);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Georgia", 10.2F);
            this.Name = "MainForm";
            this.Text = "CSV Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelOneHist.ResumeLayout(false);
            this.panelOneHist.PerformLayout();
            this.panelGraph.ResumeLayout(false);
            this.panelGraph.PerformLayout();
            this.panelRange.ResumeLayout(false);
            this.panelRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cBoxSelectedColumn;
        private System.Windows.Forms.Label lblSelectedColumn;
        private System.Windows.Forms.Panel panelOneHist;
        private System.Windows.Forms.Button btnOneHist;
        private System.Windows.Forms.Label lblOneHistHeader;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label lblSelectedColumn2;
        private System.Windows.Forms.ComboBox cBoxSelectedColumn2;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Label lblGraph;
        private System.Windows.Forms.Label lblSelectedColumn1;
        private System.Windows.Forms.ComboBox cBoxSelectedColumn1;
        private System.Windows.Forms.Panel panelRange;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
    }
}

