using AutoMapper;
using Common.Contract.Model;
using Core.DB.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarContract>();
    }
}