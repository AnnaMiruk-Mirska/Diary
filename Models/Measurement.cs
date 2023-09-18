using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diary.Models
{
    public class Measurement
    {
        public string Id { get; set; }

        [DisplayName("Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [DisplayName("Ciśnienie rozkurczowe")]
        [DataType(DataType.CreditCard)]
        public int Systolic { get; set; }

        [DisplayName("Ciśnienie skurczowe")]
        [DataType(DataType.CreditCard)]
        public int Diastolic { get; set; }

        [DisplayName("Puls")]
        [DataType(DataType.CreditCard)]

        public int HeartRate { get; set; }
    }


}