namespace ChildrenGardenInterface.UserControls
{
    partial class PanelAddGroup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblEducator;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.ComboBox cbEducators;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderGroupName;
        private System.Windows.Forms.ColumnHeader columnHeaderEducator;

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
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblEducator = new System.Windows.Forms.Label();
            this.cbEducators = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGroupName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEducator = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(20, 20);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(76, 13);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Назва групи:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(120, 17);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(200, 20);
            this.txtGroupName.TabIndex = 1;
            // 
            // lblEducator
            // 
            this.lblEducator.AutoSize = true;
            this.lblEducator.Location = new System.Drawing.Point(20, 50);
            this.lblEducator.Name = "lblEducator";
            this.lblEducator.Size = new System.Drawing.Size(70, 13);
            this.lblEducator.TabIndex = 2;
            this.lblEducator.Text = "Вихователь:";
            // 
            // cbEducators
            // 
            this.cbEducators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEducators.FormattingEnabled = true;
            this.cbEducators.Location = new System.Drawing.Point(120, 47);
            this.cbEducators.Name = "cbEducators";
            this.cbEducators.Size = new System.Drawing.Size(200, 21);
            this.cbEducators.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(340, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(340, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listViewGroups
            // 
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderGroupName,
            this.columnHeaderEducator});
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(20, 100);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(600, 420);
            this.listViewGroups.TabIndex = 6;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 50;
            // 
            // columnHeaderGroupName
            // 
            this.columnHeaderGroupName.Text = "Назва групи";
            this.columnHeaderGroupName.Width = 200;
            // 
            // columnHeaderEducator
            // 
            this.columnHeaderEducator.Text = "Вихователь";
            this.columnHeaderEducator.Width = 200;
            // 
            // PanelAddGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewGroups);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbEducators);
            this.Controls.Add(this.lblEducator);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Name = "PanelAddGroup";
            this.Size = new System.Drawing.Size(800, 550);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}