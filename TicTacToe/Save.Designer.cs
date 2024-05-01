namespace TicTacToe
{
  partial class Save
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
      this.SaveBtn = new System.Windows.Forms.Button();
      this.CancelBtn = new System.Windows.Forms.Button();
      this.TbxFilename = new System.Windows.Forms.TextBox();
      this.LblSave = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // SaveBtn
      // 
      this.SaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.SaveBtn.Location = new System.Drawing.Point(38, 56);
      this.SaveBtn.Name = "SaveBtn";
      this.SaveBtn.Size = new System.Drawing.Size(75, 23);
      this.SaveBtn.TabIndex = 0;
      this.SaveBtn.Text = "Save";
      this.SaveBtn.UseVisualStyleBackColor = true;
      // 
      // CancelBtn
      // 
      this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelBtn.Location = new System.Drawing.Point(119, 56);
      this.CancelBtn.Name = "CancelBtn";
      this.CancelBtn.Size = new System.Drawing.Size(75, 23);
      this.CancelBtn.TabIndex = 1;
      this.CancelBtn.Text = "Cancel";
      this.CancelBtn.UseVisualStyleBackColor = true;
      // 
      // TbxFilename
      // 
      this.TbxFilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
      this.TbxFilename.Location = new System.Drawing.Point(38, 28);
      this.TbxFilename.Name = "TbxFilename";
      this.TbxFilename.Size = new System.Drawing.Size(156, 22);
      this.TbxFilename.TabIndex = 2;
      // 
      // LblSave
      // 
      this.LblSave.AutoSize = true;
      this.LblSave.Location = new System.Drawing.Point(35, 9);
      this.LblSave.Name = "LblSave";
      this.LblSave.Size = new System.Drawing.Size(76, 16);
      this.LblSave.TabIndex = 3;
      this.LblSave.Text = "Save score";
      this.LblSave.Click += new System.EventHandler(this.LblSave_Click);
      // 
      // Save
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(250, 100);
      this.Controls.Add(this.LblSave);
      this.Controls.Add(this.TbxFilename);
      this.Controls.Add(this.CancelBtn);
      this.Controls.Add(this.SaveBtn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Save";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Save";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button SaveBtn;
    private System.Windows.Forms.Button CancelBtn;
    private System.Windows.Forms.TextBox TbxFilename;
    private System.Windows.Forms.Label LblSave;
  }
}