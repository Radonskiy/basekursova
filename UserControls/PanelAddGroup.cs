using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelAddGroup : UserControl
    {
        public PanelAddGroup()
        {
            InitializeComponent();
            LoadEducators();
            LoadGroups();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            this.BackColor = Styles.MainBackgroundColor;

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.Font = Styles.MainFont;
                }
                else if (control is TextBox textBox)
                {
                    textBox.Font = Styles.MainFont;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.Font = Styles.MainFont;
                    comboBox.BackColor = Styles.MainBackgroundColor;
                }
                else if (control is Button button)
                {
                    button.Font = Styles.ButtonFont;
                    button.BackColor = Styles.ButtonBackColor;
                    button.ForeColor = Styles.ButtonForeColor;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Size = new Size(Styles.ButtonWidth, Styles.ButtonHeight);
                }
                else if (control is ListView listView)
                {
                    listView.Font = Styles.MainFont;
                    listView.BackColor = Styles.MainBackgroundColor;
                }
            }
        }

        private void LoadEducators()
        {
            cbEducators.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Educators";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbEducators.Items.Add(new ComboBoxItem(
                        $"{reader["first_name"]} {reader["last_name"]}",
                        int.Parse(reader["educator_id"].ToString())
                    ));
                }
            }

            if (cbEducators.Items.Count > 0)
                cbEducators.SelectedIndex = 0;
        }

        private void LoadGroups()
        {
            listViewGroups.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Groups.group_id, Groups.group_name, Educators.first_name, Educators.last_name
                    FROM Groups
                    JOIN Educators ON Groups.educator_id = Educators.educator_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["group_id"].ToString());
                    item.SubItems.Add(reader["group_name"].ToString());
                    item.SubItems.Add($"{reader["first_name"]} {reader["last_name"]}");
                    listViewGroups.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                MessageBox.Show("Назва групи обов'язкова для заповнення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbEducators.SelectedItem == null)
            {
                MessageBox.Show("Виберіть вихователя.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int educatorId = ((ComboBoxItem)cbEducators.SelectedItem).Value;

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Groups (group_name, educator_id) VALUES (@group_name, @educator_id)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@group_name", txtGroupName.Text.Trim());
                command.Parameters.AddWithValue("@educator_id", educatorId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Групу додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadGroups();
        }

        private void ClearFields()
        {
            txtGroupName.Text = "";
            if (cbEducators.Items.Count > 0)
                cbEducators.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть групу для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int groupId = int.Parse(listViewGroups.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                // Перевірка на наявність дітей у групі
                string checkQuery = "SELECT COUNT(*) FROM Children WHERE group_id = @group_id";
                SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@group_id", groupId);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Неможливо видалити групу, оскільки в ній є діти.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "DELETE FROM Groups WHERE group_id = @group_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@group_id", groupId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Групу видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGroups();
        }
    }
}