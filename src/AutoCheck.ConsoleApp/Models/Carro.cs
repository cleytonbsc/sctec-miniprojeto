namespace AutoCheck.ConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public int NumeroPortas { get; set; }

        public Carro(string marca, string modelo, int ano, decimal quilometragem, List<ItemVistoria> vistoriaRealizada, int numeroPortas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.NumeroPortas = numeroPortas;
            TipoVeiculo = "Carro";
        } 

        public override List<string> ObterCheckListObrigatorio()
        {
            List<string> checkList = base.ObterCheckListObrigatorio();
            checkList.Add("Estepe e Macaco");
            checkList.Add("Triangulo de Sinalização");
            checkList.Add("Ar Condicionado Funciona");
            return checkList;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("\nCadastro de carro:");
            base.Cadastrar();
            Console.WriteLine("Digite o número de portas do carro:");
            this.NumeroPortas = int.Parse(Console.ReadLine());
        }

        public override void Imprimir(string tipoVeiculo)
        {
            base.Imprimir(tipoVeiculo);
            Console.WriteLine($"\n- Atributo Específico: {this.NumeroPortas} Portas");
        }

        public override string ItemRecomendar(ItemVistoria item)
        {
            string ItemRecomendacao = base.ItemRecomendar(item);
            if(item.Status == "Ruim")
            {
                if(item.Nome == "Estepe e Macaco")
                {
                     ItemRecomendacao = "Realizar a troca do estepe ou reposição do macaco, caso estejam ausentes ou danificados.";
                }
                else if(item.Nome == "Triangulo de Sinalização")
                {
                    ItemRecomendacao = "Repor equipamento obrigatório ausente/danificado.";
                }
                else if(item.Nome == "Ar Condicionado Funciona")
                {
                    ItemRecomendacao = "Recomendamos a manutenção do sistema de ar condicionado para garantir o conforto e o funcionamento adequado do veículo.";
                }
            }
            else if(item.Status == "Regular")
            {
                if(item.Nome == "Estepe e Macaco")
                {
                     ItemRecomendacao = "Calibrar pneu reserva e verificar funcionamento do macaco.";
                }
                else if(item.Nome == "Triangulo de Sinalização")
                {
                    ItemRecomendacao = "Verificar o triangulo de sinalização para garantir que esteja em boas condições.";
                }
                else if(item.Nome == "Ar Condicionado Funciona")
                {
                    ItemRecomendacao = "Realizar higienização e checagem do gás refrigerante.";
                }
            }
            return ItemRecomendacao;
        }
    }
}