using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diary.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;



namespace Diary.Controllers
{
    public class MeasurementController:Controller
    {
        IFirebaseClient client;




        public MeasurementController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = ""
            };

            client = new FirebaseClient(config);
        }

        List<Measurement> measurementList = new List<Measurement>();


        public ActionResult MeasurementList()
        {



            Dictionary<string, Measurement> measurements = new Dictionary<string, Measurement>();
            FirebaseResponse response = client.Get("measurements");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                measurements = JsonConvert.DeserializeObject<Dictionary<string, Measurement>>(response.Body);
            }


            List<Measurement> measurementList = new List<Measurement>();

            foreach (KeyValuePair<string, Measurement> item in measurements)
            {


                measurementList.Add(new Measurement()
                {
                    Id = item.Key,
                    Date = item.Value.Date,
                    Systolic = item.Value.Systolic,
                    Diastolic = item.Value.Diastolic,
                    HeartRate = item.Value.HeartRate,
                });
            }
            return View(measurementList);



        }

        public ActionResult Add()
        {
            return View();
        }


        public ActionResult Info(string id)
        {
            FirebaseResponse response = client.Get("measurements/" + id);
            Measurement measurement = response.ResultAs<Measurement>();
            measurement.Id = id;
            return View(measurement);
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Measurement measurement)
        {



             string ID = Guid.NewGuid().ToString("N");
            SetResponse setResponse = client.Set("measurements/" + ID, measurement);
            if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("MeasurementList", "Measurement");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(string id)
        {
            FirebaseResponse response = client.Delete("measurements/" + id);
            return RedirectToAction("MeasurementList", "Measurement");



        }
    }
}