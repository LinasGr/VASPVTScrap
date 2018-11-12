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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.label_Count_Server = new System.Windows.Forms.Label();
      this.label_Count_Parsiusta = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label_Klaidos = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.button_Scrap = new System.Windows.Forms.Button();
      this.backgroundWorker_Scrap = new System.ComponentModel.BackgroundWorker();
      this.label_Puslapiu_Parsiusta = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.progressBar_Scrap = new System.Windows.Forms.ProgressBar();
      this.button_Scrap_Stop = new System.Windows.Forms.Button();
      this.label_Puslapiu_Serveryje = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.button_Create_Excel = new System.Windows.Forms.Button();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.backgroundWorker_Read_Excel = new System.ComponentModel.BackgroundWorker();
      this.progressBar_Excel_Save = new System.Windows.Forms.ProgressBar();
      this.button_Read_Excel = new System.Windows.Forms.Button();
      this.backgroundWorker_Save_Excel = new System.ComponentModel.BackgroundWorker();
      this.progressBar_Excel_Read = new System.Windows.Forms.ProgressBar();
      this.button_Lyginti_Įrašus = new System.Windows.Forms.Button();
      this.progressBar_Compare = new System.Windows.Forms.ProgressBar();
      this.backgroundWorker_Compare = new System.ComponentModel.BackgroundWorker();
      this.button_Compare_Stop = new System.Windows.Forms.Button();
      this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
      this.label_Dublikatai = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.button_Open_Dir = new System.Windows.Forms.Button();
      this.checkBox_Auto = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 317);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(124, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Įrašų serveryje:";
      // 
      // label_Count_Server
      // 
      this.label_Count_Server.AutoSize = true;
      this.label_Count_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Count_Server.Location = new System.Drawing.Point(183, 317);
      this.label_Count_Server.Name = "label_Count_Server";
      this.label_Count_Server.Size = new System.Drawing.Size(18, 20);
      this.label_Count_Server.TabIndex = 2;
      this.label_Count_Server.Text = "0";
      // 
      // label_Count_Parsiusta
      // 
      this.label_Count_Parsiusta.AutoSize = true;
      this.label_Count_Parsiusta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Count_Parsiusta.Location = new System.Drawing.Point(183, 337);
      this.label_Count_Parsiusta.Name = "label_Count_Parsiusta";
      this.label_Count_Parsiusta.Size = new System.Drawing.Size(18, 20);
      this.label_Count_Parsiusta.TabIndex = 4;
      this.label_Count_Parsiusta.Text = "0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 337);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(125, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Įrašų parsiųsta:";
      // 
      // label_Klaidos
      // 
      this.label_Klaidos.AutoSize = true;
      this.label_Klaidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Klaidos.Location = new System.Drawing.Point(183, 417);
      this.label_Klaidos.Name = "label_Klaidos";
      this.label_Klaidos.Size = new System.Drawing.Size(19, 20);
      this.label_Klaidos.TabIndex = 6;
      this.label_Klaidos.Text = "0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 417);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(69, 20);
      this.label4.TabIndex = 5;
      this.label4.Text = "Klaidos:";
      // 
      // button_Scrap
      // 
      this.button_Scrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Scrap.Location = new System.Drawing.Point(274, 325);
      this.button_Scrap.Name = "button_Scrap";
      this.button_Scrap.Size = new System.Drawing.Size(174, 32);
      this.button_Scrap.TabIndex = 7;
      this.button_Scrap.Text = "Parsiūsti";
      this.button_Scrap.UseVisualStyleBackColor = true;
      this.button_Scrap.Click += new System.EventHandler(this.button_Scrap_Click);
      // 
      // backgroundWorker_Scrap
      // 
      this.backgroundWorker_Scrap.WorkerReportsProgress = true;
      this.backgroundWorker_Scrap.WorkerSupportsCancellation = true;
      this.backgroundWorker_Scrap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Scrap_DoWork);
      this.backgroundWorker_Scrap.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Scrap_ProgressChanged);
      this.backgroundWorker_Scrap.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Scrap_RunWorkerCompleted);
      // 
      // label_Puslapiu_Parsiusta
      // 
      this.label_Puslapiu_Parsiusta.AutoSize = true;
      this.label_Puslapiu_Parsiusta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Puslapiu_Parsiusta.Location = new System.Drawing.Point(183, 377);
      this.label_Puslapiu_Parsiusta.Name = "label_Puslapiu_Parsiusta";
      this.label_Puslapiu_Parsiusta.Size = new System.Drawing.Size(18, 20);
      this.label_Puslapiu_Parsiusta.TabIndex = 9;
      this.label_Puslapiu_Parsiusta.Text = "0";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 377);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(152, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Puslapių parsiūsta:";
      // 
      // progressBar_Scrap
      // 
      this.progressBar_Scrap.Location = new System.Drawing.Point(454, 325);
      this.progressBar_Scrap.Name = "progressBar_Scrap";
      this.progressBar_Scrap.Size = new System.Drawing.Size(195, 32);
      this.progressBar_Scrap.TabIndex = 10;
      // 
      // button_Scrap_Stop
      // 
      this.button_Scrap_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Scrap_Stop.Location = new System.Drawing.Point(655, 325);
      this.button_Scrap_Stop.Name = "button_Scrap_Stop";
      this.button_Scrap_Stop.Size = new System.Drawing.Size(174, 32);
      this.button_Scrap_Stop.TabIndex = 11;
      this.button_Scrap_Stop.Text = "Stabdyti";
      this.button_Scrap_Stop.UseVisualStyleBackColor = true;
      this.button_Scrap_Stop.Click += new System.EventHandler(this.button_Scrap_Stop_Click);
      // 
      // label_Puslapiu_Serveryje
      // 
      this.label_Puslapiu_Serveryje.AutoSize = true;
      this.label_Puslapiu_Serveryje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Puslapiu_Serveryje.Location = new System.Drawing.Point(183, 357);
      this.label_Puslapiu_Serveryje.Name = "label_Puslapiu_Serveryje";
      this.label_Puslapiu_Serveryje.Size = new System.Drawing.Size(18, 20);
      this.label_Puslapiu_Serveryje.TabIndex = 13;
      this.label_Puslapiu_Serveryje.Text = "0";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(12, 357);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(151, 20);
      this.label6.TabIndex = 12;
      this.label6.Text = "Puslapių serveryje:";
      // 
      // button_Create_Excel
      // 
      this.button_Create_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Create_Excel.Location = new System.Drawing.Point(274, 441);
      this.button_Create_Excel.Name = "button_Create_Excel";
      this.button_Create_Excel.Size = new System.Drawing.Size(174, 32);
      this.button_Create_Excel.TabIndex = 14;
      this.button_Create_Excel.Text = "Sukūrti Excel failą";
      this.button_Create_Excel.UseVisualStyleBackColor = true;
      this.button_Create_Excel.Click += new System.EventHandler(this.button_Create_Excel_Click);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // backgroundWorker_Read_Excel
      // 
      this.backgroundWorker_Read_Excel.WorkerReportsProgress = true;
      this.backgroundWorker_Read_Excel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Read_Excel_DoWork);
      this.backgroundWorker_Read_Excel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Read_Excel_ProgressChanged);
      this.backgroundWorker_Read_Excel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Read_Excel_RunWorkerCompleted);
      // 
      // progressBar_Excel_Save
      // 
      this.progressBar_Excel_Save.Location = new System.Drawing.Point(454, 441);
      this.progressBar_Excel_Save.Name = "progressBar_Excel_Save";
      this.progressBar_Excel_Save.Size = new System.Drawing.Size(195, 32);
      this.progressBar_Excel_Save.TabIndex = 15;
      // 
      // button_Read_Excel
      // 
      this.button_Read_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Read_Excel.Location = new System.Drawing.Point(274, 365);
      this.button_Read_Excel.Name = "button_Read_Excel";
      this.button_Read_Excel.Size = new System.Drawing.Size(174, 32);
      this.button_Read_Excel.TabIndex = 16;
      this.button_Read_Excel.Text = "Nuskaityti Excel failą";
      this.button_Read_Excel.UseVisualStyleBackColor = true;
      this.button_Read_Excel.Click += new System.EventHandler(this.button_Read_Excel_Click);
      // 
      // backgroundWorker_Save_Excel
      // 
      this.backgroundWorker_Save_Excel.WorkerReportsProgress = true;
      this.backgroundWorker_Save_Excel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Save_Excel_DoWork);
      this.backgroundWorker_Save_Excel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Save_Excel_ProgressChanged);
      this.backgroundWorker_Save_Excel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Save_Excel_RunWorkerCompleted);
      // 
      // progressBar_Excel_Read
      // 
      this.progressBar_Excel_Read.Location = new System.Drawing.Point(454, 365);
      this.progressBar_Excel_Read.Name = "progressBar_Excel_Read";
      this.progressBar_Excel_Read.Size = new System.Drawing.Size(195, 32);
      this.progressBar_Excel_Read.TabIndex = 17;
      // 
      // button_Lyginti_Įrašus
      // 
      this.button_Lyginti_Įrašus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Lyginti_Įrašus.Location = new System.Drawing.Point(274, 403);
      this.button_Lyginti_Įrašus.Name = "button_Lyginti_Įrašus";
      this.button_Lyginti_Įrašus.Size = new System.Drawing.Size(174, 32);
      this.button_Lyginti_Įrašus.TabIndex = 18;
      this.button_Lyginti_Įrašus.Text = "Lyginti įrašus";
      this.button_Lyginti_Įrašus.UseVisualStyleBackColor = true;
      this.button_Lyginti_Įrašus.Click += new System.EventHandler(this.button_Lyginti_Įrašus_Click);
      // 
      // progressBar_Compare
      // 
      this.progressBar_Compare.Location = new System.Drawing.Point(454, 403);
      this.progressBar_Compare.Name = "progressBar_Compare";
      this.progressBar_Compare.Size = new System.Drawing.Size(195, 32);
      this.progressBar_Compare.TabIndex = 19;
      // 
      // backgroundWorker_Compare
      // 
      this.backgroundWorker_Compare.WorkerReportsProgress = true;
      this.backgroundWorker_Compare.WorkerSupportsCancellation = true;
      this.backgroundWorker_Compare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Compare_DoWork);
      this.backgroundWorker_Compare.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Compare_ProgressChanged);
      this.backgroundWorker_Compare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Compare_RunWorkerCompleted);
      // 
      // button_Compare_Stop
      // 
      this.button_Compare_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Compare_Stop.Location = new System.Drawing.Point(655, 403);
      this.button_Compare_Stop.Name = "button_Compare_Stop";
      this.button_Compare_Stop.Size = new System.Drawing.Size(174, 32);
      this.button_Compare_Stop.TabIndex = 20;
      this.button_Compare_Stop.Text = "Stabdyti";
      this.button_Compare_Stop.UseVisualStyleBackColor = true;
      this.button_Compare_Stop.Click += new System.EventHandler(this.button_Compare_Stop_Click);
      // 
      // richTextBox_Log
      // 
      this.richTextBox_Log.Dock = System.Windows.Forms.DockStyle.Top;
      this.richTextBox_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBox_Log.Location = new System.Drawing.Point(0, 0);
      this.richTextBox_Log.Name = "richTextBox_Log";
      this.richTextBox_Log.ReadOnly = true;
      this.richTextBox_Log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
      this.richTextBox_Log.Size = new System.Drawing.Size(845, 314);
      this.richTextBox_Log.TabIndex = 21;
      this.richTextBox_Log.Text = "";
      this.richTextBox_Log.TextChanged += new System.EventHandler(this.richTextBox_Log_TextChanged);
      // 
      // label_Dublikatai
      // 
      this.label_Dublikatai.AutoSize = true;
      this.label_Dublikatai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Dublikatai.Location = new System.Drawing.Point(183, 397);
      this.label_Dublikatai.Name = "label_Dublikatai";
      this.label_Dublikatai.Size = new System.Drawing.Size(19, 20);
      this.label_Dublikatai.TabIndex = 23;
      this.label_Dublikatai.Text = "0";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(12, 397);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(136, 20);
      this.label7.TabIndex = 22;
      this.label7.Text = "Ištrinta dublikatų:";
      // 
      // button_Open_Dir
      // 
      this.button_Open_Dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Open_Dir.Location = new System.Drawing.Point(655, 441);
      this.button_Open_Dir.Name = "button_Open_Dir";
      this.button_Open_Dir.Size = new System.Drawing.Size(174, 32);
      this.button_Open_Dir.TabIndex = 24;
      this.button_Open_Dir.Text = "Atidaryti aplanką";
      this.button_Open_Dir.UseVisualStyleBackColor = true;
      this.button_Open_Dir.Click += new System.EventHandler(this.button_Open_Dir_Click);
      // 
      // checkBox_Auto
      // 
      this.checkBox_Auto.AutoSize = true;
      this.checkBox_Auto.Location = new System.Drawing.Point(31, 449);
      this.checkBox_Auto.Name = "checkBox_Auto";
      this.checkBox_Auto.Size = new System.Drawing.Size(146, 21);
      this.checkBox_Auto.TabIndex = 26;
      this.checkBox_Auto.Text = "Atlikti automatiškai";
      this.checkBox_Auto.UseVisualStyleBackColor = true;
      this.checkBox_Auto.CheckedChanged += new System.EventHandler(this.checkBox_Auto_CheckedChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(845, 485);
      this.Controls.Add(this.checkBox_Auto);
      this.Controls.Add(this.button_Open_Dir);
      this.Controls.Add(this.label_Dublikatai);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.richTextBox_Log);
      this.Controls.Add(this.button_Compare_Stop);
      this.Controls.Add(this.progressBar_Compare);
      this.Controls.Add(this.button_Lyginti_Įrašus);
      this.Controls.Add(this.progressBar_Excel_Read);
      this.Controls.Add(this.button_Read_Excel);
      this.Controls.Add(this.progressBar_Excel_Save);
      this.Controls.Add(this.button_Create_Excel);
      this.Controls.Add(this.label_Puslapiu_Serveryje);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.button_Scrap_Stop);
      this.Controls.Add(this.progressBar_Scrap);
      this.Controls.Add(this.label_Puslapiu_Parsiusta);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.button_Scrap);
      this.Controls.Add(this.label_Klaidos);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label_Count_Parsiusta);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label_Count_Server);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "VASPVTScrap";
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label_Count_Server;
    private System.Windows.Forms.Label label_Count_Parsiusta;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label_Klaidos;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button button_Scrap;
    private System.ComponentModel.BackgroundWorker backgroundWorker_Scrap;
    private System.Windows.Forms.Label label_Puslapiu_Parsiusta;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ProgressBar progressBar_Scrap;
    private System.Windows.Forms.Button button_Scrap_Stop;
    private System.Windows.Forms.Label label_Puslapiu_Serveryje;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button button_Create_Excel;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.ComponentModel.BackgroundWorker backgroundWorker_Read_Excel;
    private System.Windows.Forms.ProgressBar progressBar_Excel_Save;
    private System.Windows.Forms.Button button_Read_Excel;
    private System.ComponentModel.BackgroundWorker backgroundWorker_Save_Excel;
    private System.Windows.Forms.ProgressBar progressBar_Excel_Read;
    private System.Windows.Forms.Button button_Lyginti_Įrašus;
    private System.Windows.Forms.ProgressBar progressBar_Compare;
    private System.ComponentModel.BackgroundWorker backgroundWorker_Compare;
    private System.Windows.Forms.Button button_Compare_Stop;
    private System.Windows.Forms.RichTextBox richTextBox_Log;
    private System.Windows.Forms.Label label_Dublikatai;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button button_Open_Dir;
    private System.Windows.Forms.CheckBox checkBox_Auto;
  }
}

