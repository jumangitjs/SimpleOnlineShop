using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("inventory.read")]
        [HttpGet]
        public IEnumerable<IData> GetAllInventory()
        {
            return _inventoryService.RetrieveAll();
        }

        [Authorize("inventory.write")]
        [HttpPost]
        public void CreateInventory([FromBody] InventoryData data)
        {
            _inventoryService.CreateInventory(data);
        }

        #endregion

        #region /{id} region

        [Authorize("inventory.read")]
        [HttpGet("{id}")]
        public IData GetInventoryById(long id)
        {
            return _inventoryService.RetriveById(id) != null ? _inventoryService.RetriveById(id) : null;
        }

        [Authorize("inventory.delete")]
        [HttpDelete("{id}")]
        public void DeleteInventory(long id)
        {
            _inventoryService.DeleteInventory(id);   
        }

        [Authorize("inventory.read")]
        [HttpGet("{id}/product")]
        public IEnumerable<IData> GetInventoryProducts(long id)
        {
            return _inventoryService.RetrieveInventoryProducts(id);
        }

        [Authorize("inventory.modify")]
        [HttpPut("{id}/product")]
        public void AddProductToInventoryList(long id, [FromBody] InventoryProductData data)
        {
            _inventoryService.AddProductToInventory(id, data);
        }

        [Authorize("inventory.modify")]
        [HttpDelete("{id}/product")]
        public void DeleteProductFromInventoryList(long id, [FromBody] InventoryProductData data)
        {
            _inventoryService.DeleteInventoryProduct(id, data.Name);
        }

        #endregion
        

    }
}
