using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.ViewModels;

namespace COINEXEN.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterViewModel, AppUser>();
            CreateMap<Coin, CoinViewModel>();
        }
    }
}
