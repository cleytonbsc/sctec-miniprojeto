namespace AutoCheck.ConsoleApp.Models
{
    public abstract class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public decimal Quilometragem { get; set; }
        public List<ItemVistoria> VistoriaRealizada = new List<ItemVistoria>();
        public string TipoVeiculo { get; set; }
        public Veiculo(string marca, string modelo, int ano, decimal quilometragem, List<ItemVistoria> vistoriaRealizada)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = quilometragem;
            this.VistoriaRealizada = vistoriaRealizada;
            this.TipoVeiculo = "";

        }

        public void AdicionarItemVistoria(string nome, string status)
        {
            ItemVistoria item = new ItemVistoria();
            item.Nome = nome;
            item.SetStatus(status);
            VistoriaRealizada.Add(item);
        }

        public virtual List<string> ObterCheckListObrigatorio()
        {
            return new List<string>
            {
                "Nível de Óleo do Motor",
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
            this.Quilometragem = decimal.Parse(Console.ReadLine());
        }

        public virtual void Imprimir(string tipoVeiculo)
        {
            TipoVeiculo = tipoVeiculo;
            Console.WriteLine($"\n> DADOS DO VEÍCULO:");
            Console.WriteLine($"\n- Tipo: {TipoVeiculo}");
            Console.WriteLine($"\n- Marca/Modelo: {this.Marca} {this.Modelo}");
            Console.WriteLine($"\n- Ano: {this.Ano} | Quilometragem: {this.Quilometragem} km");
        }

    public virtual string ItemRecomendar(ItemVistoria item)
        {
            string ItemRecomendacao = "Nenhuma recomendação.";
            if(item.Status == "Ruim")
            {
                if(item.Nome == "Nível de Óleo do Motor")
                {
                     ItemRecomendacao = "Recomendamos a troca imediata do óleo do motor para evitar danos ao veículo.";
                }
                else if(item.Nome == "Bateria e Sistema Elétrico")
                {
                    ItemRecomendacao = "Recomendamos a substituição da bateria e verificação do sistema elétrico para garantir o funcionamento adequado do veículo.";
                }
                else if(item.Nome == "Documentação Regularizada")
                {
                    ItemRecomendacao = "Recomendamos regularizar a documentação do veículo para evitar problemas legais.";
                }
            }
            else if(item.Status == "Regular")
            {
                if(item.Nome == "Nível de Óleo do Motor")
                {
                     ItemRecomendacao = "Revisar o nível de óleo do motor para evitar danos ao veículo.";
                }
                else if(item.Nome == "Bateria e Sistema Elétrico")
                {
                    ItemRecomendacao = "Revisar a bateria e verificação do sistema elétrico para garantir o funcionamento adequado do veículo.";
                }
                else if(item.Nome == "Documentação Regularizada")
                {
                    ItemRecomendacao = "Revisar a documentação do veículo para garantir que esteja em dia.";
                }
            }
            return ItemRecomendacao;
        }
    }
}