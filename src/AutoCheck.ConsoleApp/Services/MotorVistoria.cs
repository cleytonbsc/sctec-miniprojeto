
using AutoCheck.ConsoleApp;
using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services
{

    public class Vistoria()
    {
        public List<Veiculo> VeiculosVistoriado = new List<Veiculo>();
        public void VistoriaCarro()
        {      
            Carro carro = new Carro("", "", 0, 0, new List<ItemVistoria>(), 0);
            carro.Cadastrar();

            Console.WriteLine("\nChecklist Obrigatório:");

            foreach (string item in carro.ObterCheckListObrigatorio())
            {
                Console.WriteLine($"Qual o status do item {item}? (Bom, Regular, Ruim)");
                string status = Console.ReadLine();
                carro.AdicionarItemVistoria(item, status);
            }

            VeiculosVistoriado.Add(carro);
        }

        public void VistoriaMoto()
        {      
            Moto moto = new Moto("", "", 0, 0, new List<ItemVistoria>(), 0);
            moto.Cadastrar();

            Console.WriteLine("\nChecklist Obrigatório:");

            foreach (string item in moto.ObterCheckListObrigatorio())
            {
                Console.WriteLine($"Qual o status do item {item}? (Bom, Regular, Ruim)");
                string status = Console.ReadLine();
                moto.AdicionarItemVistoria(item, status);
            }

            VeiculosVistoriado.Add(moto);
        }

        public void VistoriaCaminhao()
        {      
            Caminhao caminhao = new Caminhao("", "", 0, 0, new List<ItemVistoria>(), 0, 0);
            caminhao.Cadastrar();

            Console.WriteLine("\nChecklist Obrigatório:");

            foreach (string item in caminhao.ObterCheckListObrigatorio())
            {
                Console.WriteLine($"Qual o status do item {item}? (Bom, Regular, Ruim)");
                string status = Console.ReadLine();
                caminhao.AdicionarItemVistoria(item, status);
            }

            VeiculosVistoriado.Add(caminhao);

        }


        public void ImprimirVistoria()
        {
            int TotalVeiculos = VeiculosVistoriado.Count;
            if(TotalVeiculos == 0)
            {
                Console.WriteLine("Nenhuma vistoria realizada até o momemento.");
                return;
            }

            Console.WriteLine("===================================================================");
            Console.WriteLine("             AUTOCHECK .NET - MOTOR DE VISTORIA");
            Console.WriteLine("===================================================================");
            
            for(int i = 0; i < TotalVeiculos; i++)
            {

                Console.WriteLine($"\n[{i+1}/{TotalVeiculos}] PROCESSANDO VISTORIA");
                Console.WriteLine("--------------------------------------------------\n");
                VeiculosVistoriado[i].Imprimir(VeiculosVistoriado[i].TipoVeiculo);
                Console.WriteLine($"\n> AVALIAÇÃO DOS ITENS DE VISTORIA: ({VeiculosVistoriado[i].VistoriaRealizada.Count} ITENS)\n");
                foreach(ItemVistoria item in VeiculosVistoriado[i].VistoriaRealizada)
                {
                    if(item.Status == "Bom")
                    {
                        Console.WriteLine($"[OK] {item.Nome}  ---------- Status: {item.Status} (10 pts)");
                    }
                    else if(item.Status == "Regular")
                    {
                        Console.WriteLine($"[!] {item.Nome}  ---------- Status: {item.Status} (5 pts)");
                    }
                    else if(item.Status == "Ruim")
                    {
                        Console.WriteLine($"[X] {item.Nome}  ---------- Status: {item.Status} (0 pts)");
                    }
                    
                }
                PontuacaoVistoria(VeiculosVistoriado[i]);
            }
            Console.WriteLine("\n===================================================================");
            Console.WriteLine("            FIM DO PROCESSAMENTO DE VISTORIAS     ");
            Console.WriteLine("===================================================================");
        }

        public void PontuacaoVistoria(Veiculo veiculo)
        {
                decimal Pontuacao = 0;
                decimal PontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;
                List<ItemVistoria> ItensVistoriaRuim = new List<ItemVistoria>();
                List<ItemVistoria> ItensVistoriaRegular = new List<ItemVistoria>();
                foreach(ItemVistoria item in veiculo.VistoriaRealizada)
                {
                    if(item.Status == "Bom")
                    {
                        Pontuacao += 10;
                    }
                    else if(item.Status == "Regular")
                    {
                        Pontuacao += 5;
                        ItensVistoriaRegular.Add(item);
                    }
                    else if(item.Status == "Ruim")
                    {
                        Pontuacao += 0;
                        ItensVistoriaRuim.Add(item);
                    }
                }
                decimal Percentual = Pontuacao / PontuacaoMaxima * 100;
                string StatusVistoria;
                if(Percentual >= 90)
                {
                    StatusVistoria = "[ APROVADO COM EXCELÊNCIA ]";
                }
                else if(Percentual >= 60)
                {
                    StatusVistoria = "[ APROVADO COM APONTAMENTOS ]";
                }
                else
                {
                    StatusVistoria = "[ REPROVADO NA VISTORIA ]";
                }
                Console.WriteLine($"\n> RESUMO DA PONTUAÇÃO:\n\n - Pontuação Atingida: {Pontuacao} de {PontuacaoMaxima} \n - Percentual de Aprovação: ({Percentual:F2}%) \n - Classificação Final: {StatusVistoria}\n");

                Console.WriteLine($"\n> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
                if(ItensVistoriaRuim.Count > 0 || ItensVistoriaRegular.Count > 0)
                {
                    if (ItensVistoriaRuim.Count > 0)
                    {
                        Console.WriteLine($"\n🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMDEDIATA):\n");
                        foreach(ItemVistoria item in ItensVistoriaRuim)
                        {
                            Console.WriteLine($"- {item.Nome}: {veiculo.ItemRecomendar(item)}");
                        }
                    }
                    if(ItensVistoriaRegular.Count > 0)
                    {
                        Console.WriteLine($"\n🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):\n");
                        foreach(ItemVistoria item in ItensVistoriaRegular)
                        {
                            Console.WriteLine($"- {item.Nome}: {veiculo.ItemRecomendar(item)}");
                        }
                    }
                } else
                    {
                        Console.WriteLine("\n🟢 Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
                    }
        }
    }
}