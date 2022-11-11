namespace ServiceApp.Data
{
    public class Developer : User
    {
        public string DeveloperOrganisation { get; set; }

        public string OGRN { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public string Address { get; set; }

        public string Leader { get; set; }
    }
}