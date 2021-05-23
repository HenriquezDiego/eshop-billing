using System;
using System.Linq;
using eshop_webapi.api.DataAccess;
using eshop_webapi.api.Inputs;
using eshop_webapi.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop_webapi.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : ControllerBase
    {
        public readonly AppDbContext _appDbContext;
        public ClienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            using (_appDbContext)
            {
                var clientes = _appDbContext.Clientes.ToList();
                if(clientes == null) return BadRequest();
                return Ok(clientes);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (_appDbContext)
            {
                var clientes = _appDbContext.Clientes.FirstOrDefault(c=>c.ClienteId == id);
                if(clientes == null) return BadRequest();
                return Ok(clientes);
            }
        }

        [HttpPost]
        public IActionResult Post(ClienteInput model)
        {
            var cliente = new Cliente
            {
                Nombres  = model.Nombres,
                Apellidos = model.Apellidos,
                FechaNacimiento = model.FechaNacimiento,
                Telefono = model.Telefono,
                Email = model.Email,
                Direccion = model.Direccion
            };
            using (_appDbContext)
            {
                var clientes = _appDbContext.Clientes.Add(cliente);
                if(_appDbContext.SaveChanges()<0) return BadRequest();
                return new CreatedAtRouteResult(new {id = cliente.ClienteId},cliente);
            }
        }
    }
}