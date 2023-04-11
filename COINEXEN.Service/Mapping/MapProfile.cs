using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.ViewModels.CoinVMs;
using COINEXEN.Core.ViewModels.MessageVMs;
using COINEXEN.Core.ViewModels.UserVMs;
using COINEXEN.Core.ViewModels.WalletVm;

namespace COINEXEN.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterVM, AppUser>();
            CreateMap<Coin, GetCoinVM>();
            CreateMap<CoinWallet, CoinWalletVM>(); 
            CreateMap<Message, GetMessageVM>(); 
            CreateMap<SetMessageVM, Message>(); 
            CreateMap<UserWallet, UserWalletVM>(); 
            CreateMap<AppUser, GetUserVM>(); 
            CreateMap<AppUser, GetOnlineUserVM>();
        }

    }
}
