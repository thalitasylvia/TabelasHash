 /*
  *           2º Trabalho Prático - AED - TABELAS HASH 
  *           Desenvolvido por: Izabela Andrade e Thalita Marques
  *           Em: Maio de 2017 
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace trabalhopratico2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash tabelaHash;
            int tamanho;
            char op;
            string nomeEstado;

            Console.WriteLine("\t***CRIANDO A TABELA HASH***");
          
            do {
                Console.WriteLine("\nSendo:");
                Console.WriteLine("\t[1]- Listas Encadeadas");
                Console.WriteLine("\t[2]- Endereçamento aberto");
                Console.Write("Informe o modo de tratamento de colisões: ");
                op = char.Parse(Console.ReadLine());
                if ((op != '1') && (op != '2'))
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
            } while ((op != '1') && (op != '2'));
            
            Console.WriteLine();

            do
            {
                Console.Write("\nInforme o tamanho da tabela: ");
                tamanho = int.Parse(Console.ReadLine());

                if (tamanho <= 0)//em nenhum caso é permitido tamanho negativo
                {
                    Console.WriteLine("Tamanho inválido!. Favor informar valor positivo.");
                }
                else if ((op == '2') && (tamanho < 27))//validação do tamanho caso "Endereçamento Aberto"
                {
                    Console.WriteLine("Tamanho para tabela insuficiente para realizar armazenamento dos 27 estados.");
                    Console.WriteLine("Favor fornecer tamanho válido.");
                }

            } while ((tamanho <= 0) || ((op == '2') && (tamanho < 27)));//validação do tamanho
                        
            if (op == '1')// possibilita a utilização de herança 
            {
                 tabelaHash = new HashLE(tamanho);
            }
            else
            {
                 tabelaHash = new HashEA(tamanho);
            }

            buscarDados(tabelaHash);//busca os dados do arquivo de texto

            Console.WriteLine("Tabela criada e chaves inseridas com sucesso!");          
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadKey();                       

            op = 'S';
            while(op == 'S')
            {
                Console.Clear();

                Console.WriteLine("\n\t***BUSCA DE ESTADOS NA TABELA HASH***");//tela para pesquisa de chaves
                
                Console.WriteLine("Digite o nome do estado sem acentos ou caracteres especiais:");
                nomeEstado = (Console.ReadLine().ToUpper());
                                
                tabelaHash.procuraEstado(nomeEstado);
                //método que faz a pesquisa, utilizando o nome do estado fornecido pelo usuário

                do
                {
                    Console.WriteLine("Pesquisar outro Estado?  [N]-não  [S]-sim");
                    op = char.Parse(Console.ReadLine().ToUpper());

                    Console.Clear();
                    if ((op != 'N') && (op != 'S'))
                    {
                        Console.WriteLine("Opção inválida! Tente novamente.");
                    }
                } while ((op != 'N') && (op != 'S'));//garante validação da opção
            }
            do
            {
                //permite que o usuário visualize todo o conteúdo da tabela hash, 
                //independente do tipo de tratamento de colisões

                Console.WriteLine("Deseja visualizar a tabela?  [N]-não  [S]-sim");
                op = char.Parse(Console.ReadLine().ToUpper());
                if ((op != 'N') && (op != 'S'))
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
            } while ((op != 'N') && (op != 'S'));//garante validação da opção

            if(op == 'S')
            {
                tabelaHash.imprimir();
            }
            Console.ReadKey();
        }

        public static void buscarDados(Hash tabela)
        {
            string[] v;
            string linha;

            FileStream file = new FileStream("estados.txt", FileMode.Open);//objeto representa o arquivo
            StreamReader sr = new StreamReader(file);//objeto faz a leitura no arquivo especificado

            do//estrutura que garante a leitura do arquivo linha a linha
            {
                linha = sr.ReadLine();
                if (linha != null)
                {
                    v = linha.Split('|');

                    //os dados de uma linha completa no arquivo se tornam uma nova instância de Estado
                    //que já é inserida na tabela 
                    tabela.InsereNaTabela(new Estado(v[0], v[1], v[2], int.Parse(v[3])));
                }
            } while (linha != null);

            sr.Close();
        }

        ////método utilizado para escrever os dados no arquivo de texto, não é mais utilizado na execução        
        //public static void levarDados()
        //{
        //    FileStream arq = new FileStream("estados.txt", FileMode.OpenOrCreate);
        //    StreamWriter sw = new StreamWriter(arq);

        //    //string nome;//campo chave
        //    //string capital;
        //    //string regiao;
        //    //int quantMunicipios;

        //    sw.WriteLine("ACRE|RIO BRANCO|NORTE|22");
        //    sw.WriteLine("ALAGOAS|MACEIO|NORDESTE|102");
        //    sw.WriteLine("AMAPA|MACAPA|NORTE|16");
        //    sw.WriteLine("AMAZONAS|MANAUS|NORTE|62");
        //    sw.WriteLine("BAHIA|SALVADOR|NORDESTE|417");
        //    sw.WriteLine("CEARA|FORTALEZA|NORDESTE|184");
        //    sw.WriteLine("DISTRITO FEDERAL|BRASILIA|CENTRO-OESTE|1");
        //    sw.WriteLine("ESPIRITO SANTO|VITORIA|SUDESTE|78");
        //    sw.WriteLine("GOIAS|GOIANIA|CENTRO-OESTE|246");
        //    sw.WriteLine("MARANHAO|SAO LUIS|NORDESTE|217");
        //    sw.WriteLine("MATO GROSSO|CUIABA|CENTRO-OESTE|141");
        //    sw.WriteLine("MATO GROSSO DO SUL|CAMPO GRANDE|CENTRO-OESTE|79");
        //    sw.WriteLine("MINAS GERAIS|BELO HORIZONTE|SUDESTE|853");
        //    sw.WriteLine("PARA|BELEM|NORTE|144");
        //    sw.WriteLine("PARAIBA|JOAO PESSOA|NORDESTE|223");
        //    sw.WriteLine("PARANA|CURITIBA|SUL|399");
        //    sw.WriteLine("PERNAMBUCO|RECIFE|NORDESTE|185");
        //    sw.WriteLine("PIAUI|TERESINA|NORDESTE|224");
        //    sw.WriteLine("RIO DE JANEIRO|RIO DE JANEIRO|SUDESTE|92");
        //    sw.WriteLine("RIO GRANDE DO NORTE|NATAL|NORDESTE|167");
        //    sw.WriteLine("RIO GRANDE DO SUL|PORTO ALEGRE|SUL|496");
        //    sw.WriteLine("RONDONIA|PORTO VELHO|NORTE|52");
        //    sw.WriteLine("RORAIMA|BOA VISTA|NORTE|15");
        //    sw.WriteLine("SANTA CATARINA|FLORIANOPOLIS|SUL|293");
        //    sw.WriteLine("SAO PAULO|SAO PAULO|SUDESTE|645");
        //    sw.WriteLine("SERGIPE|ARACAJU|NORDESTE|75");
        //    sw.WriteLine("TOCANTINS|PALMAS|NORTE|139");
        //    //Fontes: Wikipédia, Associação Mineira de Municípios e Governo de Minas Gerais(2012)
        //    sw.Close();
        //}

    }
}
