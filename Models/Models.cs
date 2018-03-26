using System;

namespace code.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Income {
        public string country_name {get; set;}
        public string game_name {get; set;}
        public int owners_after {get; set;}
        public int sales {get; set;}
        public float price {get; set;}
        public string month {get; set;}
        public int gni {get; set;}
    }

    public class Hour {
        public string year {get; set;}
        public string season {get; set;}
        public int time {get; set;}
    }
}