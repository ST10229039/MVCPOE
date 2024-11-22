using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCPOE.Models;

namespace MVCPOE.Controllers
{
    public class LecturerClaims : Controller
    {
        public Connect conn = new Connect();
        public IActionResult Index()
        {
            //check the connection
            try
            {
                //get the connection string from the connection class
                Connect conn = new Connect();
                //then check
                using (SqlConnection connect = new SqlConnection(conn.Connecting()))
                {
                    //open the connection
                    connect.Open();
                    Console.WriteLine("connected");
                    connect.Close();
                }
            }
            catch (IOException error)
            {
                //error message
                Console.WriteLine("Error : " + error.Message);
            }
            return View();
        }

        //http post for the register
        //from the register form
        [HttpPost]

        public IActionResult Register_users(register add_users)
        {

            //collect user's value
            string name = add_users.username;
            string email = add_users.email;
            string password = add_users.password;
            string role = add_users.role;



            //pass all the values to insert method
            string message = add_users.insert_users(name, email, password, role);

            //then check if the user is inserted
            if (message == "done")

            {
                //track error output
                Console.Write(message);
                //direct
                return RedirectToAction("Login", "LecturerClaim");

            }
            else
            {
                //track error output
                Console.Write(message); //redirect
                return RedirectToAction("Index", "LecturerClaim");

            }


        }


        //for login page




        public IActionResult Login()
        {
            return View();
        }

        //login page
        [HttpPost]
        public IActionResult login_users(login users)
        {


            //then assign
            string email = users.email;
            string role = users.role;
            string password = users.password;

            string message = users.login_users(email, role, password);

            if (message == "found")
            {
                Console.WriteLine(message);
                return RedirectToAction("Details", "LecturerClaim");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Index", "LecturerClaim");
            }
        }
        [HttpPost]
        public IActionResult claim_sub(IFormFile file, Models.LecturerClaim claim)
        {

            string username = claim.username;
            string email = claim.USER_email;
            string module = claim.module;
            string hour_rate = claim.hour_rate;
            string hours_worked = claim.hours_worked;
            string description = claim.description;
            string documents = claim.supporting_document;
         
            //check file

            string file_found = "no";
            string filename = "none";
            string filePath = "";
            string folderPath = "";
            if (file != null && file.Length > 0)
            {

                file_found = "yes";
                // Get the file name
                filename = Path.GetFileName(file.FileName);
                // Define the folder path (pdf folder)
                folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf");
                // Ensure the pdf folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Define the full path where the file will be saved
                filePath = Path.Combine(folderPath, filename);
                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    Console.WriteLine("File " + filename + " is sccessully uploaded. ");
                    //  under " + claim_id.id);


                }
            }


            string message = claim.LecturerClaims(username, email, module, hour_rate, hours_worked, description, filename, filePath);

            //ViewBag.Message("done");

            //then open connction

            return RedirectToAction("Details", "LecturerClaim");
        }

        //open dashboard
        public IActionResult CreateEdit(MVCPOE.Models.LecturerClaim model)
        {


            if (ModelState.IsValid)
            {



                // Save the claim to the database
                return RedirectToAction("Details");
            }

            return View();
        }

        // GET: LecturerClaim/Details
        public IActionResult Details()
        {
            // Instantiate the get_claims model to fetch data
            var all = new get_claim();

            // Pass the model to the view
            return View(all);
        }
      
    
}
}
