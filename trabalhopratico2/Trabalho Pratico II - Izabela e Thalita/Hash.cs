using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhopratico2
{
    abstract class Hash
    {
        public int tamanho;

        public int funcaoHash(string chave)
        {
            int soma = 0; //acumula para toda iteração do for a seguir

            for (int i = 0; i < chave.Length; i++)
            {
                soma += (chave[i] * i); //multiplica a letra da chave pela sua 
                                        //posição 
            }

            return (soma % tamanho); //valor acumulado módulo tamanho da tabela
        }

        public abstract void InsereNaTabela(Estado estado);

        public abstract void procuraEstado(string nome);

        public abstract void imprimir();
    }
}
