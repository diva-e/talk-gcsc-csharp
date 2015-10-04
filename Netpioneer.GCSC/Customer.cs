namespace Netpioneer.GCSC
{
    public class Customer
    {
        private readonly string loginName;

        private readonly string firstName;

        private readonly string lastName;

        private readonly int age;

        private readonly Gender gender;

        public string LoginName
        {
            get { return loginName; } 
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public int Age
        {
            get { return age; }
        }

        public Gender Gender
        {
            get { return gender; }
        }

        public Customer(string loginName, string firstName, string lastName, int age, Gender gender)
        {
            this.loginName = loginName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
        }
    }
}