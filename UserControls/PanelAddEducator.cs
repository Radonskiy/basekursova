using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelAddEducator : UserControl
    {
        public PanelAddEducator()
        {
            InitializeComponent();
            LoadEducators();
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
            listViewEducators.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Educators";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["educator_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    item.SubItems.Add(reader["phone_number"].ToString());
                    listViewEducators.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Ім'я та прізвище обов'язкові для заповнення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Educators (first_name, last_name, phone_number) VALUES (@first_name, @last_name, @phone_number)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                command.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                command.Parameters.AddWithValue("@phone_number", txtPhoneNumber.Text.Trim());
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Вихователя додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadEducators();
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewEducators.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть вихователя для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int educatorId = int.Parse(listViewEducators.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                // Перевірка на наявність груп, закріплених за вихователем
                string checkQuery = "SELECT COUNT(*) FROM Groups WHERE educator_id = @educator_id";
                SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@educator_id", educatorId);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Неможливо видалити вихователя, оскільки за ним закріплені групи.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "DELETE FROM Educators WHERE educator_id = @educator_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@educator_id", educatorId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Вихователя видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEducators();
        }
    }
}