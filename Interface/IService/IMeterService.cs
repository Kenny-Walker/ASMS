using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IMeterService
    {
        Task<BaseResponse> CreateMeter(CreateMeterDto createMeter);
        Task<BaseResponse> GetMeter(int id);
        Task<MeterResponse> GetAllMeters();
        Task<BaseResponse> GetMeterByUniqueId(string UniqueId);
        Task<MeterResponse> GetActiveMeters(bool isActive);
        Task<MeterResponse> GetAllMetersByUserId(int UserId);
        Task<BaseResponse> DeleteMeter(int userId, int meterId);
        Task<BaseResponse> SelectMeter(int userId, string UniquemeterId, UpdateMeterDto updateMeter);
        Task<BaseResponse> ActivateMeter(int meterId);
        Task<BaseResponse> DeactivateMeter(int meterId);
        Task<BaseResponse> GetMeterStatus(int meterId);
    }
}
