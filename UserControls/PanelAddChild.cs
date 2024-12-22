using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelAddChild : UserControl
    {
        public PanelAddChild()
        {
            InitializeComponent();
            LoadParents();
            ApplyStyles();
            LoadChildren();
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
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Font = Styles.MainFont;
                    dateTimePicker.CalendarMonthBackground = Styles.MainBackgroundColor;
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
            cbParents.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Parents";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbParents.Items.Add(new ComboBoxItem(
                        $"{reader["first_name"]} {reader["last_name"]}",
                        int.Parse(reader["parent_id"].ToString())
                    ));
                }
            }

            if (cbParents.Items.Count > 0)
                cbParents.SelectedIndex = 0;
        }

        private void LoadChildren()
        {
            listViewChildren.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Children.child_id, Children.first_name, Children.last_name, Children.date_of_birth, Parents.first_name AS parent_first, Parents.last_name AS parent_last
                    FROM Children
                    JOIN Parents ON Children.parent_id = Parents.parent_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["child_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["date_of_birth"]).ToShortDateString());
                    item.SubItems.Add($"{reader["parent_first"]} {reader["parent_last"]}");
                    listViewChildren.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || dtpDateOfBirth.Value == null)
            {
                MessageBox.Show("Ім'я, прізвище та дата народження обов'язкові для заповнення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbParents.SelectedItem == null)
            {
                MessageBox.Show("Виберіть батьків.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int parentId = ((ComboBoxItem)cbParents.SelectedItem).Value;

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Children (first_name, last_name, date_of_birth, parent_id) VALUES (@first_name, @last_name, @date_of_birth, @parent_id)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                command.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                command.Parameters.AddWithValue("@date_of_birth", dtpDateOfBirth.Value.Date);
                command.Parameters.AddWithValue("@parent_id", parentId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Дитину додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadChildren();
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
            if (cbParents.Items.Count > 0)
                cbParents.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewChildren.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть дитину для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int childId = int.Parse(listViewChildren.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                // Видалення пов'язаних записів про відвідуваність та оплату
                string deleteAttendanceQuery = "DELETE FROM Attendance WHERE child_id = @child_id";
                SQLiteCommand deleteAttendanceCommand = new SQLiteCommand(deleteAttendanceQuery, connection);
                deleteAttendanceCommand.Parameters.AddWithValue("@child_id", childId);
                deleteAttendanceCommand.ExecuteNonQuery();

                // Видалення запису про дитину
                string query = "DELETE FROM Children WHERE child_id = @child_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@child_id", childId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Дитину видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadChildren();
        }
    }
}