using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace trabalhopratico2
{
    class HashLE : Hash
    {
        Lista[] registros;

        public HashLE(int tamanhoTabela)
        {
            this.tamanho = tamanhoTabela;
            registros = new Lista[tamanhoTabela];
            for (int i = 0; i < registros.Length; i++)
            {
                registros[i] = new Lista();
            }
        }

        
        public override void InsereNaTabela(Estado estado)
        {
            int pos = funcaoHash(estado.nome);

            registros[pos].insereFim(estado);

            /*  Método utiliza o método funcaoHash para saber a posição
             *  Logo após, insere no fim da Lista de colisões.
             *  Cada registro da tabela é uma lista de elementos
             *  com mesmo endereçamento
             */
        }
        

        //Método recebe o nome de um estado e o procura na Tabela Hash.
        public override void procuraEstado(string nome)
        {            
            Node aux;
            int numColisoes = 0, pos;

            // Utilizando a função hash o método sabe em qual endereço o estado supostamente está
            pos = funcaoHash(nome);
            aux = registros[pos].inicio;

            //Percorre toda a lista de colisões no endereço encontrado, 
            //contando também quantas foram as colisões
            while ((nome != aux.estado.nome) && (aux.next != null))
            {
                numColisoes++;
                aux = aux.next;
            }

            if (nome == aux.estado.nome)//se encontra o estado certo na tabela
            {
                //mostra na tabela o número de colisões e os dados completos do estado
                Console.WriteLine("Chave encontrada com {0} colisões", numColisoes);
                aux.estado.imprimir();
            }
            else//se a chave informada não está na tabela o usuário é avisado
            {
                Console.WriteLine("Chave {0} inexistente na tabela!", nome);
            }
        }

        public override void imprimir()//imprime toda a tabela
        {
            Node aux;
            Console.WriteLine("POS\t   CHAVES\n");
            for (int pos = 0; pos < registros.Length; pos++)//percorre todos os endereços
            {
                Console.Write(pos + "\t"); //imprime posição de cada endereço

                aux = registros[pos].inicio;

                if (aux == null)//caso não tenham elementos em determinado endereço
                {
                    Console.Write("  -");
                }
                else//caso tenham elementos no endereço
                {
                    do//percorre toda a lista de colisões imprimindo as chaves
                    {
                        Console.Write(aux.estado.nome + ",  ");
                        aux = aux.next;
                    } while (aux != null);
                }
                Console.WriteLine();
            }
        }
    }

}