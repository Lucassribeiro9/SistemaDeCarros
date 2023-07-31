namespace CarrosMvc.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string NumeroChassi { get; set; }
        public string NumeroMotor { get; set; }
        public decimal CustoProducao { get; set; }

        // Método virtual para calcular o imposto
        public virtual decimal CalcularImposto()
        {
            return CustoProducao * 0.2m; // Imposto de produção fixo em 20%
        }

        // Método para calcular o custo de venda
        public decimal CalcularCustoVenda()
        {
            decimal imposto = CalcularImposto();
            decimal lucro = CustoProducao * 0.25m; // Lucro da fábrica de 25%
            return CustoProducao + imposto + lucro;
        }
    }
}
