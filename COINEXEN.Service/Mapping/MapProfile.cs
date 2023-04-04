using AutoMapper;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterViewModel, AppUser>();
        }
    }
}
