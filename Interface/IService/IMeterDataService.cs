using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using Automated_Smart_Metering_System.Models.DTOs;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IMeterDataService
    {
        Task<BaseResponse> CreateMeterData(AddMeterDataDto createMeterData);
        Task<BaseResponse> UpdateMeter(UpdateMeterDataDto updateMeterData);
        Task<MeterDataResponse> GetAllMeterData();
        Task<MeterDataResponse> GetMeterDataByMeterId(int meterId);
    }
}
