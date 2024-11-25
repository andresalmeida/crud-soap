using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPServer
{
    public class Libro
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoPublicacion { get; set; }
    }
}