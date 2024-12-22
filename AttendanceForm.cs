using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ChildrenGardenInterface
{
    public partial class AttendanceForm : Form
    {
        private int groupId;
        private DateTime date;

        public AttendanceForm(int groupId, DateTime date)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.date = date;
            ApplyStyles();
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            listViewAttendance.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Children.child_id, Children.first_name, Children.last_name, 
                    (SELECT status FROM Attendance WHERE child_id = Children.child_id AND date = @date) AS status
                    FROM Children
                    WHERE Children.group_id = @group_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@group_id", groupId);
                command.Parameters.AddWithValue("@date", date);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bool isPresent = reader["status"] != DBNull.Value && reader["status"].ToString() == "присутній";
                    ListViewItem item = new ListViewItem(reader["child_id"].ToString());
                    item.SubItems.Add(reader["first_name"].ToString());
                    item.SubItems.Add(reader["last_name"].ToString());
                    item.Checked = isPresent;
                    item.SubItems.Add(isPresent ? "присутній" : "відсутній");
                    listViewAttendance.Items.Add(item);
                }
            }
        }
        private void ApplyStyles()
        {
            this.BackColor = Styles.MainBackgroundColor;
            this.Font = Styles.MainFont;

            btnSave.Font = Styles.ButtonFont;
            btnSave.BackColor = Styles.ButtonBackColor;
            btnSave.ForeColor = Styles.ButtonForeColor;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Size = new Size(Styles.ButtonWidth, Styles.ButtonHeight);

            listViewAttendance.Font = Styles.MainFont;
            listViewAttendance.BackColor = Styles.MainBackgroundColor;

            foreach (ColumnHeader column in listViewAttendance.Columns)
            {
                //
            }

            this.Text = "Відвідуваність";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                foreach (ListViewItem item in listViewAttendance.Items)
                {
                    int childId = int.Parse(item.Text);
                    string status = item.Checked ? "присутній" : "відсутній";

                    string queryCheck = "SELECT COUNT(*) FROM Attendance WHERE child_id = @child_id AND date = @date";
                    SQLiteCommand commandCheck = new SQLiteCommand(queryCheck, connection);
                    commandCheck.Parameters.AddWithValue("@child_id", childId);
                    commandCheck.Parameters.AddWithValue("@date", date);
                    int count = Convert.ToInt32(commandCheck.ExecuteScalar());

                    string query;
                    if (count > 0)
                    {
                        query = "UPDATE Attendance SET status = @status WHERE child_id = @child_id AND date = @date";
                    }
                    else
                    {
                        query = "INSERT INTO Attendance (child_id, date, status) VALUES (@child_id, @date, @status)";
                    }

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@child_id", childId);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@status", status);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Відвідуваність збережено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void listViewAttendance_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.SubItems[3].Text = e.Item.Checked ? "присутній" : "відсутній";
        }
    }
}