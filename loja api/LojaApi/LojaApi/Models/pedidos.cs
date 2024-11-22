namespace LojaApi.Models
{
    public class pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
        public string StatusPedido { get; set; } = "Em andamento";
        public decimal ValorTotal { get; set; }
    }
}