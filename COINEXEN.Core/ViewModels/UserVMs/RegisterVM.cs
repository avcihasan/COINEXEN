using COINEXEN.Core.Enums;

namespace COINEXEN.Core.ViewModels.UserVMs
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
