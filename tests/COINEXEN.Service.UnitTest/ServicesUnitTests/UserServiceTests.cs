using AutoMapper;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.UserVMs;
using COINEXEN.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace COINEXEN.Service.UnitTest.ServicesUnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<UserManager<AppUser>> _userManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IWalletService> _walletServiceMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UserServiceTests()
        {
            _userManagerMock = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
            _mapperMock = new Mock<IMapper>();
            _walletServiceMock = new Mock<IWalletService>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _userService = new UserService(
                _userManagerMock.Object,
                _mapperMock.Object,
                _walletServiceMock.Object,
                _httpContextAccessorMock.Object,
                _unitOfWorkMock.Object
            );
        }

        [Fact]
        public async Task CreateUserAsync_ValidRegistration_ReturnsTrue()
        {
            RegisterVM registerViewModel = new RegisterVM();
            AppUser appUser = new AppUser();

            _mapperMock.Setup(x => x.Map<AppUser>(registerViewModel)).Returns(appUser);
            _userManagerMock.Setup(x => x.CreateAsync(appUser, registerViewModel.Password)).ReturnsAsync(IdentityResult.Success);
            _walletServiceMock.Setup(x => x.CreateWalletsAsync(appUser)).Returns(Task.CompletedTask);

            bool result = await _userService.CreateUserAsync(registerViewModel);

            Assert.True(result);
            _userManagerMock.Verify(x => x.CreateAsync(appUser, registerViewModel.Password), Times.Once);
            _walletServiceMock.Verify(x => x.CreateWalletsAsync(appUser), Times.Once);
        }

        [Fact]
        public async Task GetAllUserAsync_ReturnsListOfGetUserVM()
        {
            List<AppUser> users = new List<AppUser>
            {
                new AppUser { },
                new AppUser { },
            };

            List<GetUserVM> getUserVMs = new List<GetUserVM>
            {
                new GetUserVM { },
                new GetUserVM { },
            };

            _unitOfWorkMock.Setup(x => x.UserRepository.GetAllUsersWithPropertiesAsync()).ReturnsAsync(users);
            _mapperMock.Setup(x => x.Map<List<GetUserVM>>(users)).Returns(getUserVMs);

            List<GetUserVM> result = await _userService.GetAllUserAsync();

            Assert.Equal(getUserVMs, result);
            _unitOfWorkMock.Verify(u => u.UserRepository.GetAllUsersWithPropertiesAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<GetUserVM>>(users), Times.Once);
        }

        //[Fact]
        //public async Task GetOnlineUserAsync_AuthenticatedUser_ReturnsGetOnlineUserVM()
        //{
          
        //}
    }
}
