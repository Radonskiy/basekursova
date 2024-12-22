namespace ChildrenGardenInterface.UserControls
{
    partial class PanelAddChild
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cbParents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listViewChildren;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderFirstName;
        private System.Windows.Forms.ColumnHeader columnHeaderLastName;
        private System.Windows.Forms.ColumnHeader columnHeaderDateOfBirth;
        private System.Windows.Forms.ColumnHeader columnHeaderParent;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbParents = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listViewChildren = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFirstName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLastName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDateOfBirth = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParent = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 20);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(29, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "Ім'я:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(100, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 50);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(56, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Прізвище:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(100, 47);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 80);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(89, 13);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Дата народження:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(140, 77);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(160, 20);
            this.dtpDateOfBirth.TabIndex = 5;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(20, 110);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(50, 13);
            this.lblParent.TabIndex = 6;
            this.lblParent.Text = "Батьки:";
            // 
            // cbParents
            // 
            this.cbParents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParents.FormattingEnabled = true;
            this.cbParents.Location = new System.Drawing.Point(100, 107);
            this.cbParents.Name = "cbParents";
            this.cbParents.Size = new System.Drawing.Size(200, 21);
            this.cbParents.TabIndex = 7;
            // 
            // listViewChildren
            // 
            this.listViewChildren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderFirstName,
            this.columnHeaderLastName,
            this.columnHeaderDateOfBirth,
            this.columnHeaderParent});
            this.listViewChildren.FullRowSelect = true;
            this.listViewChildren.HideSelection = false;
            this.listViewChildren.Location = new System.Drawing.Point(20, 150);
            this.listViewChildren.MultiSelect = false;
            this.listViewChildren.Name = "listViewChildren";
            this.listViewChildren.Size = new System.Drawing.Size(600, 370);
            this.listViewChildren.TabIndex = 9;
            this.listViewChildren.UseCompatibleStateImageBehavior = false;
            this.listViewChildren.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            // 
            // columnHeaderFirstName
            // 
            this.columnHeaderFirstName.Text = "Ім'я";
            this.columnHeaderFirstName.Width = 120;
            // 
            // columnHeaderLastName
            // 
            this.columnHeaderLastName.Text = "Прізвище";
            this.columnHeaderLastName.Width = 120;
            // 
            // columnHeaderDateOfBirth
            // 
            this.columnHeaderDateOfBirth.Text = "Дата народження";
            this.columnHeaderDateOfBirth.Width = 120;
            // 
            // columnHeaderParent
            // 
            this.columnHeaderParent.Text = "Батьки";
            this.columnHeaderParent.Width = 150;
            //
            // btnAdd
            //
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Location = new System.Drawing.Point(320, 17);
            this.btnAdd.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnDelete
            //
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Location = new System.Drawing.Point(320, 17 + Styles.ButtonHeight + Styles.ControlSpacing);
            this.btnDelete.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PanelAddChild
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listViewChildren);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbParents);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Name = "PanelAddChild";
            this.Size = new System.Drawing.Size(800, 550);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}