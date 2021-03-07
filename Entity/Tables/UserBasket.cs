using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tables
{
    public class UserBasket : IEntity
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "ProductCode")]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public string ProductPicture { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public string Order { get; set; }

    }

}
