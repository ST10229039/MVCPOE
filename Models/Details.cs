using Microsoft.Data.SqlClient;
using System.Collections;

namespace MVCPOE.Models
{
    public class Details
    {
        // Initialize ArrayLists when the class is created
        public ArrayList Username { get; set; } = new ArrayList();
        public ArrayList Module { get; set; } = new ArrayList();
        public ArrayList ClaimDate { get; set; } = new ArrayList();
        public ArrayList Period { get; set; } = new ArrayList();
        public ArrayList HourRate { get; set; } = new ArrayList();
        public ArrayList HoursWorked { get; set; } = new ArrayList();
        public ArrayList SupportingDocument { get; set; } = new ArrayList();
        public ArrayList Description { get; set; } = new ArrayList();
        public ArrayList Total { get; set; } = new ArrayList();
        public ArrayList No { get; set; } = new ArrayList();
        public ArrayList Id { get; set; } = new ArrayList();
        public string Ids { get; set; }
        public string On { get; set; }
        public ArrayList Status { get; set; } = new ArrayList();
        private Connect conn = new Connect();

        public Details()
        {
            LoadPendingClaims();
        }

        private void LoadPendingClaims()
        {
            try
            {
                using (SqlConnection connects = new SqlConnection(conn.Connecting()))
                {
                    connects.Open();
                    string query = "SELECT * FROM LecturerClaims WHERE status = 'pending'";
                    using (SqlCommand command = new SqlCommand(query, connects))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                count++;
                              
                                Username.Add(reader["username"].ToString());
                                Module.Add(reader["module"].ToString());
                                HourRate.Add(reader["hour_rate"].ToString());
                                HoursWorked.Add(reader["hour_worked"].ToString());
                                SupportingDocument.Add(reader["filename"].ToString());
                                Description.Add(reader["description"].ToString());
                                Total.Add("R" + reader["total"].ToString());
                                Status.Add(reader["status"].ToString());
                                Id.Add(reader["id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Handle exception (consider logging)
            }
        }
    
        }
}
