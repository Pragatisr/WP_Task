using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using CarRental_WP.App_Start;
using MongoDB.Driver;
using CarRental_WP.Models;

namespace CarRental_WP.Controllers
{
    public class CarDetailsController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<CarsModel> carsCollection;
        public CarDetailsController() {
            dbContext = new MongoDBContext();
            carsCollection = dbContext.databse.GetCollection<CarsModel>("CarDetails");
        }
        public ActionResult Index()
        {
            List<CarsModel> car = carsCollection.AsQueryable<CarsModel>().ToList();
            return View(car);
        }

        // GET: CarDetails/Details/5
        public ActionResult Details(string id)
        {
            var carid = new ObjectId(id);
            var car = carsCollection.AsQueryable<CarsModel>().SingleOrDefault(x => x.Id == carid);
            return View(car);
        }

        // GET: CarDetails/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CarDetails/Create
        [HttpPost]
        public ActionResult Create(CarsModel car, HttpPostedFileBase FileUpload1)
        {
            try
            {
                carsCollection.InsertOne(car);
                FileUpload1.SaveAs(Server.MapPath("../AdminLayout/ProductPic/" + FileUpload1.FileName));
                car.Img = "/AdminLayout/ProductPic/" + FileUpload1.FileName;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarDetails/Edit/5
        public ActionResult Edit(string id)
        {
            var carid = new ObjectId(id);
            var car = carsCollection.AsQueryable<CarsModel>().SingleOrDefault(x => x.Id == carid);
            return View(car);
            
        }

        // POST: CarDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CarsModel car)
        {
            try
            {
                var filter = Builders<CarsModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<CarsModel>.Update
                    .Set("VehicleNo", car.VehicleNo)
                    .Set("Model", car.Model)
                    .Set("SeatingCap", car.SeatingCap)
                    .Set("RentPerDay", car.RentPerDay)
                    .Set("BkdStatus", car.BkdStatus);
                var result = carsCollection.UpdateOne(filter,update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarDetails/Delete/5
        public ActionResult Delete(string id)
        {
            var carid = new ObjectId(id);
            var car = carsCollection.AsQueryable<CarsModel>().SingleOrDefault(x => x.Id == carid);
            return View(car);
        }

        // POST: CarDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, CarsModel car)
        {
            try
            {
                carsCollection.DeleteOne(Builders<CarsModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
