using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhopratico2
{
    class Node
    {
        public Estado estado;
        public Node next;

        public Node(Estado estado, Node next)
        {
            this.estado = estado;
            this.next = next;
        }
    }
}
