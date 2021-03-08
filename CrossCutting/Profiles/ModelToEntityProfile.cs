using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCutting.Profiles
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<Alarme, AlarmeModel>()
                .ReverseMap();
            
            CreateMap<Equipamento, EquipamentoModel>()
                .ReverseMap();
            
            CreateMap<AlarmeAtuado, AlarmeAtuadoModel>()
                .ReverseMap();
        }
    }
}