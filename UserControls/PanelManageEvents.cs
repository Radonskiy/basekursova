using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelManageEvents : UserControl
    {
        public PanelManageEvents()
        {
            InitializeComponent();
            LoadGroups();
            LoadEvents();
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

        private void LoadGroups()
        {
            cbGroups.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Groups";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbGroups.Items.Add(new ComboBoxItem(
                        $"{reader["group_name"]}",
                        int.Parse(reader["group_id"].ToString())
                    ));
                }
            }

            if (cbGroups.Items.Count > 0)
                cbGroups.SelectedIndex = 0;
        }

        private void LoadEvents()
        {
            listViewEvents.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Events.event_id, Events.event_name, Events.date, Groups.group_name
                    FROM Events
                    JOIN Groups ON Events.group_id = Groups.group_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["event_id"].ToString());
                    item.SubItems.Add(reader["event_name"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["date"]).ToShortDateString());
                    item.SubItems.Add(reader["group_name"].ToString());
                    listViewEvents.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text) || dtpEventDate.Value == null)
            {
                MessageBox.Show("Назва події та дата обов'язкові для заповнення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbGroups.SelectedItem == null)
            {
                MessageBox.Show("Виберіть групу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int groupId = ((ComboBoxItem)cbGroups.SelectedItem).Value;

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Events (event_name, date, group_id) VALUES (@event_name, @date, @group_id)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@event_name", txtEventName.Text.Trim());
                command.Parameters.AddWithValue("@date", dtpEventDate.Value.Date);
                command.Parameters.AddWithValue("@group_id", groupId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Подію додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadEvents();
        }

        private void ClearFields()
        {
            txtEventName.Text = "";
            dtpEventDate.Value = DateTime.Now;
            if (cbGroups.Items.Count > 0)
                cbGroups.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewEvents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть подію для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = int.Parse(listViewEvents.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                string query = "DELETE FROM Events WHERE event_id = @event_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@event_id", eventId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Подію видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEvents();
        }
    }
}