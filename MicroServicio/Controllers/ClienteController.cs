using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServicio.Code;
using MicroServicio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicio.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private readonly ABDContext context;
        public ClienteController(ABDContext context )
        {
            this.context = context;
        }
        //endpoint entrada POST / CreaCliente
        //endpoint Salida GET / KpiCliente  ( - promedio edad / - desviacion entre edades )
        //endpoint Salida GET / ListClientes (- listado de clientes )

        [HttpGet]
        public IEnumerable<Cliente> ListClientes()
        {
            return context.Clientes.ToList();
            //var lrespuesta = new List<Cliente>();
            //try
            //{
            //    using (var lobjMtoCliente = new MtoCliente())
            //    {
            //        lrespuesta = lobjMtoCliente.ObtenerClientes();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return lrespuesta;
        }

        //[HttpGet]
        //public List<Cliente> ListClientes()
        //{
        //    //list <>new string[] { "value1", "value2" };
        //    var lrespuesta = new List<Cliente>();
        //    try
        //    {
        //        using (var lobjMtoCliente = new MtoCliente())
        //        {
        //            lrespuesta = lobjMtoCliente.ObtenerClientes();
        //        }               
        //    }
        //    catch (Exception ex){
        //        throw ex;
        //    }
        //    return lrespuesta;
        //} 


        // GET: api/Cliente/D
        [HttpGet("{tipo}", Name = "Get")]
        public string KpiCliente(string tipo)
        {
            if (tipo.ToUpper() == "D")
            {
                return "Desviacion de Edades";
            }
            else if (tipo.ToUpper() == "P")
            {
                return "Promedio de Edad";
            }
            return tipo;
        }
        
        // POST: api/Cliente
        [HttpPost]
        public IActionResult CreaCliente([FromBody] Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                //AgregarCliente();
                context.Clientes.Add(objCliente);
                context.SaveChanges();
                return Ok(); 
            }
            return BadRequest(ModelState);
        }
    }
}
