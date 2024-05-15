namespace TicTacToe1._0
{
  partial class MainForms
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.BtnNewGame = new System.Windows.Forms.Button();
      this.BtnResume = new System.Windows.Forms.Button();
      this.BtnOptions = new System.Windows.Forms.Button();
      this.BtnExit = new System.Windows.Forms.Button();
      this.BtnAiOption = new System.Windows.Forms.Button();
      this.BtnAiStrength = new System.Windows.Forms.Button();
      this.BtnExitOptions = new System.Windows.Forms.Button();
      this.BtnLogs = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // BtnNewGame
      // 
      this.BtnNewGame.Location = new System.Drawing.Point(12, 30);
      this.BtnNewGame.Name = "BtnNewGame";
      this.BtnNewGame.Size = new System.Drawing.Size(276, 61);
      this.BtnNewGame.TabIndex = 0;
      this.BtnNewGame.Text = "New Game";
      this.BtnNewGame.UseVisualStyleBackColor = true;
      this.BtnNewGame.Click += new System.EventHandler(this.OnNewGameClicked);
      // 
      // BtnResume
      // 
      this.BtnResume.Location = new System.Drawing.Point(12, 97);
      this.BtnResume.Name = "BtnResume";
      this.BtnResume.Size = new System.Drawing.Size(276, 61);
      this.BtnResume.TabIndex = 2;
      this.BtnResume.Text = "Resume Game";
      this.BtnResume.UseVisualStyleBackColor = true;
      this.BtnResume.Click += new System.EventHandler(this.OnResumeGameClicked);
      // 
      // BtnOptions
      // 
      this.BtnOptions.Location = new System.Drawing.Point(12, 164);
      this.BtnOptions.Name = "BtnOptions";
      this.BtnOptions.Size = new System.Drawing.Size(276, 61);
      this.BtnOptions.TabIndex = 3;
      this.BtnOptions.Text = "Options";
      this.BtnOptions.UseVisualStyleBackColor = true;
      this.BtnOptions.Click += new System.EventHandler(this.OnOptionClicked);
      // 
      // BtnExit
      // 
      this.BtnExit.Location = new System.Drawing.Point(85, 268);
      this.BtnExit.Name = "BtnExit";
      this.BtnExit.Size = new System.Drawing.Size(125, 36);
      this.BtnExit.TabIndex = 4;
      this.BtnExit.Text = "Exit";
      this.BtnExit.UseVisualStyleBackColor = true;
      // 
      // BtnAiOption
      // 
      this.BtnAiOption.Location = new System.Drawing.Point(13, 30);
      this.BtnAiOption.Name = "BtnAiOption";
      this.BtnAiOption.Size = new System.Drawing.Size(275, 61);
      this.BtnAiOption.TabIndex = 5;
      this.BtnAiOption.Text = "Human";
      this.BtnAiOption.UseVisualStyleBackColor = true;
      this.BtnAiOption.Visible = false;
      // 
      // BtnAiStrength
      // 
      this.BtnAiStrength.Location = new System.Drawing.Point(13, 97);
      this.BtnAiStrength.Name = "BtnAiStrength";
      this.BtnAiStrength.Size = new System.Drawing.Size(275, 61);
      this.BtnAiStrength.TabIndex = 6;
      this.BtnAiStrength.Text = "Strong";
      this.BtnAiStrength.UseVisualStyleBackColor = true;
      this.BtnAiStrength.Visible = false;
      // 
      // BtnExitOptions
      // 
      this.BtnExitOptions.Location = new System.Drawing.Point(85, 268);
      this.BtnExitOptions.Name = "BtnExitOptions";
      this.BtnExitOptions.Size = new System.Drawing.Size(125, 36);
      this.BtnExitOptions.TabIndex = 7;
      this.BtnExitOptions.Text = "Exit";
      this.BtnExitOptions.UseVisualStyleBackColor = true;
      this.BtnExitOptions.Visible = false;
      // 
      // BtnLogs
      // 
      this.BtnLogs.Location = new System.Drawing.Point(13, 164);
      this.BtnLogs.Name = "BtnLogs";
      this.BtnLogs.Size = new System.Drawing.Size(275, 61);
      this.BtnLogs.TabIndex = 8;
      this.BtnLogs.Text = "Logs";
      this.BtnLogs.UseVisualStyleBackColor = true;
      this.BtnLogs.Visible = false;
      // 
      // MainForms
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(300, 350);
      this.Controls.Add(this.BtnLogs);
      this.Controls.Add(this.BtnExitOptions);
      this.Controls.Add(this.BtnAiStrength);
      this.Controls.Add(this.BtnAiOption);
      this.Controls.Add(this.BtnExit);
      this.Controls.Add(this.BtnOptions);
      this.Controls.Add(this.BtnResume);
      this.Controls.Add(this.BtnNewGame);
      this.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(5);
      this.MaximumSize = new System.Drawing.Size(318, 397);
      this.MinimumSize = new System.Drawing.Size(318, 397);
      this.Name = "MainForms";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tictactoe";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormsClosing);
      this.Load += new System.EventHandler(this.OnFormsLoad);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button BtnNewGame;
    private System.Windows.Forms.Button BtnResume;
    private System.Windows.Forms.Button BtnOptions;
    private System.Windows.Forms.Button BtnExit;
    private System.Windows.Forms.Button BtnAiOption;
    private System.Windows.Forms.Button BtnAiStrength;
    private System.Windows.Forms.Button BtnExitOptions;
    private System.Windows.Forms.Button BtnLogs;
  }
}

