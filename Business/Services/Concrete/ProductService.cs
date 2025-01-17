using AutoMapper;
using Business.Dtos.Product;
using Business.Services.Abstract;
using Business.Validators.Product;
using Business.Wrappers;
using Core.Entities;
using Core.Exceptions;
using Data.Repositories.Abstract;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<List<ProductDto>>> GetAllProductAsync()
        {
            return new Response<List<ProductDto>>
            {
                Data = _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync()),
            };
        }
        public async Task<Response<ProductDto>> GetProductAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
                throw new NotFoundException("Not found product");
            return new Response<ProductDto>
            {
                Data = _mapper.Map<ProductDto>(product)
            };
        }

        public async Task<Response> CreateProductAsync(ProductCreateDto model)
        {
          var result=await  new ProductCreateDtoValidator().ValidateAsync(model);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            var product =await _productRepository.GetByNameAsync(model.Name);
            if (product is not null)
                throw new ValidationException("Already exist with this name");
           product = _mapper.Map<Product>(model);

            await _productRepository.CreateAsync(product);
            await _unitOfWork.CommitAsync();
            return new Response
            {
                Message = "Creating successful!"
            };
        }

        public async Task<Response> UpdateProductAsync(int id, ProductUpdateDto model)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
                throw new NotFoundException("not found product");

            var result = await new ProductUpdateDtoValidator().ValidateAsync(model);
            if(!result.IsValid) 
                throw new ValidationException(result.Errors);
            _mapper.Map(model,product);
            //if (model.Photo is not null) product.Photo = model.Photo;
            _productRepository.Update(product);
            await _unitOfWork.CommitAsync();
            return new Response
            {
                Message = "Successfuly! Product was updated"
            };
        }

        public async Task<Response> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if(product is null) 
                throw new NotFoundException("Product is not found");
            _productRepository.Delete(product);
            await _unitOfWork.CommitAsync();
            return new Response
            {
                Message = " Successfull! Product was deleted"
            };
        }
    }
}
