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


        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}" )]
        //[DisplayName("Data")]
        //[DataType(DataType.Date)]
        //public DateTime Date { get; set; }


         [DataType(DataType.Date)]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
         [Display(Name = "Data")]
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


        [DisplayName("Uwagi")]
        [DataType(DataType.MultilineText)]

        public string Notes { get; set; }
    }


}