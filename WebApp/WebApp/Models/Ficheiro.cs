using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Ficheiro
    {
        [Key]
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Extensao {get; set;}   
        public Decimal Tamanho { get; set; }
        public String Url { get; set; }
        public Recibo recibo { get; set; }

    }
}
