using Mercadinho_do_Zé.Model;

namespace Mercadinho_do_Zé.Control
{
    public class ProdutoController
    {
        private ProdutoDAO Dao;

        public ProdutoController()
        {
            Dao = new ProdutoDAO();
        }

        public void Gravar(Produto produto)
        {
            if (produto.EhValido())
            {
                Dao.Gravar(produto);
            }
            else
            {
                Console.WriteLine("Dados inválido!");
            }
        }

        public List<Produto> Listar()
        {
            return Dao.Listar();
        }

        public void Excluir(int codigo)
        {
            Dao.Excluir(codigo);
        }
    }
}