namespace WindowsFormsApp4
{
    partial class MainView
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
            this.GridTabControl = new System.Windows.Forms.TabControl();
            this.AddTableButton = new System.Windows.Forms.Button();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.Synchronisieren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GridTabControl
            // 
            this.GridTabControl.Location = new System.Drawing.Point(13, 13);
            this.GridTabControl.Name = "GridTabControl";
            this.GridTabControl.SelectedIndex = 0;
            this.GridTabControl.Size = new System.Drawing.Size(567, 321);
            this.GridTabControl.TabIndex = 0;
            // 
            // AddTableButton
            // 
            this.AddTableButton.Location = new System.Drawing.Point(624, 13);
            this.AddTableButton.Name = "AddTableButton";
            this.AddTableButton.Size = new System.Drawing.Size(93, 23);
            this.AddTableButton.TabIndex = 1;
            this.AddTableButton.Text = "Add Table";
            this.AddTableButton.UseVisualStyleBackColor = true;
            this.AddTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Location = new System.Drawing.Point(624, 43);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(93, 23);
            this.SaveAllButton.TabIndex = 2;
            this.SaveAllButton.Text = "Save All";
            this.SaveAllButton.UseVisualStyleBackColor = true;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // Synchronisieren
            // 
            this.Synchronisieren.Location = new System.Drawing.Point(624, 72);
            this.Synchronisieren.Name = "Synchronisieren";
            this.Synchronisieren.Size = new System.Drawing.Size(93, 23);
            this.Synchronisieren.TabIndex = 3;
            this.Synchronisieren.Text = "Synchronisieren";
            this.Synchronisieren.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Synchronisieren);
            this.Controls.Add(this.SaveAllButton);
            this.Controls.Add(this.AddTableButton);
            this.Controls.Add(this.GridTabControl);
            this.Name = "MainView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl GridTabControl;
        private System.Windows.Forms.Button AddTableButton;
        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.Button Synchronisieren;
    }
}

