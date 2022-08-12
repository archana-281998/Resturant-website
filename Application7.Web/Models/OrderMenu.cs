using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application7.Web.Models
{
    public class OrderMenu
    {
        [Key]                                                       // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       
                                    // Label on the UI
        public int OrderMenuId { get; set; }

                          // Label on the UI
        public string OrderMenuName { get; set; }

        #region Navigation Properties to the OrderMenuModel

        public int GuestId { get; set; }
        [ForeignKey(nameof(OrderMenu.GuestId))]
        public Guest Guest { get; set; }

        #endregion

        #region Navigation Properties to the OrderMenuModel

        public int MenuItemId { get; set; }
        [ForeignKey(nameof(OrderMenu.MenuItemId))]
        public MenuItem MenuItem { get; set; }

        #endregion

        public ICollection<OrderInformation> OrderInformation { get; set; }


    }
}
