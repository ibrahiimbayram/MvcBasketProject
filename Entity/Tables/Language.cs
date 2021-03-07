using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tables
{
    public class Language : IEntity
    {
  
        public int Id { get; set; }
        public string Name { get; set; }
        public string BasketAdd { get; set; }
        public string CreateBasket { get; set; }
        public string MyBasket { get; set; }
        public string OrderCompleted { get; set; }
    }

}
