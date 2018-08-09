using Microsoft.AspNetCore.Mvc;
using Nandalala.RoyalCottage.Domain.Products;
using Nandalala.RoyalCottage.Proxies;
using Nandalala.Paas.Core;
using System;
using System.Collections.Generic;

namespace Nandalala.RoyalCottage.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IBroker _broker;

        public ProductController(IBroker broker)
        {
            _broker = broker;
        }

        [HttpGet("/api/Product/GetAllProducts")]
        public IActionResult Get()
        {
            
            ListAllProducts listAllProducts = new ListAllProducts();
            var result = _broker.Execute(listAllProducts);

            return Ok(result);
            //return Ok(new ListProductsResponse { Products = result });


        }

        [HttpGet("/api/Product/GetProduct/{id}")]
        public IActionResult Get(string id)
        {
            ListProducts listProducts = new ListProducts { ProductId = new Guid(id) };
            var result = _broker.Execute<IEnumerable<ProductProxy>>(listProducts);
            var resultList = new List<ProductProxy>(result);
            return Ok(resultList[0]);
            //return Ok(new ListProductsResponse { Products = result });
        }

        [HttpPost("/api/Product/CreateProduct")]
        public IActionResult Post([FromBody]CreateProductRequest createProductRequest)
        {
            CreateProduct createProduct = new CreateProduct
            {
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                ProductTypeId = Guid.Parse(createProductRequest.ProductTypeId)
            };

            _broker.Dispatch(createProduct);
            return Ok();
        }

        [HttpPut("/api/Product/UpdateProduct")]
        public IActionResult Put([FromBody]UpdateProductRequest updateProductRequest)
        {
            UpdateProduct updateProduct = new UpdateProduct
            {
                ProductId = Guid.Parse(updateProductRequest.entityId),
                ProductTypeId = Guid.Parse(updateProductRequest.ProductTypeId),
                Name = updateProductRequest.Name,
                Description = updateProductRequest.Description
            };

            _broker.Dispatch(updateProduct);
            return Ok();
        }

        [HttpDelete("/api/Product/DeleteProduct/{id}")]
        public IActionResult Delete(string id)
        {
            DeleteProduct deleteProduct = new DeleteProduct
            {
                ProductId = new Guid(id)
            };

            _broker.Dispatch(deleteProduct);
            return Ok();
        }


    }
}