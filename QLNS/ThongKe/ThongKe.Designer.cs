namespace QLNS.ThongKe
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTK = new System.Windows.Forms.Panel();
            this.panel_ThongKe = new System.Windows.Forms.Panel();
            this.panel_LoaiNV = new System.Windows.Forms.Panel();
            this.chartLoaiNV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.chartNVPB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNVPB)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTK
            // 
            this.panelTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelTK.Controls.Add(this.label1);
            this.panelTK.Controls.Add(this.chartLoaiNV);
            this.panelTK.Location = new System.Drawing.Point(23, 12);
            this.panelTK.Name = "panelTK";
            this.panelTK.Size = new System.Drawing.Size(727, 346);
            this.panelTK.TabIndex = 2;
            // 
            // panel_ThongKe
            // 
            this.panel_ThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_ThongKe.Location = new System.Drawing.Point(775, 377);
            this.panel_ThongKe.Name = "panel_ThongKe";
            this.panel_ThongKe.Size = new System.Drawing.Size(523, 346);
            this.panel_ThongKe.TabIndex = 4;
            // 
            // panel_LoaiNV
            // 
            this.panel_LoaiNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_LoaiNV.Location = new System.Drawing.Point(775, 12);
            this.panel_LoaiNV.Name = "panel_LoaiNV";
            this.panel_LoaiNV.Size = new System.Drawing.Size(523, 346);
            this.panel_LoaiNV.TabIndex = 5;
            this.panel_LoaiNV.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_LoaiNV_Paint);
            // 
            // chartLoaiNV
            // 
            this.chartLoaiNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartLoaiNV.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            chartArea1.Name = "ChartArea1";
            this.chartLoaiNV.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLoaiNV.Legends.Add(legend1);
            this.chartLoaiNV.Location = new System.Drawing.Point(59, 47);
            this.chartLoaiNV.Name = "chartLoaiNV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLoaiNV.Series.Add(series1);
            this.chartLoaiNV.Size = new System.Drawing.Size(514, 238);
            this.chartLoaiNV.TabIndex = 6;
            this.chartLoaiNV.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(206, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "THỐNG KÊ NHÂN VIÊN";
            // 
            // chartNVPB
            // 
            this.chartNVPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            chartArea2.Name = "ChartArea1";
            this.chartNVPB.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartNVPB.Legends.Add(legend2);
            this.chartNVPB.Location = new System.Drawing.Point(23, 377);
            this.chartNVPB.Name = "chartNVPB";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNVPB.Series.Add(series2);
            this.chartNVPB.Size = new System.Drawing.Size(727, 346);
            this.chartNVPB.TabIndex = 3;
            this.chartNVPB.Text = "chartNVPB";
            // 
            // ThongKe
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1310, 707);
            this.Controls.Add(this.panel_ThongKe);
            this.Controls.Add(this.chartNVPB);
            this.Controls.Add(this.panel_LoaiNV);
            this.Controls.Add(this.panelTK);
            this.Name = "ThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.panelTK.ResumeLayout(false);
            this.panelTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNVPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTK;
        private System.Windows.Forms.Panel panel_ThongKe;
        private System.Windows.Forms.Panel panel_LoaiNV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNVPB;
    }
}
