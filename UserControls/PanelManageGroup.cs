using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelManageGroup : UserControl
    {
        public PanelManageGroup()
        {
            InitializeComponent();
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
            {
                cbGroups.SelectedIndex = 0;
            }
        }

        private void LoadGroupChildren()
        {
            if (cbGroups.SelectedItem == null)
                return;

            int groupId = ((ComboBoxItem)cbGroups.SelectedItem).Value;
            listViewChildren.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Children.child_id, Children.first_name, Children.last_name
                    FROM Children
                    WHERE group_id = @group_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@group_id", groupId);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["child_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    listViewChildren.Items.Add(item);
                }
            }
        }

        private void LoadAvailableChildren()
        {
            listViewAvailableChildren.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT child_id, first_name, last_name
                    FROM Children
                    WHERE group_id IS NULL";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["child_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    listViewAvailableChildren.Items.Add(item);
                }
            }
        }

        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroupChildren();
            LoadAvailableChildren();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if (listViewAvailableChildren.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть дитину для додавання до групи.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int childId = int.Parse(listViewAvailableChildren.SelectedItems[0].Text);
            int groupId = ((ComboBoxItem)cbGroups.SelectedItem).Value;

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Children SET group_id = @group_id WHERE child_id = @child_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@group_id", groupId);
                command.Parameters.AddWithValue("@child_id", childId);
                command.ExecuteNonQuery();
            }

            LoadGroupChildren();
            LoadAvailableChildren();
        }

        private void btnRemoveChild_Click(object sender, EventArgs e)
        {
            if (listViewChildren.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть дитину для видалення з групи.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int childId = int.Parse(listViewChildren.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Children SET group_id = NULL WHERE child_id = @child_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@child_id", childId);
                command.ExecuteNonQuery();
            }

            LoadGroupChildren();
            LoadAvailableChildren();
        }

        private void btnManageAttendance_Click(object sender, EventArgs e)
        {
            if (cbGroups.SelectedItem == null)
            {
                MessageBox.Show("Виберіть групу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int groupId = ((ComboBoxItem)cbGroups.SelectedItem).Value;
            DateTime date = dtpAttendanceDate.Value.Date;

            AttendanceForm attendanceForm = new AttendanceForm(groupId, date);
            attendanceForm.ShowDialog();
        }
    }
}