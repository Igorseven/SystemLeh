using AutoMapper;
using SalesSystem.System.MVC.Entities;
using SalesSystem.System.MVC.Models.ViewModels;

namespace SalesSystem.System.MVC.AutoMapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            EntityForViewModel();
            ViewModelForEntity();
        }

        public void EntityForViewModel()
        {
            CreateMap<Seller, SellerViewModel>();
        }

        public void ViewModelForEntity()
        {
            CreateMap<SellerViewModel, Seller>();
        }
    }
}
