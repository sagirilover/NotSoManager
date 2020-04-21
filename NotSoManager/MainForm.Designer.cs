namespace NotSoManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountGrid = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.passCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.accountGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // accountGrid
            // 
            this.accountGrid.AllowUserToAddRows = false;
            this.accountGrid.AllowUserToDeleteRows = false;
            this.accountGrid.AllowUserToOrderColumns = true;
            this.accountGrid.AllowUserToResizeRows = false;
            this.accountGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.accountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.loginColumn,
            this.passColumn});
            this.accountGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.accountGrid.Location = new System.Drawing.Point(12, 12);
            this.accountGrid.MultiSelect = false;
            this.accountGrid.Name = "accountGrid";
            this.accountGrid.RowHeadersVisible = false;
            this.accountGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountGrid.Size = new System.Drawing.Size(374, 209);
            this.accountGrid.TabIndex = 3;
            this.accountGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountGrid_CellDoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // loginColumn
            // 
            this.loginColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loginColumn.HeaderText = "Login";
            this.loginColumn.Name = "loginColumn";
            // 
            // passColumn
            // 
            this.passColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.passColumn.HeaderText = "Password";
            this.passColumn.Name = "passColumn";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(230, 227);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(311, 227);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // passCheckBox
            // 
            this.passCheckBox.AutoSize = true;
            this.passCheckBox.Location = new System.Drawing.Point(12, 231);
            this.passCheckBox.Name = "passCheckBox";
            this.passCheckBox.Size = new System.Drawing.Size(106, 17);
            this.passCheckBox.TabIndex = 6;
            this.passCheckBox.Text = "Show passwords";
            this.passCheckBox.UseVisualStyleBackColor = true;
            this.passCheckBox.CheckedChanged += new System.EventHandler(this.passCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(397, 257);
            this.Controls.Add(this.passCheckBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.accountGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NotSoManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView accountGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passColumn;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.CheckBox passCheckBox;
    }
}

