using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KaraKita.Models
{
    public class YoneticiModel
    {
        [Required]
        public string Ad { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        [DataType(DataType.Password),Compare("Sifre")]
        public string SifreTekrar { get; set; }
    }
}