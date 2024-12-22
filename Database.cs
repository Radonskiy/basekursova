using System;
using System.Data.SQLite;
using System.IO;

namespace ChildrenGardenInterface
{
    public static class Database
    {
        private static string dbFile = "ChildrenGarden.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                CreateTables();
            }
        }

        private static void CreateTables()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string createParentsTable = @"
                    CREATE TABLE Parents (
                        parent_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        phone_number TEXT,
                        email TEXT
                    );
                ";

                string createChildrenTable = @"
                    CREATE TABLE Children (
                        child_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        date_of_birth DATE NOT NULL,
                        parent_id INTEGER NOT NULL,
                        group_id INTEGER,
                        FOREIGN KEY (parent_id) REFERENCES Parents(parent_id),
                        FOREIGN KEY (group_id) REFERENCES Groups(group_id)
                    );
                ";

                string createEducatorsTable = @"
                    CREATE TABLE Educators (
                        educator_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        phone_number TEXT
                    );
                ";

                string createGroupsTable = @"
                    CREATE TABLE Groups (
                        group_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        group_name TEXT NOT NULL,
                        educator_id INTEGER NOT NULL,
                        FOREIGN KEY (educator_id) REFERENCES Educators(educator_id)
                    );
                ";

                string createEventsTable = @"
                    CREATE TABLE Events (
                        event_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        event_name TEXT NOT NULL,
                        date DATE NOT NULL,
                        group_id INTEGER NOT NULL,
                        FOREIGN KEY (group_id) REFERENCES Groups(group_id)
                    );
                ";

                string createAttendanceTable = @"
                    CREATE TABLE Attendance (
                        attendance_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        child_id INTEGER NOT NULL,
                        date DATE NOT NULL,
                        status TEXT CHECK (status IN ('присутній', 'відсутній')) NOT NULL,
                        FOREIGN KEY (child_id) REFERENCES Children(child_id)
                    );
                ";

                string createPaymentsTable = @"
                    CREATE TABLE IF NOT EXISTS Payments (
                        payment_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        child_id INTEGER NOT NULL,
                        amount REAL NOT NULL,
                        months TEXT NOT NULL,
                        year INTEGER NOT NULL,
                        date DATE NOT NULL,
                        FOREIGN KEY (child_id) REFERENCES Children(child_id)
                    );
                ";

                SQLiteCommand command = new SQLiteCommand(createParentsTable, connection);
                command.ExecuteNonQuery();

                command.CommandText = createChildrenTable;
                command.ExecuteNonQuery();

                command.CommandText = createEducatorsTable;
                command.ExecuteNonQuery();

                command.CommandText = createGroupsTable;
                command.ExecuteNonQuery();

                command.CommandText = createEventsTable;
                command.ExecuteNonQuery();

                command.CommandText = createAttendanceTable;
                command.ExecuteNonQuery();

                command.CommandText = createPaymentsTable;
                command.ExecuteNonQuery();
            }
        }
    }
}