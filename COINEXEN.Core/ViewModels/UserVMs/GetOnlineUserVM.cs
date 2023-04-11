using COINEXEN.Core.ViewModels.WalletVm;

namespace COINEXEN.Core.ViewModels.UserVMs
{
    public class GetOnlineUserVM
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserWalletVM Wallet { get; set; }

    }
}
