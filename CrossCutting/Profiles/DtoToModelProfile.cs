using AutoMapper;
using Domain.DTOs.Alarme;
using Domain.DTOs.AlarmeAtuado;
using Domain.DTOs.Equipamento;
using Domain.Models;

namespace CrossCutting.Profiles
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<AlarmeModel, AlarmeDTO>()
                .ForMember(
                    dest => dest.EquipamentoDTO, opt => opt.MapFrom(src => src.EquipamentoModel))
                .ReverseMap();
            CreateMap<AlarmeModel, AlarmeDTOCadastrar>()
                .ReverseMap();
            CreateMap<AlarmeModel, AlarmeDTOAtualizar>()
                .ReverseMap();
            
            CreateMap<EquipamentoModel, EquipamentoDTO>()
                .ReverseMap();
            CreateMap<EquipamentoModel, EquipamentoDTOCadastrar>()
                .ReverseMap();
            CreateMap<EquipamentoModel, EquipamentoDTOAtualizar>()
                .ReverseMap();
            
            CreateMap<AlarmeAtuadoModel, AlarmeAtuadoDTO>()
                .ForMember(dest => dest.AlarmeDTO, opt => opt.MapFrom(src => src.AlarmeModel))
                .ReverseMap();
        }
    }
}