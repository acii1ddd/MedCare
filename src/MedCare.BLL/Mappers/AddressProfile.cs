using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressModel, AddressEntity>().ReverseMap();
    }
}