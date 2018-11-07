namespace VASPVTScrap
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label_Count_Server = new System.Windows.Forms.Label();
      this.label_Count_Parsiusta = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label_Klaidos = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.button_Scrap = new System.Windows.Forms.Button();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.label_Puslapiu_Parsiusta = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.button_Scrap_Stop = new System.Windows.Forms.Button();
      this.label_Puslapiu_Serveryje = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.button_Create_Excel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowTemplate.Height = 24;
      this.dataGridView1.Size = new System.Drawing.Size(982, 531);
      this.dataGridView1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 547);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(124, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Įrašų serveryje:";
      // 
      // label_Count_Server
      // 
      this.label_Count_Server.AutoSize = true;
      this.label_Count_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Count_Server.Location = new System.Drawing.Point(183, 547);
      this.label_Count_Server.Name = "label_Count_Server";
      this.label_Count_Server.Size = new System.Drawing.Size(18, 20);
      this.label_Count_Server.TabIndex = 2;
      this.label_Count_Server.Text = "0";
      // 
      // label_Count_Parsiusta
      // 
      this.label_Count_Parsiusta.AutoSize = true;
      this.label_Count_Parsiusta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Count_Parsiusta.Location = new System.Drawing.Point(183, 567);
      this.label_Count_Parsiusta.Name = "label_Count_Parsiusta";
      this.label_Count_Parsiusta.Size = new System.Drawing.Size(18, 20);
      this.label_Count_Parsiusta.TabIndex = 4;
      this.label_Count_Parsiusta.Text = "0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 567);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(125, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Įrašų parsiųsta:";
      // 
      // label_Klaidos
      // 
      this.label_Klaidos.AutoSize = true;
      this.label_Klaidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Klaidos.Location = new System.Drawing.Point(183, 627);
      this.label_Klaidos.Name = "label_Klaidos";
      this.label_Klaidos.Size = new System.Drawing.Size(18, 20);
      this.label_Klaidos.TabIndex = 6;
      this.label_Klaidos.Text = "0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 627);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(69, 20);
      this.label4.TabIndex = 5;
      this.label4.Text = "Klaidos:";
      // 
      // button_Scrap
      // 
      this.button_Scrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Scrap.Location = new System.Drawing.Point(345, 547);
      this.button_Scrap.Name = "button_Scrap";
      this.button_Scrap.Size = new System.Drawing.Size(109, 32);
      this.button_Scrap.TabIndex = 7;
      this.button_Scrap.Text = "Parsiūsti";
      this.button_Scrap.UseVisualStyleBackColor = true;
      this.button_Scrap.Click += new System.EventHandler(this.button_Scrap_Click);
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
      // 
      // label_Puslapiu_Parsiusta
      // 
      this.label_Puslapiu_Parsiusta.AutoSize = true;
      this.label_Puslapiu_Parsiusta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Puslapiu_Parsiusta.Location = new System.Drawing.Point(183, 607);
      this.label_Puslapiu_Parsiusta.Name = "label_Puslapiu_Parsiusta";
      this.label_Puslapiu_Parsiusta.Size = new System.Drawing.Size(18, 20);
      this.label_Puslapiu_Parsiusta.TabIndex = 9;
      this.label_Puslapiu_Parsiusta.Text = "0";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 607);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(152, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Puslapių parsiūsta:";
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(460, 547);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(195, 32);
      this.progressBar1.TabIndex = 10;
      // 
      // button_Scrap_Stop
      // 
      this.button_Scrap_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Scrap_Stop.Location = new System.Drawing.Point(661, 547);
      this.button_Scrap_Stop.Name = "button_Scrap_Stop";
      this.button_Scrap_Stop.Size = new System.Drawing.Size(109, 32);
      this.button_Scrap_Stop.TabIndex = 11;
      this.button_Scrap_Stop.Text = "Stabdyti";
      this.button_Scrap_Stop.UseVisualStyleBackColor = true;
      this.button_Scrap_Stop.Click += new System.EventHandler(this.button_Scrap_Stop_Click);
      // 
      // label_Puslapiu_Serveryje
      // 
      this.label_Puslapiu_Serveryje.AutoSize = true;
      this.label_Puslapiu_Serveryje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Puslapiu_Serveryje.Location = new System.Drawing.Point(183, 587);
      this.label_Puslapiu_Serveryje.Name = "label_Puslapiu_Serveryje";
      this.label_Puslapiu_Serveryje.Size = new System.Drawing.Size(18, 20);
      this.label_Puslapiu_Serveryje.TabIndex = 13;
      this.label_Puslapiu_Serveryje.Text = "0";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(12, 587);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(151, 20);
      this.label6.TabIndex = 12;
      this.label6.Text = "Puslapių serveryje:";
      // 
      // button_Create_Excel
      // 
      this.button_Create_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Create_Excel.Location = new System.Drawing.Point(345, 601);
      this.button_Create_Excel.Name = "button_Create_Excel";
      this.button_Create_Excel.Size = new System.Drawing.Size(425, 32);
      this.button_Create_Excel.TabIndex = 14;
      this.button_Create_Excel.Text = "Sukūrti Excel failą";
      this.button_Create_Excel.UseVisualStyleBackColor = true;
      this.button_Create_Excel.Click += new System.EventHandler(this.button_Create_Excel_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(982, 661);
      this.Controls.Add(this.button_Create_Excel);
      this.Controls.Add(this.label_Puslapiu_Serveryje);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.button_Scrap_Stop);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.label_Puslapiu_Parsiusta);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.button_Scrap);
      this.Controls.Add(this.label_Klaidos);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label_Count_Parsiusta);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label_Count_Server);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dataGridView1);
      this.Name = "Form1";
      this.Text = "VASPVTScrap";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label_Count_Server;
    private System.Windows.Forms.Label label_Count_Parsiusta;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label_Klaidos;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button button_Scrap;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Label label_Puslapiu_Parsiusta;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Button button_Scrap_Stop;
    private System.Windows.Forms.Label label_Puslapiu_Serveryje;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button button_Create_Excel;
  }
}

