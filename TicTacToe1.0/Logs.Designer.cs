namespace TicTacToe1._0
{
  partial class Logs
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
      this.Outputlogs = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // Outputlogs
      // 
      this.Outputlogs.Location = new System.Drawing.Point(13, 13);
      this.Outputlogs.MaxLength = 50000000;
      this.Outputlogs.Multiline = true;
      this.Outputlogs.Name = "Outputlogs";
      this.Outputlogs.ReadOnly = true;
      this.Outputlogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.Outputlogs.Size = new System.Drawing.Size(775, 425);
      this.Outputlogs.TabIndex = 0;
      this.Outputlogs.WordWrap = false;
      // 
      // Logs
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.Outputlogs);
      this.Name = "Logs";
      this.Text = "Log";
      this.Load += new System.EventHandler(this.Logs_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox Outputlogs;
  }
}