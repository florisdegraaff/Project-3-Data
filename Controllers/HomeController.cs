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

        // Get data from database
            List<Income> incomeList = new List<Income>();

            var connString = "Host=localhost;Username=postgres;Password=admin123;Database=project-3";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM vraag1 order by country, month", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        incomeList.Add(new Income {
                            country_name = reader.GetString(0),
                            game_name = reader.GetString(1),
                            owners_after = reader.GetInt32(2),
                            sales = reader.GetInt32(3),
                            price = reader.GetFloat(4),
                            month = reader.GetString(5),
                            gni = reader.GetFloat(6)
                        });
                    }
                }
            }

        // Set title and data collected from database
            ViewData["Title"] = "Income";
            ViewData["Income"] = incomeList;

            return View();
        }

        public IActionResult Hours()
        {
        
        // Get data from database
            List<Hour> hourList = new List<Hour>();

            var connString = "Host=localhost;Username=postgres;Password=admin123;Database=project-3";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM vraag2", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        hourList.Add(new Hour{year = reader.GetString(0), season = reader.GetString(1), time = reader.GetInt32(2)});
                    }
                }
            }

        // Set title and data collected from database
            ViewData["Title"] = "Hours";
            ViewData["Hour"] = hourList;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
