using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BOL.Dto
{
    public class GridParamDTO
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Draw { get; set; }
    }
}
