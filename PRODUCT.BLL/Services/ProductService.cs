using Microsoft.Extensions.Logging;
using PRODUCT.BLL.Services.Interfaces;
using PRODUCT.BOL.Dto;
using PRODUCT.DAL.Repository.Interfaces;
using PRODUCT.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRODUCT.BLL.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(
                  IProductRepository productRepository, ILogger<ProductService> logger
            ) : base(logger)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            try
            {
                var insertedProduct = await _productRepository.CreateAsync(new Product
                {
                    Matricule = productDTO.Matricule,
                    Name = productDTO.Name,
                    Slug = productDTO.Slug
                });
                productDTO.Id = insertedProduct.Id;
                productDTO.CreateDate = insertedProduct.DateCreate;
                return productDTO;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Unable to create product. Error: {ex.Message}");
                throw new Exception($"Unable to create product. Error: {ex.Message}");
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var rowCount = await _productRepository.DeleteAsync(id);
                return rowCount > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to delete product. Error: {ex.Message}");
                throw new Exception($"Unable to delete product. Error: {ex.Message}");
            }
        }

        public async Task<ProductDTO> GetById(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if(product == null)
                {
                    throw new Exception($"Unable to get product where Id {id}");
                }
                return new ProductDTO
                {
                    CreateDate = product.DateCreate,
                    DateEdit = product.DateEdit,
                    Id = product.Id,
                    Name = product.Name,
                    Slug = product.Slug,
                    Matricule = product.Matricule
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get product. Error: {ex.Message}");
                throw new Exception($"Unable to get product. Error: {ex.Message}");
            }
        }

        public async Task<GridDataDTO> GetGridData(GridParamDTO gridParamDTO)
        {
            try
            {
                var productData =  await _productRepository.GetProductByPagination(gridParamDTO.Take, gridParamDTO.Skip);
                var totalRecord = await _productRepository.GetCountAsync();
                return new GridDataDTO
                {
                    Data = productData.Any()? productData.Select(item => new ProductDTO
                    {
                        CreateDate = item.DateCreate,
                        DateEdit = item.DateEdit,
                        Id = item.Id,
                        Matricule = item.Matricule,
                        Name = item.Name,
                        Slug = item.Slug
                    }).ToList() : new List<ProductDTO>(),
                    Draw = gridParamDTO.Draw,
                    RecordsFiltered = totalRecord,
                    RecordsTotal = totalRecord
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get grid data. Error: {ex.Message}");
                throw new Exception($"Unable to get grid data. Error: {ex.Message}");
            }
        }

        public async Task<bool> Update(ProductDTO productDTO)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(productDTO.Id);
                if (product == null)
                {
                    throw new Exception($"Unable to get product where Id {productDTO.Id}");
                }
                product.Matricule = productDTO.Matricule;
                product.Name = productDTO.Name;
                product.Slug = productDTO.Slug;
                product.DateEdit = DateTime.Now;
                var rowCount = await _productRepository.UpdateAsync(product);
                return rowCount>0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to update product. Error: {ex.Message}");
                throw new Exception($"Unable to update product. Error: {ex.Message}");
            }
        }
    }
}
