using AutoMapper;
using PharmaciesManagement.Models;
using PharmaciesManagement.ViewModels;

namespace PharmaciesManagement.Mapper
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseViewModel>().ReverseMap();

        }
    }
}
