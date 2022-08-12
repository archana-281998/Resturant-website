using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application7.Web.Models
{
    public class OrderInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderInformationId { get; set; }

        #region Navigation Properties to the OrderMenuModel

        public int OrderMenuId { get; set; }
        [ForeignKey(nameof(OrderInformation.OrderMenuId))]
        public OrderMenu OrderMenu { get; set; }

        #endregion

        //#region 
        //public int GuestId { get; set; }
        //[ForeignKey(nameof(OrderInformation.GuestId))]
        //public Guest Guest{ get; set; }

        // #endregion

    }
}
