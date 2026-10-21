namespace AutoCheck.ConsoleApp.Models
{
    public class Moto : Veiculo
    {
        public int Cilindradas { get; set; }

        public Moto(string marca, string modelo, int ano, decimal quilometragem, List<ItemVistoria> vistoriaRealizada, int cilindradas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.Cilindradas = cilindradas;
            TipoVeiculo = "Moto";
        } 

        public override List<string> ObterCheckListObrigatorio()
        {
            List<string> checkList = base.ObterCheckListObrigatorio();
            checkList.Add("Kit Transmissão/Corrente");
            checkList.Add("Manetes de Freio/Embreagem");
            checkList.Add("Pezinho Lateral");
            return checkList;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("\nCadastro de moto:");
            base.Cadastrar();
            Console.WriteLine("Digite o número de cilindradas da moto:");
            this.Cilindradas = int.Parse(Console.ReadLine());
        }

        public override void Imprimir(string tipoVeiculo)
        {
            base.Imprimir(tipoVeiculo);
            Console.WriteLine($"\n- Atributo Específico: {this.Cilindradas} Cilindradas");
        }

        public override string ItemRecomendar(ItemVistoria item)
        {
            string ItemRecomendacao = base.ItemRecomendar(item);
            if(item.Status == "Ruim")
            {
                if(item.Nome == "Kit Transmissão/Corrente")
                {
                     ItemRecomendacao = "Recomendamos a manutenção do sistema de transmissão e corrente para garantir o funcionamento adequado da moto.";
                }
                else if(item.Nome == "Manetes de Freio/Embreagem")
                {
                    ItemRecomendacao = "Recomendamos a substituição dos manetes de freio/embreagem para garantir a segurança e o controle adequado da moto.";
                }
                else if(item.Nome == "Pezinho Lateral")
                {
                    ItemRecomendacao = "Recomendamos a manutenção do pezinho lateral para garantir a estabilidade e o suporte adequado da moto.";
                }
            }
            else if(item.Status == "Regular")
            {
                if(item.Nome == "Kit Transmissão/Corrente")
                {
                     ItemRecomendacao = "Verificar a tensão da corrente e lubrificar o kit de transmissão.";
                }
                else if(item.Nome == "Manetes de Freio/Embreagem")
                {
                    ItemRecomendacao = "Verificar o funcionamento dos manetes de freio/embreagem para garantir a segurança e o controle adequado da moto.";
                }
                else if(item.Nome == "Pezinho Lateral")
                {
                    ItemRecomendacao = "Verificar o funcionamento do pezinho lateral para garantir a estabilidade e o suporte adequado da moto.";
                }
            }
            return ItemRecomendacao;
        }
    }
}