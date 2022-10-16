using Microsoft.AspNetCore.Mvc;
using TestLil.Aplication;
using TestLil.DTOs;
using TestLil.Entities;

namespace TestLil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoAplication<Producto> _applicationProducto;
        private readonly IProductoAplication<ProductoHistory> applicationProducHistory;

        public ProductosController(IProductoAplication<Producto> applicationProducto, IProductoAplication<ProductoHistory> _applicationProducHistory)
        {
            this._applicationProducto = applicationProducto;
            this.applicationProducHistory = _applicationProducHistory;
        }

        [HttpGet]
        public IActionResult listarProductos()
        {
            return Ok(_applicationProducto.GetAll());
        }

        [HttpPost("[action]")] 
        public IActionResult crearProducto(ProductoDTO dto)
        {

            Producto product = _applicationProducto.GetBySearchKey(dto.code);

            if(product == null) //Producto nuevo
            {
                product = new Producto()
                {
                    name = dto.name,
                    stock = 0,
                    Code = dto.code,
                    State = (int)Producto.KdState.Active
                    
                };

                _applicationProducto.save(product);

                return Ok("Producto " + product.name + " creado exitosamente");
            }
            else{

                product.stock += dto.stock;

                _applicationProducto.Update(product);
            }

            ProductoHistory productHistory = new ProductoHistory()
            {
                productId = product.Id,
                amount = dto.stock,
                Code = dto.code,
            };

            applicationProducHistory.save(productHistory);

            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult deleteProducto(ProductoDTO dto)
        {
            Producto product = _applicationProducto.GetBySearchKey(dto.code);

            product.State = (int)Producto.KdState.Inactive;

            return Ok(_applicationProducto.Update(product));

        }
    }
}
