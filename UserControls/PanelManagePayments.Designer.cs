namespace ChildrenGardenInterface.UserControls
{
    partial class PanelManagePayments
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.ComboBox cbChildren;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.CheckedListBox clbMonths;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listViewPayments;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderChild;
        private System.Windows.Forms.ColumnHeader columnHeaderAmount;
        private System.Windows.Forms.ColumnHeader columnHeaderMonths;
        private System.Windows.Forms.ColumnHeader columnHeaderYear;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;

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
            this.lblChildren = new System.Windows.Forms.Label();
            this.cbChildren = new System.Windows.Forms.ComboBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.clbMonths = new System.Windows.Forms.CheckedListBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listViewPayments = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChild = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAmount = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMonths = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderYear = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDate = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.Location = new System.Drawing.Point(20, 20);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(40, 13);
            this.lblChildren.TabIndex = 0;
            this.lblChildren.Text = "Дитина:";
            // 
            // cbChildren
            // 
            this.cbChildren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChildren.FormattingEnabled = true;
            this.cbChildren.Location = new System.Drawing.Point(100, 17);
            this.cbChildren.Name = "cbChildren";
            this.cbChildren.Size = new System.Drawing.Size(200, 21);
            this.cbChildren.TabIndex = 1;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Location = new System.Drawing.Point(20, 50);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(44, 13);
            this.lblMonths.TabIndex = 2;
            this.lblMonths.Text = "Місяці:";
            // 
            // clbMonths
            // 
            this.clbMonths.CheckOnClick = true;
            this.clbMonths.FormattingEnabled = true;
            this.clbMonths.Items.AddRange(new object[] {
            "Січень",
            "Лютий",
            "Березень",
            "Квітень",
            "Травень",
            "Червень",
            "Липень",
            "Серпень",
            "Вересень",
            "Жовтень",
            "Листопад",
            "Грудень"});
            this.clbMonths.Location = new System.Drawing.Point(100, 50);
            this.clbMonths.Name = "clbMonths";
            this.clbMonths.Size = new System.Drawing.Size(200, 109);
            this.clbMonths.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 170);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(27, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Рік:";
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(100, 168);
            this.numericYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(200, 20);
            this.numericYear.TabIndex = 5;
            this.numericYear.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Location = new System.Drawing.Point(320, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Location = new System.Drawing.Point(320, 17 + Styles.ButtonHeight + Styles.ControlSpacing);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(Styles.ButtonWidth, Styles.ButtonHeight);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // 
            // listViewPayments
            // 
            this.listViewPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderChild,
            this.columnHeaderAmount,
            this.columnHeaderMonths,
            this.columnHeaderYear,
            this.columnHeaderDate});
            this.listViewPayments.FullRowSelect = true;
            this.listViewPayments.HideSelection = false;
            this.listViewPayments.Location = new System.Drawing.Point(20, 200);
            this.listViewPayments.MultiSelect = false;
            this.listViewPayments.Name = "listViewPayments";
            this.listViewPayments.Size = new System.Drawing.Size(600, 320);
            this.listViewPayments.TabIndex = 8;
            this.listViewPayments.UseCompatibleStateImageBehavior = false;
            this.listViewPayments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            // 
            // columnHeaderChild
            // 
            this.columnHeaderChild.Text = "Дитина";
            this.columnHeaderChild.Width = 120;
            // 
            // columnHeaderAmount
            // 
            this.columnHeaderAmount.Text = "Сума";
            this.columnHeaderAmount.Width = 80;
            // 
            // columnHeaderMonths
            // 
            this.columnHeaderMonths.Text = "Місяці";
            this.columnHeaderMonths.Width = 180;
            // 
            // columnHeaderYear
            // 
            this.columnHeaderYear.Text = "Рік";
            this.columnHeaderYear.Width = 50;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Дата оплати";
            this.columnHeaderDate.Width = 100;
            // 
            // PanelManagePayments
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewPayments);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.clbMonths);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.cbChildren);
            this.Controls.Add(this.lblChildren);
            this.Name = "PanelManagePayments";
            this.Size = new System.Drawing.Size(800, 550);
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}