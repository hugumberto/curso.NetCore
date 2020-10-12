using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    //[Table("tblItem")]
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ReciboId { get; set; }
        //[ForeignKey("ReciboId")]
        public Recibo recibo { get; set; }
        public String Descricao { get; set; }
        //[Column("Quantidade")]
        public Decimal Qnt { get; set; }
        public Decimal PUnit { get; set; }
        public Decimal Iva { get; set; }
        public Decimal Total { get; set; }

    }
}
