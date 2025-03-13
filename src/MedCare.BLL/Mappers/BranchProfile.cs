using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<BranchModel, BranchEntity>().ReverseMap();
    }
}