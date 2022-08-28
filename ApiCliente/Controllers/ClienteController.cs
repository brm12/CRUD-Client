using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClientes.Context;
using ApiClientes.Models;
using ApiClientes.Services;

namespace ApiClientes.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IClienteService _clienteService;

        public ClienteController(
            IClienteService clienteService,
            AppDbContext context
            )
        {
            _clienteService = clienteService;
            _context = context;
        }

        [HttpGet("/clientes")]
        public IActionResult GetClientes()
        {
            try
            {
                var result = _clienteService.GetClientes();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/alterar-cliente")]
        public IActionResult PutCliente(IList<ClienteViewModel> Clientes)
        {
            try
            {
                var result = _clienteService.AlterarCliente(Clientes);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/adicionar-cliente")]
        public IActionResult PostCliente(ClienteViewModel cliente)
        {
            try
            {
                var result = _clienteService.AdicionarCliente(cliente);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/cliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                var result = _clienteService.RemoverCliente(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
