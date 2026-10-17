
using AutoCheck.ConsoleApp;
using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services
{

    public class Vistoria()
    {
        public List<Veiculo> veiculosVistoriado = new List<Veiculo>();
        public void VistoriaCarro()
        {      
            Carro carro = new Carro("", "", 0, 0, new List<ItemVistoria>(), false, 0);
            carro.Cadastrar();

            Console.WriteLine("Checklist Obrigatório:");

            foreach (String item in carro.ObterCheckListObrigatorio())
            {
                Console.WriteLine($"Qual o status do item {item}? (Bom, Regular, Ruim)");
                string status = Console.ReadLine();
                carro.AdicionarItemVistoria(item, status);
            }

            carro.VistoriaRealizada = true;
            veiculosVistoriado.Add(carro);

            for(int i = 0; i < veiculosVistoriado.Count; i++)
            {
                veiculosVistoriado[i].Imprimir();
                Console.WriteLine($"\n > AVALIAÇÃO DOS ITENS DE VISTORIA:");
                foreach(ItemVistoria item in veiculosVistoriado[i].ItensVistoria)
                {

                    Console.WriteLine($"Item: {item.Nome}, Status: {item.Status}");
                }
            }
        }

        public void ImprimirVistoria()
        {
            int TotalVeiculos = veiculosVistoriado.Count;
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

                Console.WriteLine($"[{i+1}/{TotalVeiculos}] PROCESSANDO VISTORIA\n");
                veiculosVistoriado[i].Imprimir();
                Console.WriteLine($"\n> AVALIAÇÃO DOS ITENS DE VISTORIA: {TotalVeiculos}");
                foreach(ItemVistoria item in veiculosVistoriado[i].ItensVistoria)
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
                PontuacaoVistoria(veiculosVistoriado[i]);
            }
        }

        public void PontuacaoVistoria(Veiculo veiculo)
        {
                decimal pontuacao = 0;
                decimal pontuacaoMaxima = veiculo.ItensVistoria.Count * 10;
                List<ItemVistoria> itensVistoriaRuim = new List<ItemVistoria>();
                List<ItemVistoria> itensVistoriaRegular = new List<ItemVistoria>();
                foreach(ItemVistoria item in veiculo.ItensVistoria)
                {
                    if(item.Status == "Bom")
                    {
                        pontuacao += 10;
                    }
                    else if(item.Status == "Regular")
                    {
                        pontuacao += 5;
                        itensVistoriaRegular.Add(item);
                    }
                    else if(item.Status == "Ruim")
                    {
                        pontuacao += 0;
                        itensVistoriaRuim.Add(item);
                    }
                }
                decimal percentual = pontuacao / pontuacaoMaxima * 100;
                String statusVistoria = "";
                if(percentual >= 90)
                {
                    statusVistoria = "APROVADO COM EXCELÊNCIA";
                }
                else if(percentual >= 60)
                {
                    statusVistoria = "APROVADO COM APONTAMENTOS";
                }
                else
                {
                    statusVistoria = "REPROVADO NA VISTORIA";
                }
                Console.WriteLine($"\n> RESUMO DA PONTUAÇÃO:\n - Pontuação Atingida: {pontuacao} de {pontuacaoMaxima} \n - Percentual de Aprovação: ({percentual:F2}%) \n - Classificação Final: {statusVistoria}\n");

                Console.WriteLine($"\n> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
                if(itensVistoriaRuim.Count > 0 || itensVistoriaRegular.Count > 0)
                {
                    if (itensVistoriaRuim.Count > 0)
                    {
                        Console.WriteLine($"\n🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMDEDIATA):\n");
                        foreach(ItemVistoria item in itensVistoriaRuim)
                        {
                            Console.WriteLine($"- {item.Nome}");
                        }
                    }
                    if(itensVistoriaRegular.Count > 0)
                    {
                        Console.WriteLine($"\n🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):\n");
                        foreach(ItemVistoria item in itensVistoriaRegular)
                        {
                            Console.WriteLine($"- {item.Nome}");
                        }
                    }
                } else
                    {
                        Console.WriteLine("Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
                    }
        }
    }
}