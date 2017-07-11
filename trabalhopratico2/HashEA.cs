using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace trabalhopratico2
{
    class HashEA : Hash
    {
        Estado[] registros;

        public HashEA(int tamanhoTabela)
        {
            this.tamanho = tamanhoTabela;
            registros = new Estado[tamanhoTabela];           
        }
       
        public override void InsereNaTabela(Estado estado)
        {
            //Método utiliza o método funcaoHash para saber a posição            
            int pos = funcaoHash(estado.nome);
            
            //se o endereço está ocupado, percorre os endereços até que
            //um esteja livre
            while(registros[pos] != null)
            {
                pos++;
                if(pos == registros.Length)//se chegar no fim, 
                {
                    pos = 0;//volta no início
                }
                //não há possibilidade de infinity looping pois 
                //o tamanho da tabela é adequado (validado ao receber do usuário)
            }
            registros[pos] = estado;
        }

        public override void procuraEstado(string nome)
        {
            int pos, posInicial, numColisoes = 0;
            bool existe = true;

            // Utilizando a função hash o método sabe em qual endereço o estado supostamente está
            pos = funcaoHash(nome);

            posInicial = pos;//anula possibilidade de infinity looping, 
                             //no caso de busca por chave inexistente
            while((registros[pos] != null)&&
                (registros[pos].nome != nome)&&
                (existe == true))//percorre os endereçamentos
            {
                pos++;
                numColisoes++;
                if(pos == registros.Length)//se chegar ao fim,
                {
                    pos = 0;//volta ao início       
                }
                else if(pos == posInicial)
                {
                    //se percorreu todos os endereçamentos sem encontrar a chave
                    Console.WriteLine("Chave {0} inexistente na tabela!", nome);
                    existe = false;
                }               
            }
            if(registros[pos] == null)
            {
                Console.WriteLine("Chave {0} inexistente na tabela!", nome);
                existe = false;
            }
            if (existe)//localizou a chave (registros[pos].nome == nome)
            {
                Console.WriteLine("Chave encontrada com {0} colisões", numColisoes);
                registros[pos].imprimir();
            }
        }

        public override void imprimir()//imprime toda a tabela
        {
            Console.WriteLine("POS\t CHAVES\t                        h(x)\n");
            for (int pos = 0; pos < registros.Length; pos++)//percorre endereçamentos
            {
                Console.Write(pos + "\t");//imprime a posição
                if(registros[pos] == null)//caso não tenha chave no endereço
                {
                    Console.Write("  -");
                }
                else//caso tenha uma chave
                {
                    Console.Write(registros[pos].nome);//imprime a chave (nome do estado)

                    for (int i = 0; i < (30-registros[pos].nome.Length); i++)
                    {
                        //este laço garante um alinhamento para exibir "h(x)="
                        Console.Write(" ");
                    }

                    //imprime seu resultado de hashing primario
                    Console.Write("h(x)=" + funcaoHash(registros[pos].nome));
                }
                Console.WriteLine();
            }
        }

    }
}
