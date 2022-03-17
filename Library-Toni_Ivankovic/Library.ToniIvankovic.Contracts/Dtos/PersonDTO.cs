using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.ToniIvankovic.Contracts.Dtos
{
    public class PersonDTO
    {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 100 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Street name must be between 3 and 100 characters long")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 100 characters long")]
        public string City { get; set; }

        [Required(ErrorMessage ="Country name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Country name must be between 2 and 100 characters long")]
        public string Country { get; set; }

    }
}
