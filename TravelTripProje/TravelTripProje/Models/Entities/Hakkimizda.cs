using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace TravelTripProje.Models.Entities
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; }
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }    
    }
}