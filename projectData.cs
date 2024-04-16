using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace GestionDeProhet
{
    class projectData
    {
        public int id { set; get; }
        public string code { set; get; }
        public string Description { set; get; }
        public DateTime startDate { set; get; }
        public int completionRate { set; get; }



        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Badis Ben Sassi\Documents\gestionDeProjet.mdf"";Integrated Security=True;Connect Timeout=30");
        public projectData()
        {

        }



        public void update(projectData project)
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();


                    string update = "UPDATE Project SET Description = @Description, start = @StartDate WHERE code = @code";



                    SqlCommand cmd = new SqlCommand(update, this.connect);


                    cmd.Parameters.AddWithValue("@code", project.code);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@StartDate", project.startDate);



                    int rowsAffected = cmd.ExecuteNonQuery();


                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public projectData(string code, string description, DateTime startDate)
        {
            this.code = code;
            this.Description = description;
            this.startDate = startDate;
            this.completionRate = 0;

        }
        public void persist(projectData project)
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    Console.WriteLine("i'am trying to persist");
                    Console.WriteLine(this.code);

                    string insert = "INSERT INTO Project (code, Description, start) VALUES (@code, @Description, @StartDate)";


                    SqlCommand cmd = new SqlCommand(insert, this.connect);


                    cmd.Parameters.AddWithValue("@code", project.code);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@StartDate", project.startDate);


           
                    int rowsAffected = cmd.ExecuteNonQuery();
                
                    Console.WriteLine("here");
               

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Project data inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows were affected.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void delete(projectData project)
        {


            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();


                    string delete = "DELETE FROM Project  where  project.code=@code";
                    SqlCommand cmd = new SqlCommand(delete, this.connect);
                    cmd.Parameters.AddWithValue("@code", project.code);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public List<projectData> taskList()
        {
            List<projectData> listdata = new List<projectData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM Project ";

                    using (SqlCommand cmd = new SqlCommand(selectData, this.connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            projectData ed = new projectData();
                            ed.id = (int)reader["id"];
                            ed.code = reader["code"].ToString();
                            ed.Description = reader["Description"].ToString();
                            ed.startDate = (DateTime)reader["start"];
                        
                            listdata.Add(ed);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }

         
    }




   

}
