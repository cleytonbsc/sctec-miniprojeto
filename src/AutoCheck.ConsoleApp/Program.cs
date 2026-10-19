
using AutoCheck.ConsoleApp;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

Vistoria motorVistoria = new Vistoria();

int opcao;
do
{
    Console.WriteLine("\nEscolha uma opção: ");
    Console.WriteLine("1 - Realizar Nova Vistoria");
    Console.WriteLine("2 - Exibir Relatório das Vistorias");
    Console.WriteLine("3 - Sair");
    opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        Console.WriteLine("\nEscolha o tipo de veículo para vistoria: ");
        Console.WriteLine("1 - Carro");
        Console.WriteLine("2 - Moto");
        Console.WriteLine("3 - Caminhão");
        int tipoVeiculo = int.Parse(Console.ReadLine());
        switch (tipoVeiculo)
        {
            case 1:
                motorVistoria.VistoriaCarro();
                break;
            case 2:
                motorVistoria.VistoriaMoto();
                break;
            case 3:
                motorVistoria.VistoriaCaminhao();
                break;
            default:
                Console.WriteLine("Tipo de veículo inválido. Tente novamente.");
                break;
        }
    }
    else if (opcao == 2)
    {
        motorVistoria.ImprimirVistoria();
    }

    else if (opcao == 3)
    {
        Console.WriteLine("Saindo do programa...");
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }

} while (opcao != 3);