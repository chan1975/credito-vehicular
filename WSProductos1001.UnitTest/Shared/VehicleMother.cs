using WSProductos1001.Entities;

namespace WSProductos1001.UnitTest.Shared
{
    public static class VehicleMother
    {
        public static EVehicle Creta2018(){
            return new EVehicle()
            {
                Id = 1,
                BrandId = 1,
                TypeId = 1,
                Model = "Creta",
                ChassisNumber = "812937hy128y812y",
                Year = 2018,
                Appraisal = 1000000,
                CylinderCapacity = 1600,
                LicensePlate = "ABC123",
            };
        }
        public static EVehicle Tucson(){
            return new EVehicle()
            {
                Id = 2,
                BrandId = 1,
                TypeId = 1,
                Model = "Tucson",
                ChassisNumber = "812937hy128y812y",
                Year = 2018,
                Appraisal = 1000000,
                CylinderCapacity = 1600,
                LicensePlate = "IUN153",
            };
        }

        internal static EVehicle Creta2018MissingChassis()
        {
            return new EVehicle()
            {
                Id = 1,
                BrandId = 1,
                TypeId = 1,
                Model = "Creta",
                Year = 2018,
                Appraisal = 1000000,
                CylinderCapacity = 1600,
                LicensePlate = "ABC123",
            };
        }

        public static EVehicle Sandero2022()
        {
            return new EVehicle()
            {
                Id = 2,
                BrandId = 2,
                TypeId = 2,
                Model = "Sandero",
                ChassisNumber = "812937hy128y812y",
                Year = 2022,
                Appraisal = 1000000,
                CylinderCapacity = 1600,
                LicensePlate = "CBA234",
            };
        }
    }
}
