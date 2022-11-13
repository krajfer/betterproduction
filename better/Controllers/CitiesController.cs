using better.Models;
using better.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace better.Controllers
{
    public class CitiesController : ApiController
    {
       private readonly ICityService cityService;
        
        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        [HttpGet]
        [Route("Cities/GetCities")]
        public IHttpActionResult GetCites()
        {
            return Content(HttpStatusCode.OK, cityService.GetCities().Result);
        }

        [HttpGet]
        [Route("Cities/GetCityByName/{name}")]
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCitiesByName(string name)
        {
            City city = cityService.GetCityByName(name);
            if(city == null)
            {
                return NotFound();
            }
            return Content<City>(HttpStatusCode.OK, city);
        }
        [HttpPut]
        [Route("Cities/UpdateTransportCost")]
        public IHttpActionResult UpdateTransportCost(City city)
        {
            var response = cityService.UpdateTransportCost(city.Name, city.TransportCostToCity);

            if (response.Message.Equals("Sukces"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, response.Message);
        }

        [HttpPut]
        [Route("Cities/UpdateCostOfWorkingHour")]
        public IHttpActionResult UpdateCostOfWorkingHour(City city)
        {
            var response = cityService.UpdateCostOfWorkingHour(city.Name, city.PriceByHour);

            if (response.Message.Equals("Sukces"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, response.Message);
        }

        [HttpPost]
        [Route("Cities/AddCity")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddCity(City city)
        {
            if (city == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object city jest null");
            }
            var response = cityService.AddCity(city);

            if (response.Message.Equals("Sukces"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, "Error");

        }
        [HttpPost]
        [Route("Cities/DeleteCity/{name}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCity(string name)
        {
            if (name == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object city jest null");
            }
            var response = cityService.DeleteCity(name);

            if (response.Message.Equals("Sukces"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, "Error");

        }
    }
}