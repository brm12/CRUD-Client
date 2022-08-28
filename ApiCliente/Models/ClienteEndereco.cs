using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClientes.Models
{
    public class ClienteEndereco
    {
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]
        public string Logradouro { get; set; }
        
        [Required()]
        [MaxLength(8)]
        public string Cep { get; set; }
        
        [Required()]
        [MaxLength(2)]
        public string Uf { get; set; }
        
        [Required()]
        [MaxLength(100)]
        public string Cidade { get; set; }
        
        [Required()]
        [MaxLength(60)]
        public string Bairro { get; set; }
        public byte Status { get; set; }
        public DateTime Dat_Inclusao { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
