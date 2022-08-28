using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Models
{
    public class ClienteEnderecoViewModel
    {
            public string Logradouro { get; set; }
            public string Cep { get; set; }
            public string Uf { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public byte Status { get; set; }
            public DateTime Dat_Inclusao { get; set; }
    }
}
