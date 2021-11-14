using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Map.Location.Data;
using Map.Location.Data.Entity;
using System;
using System.Linq;

namespace Map.Location.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
