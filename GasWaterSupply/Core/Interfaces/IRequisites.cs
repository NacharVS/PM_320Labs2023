using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequisites
    {
        public string? INN { get; set; }
        public string? KPP { get; set; }
        public string? OGRN { get; set; }
        public string? Adress { get; set; }
        public string? NameOfCompany { get; set; }
    }
}
