using DVLDBusiness;
using DVLDShared.DTOs.Users;

namespace DVLDBusinessTest
{
    public class clsUsersBusinessTest
    {
        [Fact]
        public async Task LoginAsync_WhenLoginDtoIsNull_ThrowsArgumentNullException()
        {
            // 1. Arrange (التجهيز)
            var usersBusiness = new clsUsersBusiness(null!);
            LoginDTO loginDto = null!;

            // 2. Act & 3. Assert (التنفيذ والتحقق معاً لاختبار الـ Exception)
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await usersBusiness.LoginAsync(loginDto);
            });
        }

        


            [Fact]
        public async Task DeleteUserAsync_WhenUserIdIsInvalid_ReturnsFailedResult()
        {
            // Arrange (التجهيز)
            var usersBusiness = new clsUsersBusiness(null!);
            int invalidUserId = 0;

            // Act (التنفيذ)
            var actual = await usersBusiness.DeleteUserAsync(invalidUserId);

            // Assert (التحقق)
            bool expectedSuccess = false;
            string expectedMessage = "Invalid user ID";

            Assert.Equal(expectedSuccess, actual.Success);
            Assert.Equal(expectedMessage, actual.Message);
        }


        [Fact]
        public async Task VerifyCurrentPasswordAsync_WhenUserIdIsInvalid_ReturnsFailedResult()
        {
            var userBusiness = new clsUsersBusiness(null!);
            int invalidUserId = 0;
            string pass = "Ali";

            var act = await userBusiness.VerifyCurrentPasswordAsync(invalidUserId, pass);

            bool expectedSuccess = false;
            string expectedMessage = "Invalid user ID";

            Assert.Equal(expectedSuccess, act.Success);
            Assert.Equal(expectedMessage, act.Message);
        }



    }
}