namespace AutoCheck.ConsoleApp.Models
{
    public abstract class Veiculo
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public int Ano { get; set; }
        public double Quilometragem { get; set; }

        public List<ItemVistoria> ItensVistoria = new List<ItemVistoria>();

        public bool VistoriaRealizada { get; set; }

        public Veiculo(String Marca, String Modelo, int Ano, double Quilometragem, List<ItemVistoria> ItensVistoria, bool VistoriaRealizada)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Ano = Ano;
            this.Quilometragem = Quilometragem;
            this.ItensVistoria = ItensVistoria;
            this.VistoriaRealizada = VistoriaRealizada; 
        }

        public void AdicionarItemVistoria(String nome, String status)
        {
            ItemVistoria item = new ItemVistoria();
            item.Nome = nome;
            item.SetStatus(status);
            ItensVistoria.Add(item);
        }

        public virtual List<String> ObterCheckListObrigatorio()
        {
            return new List<String>
            {
                "Nível de Óleo do Moto",
                "Bateria e Sistema Elétrico",
                "Documentação Regularizada"
            };
        }

        public virtual void Cadastrar()
        {
            Console.WriteLine("Digite a marca do veículo:");
            this.Marca = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo:");
            this.Modelo = Console.ReadLine();
            Console.WriteLine("Digite o ano do veículo:");
            this.Ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quilometragem do veículo:");
            this.Quilometragem = double.Parse(Console.ReadLine());
        }

        public virtual void Imprimir()
        {
            Console.WriteLine("\n> DADOS DO VEÍCULO:");
            Console.WriteLine($"Marca: {this.Marca}");
            Console.WriteLine($"Modelo: {this.Modelo}");
            Console.WriteLine($"Ano: {this.Ano}");
            Console.WriteLine($"Quilometragem: {this.Quilometragem}");
            Console.WriteLine($"Vistoria Realizada: {this.VistoriaRealizada}");
        }
    }
}