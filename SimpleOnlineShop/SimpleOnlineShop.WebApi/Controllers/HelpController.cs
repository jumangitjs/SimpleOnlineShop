using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;

namespace SimpleOnlineShop.WebApi.Controllers
{
    //    [Authorize]
    [Produces("application/json")]
    [Route("api/help")]
    public class HelpController : ControllerBase
    {
        //        [Authorize("roles")]
        [HttpGet]
        public string GetAllRoles()
        {
            return "Hello! this is my tutorial! \n" +
                   "here are my routes: \n" +
                   "192.168.143.184:5001 \n" +
                   "[get] /api/customer - get customers \n" +
                   "[get] /api/customer/{id} - get customer with {id} \n" +
                   "[post] /api/customer - creates new customer, json data as follows => {\n\t\"FirstName\" : \"John\",\n\t\"LastName\" : \"Doe\",\n\t\"Gender\" : \"Male\",\n\t\"Address\": \"Nigeria\",\n\t\"Email\": \"JohnDoe@does.com\",\n\t\"ContactNo\": \"094588789685\"\n} \n " +
                   "[put] /api/customer/{id}/email - change email of customer {id} (email must be legit) {\"email\": \"JohnDoe@does.com\"} \n" +
                   "[put] /api/customer/{id}/contactno - change contact no of customer {id} (number must be legit ph) {\"contactNo\": \"09325477896\"}\n " +
                   "[put] /api/customer/{id}/order - add product to customer {\n\t\"productName\" : \"Samsung S7 Edge\",\n\t\"inventoryName\": \"Gadgets\"\n} \n" +
                   "[delete] /api/customer/{id} - deletes customer {id} \n" +
                   "[delete] /api/customer/{id}/order - deletes customer product order {\n\t\"productName\" : \"Samsung S7 Edge\",\n\t\"inventoryName\": \"Gadgets\"\n} \n" +
                   "[get] /api/inventory - gets all inventories and their inventory products";
        }
    }
}