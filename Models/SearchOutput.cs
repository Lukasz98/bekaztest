using System.ComponentModel.DataAnnotations;

namespace WymianaKsiazek.Api.Models
{
    public class SearchOutput
    {
        [Required]
        public string name { get; set; }

    }
}
