using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Domain.Features.Vehicle;
using WSProductos1001.UnitTest.Shared;

namespace WSProductos1001.UnitTest.ValidationsModels
{
    public class VehicleValidation
    {
        private VehicleValidator _validator;
        [SetUp]
        public void Setup()
        {
            _validator = new VehicleValidator();
        }
        [Test]
        public void VehicleValid_ReturnTrue()
        {
            var result = _validator.Validate(VehicleMother.Creta2018());
            Assert.IsTrue(result.IsValid);
        }
        [Test]
        public void VehicleValid_ReturnFalse()
        {
            var result = _validator.Validate(VehicleMother.Creta2018MissingChassis());
            Assert.IsFalse(result.IsValid);
        }
    }
}
