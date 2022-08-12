using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application7.Web.Models
{
    
    public class Category
    {
        [Key]                                                       // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]      
                                  // Label on the UI
        public int CategoryId { get; set; }

                          // Label on the UI
        public string CategoryName { get; set; }
        #region Navigation Properties to the menu Model

        public ICollection<MenuItem> MenuItems { get; set; }


        #endregion
        


    }
}
