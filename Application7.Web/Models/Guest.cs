using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application7.Web.Models
{
    public class Guest
    {
      
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
             public int GuestId{ get; set; }

            [Required]
            [StringLength(100)]
             public string GuestName{ get; set; }

        
        public ICollection<OrderMenu> OrderMenu { get; set; }
    }
}
