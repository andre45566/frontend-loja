namespace LojaApi.Models
{
    public class carrinho
    {
        public int Id { get; set; }
        public int produtosId { get; set; }
        public int UsuariosId { get; set; }
        public int Quantidade{ get; set; }
    }
}