using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IDeviceService
    {
        Task<BaseResponse> AddDevice(AddDeviceDto addDevice);
        Task<DeviceResponse> GetDeviceByMeterId(int meterId);
        Task<BaseResponse> DeleteDevice(int Id);
        Task<BaseResponse> ActivateDevice(int Id, bool isActive);
        Task<BaseResponse> DeactivateDevice(int Id);
        Task<BaseResponse> UpdateDevice(UpdateDeviceDto updateDevice);

    }
}
