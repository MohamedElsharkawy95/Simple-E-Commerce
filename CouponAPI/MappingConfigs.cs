using AutoMapper;
using CouponAPI.Dtos;
using CouponAPI.Models;

namespace CouponAPI
{
    public class MappingConfigs
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
             {
                 config.CreateMap<Coupon, CouponDto>();
                 config.CreateMap<CouponDto, Coupon>();
             });

            return mappingConfig;
        }
    }
}
