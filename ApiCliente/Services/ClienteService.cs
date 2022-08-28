using ApiClientes.Models;
using System;
using System.Collections.Generic;
using ApiClientes.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ApiClientes.Services
{
    public class ClienteService : IClienteService
    {
        protected readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ClienteService(
            IMapper mapper,
            AppDbContext context
        )
        {
            _mapper = mapper;
            _context = context;
        }

        public List<ClienteViewModel> GetClientes()
        {
            try
            {
                var clientes = new List<ClienteViewModel>();

                foreach (var clienteAux in _context.Clientes.Include(x => x.ClienteEnderecos).ToList())
                {
                    ClienteViewModel cliente = new();
                    cliente.Nome = clienteAux.Nome;
                    cliente.Dt_Nascimento = clienteAux.Dt_Nascimento;
                    cliente.Status = clienteAux.Status;
                    cliente.Dat_Inclusao = clienteAux.Dat_Inclusao;
                    cliente.ClienteEnderecos = _mapper.Map<List<ClienteEnderecoViewModel>>(clienteAux.ClienteEnderecos);

                    clientes.Add(cliente);
                }

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ClienteViewModel AdicionarCliente(ClienteViewModel cliente)
        {
            try
            {
                Cliente clienteAux = _mapper.Map<Cliente>(cliente);
                clienteAux.Dat_Inclusao = DateTime.Now;

                foreach (var clienteEndereco in clienteAux.ClienteEnderecos)
                {
                    clienteEndereco.Dat_Inclusao = DateTime.Now;
                }
                _context.Clientes.Add(clienteAux);
                _context.SaveChanges();
                return _mapper.Map<ClienteViewModel>(clienteAux);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AlterarCliente(IList<ClienteViewModel> Clientes)
        {
            try
            {
                //Cliente newCliente = _mapper.Map<Cliente>(Clientes);
                var clientesBD = _context.Clientes.Include(x => x.ClienteEnderecos).ToList();

                foreach (var clienteAux in Clientes)
                { 
                    Cliente newCliente = _mapper.Map<Cliente>(clienteAux);
                    
                    if (clientesBD.Find(x => x.Nome == newCliente.Nome && x.Dt_Nascimento == newCliente.Dt_Nascimento) != null)
                    {
                        _context.Clientes.Update(newCliente);
                        _context.SaveChanges();
                    }

                    if (clientesBD.Find(x => x.Nome == newCliente.Nome && x.Dt_Nascimento == newCliente.Dt_Nascimento) == null)
                    {
                        _context.Clientes.Add(newCliente);
                        _context.SaveChanges();
                    }
                }
                return "Sucesso ao alterar dados";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RemoverCliente(int id)
        {
            try
            {
                var dadosCliente = _context.Clientes.Where(x => x.Id == id).FirstOrDefault();
                
                _context.Clientes.Remove(dadosCliente);
                _context.SaveChanges();

                return "Cliente apagado com sucesso";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
