using AutoMapper;
using PharmaciesManagement.Models;
using PharmaciesManagement.ViewModels;

namespace PharmaciesManagement.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemViewModel>().ReverseMap();

        }
    }
}
