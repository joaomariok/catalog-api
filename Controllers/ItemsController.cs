using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ImMemItemsRepository repository;

        public ItemsController()
        {
            repository = new ImMemItemsRepository();
        }

        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            return (item is not null) ? item : NotFound();
        }
    }
}