using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace s10p21
{
    public class Nodo
    {
        public int dato { get; set; }

        public Nodo izq { get; set; }
        public Nodo der { get; set; }


        public Nodo()
        {
            dato = 0;
            izq = null;
            der = null;
        }

    }
}
