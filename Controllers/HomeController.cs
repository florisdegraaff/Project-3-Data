using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using code.Models;
using Npgsql;

namespace code.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Income()
        {
            ViewData["Title"] = "Income";

            return View();
        }

        public IActionResult Hours()
        {
            
            Dictionary<string, int> teachers = new Dictionary<string, int>();

            ViewData["Title"] = "Hours";

            var connString = "Host=localhost;Username=postgres;Password=usE5k6mBMC1ciwv;Database=school";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM teacher", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                       teachers.Add(reader.GetString(0), reader.GetInt32(3));
                    }
                }
            }

            ViewData["Teachers"] = teachers;

            //Console.WriteLine(ViewData["Teachers"]);

            /*foreach (var teacher in ViewData["Teachers"])
            {
                Console.WriteLine(teacher)
            }*/

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
