using Mercadinho_do_Zé.Control;
using Mercadinho_do_Zé.Model;

namespace Mercadinho_do_Zé.View
{
    public class ProdutoView
    {
        private ProdutoController controller;

        public ProdutoView()
        {
            controller = new ProdutoController();
        }

        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                    ### PRODUTO ###
                    1- Cadastrar
                    2- Listar
                    3- Excluir
                    9- Voltar ao menu principal
                    Escolhe a opção desejada:
                ";
                Console.Write(menu);

                /*
                 * CRUD
                 *  C- Create Inserir
                 *  R- Read   Ler
                 *  U- Update Alterar
                 *  D- Delete Deletar
                 * */

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            Cadastrar();
                            break;
                        case 2:
                            Console.Clear();
                            Listar();
                            break;
                        case 3:
                            Console.Clear();
                            Excluir();
                            break;
                        case 9:
                            Console.Clear();
                            MenuView mV = new MenuView();
                            mV.CriarMenuPrincipal();
                            break;
                        default:
                            throw new Exception("Opção selecionada não existe");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida");
                }

            } while (opcao != 9);
        }

        private void Cadastrar()
        {
            Console.WriteLine("### CADASTRAR PRODUTO ###");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade:");
            double quantidade = double.Parse(Console.ReadLine());

            Produto p = new Produto();
            p.Descricao = descricao;
            p.Valor = valor;

            ProdutoController control = new ProdutoController();
            controller.Gravar(p);
        }

        private void Listar()
        {
            Console.WriteLine("### LISTA DE PRODUTOS ###");
            var lista = controller.Listar();
            int cont = 0;
            foreach (var p in lista)
            {
                Console.WriteLine(string.Format("{0} - {1} ({2})", cont++, p.Descricao, p.Valor.ToString("C2")));
            }
        }

        private void Excluir()
        {
            Listar();
            Console.WriteLine();
            Console.WriteLine("### EXCLUIR PRODUTO ###");
            Console.WriteLine("Digite o código a ser excluído:");
            int codigo = int.Parse(Console.ReadLine());

            controller.Excluir(codigo);
            Console.Clear();
        }
    }
}