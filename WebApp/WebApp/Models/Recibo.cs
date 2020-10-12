using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Recibo
    {
        [Key]
        public Guid Id { get; set; }
        public String Numero { get; set; }
        public DateTime Data { get; set; }
        public String Fornecedor { get; set; }
        public Decimal Valor { get; set; }
        public ICollection<Item> Detalhes { get; set; }
        public Guid FicheiroId { get; set; }
        public Ficheiro ficheiro { get; set; }

    }
}
