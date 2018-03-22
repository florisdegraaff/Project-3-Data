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
            List<(string name, string game_name, int owners_after, int sales, float price, string month, float gni)> hoursData = 
            new List<(string name, string game_name, int owners_after, int sales, float price, string month, float gni)>();

            ViewData["Title"] = "Hours";

            var connString = "Host=localhost;Username=postgres;Password=usE5k6mBMC1ciwv;Database=project-3";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM vraag1", conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        (string name, string game_name, int owners_after, int sales, float price, string month, float gni) data = (reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetString(5), 0f);
                        /*data.name = reader.GetString(0);
                        data.game_name = reader.GetString(1);
                        data.owners_after = reader.GetInt32(2);
                        data.sales = reader.GetInt32(3);
                        data.price = reader.GetFloat(4);
                        data.month = reader.GetString(5);
                        data.gni = reader.GetInt32(6);*/
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
