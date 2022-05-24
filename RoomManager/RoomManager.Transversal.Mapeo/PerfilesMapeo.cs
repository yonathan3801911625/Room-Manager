using AutoMapper;
using RoomManager.Aplicacion.DTO;
using RoomManager.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Transversal.Mapeo
{
    public class PerfilesMapeo : Profile
    {
        public PerfilesMapeo()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            #region Ejemplo de mapeo cuando sólo se desean mapear algunos atributos.

            /* CreateMap<Novedad, NovedadDTO>().ReverseMap()
                 .ForMember(origen => origen.Id, destino => destino.MapFrom(dest => dest.Id))
                 .ForMember(origen => origen.Descripcion, destino => destino.MapFrom(dest => dest.Descripcion));*/

            #endregion
        }//Fín método
    }//Fín class
}//Fín nameSpace
