using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application7.Web.Models
{
    [Table(name: "MenuItems")]
    public class MenuItem
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuItemName { get; set; }

        [Required]
        [DefaultValue(1)]
        public short NumberOfPlates { get; set; }


        #region Navigation Properties to the CategoryModel

        [Display(Name="Category Name")]
            public int CategoryId { get; set; }
            [ForeignKey(nameof(MenuItem.CategoryId))]
            public Category Category { get; set; }

        #endregion
        
       public ICollection<OrderMenu> OrderMenus { get; set; }
    }
    }
