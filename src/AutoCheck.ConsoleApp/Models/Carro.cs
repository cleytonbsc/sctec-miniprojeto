namespace AutoCheck.ConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public int NumeroPortas { get; set; }

        public Carro(String Marca, String Modelo, int Ano, decimal Quilometragem, List<ItemVistoria> ItensVistoria, bool VistoriaRealizada, int NumeroPortas)
            : base(Marca, Modelo, Ano, Quilometragem, ItensVistoria, VistoriaRealizada)
        {
            this.NumeroPortas = NumeroPortas;
        } 

        public override List<String> ObterCheckListObrigatorio()
        {
            List<String> checkList = base.ObterCheckListObrigatorio();
            checkList.Add("Estepe");
            checkList.Add("Macaco");
            checkList.Add("Triangulo de Sinalização");
            checkList.Add("Ar Condicionado Funciona");
            return checkList;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Cadastro de carro:");
            base.Cadastrar();
            Console.WriteLine("Digite o número de portas do carro:");
            this.NumeroPortas = int.Parse(Console.ReadLine());
        }

        public override void Imprimir()
        {
            Console.WriteLine("Tipo: Carro");
            base.Imprimir();
            Console.WriteLine($"Atributo Específico: {this.NumeroPortas} Portas");
        }
    }
}