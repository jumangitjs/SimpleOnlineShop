using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;

namespace SimpleOnlineShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/inventory")]
    public class ProductInventoryListController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public ProductInventoryListController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IEnumerable<IData> GetAllInventory()
        {
            return _inventoryService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public IData GetProducts(long id)
        {
            return _inventoryService.RetriveById(id) != null ? _inventoryService.RetriveById(id) : null;
        }

        [HttpPost]
        public void CreateInventory([FromBody] ProductInventoryListData data)
        {
            _inventoryService.CreateInventory(data);
        }

        [HttpPut("{id}/addproduct")]
        public void AddProductToInventoryList(long id, [FromBody] InventoryProductData data)
        {
            _inventoryService.AddProductToInventory(id, data);
        }
    }
}
