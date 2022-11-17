using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPrimaryData
    {
        public ObjectId Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Too long")]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
