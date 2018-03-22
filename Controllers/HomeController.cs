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
            List<(string name, string game_name, int owners_after, int sales, float price, string month, float gni)> incomeData = 
            new List<(string name, string game_name, int owners_after, int sales, float price, string month, float gni)>();

            ViewData["Title"] = "Income";

            var connString = "Host=localhost;Username=postgres;Password=usE5k6mBMC1ciwv;Database=project-3";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM vraag1", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        (string name, string game_name, int owners_after, int sales, float price, string month, float gni) data = (reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetString(5), 0f);
                        incomeData.Add(data);
                    }
                }
            }

            ViewData["data"] = incomeData;

            
            return View();
        }

        public IActionResult Hours()
        {
            List<(string year, string season, int time)> hoursData = 
            new List<(string year, string season, int time)>();
            
            ViewData["Title"] = "Hours";
            

            var connString = "Host=localhost;Username=postgres;Password=usE5k6mBMC1ciwv;Database=project-3";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM vraag2", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        (string year, string season, int time) data = (reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                        hoursData.Add(data);
                    }
                }
            }

            ViewData["data"] = hoursData;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
