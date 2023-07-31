namespace CarrosMvc.Models
{
    public class CarroFlex : Carro
    {
        public int NumeroPortas { get; set; }
        public double Cilindrada { get; set; }

        public override decimal CalcularImposto()
        {
            return CustoProducao * 0.2m; // Imposto de produção fixo em 20% para carros flex
        }
    }
}
