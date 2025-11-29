using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Implementations.Repository;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class DeviceService : IDeviceService
    {
        private IMeterRepository _meterRepository;
        private IDeviceRepository _deviceRepository;


        public DeviceService(IMeterRepository meterRepository, IDeviceRepository deviceRepository)
        {
            _meterRepository = meterRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<BaseResponse> ActivateDevice(int Id, bool isActive)
        {
            var device = await _deviceRepository.GetDeviceById(Id);
            if (device == null)
            {
                return new BaseResponse()
                {
                    Message = "Device doesn't exist",
                    Success = false
                };
            }
            device.IsActive = isActive;
            await _deviceRepository.UpdateAsync(device);
            return new BaseResponse()
            {
                Message = "Device Activated",
                Success = true
            };
        }
        public async Task<BaseResponse> DeactivateDevice(int Id)
        {
            var device = await _deviceRepository.GetDeviceById(Id);
            if (device == null)
            {
                return new BaseResponse()
                {
                    Message = "Device doesn't exist",
                    Success = false
                };
            }
            device.IsActive = false;
            await _deviceRepository.UpdateAsync(device);
            return new BaseResponse()
            {
                Message = "Device Activated",
                Success = true
            };
        }

        public async Task<BaseResponse> AddDevice(AddDeviceDto addDevice)
        {
            var meter = await _meterRepository.GetAsync(x => x.Id == addDevice.MeterId);
            if(meter == null)
            {
                return new BaseResponse()
                { 
                    Message = "Meter doesn't exist",
                    Success = false
                };
            }
            var device = new Device
            {
                DeviceName = addDevice.DeviceName,
                DeviceKey = addDevice.DeviceKey,
                PowerConsumed = 0,
                IsActive = false,
                MeterId = addDevice.MeterId,

            };
            await _deviceRepository.CreateAsync(device);
            return new BaseResponse()
            {
                Message = "Device added successfully",
                Success = true
            };
        }
        public async Task<BaseResponse> UpdateDevice(UpdateDeviceDto updateDevice)
        {
            var device = await _deviceRepository.GetDeviceById(updateDevice.Id);
            if (device == null)
            {
                return new BaseResponse()
                {
                    Message = "Device doesn't exist",
                    Success = false
                };
            }
            device.PowerConsumed = updateDevice.PowerConsumed;
            await _deviceRepository.UpdateAsync(device);
            return new BaseResponse()
            {
                Message = "Device updated successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeleteDevice(int Id)
        {
            var device = await _deviceRepository.GetDeviceById(Id);
            if(device == null)
            {
                return new BaseResponse()
                {
                    Message = "Device doesn't exist",
                    Success = false
                };
            }
            device.IsDeleted = true;
            await _deviceRepository.UpdateAsync(device);
            return new BaseResponse()
            {
                Message = "Device deleted successfully",
                Success = true
            };
        }

        public async Task<DeviceResponse> GetDeviceByMeterId(int meterId)
        {
            var device = await _deviceRepository.GetAllDevicesByMeterId(meterId);
            if (device == null)
            {
                return new DeviceResponse()
                {
                    Data = null,
                    Message = "Device do not exist",
                    Success = false
                };
            }
            var deviceList = new List<GetDeviceDto>();
            foreach (var x in device) deviceList.Add(await GetDeviceDetails(x));
            return new DeviceResponse
            {
                Data = deviceList,
                Success = true,
                Message = "Devices Retrieved"
            };
        }
        public async Task<GetDeviceDto> GetDeviceDetails(Device x)
        {
            var device = await _deviceRepository.GetAsync(c => c.Id == x.Id);
            return new GetDeviceDto()
            {
                Id = x.Id,
                DeviceName = x.DeviceName,
                DeviceKey = x.DeviceKey,
                MeterId = x.MeterId,
                PowerConsumed = x.PowerConsumed,
                IsActive = x.IsActive,
            };
        }
    }
}
