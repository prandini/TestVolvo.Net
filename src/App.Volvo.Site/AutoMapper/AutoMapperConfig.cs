using App.Volvo.Business.Models;
using App.Volvo.Site.ViewModels;
using AutoMapper;

namespace App.Volvo.Site.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Caminhao, CaminhaoViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloViewModel>().ReverseMap();
        }
    }
}