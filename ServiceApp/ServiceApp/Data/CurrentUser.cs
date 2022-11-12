namespace ServiceApp.Data
{
    public class CurrentUser
    {
        public Customer CurrentCustomer { get; set; }
        public Designer CurrentDesigner { get; set; }
        public Developer CurrentDeveloper { get; set; }
    }
}