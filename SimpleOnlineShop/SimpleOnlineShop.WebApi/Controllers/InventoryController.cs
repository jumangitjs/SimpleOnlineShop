using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;

namespace SimpleOnlineShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        #region Index

        [HttpGet]
        public IEnumerable<IData> GetAllInventory()
        {
            return _inventoryService.RetrieveAll();
        }

        [HttpPost]
        public void CreateInventory([FromBody] InventoryData data)
        {
            _inventoryService.CreateInventory(data);
        }
        
        #endregion

        #region /{id} region

        [HttpGet("{id}")]
        public IData GetInventoryById(long id)
        {
            return _inventoryService.RetriveById(id) != null ? _inventoryService.RetriveById(id) : null;
        }

        [HttpDelete("{id}")]
        public void DeleteInventory(long id)
        {
            _inventoryService.DeleteInventory(id);   
        }

        [HttpGet("{id}/product")]
        public IEnumerable<IData> GetInventoryProducts(long id)
        {
            return _inventoryService.RetrieveInventoryProducts(id);
        }

        [HttpPut("{id}/product")]
        public void AddProductToInventoryList(long id, [FromBody] InventoryProductData data)
        {
            _inventoryService.AddProductToInventory(id, data);
        }

        [HttpDelete("{id}/product")]
        public void DeleteProductFromInventoryList(long id, [FromBody] InventoryProductData data)
        {
            _inventoryService.DeleteInventoryProduct(id, data.Name);
        }

        #endregion
        

    }
}
