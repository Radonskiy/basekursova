namespace ChildrenGardenInterface
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewAttendance;
        private System.Windows.Forms.ColumnHeader columnHeaderChildId;
        private System.Windows.Forms.ColumnHeader columnHeaderChildFirstName;
        private System.Windows.Forms.ColumnHeader columnHeaderChildLastName;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button btnSave;

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
            this.listViewAttendance = new System.Windows.Forms.ListView();
            this.columnHeaderChildId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChildFirstName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChildLastName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStatus = new System.Windows.Forms.ColumnHeader();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewAttendance
            // 
            this.listViewAttendance.CheckBoxes = true;
            this.listViewAttendance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChildId,
            this.columnHeaderChildFirstName,
            this.columnHeaderChildLastName,
            this.columnHeaderStatus});
            this.listViewAttendance.FullRowSelect = true;
            this.listViewAttendance.HideSelection = false;
            this.listViewAttendance.Location = new System.Drawing.Point(20, 20);
            this.listViewAttendance.MultiSelect = false;
            this.listViewAttendance.Name = "listViewAttendance";
            this.listViewAttendance.Size = new System.Drawing.Size(600, 500);
            this.listViewAttendance.TabIndex = 0;
            this.listViewAttendance.UseCompatibleStateImageBehavior = false;
            this.listViewAttendance.View = System.Windows.Forms.View.Details;
            this.listViewAttendance.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewAttendance_ItemChecked);
            // 
            // columnHeaderChildId
            // 
            this.columnHeaderChildId.Text = "ID";
            this.columnHeaderChildId.Width = 50;
            // 
            // columnHeaderChildFirstName
            // 
            this.columnHeaderChildFirstName.Text = "Ім'я";
            this.columnHeaderChildFirstName.Width = 150;
            // 
            // columnHeaderChildLastName
            // 
            this.columnHeaderChildLastName.Text = "Прізвище";
            this.columnHeaderChildLastName.Width = 150;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Статус";
            this.columnHeaderStatus.Width = 100;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40); // Використовуємо розмір з Styles
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AttendanceForm
            // 
            this.ClientSize = new System.Drawing.Size(640, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewAttendance);
            this.Name = "AttendanceForm";
            this.Text = "Відвідуваність";
            this.ResumeLayout(false);
        }
    }
}