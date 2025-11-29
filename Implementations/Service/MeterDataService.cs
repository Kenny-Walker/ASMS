using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class MeterDataService : IMeterDataService
    {
        private IMeterRepository _meterRepository;
        private IMeterDataRepository _meterDataRepository;

        public MeterDataService(IMeterRepository meterRepository, IMeterDataRepository meterDataRepository)
        {
            _meterRepository = meterRepository;
            _meterDataRepository = meterDataRepository;
        }

        public async Task<BaseResponse> CreateMeterData(AddMeterDataDto createMeterData)
        {
            var data = await _meterRepository.GetAsync(x => x.Id == createMeterData.MeterId);
            if(data == null)
            {
                return new BaseResponse()
                {
                    Message = "Meter not found",
                    Success = false,
                };
            }
            var meterData = new MeterData
            {
                MeterId = createMeterData.MeterId,
                Power = createMeterData.Power,
                CurrentPowerConsumed = createMeterData.CurrentPowerConsumed,
                Voltage = createMeterData.Voltage,
                Current = createMeterData.Current,
                BaseLoad = createMeterData.BaseLoad,
                OffPeakLoad = createMeterData.OffPeakLoad,
                PeakLoad = createMeterData.PeakLoad,
                TodayUsage = createMeterData.TodayUsage,
                AverageUsage = createMeterData.AverageUsage,
                PercentageChange = createMeterData.PercentageChange,
            };
            await _meterDataRepository.CreateAsync(meterData);
            return new BaseResponse
            {
                Message = "Data Added Successfully",
                Success = true
            };
        }

        public async Task<MeterDataResponse> GetAllMeterData()
        {
            var data = await _meterDataRepository.GetAllMeterData();
            var dataList = new List<GetMeterDataDto>();
            foreach (var x in data) dataList.Add(await GetMeterDataDetails(x));
            return new MeterDataResponse
            {
                Data = dataList,
                Success = true,
                Message = "MeterData Retrieved"
            };
        }



        public async Task<MeterDataResponse> GetMeterDataByMeterId(int meterId)
        {
            var data = await _meterDataRepository.GetMeterDataByMeterId(meterId);
            if(data != null)
            {
                var dataList = new List<GetMeterDataDto>();
                foreach (var x in data) dataList.Add(await GetMeterDataDetails(x));
                return new MeterDataResponse
                {
                    Data = dataList,
                    Success = true,
                    Message = "MeterData Retrieved"
                };
            }
            return new MeterDataResponse
            {
                Data = null,
                Message = "Data not retrieved",
                Success = false,
            };

        }

        public async Task<BaseResponse> UpdateMeter(UpdateMeterDataDto updateMeterData)
        {
            var data = await _meterDataRepository.GetAsync(x => x.MeterId == updateMeterData.MeterId);
            if(data == null)
            {
                return new BaseResponse()
                {
                    Message = "Meter doesn't exist",
                    Success = false
                };
            }
            data.AverageUsage = updateMeterData.Power/7000;
            data.TodayUsage = updateMeterData.CurrentPowerConsumed/1000;
            data.PercentageChange = updateMeterData.CurrentPowerConsumed * 100/updateMeterData.AverageUsage;
            await _meterDataRepository.UpdateAsync(data);
            var meterInfo = await _meterRepository.GetMeter(updateMeterData.MeterId);
            if(meterInfo == null)
            {
                return new BaseResponse()
                {
                    Message = "Meter doesn't exist",
                    Success = false
                };
            }
            meterInfo.Units = meterInfo.Units - data.TodayUsage;
            await _meterRepository.UpdateAsync(meterInfo);
            return new BaseResponse
            { 
                Message = "Data updated successfully",
                Success = true
            };
        }
        public async Task<GetMeterDataDto> GetMeterDataDetails(MeterData x)
        {
            var meter = await _meterDataRepository.GetAsync(c => c.Id == x.Id);
            return new GetMeterDataDto()
            {
                Id = meter.Id,
                CurrentPowerConsumed = meter.CurrentPowerConsumed,
                AverageUsage = meter.AverageUsage,
                BaseLoad = meter.BaseLoad,
                Current = meter.Current,
                Voltage = meter.Voltage,
                Power = meter.Power,
                OffPeakLoad= meter.OffPeakLoad,
                PeakLoad = meter.PeakLoad,
                TodayUsage = meter.TodayUsage,
                PercentageChange = meter.PercentageChange,
            };
        }

    }
}
