using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace GestionDeProhet
{
    class TaskData
    {
        public int TaskID { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int PercentageCompletion { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        private SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Badis Ben Sassi\Documents\gestionDeProjet.mdf"";Integrated Security=True;Connect Timeout=30");
 
        public TaskData() { }

        public void AddTask(TaskData task)
        {
            try
            {
                connect.Open();
                string insertQuery = "INSERT INTO Task (Description, DueDate, PercentageCompletion, UserID, ProjectID) VALUES (@Description, @DueDate, @PercentageCompletion, @UserID, @ProjectID)";
                SqlCommand cmd = new SqlCommand(insertQuery, connect);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                cmd.Parameters.AddWithValue("@PercentageCompletion", task.PercentageCompletion);
                cmd.Parameters.AddWithValue("@UserID", task.UserID);
                cmd.Parameters.AddWithValue("@ProjectID", task.ProjectID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public void UpdateTask(TaskData task)
        {
            try
            {
                connect.Open();
                string updateQuery = "UPDATE Task SET Description = @Description, DueDate = @DueDate, PercentageCompletion = @PercentageCompletion, UserID = @UserID, ProjectID = @ProjectID WHERE TaskID = @TaskID";
                SqlCommand cmd = new SqlCommand(updateQuery, connect);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                cmd.Parameters.AddWithValue("@PercentageCompletion", task.PercentageCompletion);
                cmd.Parameters.AddWithValue("@UserID", task.UserID);
                cmd.Parameters.AddWithValue("@ProjectID", task.ProjectID);
                cmd.Parameters.AddWithValue("@TaskID", task.TaskID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                connect.Open();
                string deleteQuery = "DELETE FROM Task WHERE TaskID = @TaskID";
                SqlCommand cmd = new SqlCommand(deleteQuery, connect);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public List<TaskData> GetAllTasks()
        {
            List<TaskData> tasks = new List<TaskData>();
            try
            {
                connect.Open();
                string selectQuery = "SELECT * FROM Task";
                SqlCommand cmd = new SqlCommand(selectQuery, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TaskData task = new TaskData
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        Description = reader["Description"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"]),
                        PercentageCompletion = Convert.ToInt32(reader["PercentageCompletion"]),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        ProjectID = Convert.ToInt32(reader["ProjectID"])
                    };
                    tasks.Add(task);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return tasks;
        }
    }
}
