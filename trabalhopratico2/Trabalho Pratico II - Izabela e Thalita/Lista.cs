using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhopratico2
{
    class Lista
    {
        public Node inicio;

        public Lista()
        {
            inicio = null;
        }

        public bool vazia()
        {
            return(inicio == null);
        }

        public void insereFim(Estado estado)
        {
            Node novo = new Node(estado, null);
            if (vazia())
            {
                inicio = novo;
            }
            else
            {
                Node aux = inicio;

                while(aux.next != null)
                {
                    aux = aux.next;
                }
                aux.next = novo;                
            }
        }
    }
}
