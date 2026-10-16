# AutoCheck.ConsoleApp: Motor de Vistoria Veicular

Projeto criado para SCTec/SENAI do curso 
Desenvolvedor-BackEnd-NET.

Sistema para vistoria técnica para empresa de veículos

## Estrutura do projeto

<pre>
sctec-miniprojeto/
├── src/
│   └── AutoCheck.ConsoleApp/
│       ├── Program.cs
│       ├── Models/
│       │   ├── ItemVistoria.cs
│       │   ├── Veiculo.cs
│       │   ├── Carro.cs
│       │   ├── Moto.cs
│       │   └── Caminhao.cs
│       ├── Services/
│       │   └── MotorVistoria.cs
│       └── AutoCheck.ConsoleApp.csproj
├── README.md
</pre>

## Requisitos Funcionais (RFs)

### RF01 - Modelo do Item de Vistoria (ItemVistoria)

Criar uma classe ItemVistoria com as propriedades Nome (string) e Status (string), aceitando apenas os valores: "Bom", "Regular" ou "Ruim".

### RF02 - Classe Base Veiculo

Criar a classe abstrata/base Veiculo contendo:

* Propriedades: Marca, Modelo, Ano, Quilometragem e List<ItemVistoria> VistoriaRealizada;

* Construtor explícito utilizando a palavra-chave this para atribuição das propriedades;

* Método AdicionarItemVistoriado(string nome, string status);

* Método virtual List<string> ObterChecklistObrigatorio() que retorna itens genéricos de inspeção (ex: "Nível de Óleo do Motor", "Bateria e Sistema Elétrico", "Documentação Regularizada").

### RF03 - Herança e Checklists Específicos

Criar 3 subclasses que herdam (:) de Veiculo:

1. Carro: Adiciona a propriedade QuantidadePortas (int) e sobrescreve (override) o método ObterChecklistObrigatorio()adicionando itens de carros (ex: "Estepe e Macaco", "Triângulo de Sinalização", "Ar Condicionado Funcional").

2. Moto: Adiciona a propriedade Cilindradas (int) e sobrescreve ObterChecklistObrigatorio() com itens de moto (ex: "Kit Transmissão/Corrente", "Manetes de Freio/Embreagem", "Pezinho Lateral").

3. Caminhao: Adiciona as propriedades QuantidadeEixos (int) e CapacidadeCargaToneladas (double), sobrescrevendo ObterChecklistObrigatorio() com itens pesados (ex: "Tacógrafo", "Sistema de Freios a Ar", "Trava e Lona da Caçamba").

### RF04 - Tabela de Pontuação por Item

No processamento da vistoria, o sistema deve converter o status do item na seguinte pontuação:

* Status "Bom": 10 pontos
* Status "Regular": 5 pontos
* Status "Ruim": 0 pontos

### RF05 - Cálculo do Percentual de Aprovação

O sistema deve somar a pontuação atingida e comparar com a pontuação máxima possível (Total de Itens×10), utilizando a fórmula:

Percentual (%)=( PontuaçãoObtida / PontuaçãoMaximaPossivel)×100
💡 Atenção: 

* Certifique-se de realizar o cast (double) na divisão de inteiros em C# para evitar que o valor seja truncado para zero.

### RF06 - Classificação do Estado do Veículo

O sistema deve classificar o resultado usando estruturas de decisão (if/else ou switch):
Percentual Calculado
Classificação Final
Ação Corporativa
90% a 100%
Aprovado com Excelência
Liberado para compra/revenda imediata.
60% a 89%
Aprovado com Apontamentos
Exige desconto na compra para reparos da oficina.
0% a 59%
Reprovado na Vistoria
Veículo recusado pela concessionária.


### RF07 - Relatório de Pendências e Apontamentos

O sistema deve listar separadamente no terminal:
    
* 🔴 Itens Críticos / Reprovados (Status "Ruim"): Exigem troca/reparo obrigatório.

* 🟡 Itens de Atenção (Status "Regular"): Exigem revisão preventiva.

### RF08 - Recomendação de Serviços da Oficina

Com base nos itens ruins e regulares, o programa deve emitir uma orientação em texto informando os serviços prioritários que a equipe mecânica deverá executar.

### RF09 - Varredura de Listas com Laços Tradicionais

Toda a busca, filtragem e cálculo de pontuação deve ser feita utilizando laços de repetição tradicionais (foreach ou for)e estruturas decisao (if). 

### RF10 - Exibição no Terminal (Console Application)

O sistema deve imprimir um relatório formatado e limpo no console, exibindo os dados do veículo, dados específicos da subclasse, notas, percentual e parecer final.

Sugestão de output experado: 

<pre>
===================================================================
                   AUTOCHECK .NET - MOTOR DE VISTORIA              
===================================================================

[1/2] PROCESSANDO VISTORIA
-------------------------------------------------------------------
> DADOS DO VEÍCULO:
  - Tipo: Carro
  - Modelo: Toyota Corolla 2.0 Flex
  - Ano: 2021 | Quilometragem: 45.000 km
  - Atributo Específico: 4 Portas

