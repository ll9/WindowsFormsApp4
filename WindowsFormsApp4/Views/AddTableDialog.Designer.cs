namespace WindowsFormsApp4.Views
{
    partial class AddTableDialog
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
            System.Windows.Forms.Label nameLabel;
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.columnViewModelsDataGridView = new System.Windows.Forms.DataGridView();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addTableViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SqlCombobox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTableViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addTableViewModelBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(65, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(210, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // columnViewModelsDataGridView
            // 
            this.columnViewModelsDataGridView.AutoGenerateColumns = false;
            this.columnViewModelsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.columnViewModelsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.SqlCombobox});
            this.columnViewModelsDataGridView.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.addTableViewModelBindingSource, "ColumnViewModels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.columnViewModelsDataGridView.DataSource = this.columnViewModelBindingSource;
            this.columnViewModelsDataGridView.Location = new System.Drawing.Point(12, 55);
            this.columnViewModelsDataGridView.Name = "columnViewModelsDataGridView";
            this.columnViewModelsDataGridView.Size = new System.Drawing.Size(263, 220);
            this.columnViewModelsDataGridView.TabIndex = 2;
            this.columnViewModelsDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.columnViewModelsDataGridView_DefaultValuesNeeded);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(119, 297);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(200, 297);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Abbrechen";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // addTableViewModelBindingSource
            // 
            this.addTableViewModelBindingSource.DataSource = typeof(WindowsFormsApp4.ViewModels.AddTableViewModel);
            // 
            // columnViewModelBindingSource
            // 
            this.columnViewModelBindingSource.DataSource = typeof(WindowsFormsApp4.ViewModels.ColumnViewModel);
            // 
            // SqlType
            // 
            this.SqlCombobox.DataPropertyName = "SqlType";
            this.SqlCombobox.HeaderText = "SqlType";
            this.SqlCombobox.Name = "SqlType";
            // 
            // AddTableDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 332);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.columnViewModelsDataGridView);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Name = "AddTableDialog";
            this.Text = "AddTableDialog";
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTableViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource addTableViewModelBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridView columnViewModelsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource columnViewModelBindingSource;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn SqlCombobox;
    }
}