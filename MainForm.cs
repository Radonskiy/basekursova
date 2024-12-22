using System;
using System.IO;
using System.Windows.Forms;
//using ChildrenGardenInterface.UserControl;
using ChildrenGardenInterface.UserControls;
using System.Drawing;

namespace ChildrenGardenInterface
{
    public partial class MainForm : Form
    {
        private UserControl currentPanel;

        public MainForm()
        {
            InitializeComponent();
            LoadLogoImage();
            ApplyStyles();
        }

        private void LoadLogoImage()
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons", "main.png");
            if (File.Exists(imagePath))
            {
                pictureBoxLogo.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show($"Зображення не знайдено за шляхом: {imagePath}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyStyles()
        {
            this.BackColor = Styles.MainBackgroundColor;
            mainPanel.BackColor = Styles.MainBackgroundColor;

            sidePanel.Paint += SidePanel_Paint;

            foreach (Control control in sidePanel.Controls)
            {
                if (control is Button button)
                {
                    button.Font = Styles.ButtonFont;
                    button.BackColor = Styles.ButtonBackColor;
                    button.ForeColor = Styles.ButtonForeColor;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                }
            }

            this.Font = Styles.MainFont;
        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                sidePanel.ClientRectangle,
                Styles.SidePanelGradientStartColor,
                Styles.SidePanelGradientEndColor,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, sidePanel.ClientRectangle);
        }

        private void ShowPanel(UserControl panel)
        {
            if (currentPanel != null)
                mainPanel.Controls.Remove(currentPanel);

            currentPanel = panel;
            currentPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(currentPanel);
        }

        private void btnAddEducator_Click(object sender, EventArgs e)
        {
            PanelAddEducator panel = new PanelAddEducator();
            ShowPanel(panel);
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            PanelAddGroup panel = new PanelAddGroup();
            ShowPanel(panel);
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            PanelAddParent panel = new PanelAddParent();
            ShowPanel(panel);
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            PanelAddChild panel = new PanelAddChild();
            ShowPanel(panel);
        }

        private void btnManageEvents_Click(object sender, EventArgs e)
        {
            PanelManageEvents panel = new PanelManageEvents();
            ShowPanel(panel);
        }

        private void btnManagePayments_Click(object sender, EventArgs e)
        {
            PanelManagePayments panel = new PanelManagePayments();
            ShowPanel(panel);
        }

        private void btnManageGroup_Click(object sender, EventArgs e)
        {
            PanelManageGroup panel = new PanelManageGroup();
            ShowPanel(panel);
        }
    }
}