using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using Xunit;

namespace SimpleOnlineShop.test.Domain.Customer
{
    public class CustomerTest
    {

        [Fact]
        public SimpleOnlineShop.Domain.Customer.Customer TestCustomer()
        {
            const string firstName = "First name";
            const string lastNAme = "LastName";
            const string address = "Lapu Lapu City";
            const string email = "firstlast@email.com";
            const Gender gender = Gender.male;
            const string contactNo = "09322554478";

            return SimpleOnlineShop.Domain.Customer.Customer.Create(
                firstName,
                lastNAme,
                gender,
                address,
                email,
                contactNo);
        }
    }
}