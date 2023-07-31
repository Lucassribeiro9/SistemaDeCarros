namespace CarrosMvc.Models
{
    public class CarroDiesel : Carro
    {
        public double CapacidadeCarga { get; set; }
        public double VolumeCacamba { get; set; }

        public override decimal CalcularImposto()
        {
            return CustoProducao * 0.3m; // Imposto de produção de 30% para carros diesel (20% + 10%)
        }
    }
}
