using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelAddParent : UserControl
    {
        public PanelAddParent()
        {
            InitializeComponent();
            LoadParents();
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

        private void LoadParents()
        {
            listViewParents.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Parents";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["parent_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    item.SubItems.Add(reader["phone_number"].ToString());
                    item.SubItems.Add(reader["email"].ToString());
                    listViewParents.Items.Add(item);
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
                string query = "INSERT INTO Parents (first_name, last_name, phone_number, email) VALUES (@first_name, @last_name, @phone_number, @email)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                command.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                command.Parameters.AddWithValue("@phone_number", txtPhoneNumber.Text.Trim());
                command.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Батьків додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadParents();
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewParents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть батьків для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int parentId = int.Parse(listViewParents.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                // Перевірка на наявність дітей, пов'язаних з батьками
                string checkQuery = "SELECT COUNT(*) FROM Children WHERE parent_id = @parent_id";
                SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@parent_id", parentId);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Неможливо видалити батьків, оскільки з ними пов'язані діти.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "DELETE FROM Parents WHERE parent_id = @parent_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@parent_id", parentId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Батьків видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadParents();
        }
    }
}