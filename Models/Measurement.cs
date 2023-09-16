using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diary.Models
{
    public class Measurement
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }

        public int HeartRate { get; set; }
    }


}