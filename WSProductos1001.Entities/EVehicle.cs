using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProductos1001.Entities
{
    public class EVehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string ChassisNumber { get; set; }
        public int BrandId { get; set; }
        public int? TypeId { get; set; }
        public int CylinderCapacity{ get; set; }
        public int Appraisal { get; set; }
        public int Year { get; set; }
    }
}
