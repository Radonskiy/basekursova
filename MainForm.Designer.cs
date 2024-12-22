namespace ChildrenGardenInterface
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnAddEducator;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnManageEvents;
        private System.Windows.Forms.Button btnManagePayments;
        private System.Windows.Forms.Button btnManageGroup;

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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnManageGroup = new System.Windows.Forms.Button();
            this.btnManagePayments = new System.Windows.Forms.Button();
            this.btnManageEvents = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnAddParent = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddEducator = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.pictureBoxLogo);
            this.sidePanel.Controls.Add(this.btnManageGroup);
            this.sidePanel.Controls.Add(this.btnManagePayments);
            this.sidePanel.Controls.Add(this.btnManageEvents);
            this.sidePanel.Controls.Add(this.btnAddChild);
            this.sidePanel.Controls.Add(this.btnAddParent);
            this.sidePanel.Controls.Add(this.btnAddGroup);
            this.sidePanel.Controls.Add(this.btnAddEducator);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(220, 600);
            this.sidePanel.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 150);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnAddEducator
            // 
            this.btnAddEducator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddEducator.Location = new System.Drawing.Point(10, 170);
            this.btnAddEducator.Name = "btnAddEducator";
            this.btnAddEducator.Size = new System.Drawing.Size(200, 50);
            this.btnAddEducator.TabIndex = 1;
            this.btnAddEducator.Text = "Додати вихователя";
            this.btnAddEducator.UseVisualStyleBackColor = true;
            this.btnAddEducator.Click += new System.EventHandler(this.btnAddEducator_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddGroup.Location = new System.Drawing.Point(10, 230);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(200, 50);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "Додати групу";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddParent
            // 
            this.btnAddParent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddParent.Location = new System.Drawing.Point(10, 290);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(200, 50);
            this.btnAddParent.TabIndex = 3;
            this.btnAddParent.Text = "Додати батьків";
            this.btnAddParent.UseVisualStyleBackColor = true;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddChild.Location = new System.Drawing.Point(10, 350);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(200, 50);
            this.btnAddChild.TabIndex = 4;
            this.btnAddChild.Text = "Додати дітей";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnManageEvents
            // 
            this.btnManageEvents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageEvents.Location = new System.Drawing.Point(10, 410);
            this.btnManageEvents.Name = "btnManageEvents";
            this.btnManageEvents.Size = new System.Drawing.Size(200, 50);
            this.btnManageEvents.TabIndex = 5;
            this.btnManageEvents.Text = "Керування подіями";
            this.btnManageEvents.UseVisualStyleBackColor = true;
            this.btnManageEvents.Click += new System.EventHandler(this.btnManageEvents_Click);
            // 
            // btnManagePayments
            // 
            this.btnManagePayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManagePayments.Location = new System.Drawing.Point(10, 470);
            this.btnManagePayments.Name = "btnManagePayments";
            this.btnManagePayments.Size = new System.Drawing.Size(200, 50);
            this.btnManagePayments.TabIndex = 6;
            this.btnManagePayments.Text = "Керування оплатами";
            this.btnManagePayments.UseVisualStyleBackColor = true;
            this.btnManagePayments.Click += new System.EventHandler(this.btnManagePayments_Click);
            // 
            // btnManageGroup
            // 
            this.btnManageGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageGroup.Location = new System.Drawing.Point(10, 530);
            this.btnManageGroup.Name = "btnManageGroup";
            this.btnManageGroup.Size = new System.Drawing.Size(200, 50);
            this.btnManageGroup.TabIndex = 7;
            this.btnManageGroup.Text = "Керування групою";
            this.btnManageGroup.UseVisualStyleBackColor = true;
            this.btnManageGroup.Click += new System.EventHandler(this.btnManageGroup_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(220, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(780, 600);
            this.mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Name = "MainForm";
            this.Text = "Дитячий садок";
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}