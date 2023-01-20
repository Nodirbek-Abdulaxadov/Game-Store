using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class OrderViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [MaxLength(600)]
        public string? Comments { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentType Payment { get; set; }
        public string DetailsData { get; set; }
        public string? UserId { get; set; }
    }
}
