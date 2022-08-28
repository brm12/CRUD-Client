using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Models
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteEnderecos = new List<ClienteEnderecoViewModel>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public byte Status { get; set; }
        public DateTime Dat_Inclusao { get; set; }
        public virtual ICollection<ClienteEnderecoViewModel> ClienteEnderecos { get; set; }
    }
}
