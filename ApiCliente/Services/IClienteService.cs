using ApiClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Services
{
    public interface IClienteService
    {
        ClienteViewModel AdicionarCliente(ClienteViewModel cliente);
        List<ClienteViewModel> GetClientes();
        string AlterarCliente(IList<ClienteViewModel> Clientes);
        string RemoverCliente(int id);
    }
}
