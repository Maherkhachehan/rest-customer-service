namespace RestCustomerConsumer
{
    public class Customer
    {
        private static int nextId = 0;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        public Customer(string firstName, string lastName, int year)
        {
            Id = ++nextId;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }

        public Customer()
        {

        }
    }
}
