
namespace Wilsi2D
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
                  this.components = new System.ComponentModel.Container();
                  System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                  System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                  System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
                  System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
                  this.pictureBox1 = new System.Windows.Forms.PictureBox();
                  this.Timer = new System.Windows.Forms.Timer(this.components);
                  this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
                  this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                  ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                  ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
                  this.SuspendLayout();
                  // 
                  // pictureBox1
                  // 
                  this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
                  this.pictureBox1.Location = new System.Drawing.Point(13, 13);
                  this.pictureBox1.Name = "pictureBox1";
                  this.pictureBox1.Size = new System.Drawing.Size(1900, 600);
                  this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                  this.pictureBox1.TabIndex = 0;
                  this.pictureBox1.TabStop = false;
                  this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGraphics);
                  // 
                  // chart1
                  // 
                  chartArea2.Name = "ChartArea1";
                  this.chart1.ChartAreas.Add(chartArea2);
                  this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
                  legend2.Name = "Legend1";
                  this.chart1.Legends.Add(legend2);
                  this.chart1.Location = new System.Drawing.Point(13, 616);
                  this.chart1.Name = "chart1";
                  series3.BorderWidth = 5;
                  series3.ChartArea = "ChartArea1";
                  series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                  series3.Legend = "Legend1";
                  series3.MarkerBorderWidth = 0;
                  series3.Name = "Prey";
                  series4.BorderWidth = 5;
                  series4.ChartArea = "ChartArea1";
                  series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                  series4.Legend = "Legend1";
                  series4.MarkerBorderWidth = 0;
                  series4.Name = "Predator";
                  this.chart1.Series.Add(series3);
                  this.chart1.Series.Add(series4);
                  this.chart1.Size = new System.Drawing.Size(1600, 417);
                  this.chart1.TabIndex = 1;
                  this.chart1.Text = "chart1";
                  this.chart1.Click += new System.EventHandler(this.chart1_Click);
                  // 
                  // Form1
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.AutoSize = true;
                  this.ClientSize = new System.Drawing.Size(1904, 1041);
                  this.Controls.Add(this.chart1);
                  this.Controls.Add(this.pictureBox1);
                  this.Name = "Form1";
                  this.Text = "Wilsi2D";
                  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                  ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                  ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
                  this.ResumeLayout(false);
                  this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.PictureBox pictureBox1;
            private System.Windows.Forms.Timer Timer;
            private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
            private System.ComponentModel.BackgroundWorker backgroundWorker1;
      }
}

