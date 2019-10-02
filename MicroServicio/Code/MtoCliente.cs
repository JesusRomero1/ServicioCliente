using MicroServicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MicroServicio.Code
{
    public sealed class MtoCliente : IDisposable
    {

        public MtoCliente()   
            :base()
        {
        }

        //~MtoCliente()
        //{
        //    Dispose(false);
            
        //}

        public  List<Cliente> ObtenerClientes() {
            return new List<Cliente> { new Cliente { Apellido = "Romero" } };
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
