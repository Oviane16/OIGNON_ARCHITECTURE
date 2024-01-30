using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BLL.Services
{
    public class BaseService
    {
        protected ILogger<BaseService> _logger { get; private set; }
        protected BaseService(ILogger<BaseService> logger)
        {
            _logger = logger;
        }
    }
}