> AVALIAÇÃO DOS ITENS INSPECIONADOS (5 ITENS):
  [OK] Nível de Óleo do Motor ---------- Status: Bom (10 pts)
  [OK] Bateria e Sistema Elétrico ------ Status: Bom (10 pts)
  [ ! ] Ar Condicionado Funcional ------- Status: Regular (5 pts)
  [ ! ] Estepe e Macaco ----------------- Status: Regular (5 pts)
  [ X ] Triângulo de Sinalização -------- Status: Ruim (0 pts)

> RESUMO DA PONTUAÇÃO:
  - Pontuação Atingida: 30 de 50 pontos possíveis
  - Percentual de Aprovação: 60,0%
  - Classificação Final: [ APROVADO COM APONTAMENTOS ]

> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:
  🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):
     - Triângulo de Sinalização: Repor equipamento obrigatório ausente/danificado.

  🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):
     - Ar Condicionado Funcional: Realizar higienização e checagem do gás refrigerante.
     - Estepe e Macaco: Calibrar pneu reserva e verificar funcionamento do macaco.

-------------------------------------------------------------------

[2/2] PROCESSANDO VISTORIA
-------------------------------------------------------------------
> DADOS DO VEÍCULO:
  - Tipo: Caminhão
  - Modelo: Volvo FH 540
  - Ano: 2019 | Quilometragem: 280.000 km
  - Atributo Específico: 3 Eixos | Cap. Carga: 30,0 Toneladas

> AVALIAÇÃO DOS ITENS INSPECIONADOS (5 ITENS):
  [OK] Nível de Óleo do Motor ---------- Status: Bom (10 pts)
  [OK] Bateria e Sistema Elétrico ------ Status: Bom (10 pts)
  [OK] Funcionamento do Tacógrafo ------- Status: Bom (10 pts)
  [OK] Trava e Lona da Caçamba --------- Status: Bom (10 pts)
  [OK] Sistema de Freios a Ar ---------- Status: Bom (10 pts)

> RESUMO DA PONTUAÇÃO:
  - Pontuação Atingida: 50 de 50 pontos possíveis
  - Percentual de Aprovação: 100,0%
  - Classificação Final: [ APROVADO COM EXCELÊNCIA ]

> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:
  🟢 Nenhuma pendência mecânica identificada. Veículo liberado para operação!

===================================================================
                   FIM DO PROCESSAMENTO DE VISTORIAS              
===================================================================
</pre>

### RF11 - Menu Principal e Navegação (Console.ReadLine)

O sistema deve ser iniciado com um Menu Principal que permaneça em execução dentro de um laço de repetição (whileou do-while), oferecendo as seguintes opções ao usuário:

1. `1 - Realizar Nova Vistoria`:
    * Pergunta o tipo de veículo (Carro, Moto ou Caminhão).

    * Instancia a subclasse correspondente (new Carro(...), new Moto(...) ou new Caminhao(...)).

    * Coleta os dados cadastrais (Marca, Modelo, Ano, Km e atributos específicos da categoria).

    * Percorre o checklist específico da subclasse solicitando o status ("Bom", "Regular" ou "Ruim") de cada item.

    * Salva o veículo finalizado em uma lista central de vistorias (List<Veiculo>).

2. `2 - Exibir Relatório das Vistorias`:

    * Verifica se existem vistorias registradas na lista.

    * Se a lista estiver vazia, exibe uma mensagem informativa ("Nenhuma vistoria realizada até o momento").

    * Se houver vistorias, percorre a lista e exibe o relatório detalhado de cada veículo avaliado (pontuação, percentual, classificação e pendências).

3. `0 - Sair`:

    * Encerra a execução do programa.


## 4.3. REQUISITOS TÉCNICOS


| Conteúdo .NET / C# | Obrigatório? | Como Demonstrar no Código |
| :--- | :---: | :--- |
| **Console Application** | Sim | Projeto C# .NET Core executável no terminal. |
| **Tipos Primitivos** | Sim | Uso de `string`, `int`, `double` e `bool`. |
| **Listas (`List<T>`)** | Sim | Armazenar os itens inspecionados no veículo. |
| **Laços (`foreach` / `for`)** | Sim | Varredura das listas para cálculo de pontos e busca. |
| **Condicionais (`if`/`else`)** | Sim | Mapear notas ("Bom"=10, "Regular"=5, "Ruim"=0) e faixas de %. |
| **Classes & Objetos** | Sim | Instanciação de `Carro`, `Moto`, `Caminhao` com `new`. |
| **Construtores** | Sim | Construtores com parâmetros explicitamente declarados. |
| **Herança (`:`)** | Sim | Classes filhas herdando de `Veiculo`. |
| **Polimorfismo (`override`)** | Sim | Sobrescrever `ObterChecklistObrigatorio()` em cada subclasse. |
| **Encapsulamento** | Sim | Propriedades com `{ get; set; }` e métodos apropriados. |
| **Git / GitHub** | Sim | Repositório público com branches e commits. |