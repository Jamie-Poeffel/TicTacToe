namespace TicTacToe
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
      this.SuspendLayout();
      // 
      // MainForms
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(300, 350);
      this.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
  }
}

