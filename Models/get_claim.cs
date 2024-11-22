using Microsoft.Data.SqlClient;
using System.Collections;

namespace MVCPOE.Models
{
    public class get_claim
    {
        public ArrayList user_id { get; set; } = new ArrayList();
        public ArrayList username { get; set; } = new ArrayList();
        public ArrayList email { get; set; } = new ArrayList();

        public ArrayList module { get; set; } = new ArrayList();

        public ArrayList id { get; set; } = new ArrayList();
        public List<string> Id { get; set; } = new List<string>();
        public ArrayList hours_worked { get; set; } = new ArrayList();

        public ArrayList rate { get; set; } = new ArrayList();

        public ArrayList description { get; set; } = new ArrayList();

        public ArrayList total { get; set; } = new ArrayList();

        public ArrayList status { get; set; } = new ArrayList();
        public ArrayList isApproved { get; set; } = new ArrayList();
        public ArrayList filename { get; set; } = new ArrayList();
        public bool? IsApproved { get; set; }
        public string ids { get; set; }
        public string on { get; set; }

        

        Connect connect = new Connect();


        //constructor
        public get_claim()
        {
            string connectionString = "Data Source = (localdb)\\Thabelop2; Initial Catalog = CLAIMS; Integrated Security = True; Trust Server Certificate = True";
            string emails = Gets_email();


            try
            {

                using (SqlConnection connects = new SqlConnection(connect.Connecting()))
                {
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("select * from active", connects))
                    {
                        using (SqlDataReader getmail = prepare.ExecuteReader())

                        {
                            if (getmail.HasRows)
                            {

                                //check all, but get one
                                while (getmail.Read())
                                {
                                    //then get it
                                    // hold_email = getmail["email"].ToString();

                                }
                            }
                            getmail.Close();

                        }
                    }

                    connects.Close();
                }

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);

            }
        }

        //get email
        public string Gets_email()
        {
            string hold_email = "";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.Connecting()))
                {
                    connects.Open();
                    string sql = "SELECT * FROM LecturerClaims ";
                    using (SqlCommand prepare = new SqlCommand(sql, connects))
                    {
                        using (SqlDataReader reader = prepare.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hold_email = reader["email"].ToString();
                                id.Add(reader["id"]?.ToString() ?? "");
                                username.Add(reader["username"].ToString());
                                email.Add(reader["email"]?.ToString() ?? "");
                                module.Add(reader["module"]?.ToString() ?? "");
                                hours_worked.Add(reader["hours_worked"]?.ToString() ?? "");
                                rate.Add(reader["rate"]?.ToString() ?? "");
                                description.Add(reader["description"]?.ToString() ?? "");
                                total.Add(reader["total"]?.ToString() ?? "");
                                status.Add(reader["status"]?.ToString() ?? "");

                                // Check if 'filename' column exists
                                if (reader.GetSchemaTable().Columns.Contains("filename"))
                                {
                                    filename.Add(reader["filename"].ToString());
                                }
                                else
                                {
                                    filename.Add("N/A"); // or handle accordingly
                                }
                            }
                        }
                    }

                    connects.Close();
                }
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_email = error.Message;
            }
            return hold_email;
        }
    }
}
