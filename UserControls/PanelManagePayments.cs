using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChildrenGardenInterface.UserControls
{
    public partial class PanelManagePayments : UserControl
    {
        private Dictionary<int, List<string>> selectedMonthsPerYear = new Dictionary<int, List<string>>();
        private List<string> allMonths = new List<string>
        {
            "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
            "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
        };

        public PanelManagePayments()
        {
            InitializeComponent();
            LoadChildren();
            LoadPayments();
            ApplyStyles();
            SetDefaultYear();
            numericYear.ValueChanged += NumericYear_ValueChanged;
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
                else if (control is CheckedListBox checkedListBox)
                {
                    checkedListBox.Font = Styles.MainFont;
                    checkedListBox.BackColor = Styles.MainBackgroundColor;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Font = Styles.MainFont;
                    numericUpDown.BackColor = Styles.MainBackgroundColor;
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

        private void LoadChildren()
        {
            cbChildren.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = "SELECT child_id, first_name, last_name FROM Children";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbChildren.Items.Add(new ComboBoxItem(
                        $"{reader["first_name"]} {reader["last_name"]}",
                        int.Parse(reader["child_id"].ToString())
                    ));
                }
            }

            if (cbChildren.Items.Count > 0)
                cbChildren.SelectedIndex = 0;
        }

        private void SetDefaultYear()
        {
            int currentYear = DateTime.Now.Year;
            numericYear.Value = currentYear;
            LoadMonthsForYear(currentYear);
        }

        private void NumericYear_ValueChanged(object sender, EventArgs e)
        {
            SaveCurrentYearMonths();
            int year = (int)numericYear.Value;
            LoadMonthsForYear(year);
        }

        private void SaveCurrentYearMonths()
        {
            int currentYear = (int)numericYear.Value;
            var selectedMonths = clbMonths.CheckedItems.Cast<string>().ToList();
            if (selectedMonthsPerYear.ContainsKey(currentYear))
            {
                selectedMonthsPerYear[currentYear] = selectedMonths;
            }
            else
            {
                selectedMonthsPerYear.Add(currentYear, selectedMonths);
            }
        }

        private void LoadMonthsForYear(int year)
        {
            clbMonths.Items.Clear();
            foreach (var month in allMonths)
            {
                clbMonths.Items.Add(month);
            }

            if (selectedMonthsPerYear.ContainsKey(year))
            {
                var selectedMonths = selectedMonthsPerYear[year];
                for (int i = 0; i < clbMonths.Items.Count; i++)
                {
                    clbMonths.SetItemChecked(i, selectedMonths.Contains(clbMonths.Items[i].ToString()));
                }
            }
            else
            {
                for (int i = 0; i < clbMonths.Items.Count; i++)
                {
                    clbMonths.SetItemChecked(i, false);
                }
            }
        }

        private void LoadPayments()
        {
            listViewPayments.Items.Clear();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Payments.payment_id, Payments.amount, Payments.months, Payments.year, Payments.date,
                           Children.first_name, Children.last_name
                    FROM Payments
                    JOIN Children ON Payments.child_id = Children.child_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["payment_id"].ToString());
                    item.SubItems.Add($"{reader["first_name"]} {reader["last_name"]}");
                    item.SubItems.Add(reader["amount"].ToString());
                    item.SubItems.Add(reader["months"].ToString());
                    item.SubItems.Add(reader["year"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["date"]).ToShortDateString());
                    listViewPayments.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveCurrentYearMonths();

            if (cbChildren.SelectedItem == null)
            {
                MessageBox.Show("Виберіть дитину.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int childId = ((ComboBoxItem)cbChildren.SelectedItem).Value;

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                foreach (var kvp in selectedMonthsPerYear)
                {
                    int year = kvp.Key;
                    var months = kvp.Value;

                    if (months.Count == 0)
                    {
                        continue;
                    }

                    double amount = months.Count * 8000;
                    string monthsStr = BuildMonthRanges(months);
                    DateTime date = DateTime.Now;

                    string query = "INSERT INTO Payments (child_id, amount, months, year, date) VALUES (@child_id, @amount, @months, @year, @date)";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@child_id", childId);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@months", monthsStr);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@date", date);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Оплату додано успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedMonthsPerYear.Clear();
            LoadMonthsForYear((int)numericYear.Value);
            LoadPayments();
        }

        private string BuildMonthRanges(List<string> months)
        {
            months = months.Select(m => m.Substring(0, 3).ToLower()).ToList();
            months.Sort(new MonthComparer());

            List<string> ranges = new List<string>();
            int start = 0;

            while (start < months.Count)
            {
                int end = start;
                while (end + 1 < months.Count && IsConsecutiveMonths(months[end], months[end + 1]))
                {
                    end++;
                }

                if (start == end)
                {
                    ranges.Add(months[start]);
                }
                else
                {
                    ranges.Add($"{months[start]}-{months[end]}");
                }

                start = end + 1;
            }

            return string.Join(", ", ranges);
        }

        private bool IsConsecutiveMonths(string current, string next)
        {
            int currentIndex = allMonths.FindIndex(m => m.StartsWith(current, StringComparison.InvariantCultureIgnoreCase));
            int nextIndex = allMonths.FindIndex(m => m.StartsWith(next, StringComparison.InvariantCultureIgnoreCase));
            return (nextIndex - currentIndex) == 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPayments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть оплату для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int paymentId = int.Parse(listViewPayments.SelectedItems[0].Text);

            using (var connection = Database.GetConnection())
            {
                connection.Open();

                string query = "DELETE FROM Payments WHERE payment_id = @payment_id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@payment_id", paymentId);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Оплату видалено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPayments();
        }
    }

    // Допоміжний клас для сортування місяців
    public class MonthComparer : IComparer<string>
    {
        private List<string> monthsOrder = new List<string>
        {
            "січ", "лют", "бер", "кві", "тра", "чер",
            "лип", "сер", "вер", "жов", "лис", "гру"
        };

        public int Compare(string x, string y)
        {
            int indexX = monthsOrder.IndexOf(x);
            int indexY = monthsOrder.IndexOf(y);
            return indexX.CompareTo(indexY);
        }
    }
}