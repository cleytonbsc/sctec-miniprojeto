
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
            if(veiculosVistoriado.Count == 0)
            {
                Console.WriteLine("Nenhuma vistoria realizada até o momemento.");
                return;
            }

            for(int i = 0; i < veiculosVistoriado.Count; i++)
            {
                veiculosVistoriado[i].Imprimir();
                Console.WriteLine($"\n > AVALIAÇÃO DOS ITENS DE VISTORIA:");
                foreach(ItemVistoria item in veiculosVistoriado[i].ItensVistoria)
                {

                    Console.WriteLine($"Item: {item.Nome}, Status: {item.Status}");
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
                Console.WriteLine($"> RESUMO DA PONTUAÇÃO: Pontuação Atingida: {pontuacao} de {pontuacaoMaxima} \n Percentual de Aprovação: ({percentual:F2}%) \n Classificação Final: {statusVistoria}");

                Console.WriteLine($"\n> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
                if(itensVistoriaRuim.Count > 0 || itensVistoriaRegular.Count > 0)
                {
                    if (itensVistoriaRuim.Count > 0)
                    {
                        Console.WriteLine($" ITENS CRÍTICOS / REPROVADOS (AÇÃO IMDEDIATA):");
                        foreach(ItemVistoria item in itensVistoriaRuim)
                        {
                            Console.WriteLine($"Item: {item.Nome}");
                        }
                    }
                    if(itensVistoriaRegular.Count > 0)
                    {
                        Console.WriteLine($" ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):");
                        foreach(ItemVistoria item in itensVistoriaRegular)
                        {
                            Console.WriteLine($"Item: {item.Nome}");
                        }
                    }
                } else
                    {
                        Console.WriteLine("Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
                    }
        }
    }
}