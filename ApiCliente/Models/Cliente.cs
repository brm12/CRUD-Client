using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Models
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteEnderecos = new List<ClienteEndereco>();
        }

        public int Id { get; set; }
        
        [Required()]
        [MaxLength(200)]
        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public byte Status { get; set; }
        public DateTime Dat_Inclusao { get; set; }
        public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; set; }
    }
}
