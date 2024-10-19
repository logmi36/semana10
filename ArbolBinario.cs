using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace s10p21
{
    public class ArbolBinario
    {

        public Nodo raiz { get; set; }
        public Nodo trabajo;

        public int i = 0;

        public ArbolBinario()
        {
            raiz = null;
        }

        public Nodo Insertar(int dato, Nodo nodo)
        {
            Nodo temp = null;

            if (nodo == null)
            {
                temp = new Nodo();
                temp.dato = dato;
                return temp;
            }


            if (dato < nodo.dato)
            {
                nodo.izq = Insertar(dato, nodo.izq);
            }
            if (dato > nodo.dato)
            {
                nodo.der = Insertar(dato, nodo.der);
            }

            return nodo;
        }

        public void Transversa(Nodo nodo)
        {
            if (nodo == null)
                return;

            for (int n = 0; n < i; n++)
                Console.Write("\t");

            Console.WriteLine(nodo.dato);

            if (nodo.izq != null)
            {
                i++;
                Console.Write("I ");
                Transversa(nodo.izq);
                i--;
            }

            if (nodo.der != null)
            {
                i++;
                Console.Write("D ");
                Transversa(nodo.der);
                i--;
            }
        }


        public int EncuentraMinimo(Nodo nodo)
        {

            if (nodo == null)
                return 0;

            trabajo = nodo;
            int minimo = trabajo.dato;

            while (trabajo.izq != null)
            {
                trabajo = trabajo.izq;
                minimo = trabajo.dato;
            }

            return minimo;
        }


        public int EncuentraMaximo(Nodo nodo)
        {

            if (nodo == null)
                return 0;

            trabajo = nodo;
            int maximo = trabajo.dato;

            while (trabajo.der != null)
            {
                trabajo = trabajo.der;
                maximo = trabajo.dato;
            }

            return maximo;
        }

        public void TransversaOrdenada(Nodo nodo)
        {
            if (nodo == null)
                return;

            if (nodo.izq != null)
            {
                i++;
                TransversaOrdenada(nodo.izq);
                i--;
            }

            Console.Write("{0},", nodo.dato);

            if (nodo.der != null)
            {
                i++;
                TransversaOrdenada(nodo.der);
                i--;
            }

        }

        public Nodo NodoMinimo(Nodo nodo)
        {
            if (nodo == null)
                return null;

            trabajo = nodo;
            int minimo = trabajo.dato;

            while (trabajo.izq != null)
            {
                trabajo = trabajo.izq;
                minimo = trabajo.dato;
            }

            return trabajo;
        }

        public Nodo NodoMaximo(Nodo nodo)
        {
            if (nodo == null)
                return null;

            trabajo = nodo;
            int maximo = trabajo.dato;

            while (trabajo.izq != null)
            {
                trabajo = trabajo.izq;
                maximo = trabajo.dato;
            }

            return trabajo;
        }

        public Nodo BuscarPadre(int dato, Nodo nodo)
        {
            Nodo temp = null;
            if (nodo == null)
                return null;

            if (nodo.izq != null)
                if (nodo.izq.dato == dato)
                    return nodo;

            if (nodo.der != null)
                if (nodo.der.dato == dato)
                    return nodo;

            if (nodo.izq != null && dato < nodo.dato)
            {
                temp = BuscarPadre(dato, nodo.izq);
            }

            if (nodo.der != null && dato > nodo.dato)
            {
                temp = BuscarPadre(dato, nodo.der);
            }

            return temp;
        }


        public Boolean Insertar(int q0, int q1, int q2)
        {
            if (raiz == null)
                return false;

            Nodo tmp = raiz;

            do
            {
                if (tmp.dato == q0)
                {
                    Nodo n1 = new Nodo();
                    n1.dato = q1;
                    Nodo n2 = new Nodo();
                    n2.dato = q2;

                    tmp.izq = n1;
                    tmp.der = n2;
                    break;
                }
                tmp = tmp.izq;
            }
            while (tmp != null);

        
            tmp = raiz;

            do
            {
                if (tmp.dato == q0)
                {
                    Nodo n1 = new Nodo();
                    n1.dato = q1;
                    Nodo n2 = new Nodo();
                    n2.dato = q2;
                    tmp.izq = n1;
                    tmp.der = n2;
                    break;
                }
                tmp = tmp.der;
            }
            while (tmp != null);

            return true;

        }

    }
}
