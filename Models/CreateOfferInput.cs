
using System;
using System.ComponentModel.DataAnnotations;

namespace WymianaKsiazek.Api.Models
{
    public class CreateOfferInput
    {
        [Required]
        public string Content { get; set; }
     
        [Required]
        public long AddressId { get; set; }
       
        [Required]
        public Boolean Type { get; set; }
        
        [Required]
        public decimal Price { get; set; } //cos mu sie typ nie zgadza

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
       
        public long CategoryId { get; set; }

    }
}
