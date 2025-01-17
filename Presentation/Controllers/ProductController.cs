using Business.Dtos.Product;
using Business.Services.Abstract;
using Business.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        #region Documentation
        /// <summary>
        /// List of products
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<List<ProductDto>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status500InternalServerError)]
        #endregion

        [HttpGet]
        public async Task<Response<List<ProductDto>>> GetAllProductAsync()
         => await _productService.GetAllProductAsync();

        #region Documentation
        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status500InternalServerError)]

        #endregion

        [HttpGet("{id}")]
        public async Task<Response<ProductDto>> GetProductAsync(int id) => await _productService.GetProductAsync(id);

     

        #region Documentation
        /// <summary>
        ///  For creating Product
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>  <b>Type:</b> <p> 0 - New 1 - Sold </p>  </li>
        /// </ul>
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status500InternalServerError)]
        #endregion
        [HttpPost]
        public async Task<Response> CreateProductAsync(ProductCreateDto model)
            =>await _productService.CreateProductAsync(model);


        #region Documentation
        /// <summary>
        /// Update of Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
        #endregion

        [HttpPut("{id}")]
        public async Task<Response> UpdateProductAsync(int id,ProductUpdateDto model)
            => await _productService.UpdateProductAsync(id,model);

        #region Documentation
        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
        #endregion
        [HttpDelete("{id}")]
        public async Task<Response> DeleteProductAsync(int id)
            => await _productService.DeleteProductAsync( id);


    }
}
