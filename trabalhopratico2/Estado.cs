using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhopratico2
{
    class Estado
    {
        public string nome;//campo chave
        public string capital;
        public string regiao;
        public int quantMunicipios;

        public Estado(string nome, string capital, string regiao, int quantMunicipios)
        {
            this.nome = nome;
            this.capital = capital;
            this.regiao = regiao;
            this.quantMunicipios = quantMunicipios;
        }
        public void imprimir()
        {
            Console.WriteLine("Estado: " + nome);
            Console.WriteLine("Capital: " + capital);
            Console.WriteLine("Região: " + regiao);
            Console.WriteLine(quantMunicipios + " Municípios");
        }
    }
}
