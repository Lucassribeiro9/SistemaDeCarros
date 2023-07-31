namespace CarrosMvc.Models
{
    public class CarroEletrico : Carro
    {
        public double Potencia { get; set; }
        public double DuracaoBateria { get; set; }

        public override decimal CalcularImposto()
        {
            return CustoProducao * 0.1m; // Imposto de produção de 10% para carros elétricos (20% - 10%)
        }
    }
}
