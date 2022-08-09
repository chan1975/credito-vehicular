using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProductos1001.Domain.Services
{
    public interface IBrandService
    {
        Task UploadBrands(List<string> brands);
    }
}
