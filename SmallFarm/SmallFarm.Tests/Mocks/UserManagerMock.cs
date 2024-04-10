using Microsoft.AspNetCore.Identity;
using Moq;
using SmallFarm.Data.Entities;

namespace SmallFarm.Tests.Mocks
{
    public static class UserManagerMock
    {
        public static Mock<UserManager<ApplicationUser>> Instance
        {
            get
            {
                var userStoreMock = new Mock<IUserStore<ApplicationUser>>();

                return new Mock<UserManager<ApplicationUser>>(
                    userStoreMock.Object,
                    null, // You can add other parameters here if needed
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);
            }
        }
    }
}
