using FluentValidation;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Vehicle
{
    internal class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IValidator<EVehicle> _validator;
        public VehicleService(IVehicleRepository vehicleRepository, IValidator<EVehicle> validator, IBrandRepository brandRepository)
        {
            _vehicleRepository = vehicleRepository;
            _validator = validator;
            _brandRepository = brandRepository;
        }
        

        public async Task<EVehicle> CreateAsync(EVehicle vehicle)
        {
            var result = await _validator.ValidateAsync(vehicle);
            if (!result.IsValid)
                throw new Exceptions.ValidationException(result.Errors);
            var brand = await _brandRepository.GetByIdAsync(vehicle.BrandId);
            if (brand == null) throw new Exceptions.BadRequestException("Marca no existe");
            var newVehicle = await _vehicleRepository.CreateAsync(vehicle);
            return newVehicle;

        }

        public async Task DeleteAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null) throw new Exceptions.NotFoundException(nameof(EVehicle), id);
            await _vehicleRepository.DeleteAsync(vehicle);
            
        }

        public async Task<IEnumerable<EVehicle>> GetAllAsync()
        {
            var vehicleList = await _vehicleRepository.GetAllAsync();
            return vehicleList;
        }

        public async Task<EVehicle> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            return vehicle;

        }

        public async Task UpdateAsync(int id, EVehicle vehicle)
        {
            var result = await _validator.ValidateAsync(vehicle);
            if (!result.IsValid)
                throw new Exceptions.ValidationException(result.Errors);
            var brand = await _brandRepository.GetByIdAsync(vehicle.BrandId);
            if (brand == null) throw new Exceptions.BadRequestException("Marca no existe");
            var vehicleToUpdate = await _vehicleRepository.GetByIdAsync(id);
            if (vehicleToUpdate == null) throw new Exceptions.NotFoundException(nameof(EVehicle),id);
            vehicleToUpdate.Appraisal = vehicle.Appraisal;
            vehicleToUpdate.BrandId = vehicle.BrandId;
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.Year = vehicle.Year;
            vehicleToUpdate.ChassisNumber = vehicle.ChassisNumber;
            vehicleToUpdate.CylinderCapacity = vehicle.CylinderCapacity;
            vehicleToUpdate.LicensePlate = vehicle.LicensePlate;
            vehicleToUpdate.TypeId = vehicle.TypeId;
            await _vehicleRepository.UpdateAsync(vehicleToUpdate);

        }
    }
}
