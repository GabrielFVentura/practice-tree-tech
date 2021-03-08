using AutoMapper;
using Domain.DTOs.Alarme;
using Domain.DTOs.AlarmeAtuado;
using Domain.DTOs.Equipamento;
using Domain.Entities;

namespace CrossCutting.Profiles
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region Alarme
            CreateMap<AlarmeDTO, Alarme>()
                .ForMember(
                    dest => dest.Equipamento, opt => opt.MapFrom(src => src.EquipamentoDTO))
                .ReverseMap();
            CreateMap<AlarmeDTOCadastrarResult, Alarme>()
                .ReverseMap();
            CreateMap<AlarmeDTOAtualizarResult, Alarme>()
                .ReverseMap();
            CreateMap<AlarmeDTOCadastrar, Alarme>()
                .ReverseMap();
            CreateMap<AlarmeDTOAtualizar, Alarme>()
                .ReverseMap();
            #endregion

            #region Equipamento
            CreateMap<EquipamentoDTO, Equipamento>()
                .ReverseMap();
            CreateMap<EquipamentoDTOCadastrarResult, Equipamento>()
                .ReverseMap();
            CreateMap<EquipamentoDTOAtualizarResult, Equipamento>()
                .ReverseMap();
            CreateMap<EquipamentoDTOCadastrar, Equipamento>()
                .ReverseMap();
            CreateMap<EquipamentoDTOAtualizar, Equipamento>()
                .ReverseMap();
            #endregion

            #region AlarmeAtuado
            CreateMap<AlarmeAtuadoDTO, AlarmeAtuado>()
                // .ForMember(
                //     dest => dest.Alarme, opt => opt.MapFrom(src => src.AlarmeDTO))
                .ReverseMap();
            CreateMap<AlarmeAtuadoDTOCadastrarResult, AlarmeAtuado>()
                .ReverseMap();
            #endregion

        }
    }
}