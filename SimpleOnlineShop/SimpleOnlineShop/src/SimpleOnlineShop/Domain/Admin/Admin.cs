namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Admin
{
    public class Admin : IAgreggateRoot
    {
        //do this later :D
        public static Admin Create(string firstName, string lastName, string address, string email, string contactNo, string employeeId)
        {
            return new Admin
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                ContactNo = contactNo,
                EmployeeId = employeeId
            };
        }

        public long Id { get; set; }

        public virtual string EmployeeId { get; private set; }
        public virtual string FirstName { get ; private set; }
        public virtual string LastName { get; private set; }
        public virtual string Name => $"{LastName}, {FirstName}";

        public virtual string Address { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string ContactNo { get; protected set; }

        public virtual void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public virtual void ChangeContactNo(string newNumber)
        {
            ContactNo = newNumber;
        }
    }
}