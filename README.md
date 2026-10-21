# AutoCheck.ConsoleApp

Sistema de vistoria veicular desenvolvido em C# para o projeto SCTec/SENAI do curso de Desenvolvedor Back-End .NET.

## O que o sistema faz

O AutoCheck permite cadastrar e avaliar **carros, motos e caminhões** por meio de um checklist específico para cada tipo de veículo. Para cada item, o usuário informa um dos status abaixo:

- **Bom**: item em condições adequadas;
- **Regular**: item que precisa de revisão preventiva;
- **Ruim**: item que exige reparo ou troca.

Ao final, o sistema guarda a vistoria em memória e pode exibir um relatório com os dados do veículo, a pontuação, o percentual de aprovação, a classificação e as recomendações da oficina para os itens pendentes.

## Requisitos

- Windows, Linux ou macOS;
- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) ou compatível com o `TargetFramework` definido no projeto;
- Terminal (PowerShell, Prompt de Comando ou equivalente).

## Como executar

1. Abra um terminal:

   - No Windows, abra o **PowerShell** ou o **Prompt de Comando** pelo menu Iniciar;
   - No VS Code, abra o projeto e selecione **Terminal > Novo Terminal**.

2. Clone o repositório e entre na pasta do projeto:

   ```powershell
   git clone https://github.com/cleytonbsc/sctec-miniprojeto.git
   cd sctec-miniprojeto
   ```

3. Restaure as dependências:

   ```powershell
   dotnet restore .\src\AutoCheck.ConsoleApp\AutoCheck.ConsoleApp.csproj
   ```

4. Execute a aplicação:

   ```powershell
   dotnet run --project .\src\AutoCheck.ConsoleApp\AutoCheck.ConsoleApp.csproj
   ```

5. Use o menu apresentado no terminal:

   - `1 - Realizar Nova Vistoria`: escolha o tipo de veículo, informe seus dados e responda ao checklist;
   - `2 - Exibir Relatório das Vistorias`: exiba as vistorias realizadas durante a execução atual;
   - `3 - Sair`: encerre o programa.

Os dados ficam somente em memória. Portanto, ao encerrar a aplicação, as vistorias cadastradas são perdidas.

## Regra de cálculo da vistoria

Cada item recebe uma pontuação conforme o status informado:

| Status | Pontos |
| --- | ---: |
| Bom | 10 |
| Regular | 5 |
| Ruim | 0 |

O percentual é calculado dividindo a pontuação obtida pela pontuação máxima possível e multiplicando o resultado por 100:

```text
percentual = (pontuação obtida / (quantidade de itens × 10)) × 100
```

Essa regra foi escolhida porque transforma todos os checklists em uma escala comum, mesmo que os veículos tenham itens específicos diferentes. Assim, o resultado é simples de interpretar e permite comparar o estado geral dos veículos.

A classificação adotada é:

- **90% a 100%**: Aprovado com Excelência;
- **60% a 89%**: Aprovado com Apontamentos;
- **0% a 59%**: Reprovado na Vistoria.

Além da classificação, os itens `Ruim` são exibidos como críticos e os itens `Regular` como itens de atenção.

## Critério de priorização das recomendações

As recomendações de manutenção são priorizadas pelo risco:

1. Itens com status **Ruim** aparecem primeiro, pois exigem ação imediata, troca ou reparo;
2. Itens com status **Regular** aparecem depois, pois indicam revisão preventiva;
3. Itens com status **Bom** não geram recomendação.

A recomendação também considera o tipo do veículo. Por exemplo, um problema no sistema de freios a ar gera uma orientação específica para caminhões, enquanto um problema no kit de transmissão gera uma orientação específica para motos. Essa lógica está nos métodos `ItemRecomendar` das classes de veículo.

Como este projeto é um sistema de vistoria, ele não recomenda habilidades ou uma trilha de estudos. O critério equivalente é a priorização dos serviços da oficina conforme a gravidade dos itens encontrados.

## Conceitos do Módulo 01 aplicados

Os principais conceitos aparecem nestes pontos do projeto:

- **Console Application e entrada/saída**: o menu, os cadastros e os relatórios usam `Console.ReadLine` e `Console.WriteLine` em [`Program.cs`](src/AutoCheck.ConsoleApp/Program.cs);
- **Tipos primitivos e conversões**: `string`, `int`, `decimal`, `double` e `bool` são usados nos dados dos veículos e na validação dos status;
- **Classes, objetos e construtores**: [`Veiculo.cs`](src/AutoCheck.ConsoleApp/Models/Veiculo.cs), [`Carro.cs`](src/AutoCheck.ConsoleApp/Models/Carro.cs), [`Moto.cs`](src/AutoCheck.ConsoleApp/Models/Moto.cs) e [`Caminhao.cs`](src/AutoCheck.ConsoleApp/Models/Caminhao.cs);
- **Encapsulamento**: propriedades e métodos controlam o cadastro dos dados e a inclusão dos itens de vistoria;
- **Herança**: `Carro`, `Moto` e `Caminhao` herdam de `Veiculo`;
- **Polimorfismo**: cada subclasse sobrescreve `ObterCheckListObrigatorio`, `Cadastrar`, `Imprimir` e `ItemRecomendar`;
- **Listas**: `List<Veiculo>` armazena as vistorias e `List<ItemVistoria>` armazena os itens avaliados;
- **Laços e condicionais**: `do/while`, `for`, `foreach`, `switch` e `if/else` controlam o menu, percorrem os checklists e calculam a pontuação;
- **Validação**: [`ItemVistoria.cs`](src/AutoCheck.ConsoleApp/Models/ItemVistoria.cs) aceita somente `Bom`, `Regular` ou `Ruim`.

O processamento central da pontuação, da classificação e do relatório está em [`MotorVistoria.cs`](src/AutoCheck.ConsoleApp/Services/MotorVistoria.cs).

## Arquitetura cliente-servidor no projeto

Em uma arquitetura cliente-servidor, o **cliente** é a aplicação que apresenta a interface e envia solicitações, enquanto o **servidor** recebe essas solicitações, executa as regras de negócio e devolve os resultados. Em um sistema web, por exemplo, um navegador seria o cliente e uma API seria o servidor.

Este projeto é uma aplicação de console monolítica e local, portanto **não implementa uma arquitetura cliente-servidor completa**. O terminal atua como camada de interação do cliente e as classes de `Models` e `Services` executam as regras de negócio no mesmo processo. Não há API, comunicação pela rede, banco de dados ou persistência externa. A separação entre `Program`, modelos e serviço demonstra a divisão de responsabilidades e pode servir de base para uma futura API cliente-servidor.

## Estrutura do projeto

```text
sctec-miniprojeto/
├── src/
│   └── AutoCheck.ConsoleApp/
│       ├── Models/
│       │   ├── ItemVistoria.cs
│       │   ├── Veiculo.cs
│       │   ├── Carro.cs
│       │   ├── Moto.cs
│       │   └── Caminhao.cs
│       ├── Services/
│       │   └── MotorVistoria.cs
│       ├── Program.cs
│       └── AutoCheck.ConsoleApp.csproj
└── README.md
```

## Vídeo de apresentação

**Link:** https://drive.google.com/file/d/19-pABAdpPxH6mo6w1mrUCvEcC32aYD-w/view?usp=sharing
