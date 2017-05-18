using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;
using Xunit;

namespace SimpleOnlineShop.test.Domain.User
{
    public partial class UserTest
    {

        [Fact]
        public SimpleOnlineShop.Domain.UserAgg.User CreateUserTest()
        {
            const string firstName = "First name";
            const string lastNAme = "LastName";
            const string address = "Lapu Lapu City";
            const string email = "firstlast@email.com";
            const Gender gender = Gender.male;
            const string contactNo = "09322554478";

            return SimpleOnlineShop.Domain.UserAgg.User.Create(
                firstName,
                lastNAme,
                gender,
                address,
                email,
                contactNo);
        }
    }
}