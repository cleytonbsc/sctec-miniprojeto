namespace AutoCheck.ConsoleApp.Models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; set; }
        public double CapacidadeCargaToneladas { get; set; }

        public Caminhao(string marca, string modelo, int ano, decimal quilometragem, List<ItemVistoria> vistoriaRealizada, int quantidadeEixos, double capacidadeCargaToneladas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.QuantidadeEixos = quantidadeEixos;
            this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
            TipoVeiculo = "Caminhao";
        } 

        public override List<string> ObterCheckListObrigatorio()
        {
            List<string> checkList = base.ObterCheckListObrigatorio();
            checkList.Add("Tacógrafo");
            checkList.Add("Sistema de Freios a Ar");
            checkList.Add("Trava e Lona da Caçamba");
            return checkList;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("\nCadastro de caminhão:");
            base.Cadastrar();
            Console.WriteLine("Digite o número de eixos do caminhão:");
            this.QuantidadeEixos = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a capacidade de carga do caminhão (em toneladas):");
            this.CapacidadeCargaToneladas = double.Parse(Console.ReadLine());
        }

        public override void Imprimir(string TipoVeiculo)
        {
            base.Imprimir(TipoVeiculo);
            Console.WriteLine($"\n- Atributo Específico: {this.QuantidadeEixos} Eixos | {this.CapacidadeCargaToneladas} Toneladas");
        }

        public override string ItemRecomendar(ItemVistoria item)
        {
            string ItemRecomendacao = base.ItemRecomendar(item);
            if(item.Status == "Ruim")
            {
                if(item.Nome == "Tacógrafo")
                {
                     ItemRecomendacao = "Recomendamos a manutenção do tacógrafo para garantir o funcionamento adequado do caminhão.";
                }
                else if(item.Nome == "Sistema de Freios a Ar")
                {
                    ItemRecomendacao = "Recomendamos a substituição do sistema de freios a ar para garantir a segurança e o controle adequado do caminhão.";
                }
                else if(item.Nome == "Trava e Lona da Caçamba")
                {
                    ItemRecomendacao = "Recomendamos a manutenção da trava e lona da caçamba para garantir a segurança e o funcionamento adequado do caminhão.";
                }
            }
            else if(item.Status == "Regular")
            {
                if(item.Nome == "Tacógrafo")
                {
                     ItemRecomendacao = "Verificar o funcionamento do tacógrafo para garantir o funcionamento adequado do caminhão.";
                }
                else if(item.Nome == "Sistema de Freios a Ar")
                {
                    ItemRecomendacao = "Verificar o funcionamento do sistema de freios a ar para garantir a segurança e o controle adequado do caminhão.";
                }
                else if(item.Nome == "Trava e Lona da Caçamba")
                {
                    ItemRecomendacao = "Verificar o funcionamento da trava e lona da caçamba para garantir a segurança e o funcionamento adequado do caminhão.";
                }
            }
            return ItemRecomendacao;
        }
    }
}