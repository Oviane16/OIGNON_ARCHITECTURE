using PRODUCT.BOL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<bool> Update(ProductDTO productDTO);
        Task<bool> Delete(int id);
        Task<ProductDTO> GetById(int id);
        Task<GridDataDTO> GetGridData(GridParamDTO gridParamDto);
    }
}
