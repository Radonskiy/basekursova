namespace ChildrenGardenInterface.UserControls
{
    partial class PanelManageGroup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.ListView listViewChildren;
        private System.Windows.Forms.ColumnHeader columnHeaderChildId;
        private System.Windows.Forms.ColumnHeader columnHeaderChildFirstName;
        private System.Windows.Forms.ColumnHeader columnHeaderChildLastName;
        private System.Windows.Forms.ListView listViewAvailableChildren;
        private System.Windows.Forms.ColumnHeader columnHeaderAvailableChildId;
        private System.Windows.Forms.ColumnHeader columnHeaderAvailableChildFirstName;
        private System.Windows.Forms.ColumnHeader columnHeaderAvailableChildLastName;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnRemoveChild;
        private System.Windows.Forms.Label lblGroupChildren;
        private System.Windows.Forms.Label lblAvailableChildren;
        private System.Windows.Forms.Label lblAttendanceDate;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Button btnManageAttendance;

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
            this.lblGroup = new System.Windows.Forms.Label();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.listViewChildren = new System.Windows.Forms.ListView();
            this.columnHeaderChildId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChildFirstName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChildLastName = new System.Windows.Forms.ColumnHeader();
            this.listViewAvailableChildren = new System.Windows.Forms.ListView();
            this.columnHeaderAvailableChildId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAvailableChildFirstName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAvailableChildLastName = new System.Windows.Forms.ColumnHeader();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnRemoveChild = new System.Windows.Forms.Button();
            this.lblGroupChildren = new System.Windows.Forms.Label();
            this.lblAvailableChildren = new System.Windows.Forms.Label();
            this.lblAttendanceDate = new System.Windows.Forms.Label();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.btnManageAttendance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(20, 20);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Група:";
            // 
            // cbGroups
            // 
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(80, 17);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(200, 21);
            this.cbGroups.TabIndex = 1;
            this.cbGroups.SelectedIndexChanged += new System.EventHandler(this.cbGroups_SelectedIndexChanged);
            // 
            // lblGroupChildren
            // 
            this.lblGroupChildren.AutoSize = true;
            this.lblGroupChildren.Location = new System.Drawing.Point(20, 50);
            this.lblGroupChildren.Name = "lblGroupChildren";
            this.lblGroupChildren.Size = new System.Drawing.Size(92, 13);
            this.lblGroupChildren.TabIndex = 2;
            this.lblGroupChildren.Text = "Діти в групі:";
            // 
            // listViewChildren
            // 
            this.listViewChildren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChildId,
            this.columnHeaderChildFirstName,
            this.columnHeaderChildLastName});
            this.listViewChildren.FullRowSelect = true;
            this.listViewChildren.HideSelection = false;
            this.listViewChildren.Location = new System.Drawing.Point(20, 70);
            this.listViewChildren.MultiSelect = false;
            this.listViewChildren.Name = "listViewChildren";
            this.listViewChildren.Size = new System.Drawing.Size(300, 200);
            this.listViewChildren.TabIndex = 3;
            this.listViewChildren.UseCompatibleStateImageBehavior = false;
            this.listViewChildren.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderChildId
            // 
            this.columnHeaderChildId.Text = "ID";
            // 
            // columnHeaderChildFirstName
            // 
            this.columnHeaderChildFirstName.Text = "Ім'я";
            this.columnHeaderChildFirstName.Width = 120;
            // 
            // columnHeaderChildLastName
            // 
            this.columnHeaderChildLastName.Text = "Прізвище";
            this.columnHeaderChildLastName.Width = 120;
            // 
            // lblAvailableChildren
            // 
            this.lblAvailableChildren.AutoSize = true;
            this.lblAvailableChildren.Location = new System.Drawing.Point(340, 50);
            this.lblAvailableChildren.Name = "lblAvailableChildren";
            this.lblAvailableChildren.Size = new System.Drawing.Size(117, 13);
            this.lblAvailableChildren.TabIndex = 4;
            this.lblAvailableChildren.Text = "Доступні діти:";
            // 
            // listViewAvailableChildren
            // 
            this.listViewAvailableChildren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAvailableChildId,
            this.columnHeaderAvailableChildFirstName,
            this.columnHeaderAvailableChildLastName});
            this.listViewAvailableChildren.FullRowSelect = true;
            this.listViewAvailableChildren.HideSelection = false;
            this.listViewAvailableChildren.Location = new System.Drawing.Point(340, 70);
            this.listViewAvailableChildren.MultiSelect = false;
            this.listViewAvailableChildren.Name = "listViewAvailableChildren";
            this.listViewAvailableChildren.Size = new System.Drawing.Size(300, 200);
            this.listViewAvailableChildren.TabIndex = 5;
            this.listViewAvailableChildren.UseCompatibleStateImageBehavior = false;
            this.listViewAvailableChildren.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAvailableChildId
            // 
            this.columnHeaderAvailableChildId.Text = "ID";
            // 
            // columnHeaderAvailableChildFirstName
            // 
            this.columnHeaderAvailableChildFirstName.Text = "Ім'я";
            this.columnHeaderAvailableChildFirstName.Width = 120;
            // 
            // columnHeaderAvailableChildLastName
            // 
            this.columnHeaderAvailableChildLastName.Text = "Прізвище";
            this.columnHeaderAvailableChildLastName.Width = 120;
            // 
            // btnAddChild
            // 
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnAddChild.Location = new System.Drawing.Point(660, 70);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnAddChild.TabIndex = 6;
            this.btnAddChild.Text = "Додати до групи";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnRemoveChild
            // 
            this.btnRemoveChild = new System.Windows.Forms.Button();
            this.btnRemoveChild.Location = new System.Drawing.Point(660, 70 + Styles.ButtonHeight + Styles.ControlSpacing);
            this.btnRemoveChild.Name = "btnRemoveChild";
            this.btnRemoveChild.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnRemoveChild.TabIndex = 7;
            this.btnRemoveChild.Text = "Прибрати \nз групи";
            this.btnRemoveChild.UseVisualStyleBackColor = true;
            this.btnRemoveChild.Click += new System.EventHandler(this.btnRemoveChild_Click);
            // 
            // lblAttendanceDate
            // 
            this.lblAttendanceDate.AutoSize = true;
            this.lblAttendanceDate.Location = new System.Drawing.Point(20, 330);
            this.lblAttendanceDate.Name = "lblAttendanceDate";
            this.lblAttendanceDate.Size = new System.Drawing.Size(33, 13);
            this.lblAttendanceDate.TabIndex = 8;
            this.lblAttendanceDate.Text = "Дата:";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Location = new System.Drawing.Point(80, 327);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(200, 20);
            this.dtpAttendanceDate.TabIndex = 9;
            // 
            // btnManageAttendance
            // 
            this.btnManageAttendance = new System.Windows.Forms.Button();
            this.btnManageAttendance.Location = new System.Drawing.Point(660, 70 + (Styles.ButtonHeight + Styles.ControlSpacing) * 2);
            this.btnManageAttendance.Name = "btnManageAttendance";
            this.btnManageAttendance.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnManageAttendance.TabIndex = 8;
            this.btnManageAttendance.Text = "Відвідуваність";
            this.btnManageAttendance.UseVisualStyleBackColor = true;
            this.btnManageAttendance.Click += new System.EventHandler(this.btnManageAttendance_Click);
            // 
            // PanelManageGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnManageAttendance);
            this.Controls.Add(this.dtpAttendanceDate);
            this.Controls.Add(this.lblAttendanceDate);
            this.Controls.Add(this.btnRemoveChild);
            this.Controls.Add(this.btnAddChild);
            this.Controls.Add(this.listViewAvailableChildren);
            this.Controls.Add(this.lblAvailableChildren);
            this.Controls.Add(this.listViewChildren);
            this.Controls.Add(this.lblGroupChildren);
            this.Controls.Add(this.cbGroups);
            this.Controls.Add(this.lblGroup);
            this.Name = "PanelManageGroup";
            this.Size = new System.Drawing.Size(800, 550);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}