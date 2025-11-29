using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Implementations.Repository;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class MeterService : IMeterService
    {
        private IUserRepository _userRepository;
        private IMeterRepository _meterRepository;

        public MeterService(IUserRepository userRepository, IMeterRepository meterRepository)
        {
            _userRepository = userRepository;
            _meterRepository = meterRepository;
        }

        public async Task<BaseResponse> CreateMeter(CreateMeterDto createMeter)
        {
            var user = await _userRepository.GetAsync(x => x.Id == createMeter.UserId);
            if(user == null)
            {
                return new BaseResponse()
                {
                    Message = "User does not exist",
                    Success = false,
                };
            }
            var meter = new Meter
            {
                UserId = 0,
                MeterName = "",
                Location = "",
                IsActive = false,
                UniqueMeterId = "MT" + Guid.NewGuid().ToString("N").Substring(0, 8),
                Units = 0,
            };
            await _meterRepository.CreateAsync(meter);
            return new BaseResponse()
            { 
                Message = "Meter Created Successfully",
                Success = true,
            };

        }



        public async Task<MeterResponse> GetActiveMeters(bool isActive)
        {
            var meter = await _meterRepository.GetMeterByIsActive(isActive);
            if(isActive == true && meter != null)
            {
                var meterList = new List<GetMeterDto>();
                foreach (var x in meter) meterList.Add(await GetMeterDetails(x));
                return new MeterResponse
                {
                    Data = meterList,
                    Success = true,
                    Message = "Meters Retrieved"
                };
            }
            return new MeterResponse
            {
                Data = null,
                Success = false,
                Message = "Meters not found"
            };
        }

        public async Task<MeterResponse> GetAllMeters()
        {
            var meter = await _meterRepository.GetAllMeters();
            var meterList = new List<GetMeterDto>();
            foreach (var x in meter) meterList.Add(await GetMeterDetails(x));
            return new MeterResponse
            {
                Data = meterList,
                Success = true,
                Message = "Meters Retrieved"
            };
        }

        public async Task<BaseResponse> GetMeter(int id)
        {
            var meter = await _meterRepository.GetMeter(id);
            if (meter == null)
            {
                return new SingleMeterResponse()
                {
                    Data = null,
                    Message = "meter doesn't exist",
                    Success = false,
                };
            }
            return new SingleMeterResponse
            {
                Data = await GetMeterDetails(meter),
                Success = true,
                Message = "Meter Retrieved"
            };
        }

        public async Task<BaseResponse> GetMeterByUniqueId(string UniqueId)
        {
            var meter = await _meterRepository.GetMeterByUniqueId(UniqueId);
            if (meter == null)
            {
                return new SingleMeterResponse()
                {
                    Data = null,
                    Message = "meter doesn't exist",
                    Success = false,
                };
            }
            return new SingleMeterResponse
            {
                Data = await GetMeterDetails(meter),
                Success = true,
                Message = "Meter Retrieved"
            };
        }
        public async Task<BaseResponse> SelectMeter(int userId, string UniquemeterId, UpdateMeterDto updateMeter)
        {
            var user = await _userRepository.GetAsync(userId);
            var meter = await _meterRepository.GetMeterByUniqueId(UniquemeterId);
            
            if (meter != null || user != null)
            {
                meter.UserId = userId;

                meter.MeterName = updateMeter.MeterName;
                meter.Location = updateMeter.Location;
                await _meterRepository.UpdateAsync(meter);
                return new BaseResponse()
                {
                    Message = "Meter Selected",
                    Success = true,
                };
              
            }
            return new BaseResponse()
            {
                Message = "meter or user doesn't exist",
                Success = false,
            };

        }
        public async Task<BaseResponse> ActivateMeter(int meterId)
        {
            var meter = await _meterRepository.GetMeter(meterId);

            if (meter != null )
            {
                meter.IsActive = true;
                await _meterRepository.UpdateAsync(meter);
                return new BaseResponse()
                {
                    Message = "Meter Activated",
                    Success = true,
                };

            }
           
            return new BaseResponse()
            {
                Message = "meter doesn't exist",
                Success = false,
            };

        }
        public async Task<BaseResponse> DeactivateMeter(int meterId)
        {
            var meter = await _meterRepository.GetMeter(meterId);

            if (meter != null)
            {
                meter.IsActive = false;
                await _meterRepository.UpdateAsync(meter);
                return new BaseResponse()
                {
                    Message = "Meter Deactivated",
                    Success = true,
                };

            }

            return new BaseResponse()
            {
                Message = "eter doesn't exist",
                Success = false,
            };

        }

        public async Task<BaseResponse> DeleteMeter(int userId, int meterId)
        {
            var meter = await _meterRepository.GetMeter(meterId);
            var user = await _userRepository.GetAsync(userId);
            if (meter == null || user == null)
            {
                return new BaseResponse()
                {
                    Message = "meter doesn't exist",
                    Success = false,
                };
            }
            meter.UserId = 0;
            await _meterRepository.UpdateAsync(meter);
            return new BaseResponse()
            {
                Message = "Meter Selected",
                Success = true,
            };
        }
        public async Task<GetMeterDto> GetMeterDetails(Meter x)
        {
            var meter = await _meterRepository.GetAsync(c => c.Id == x.Id);
            return new GetMeterDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                MeterName = x.MeterName,
                UniqueMeterId= x.UniqueMeterId,
                Location = x.Location,
                Units = x.Units,
                IsActive= x.IsActive,
            };
        }

        public async Task<GetMeterStatusDto> GetMeterStateStatus(Meter x)
        {
            var meter = await _meterRepository.GetAsync(c => c.Id == x.Id);
            return new GetMeterStatusDto()
            {
                Id = x.Id,
                IsActive = x.IsActive,
            };
        }

        public async Task<MeterResponse> GetAllMetersByUserId(int UserId)
        {
            var meter = await _meterRepository.GetMetersByUserId(UserId);
            if (meter != null)
            {
                var meterList = new List<GetMeterDto>();
                foreach (var x in meter) meterList.Add(await GetMeterDetails(x));
                return new MeterResponse
                {
                    Data = meterList,
                    Success = true,
                    Message = "Meters Retrieved"
                };
            }
            return new MeterResponse
            {
                Data = null,
                Success = false,
                Message = "Meters not found"
            };
        }

        public async Task<BaseResponse> GetMeterStatus(int meterId)
        {
            var meter = await _meterRepository.GetMeter(meterId);
            if (meter == null)
            {
                return new BaseResponse()
                {
                    Success = true,
                    Message = "Meter Retrieved"
                };
            }
                return new MeterStatusResponse
                {
                    Data = await GetMeterStateStatus(meter),
                    Success = true,
                    Message = "Meter Retrieved"
                };
        }
    }
}
