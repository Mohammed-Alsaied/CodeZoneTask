using AutoMapper;
using PharmaciesManagement.Models;
using PharmaciesManagement.ViewModels;

namespace PharmaciesManagement.Mapper
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreViewModel>().ReverseMap();

        }
    }
}
