using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BOL.Dto
{
    public class GridDataDTO
    {
        public GridDataDTO()
        {
            this.Data = new List<ProductDTO>();
        }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int Draw { get; set; }
        public List<ProductDTO> Data { get; set; }
    }
}
