List<ContaBancaria> contas = new List<ContaBancaria>();

bool encerrarPrograma = false;
while (!encerrarPrograma)
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("     CADASTRO DE CONTAS");
    Console.WriteLine("==============================");
    Console.WriteLine("1 - Cadastrar Conta");
    Console.WriteLine("2 - Listar Contas");
    Console.WriteLine("3 - Depositar");
    Console.WriteLine("4 - Sacar");
    Console.WriteLine("5 - Filtrar por saldo");
    Console.WriteLine("6 - Saldo Total das Contas");
    Console.WriteLine("7 - Buscar Conta");
    Console.WriteLine("8 - Transferir");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("==============================");
    Console.Write("Escolha uma opção: ");
    int opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 0:
            {
                Console.WriteLine("Encerrando o programa...");
                encerrarPrograma = true;
                break;
            }
        case 1:
            CadastrarConta();
            break;
        case 2:
            ListarContas(); 
            break;
        case 3:
            Deposito();
            break;

        case 4:
            Saque();
            break;
        case 5:
            FiltrarSaldo();
            break;
        case 6:
            SaldoTotal();
            break;
        case 7:
            BuscarConta();
            break;
        case 8:
            Transferir();
            break;

        default:
            Console.WriteLine("Opção Inválida");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

void CadastrarConta()
{
    try
    {
        string opcContinuar = "s";

        while (opcContinuar != "n")
        {
            Console.Clear();
            Console.WriteLine("Informe o ID da conta: ");
            int idConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a agência da conta: ");
            int agencia = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o número da conta: ");
            int nuConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o nome do titular:");
            string titularConta = Console.ReadLine();

            Console.WriteLine("Informe o saldo da conta: ");
            double saldo = Convert.ToDouble(Console.ReadLine());
            
            ContaBancaria c1 = new ContaBancaria(idConta, agencia, nuConta, titularConta, saldo); // criando o objeto
            contas.Add(c1); 

            Console.Write("Deseja cadastrar uma nova conta (s/n):");
            opcContinuar = Console.ReadLine().ToLower().Trim();

        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Erro: " + e.Message);
        Console.ReadKey();
    }
}
void ListarContas()
{
    Console.Clear();
    if (contas.Count == 0)
    {
        Console.WriteLine("Não há contas cadastradas.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else
    {
        Console.Clear();
        foreach (ContaBancaria c in contas)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"ID: {c.getId} | Agência: {c.Agencia} | Conta: {c.NuConta}");
            Console.WriteLine($"Titular: {c.TitularConta}");
            Console.WriteLine($"Saldo: {c.Saldo.ToString("C2")}");
            Console.WriteLine("------------------------------------------");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
void Deposito()
{
    Console.Clear();
    Console.Write("Informe o ID da conta para depositar: ");
    int idConta = Convert.ToInt32(Console.ReadLine());

    ContaBancaria contaCli = contas.FirstOrDefault(x => x.getId() == idConta);
    //localizando a conta bancário correta antes de efetuar o depósito

    if (contaCli != null)
    {
        Console.WriteLine($"\nTitular da Conta: {contaCli.TitularConta}");
        Console.Write("\nInforme o valor do depósito: R$");
        double valorDep = Convert.ToDouble(Console.ReadLine());
        contaCli.Depositar(valorDep);
        Console.WriteLine("\nDepósito realizado com sucesso!");
    }
    else
    {
        Console.WriteLine("Conta bancária não localizada.");
    }
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}
void Saque()
{
    Console.Clear();
    Console.Write("Informe o ID da conta para sacar: ");
    int idConta = Convert.ToInt32(Console.ReadLine());

    ContaBancaria contaCli = contas.FirstOrDefault(x => x.getId() == idConta);
    //localizando a conta bancário correta antes de efetuar o saque

    if (contaCli != null)
    {
        Console.WriteLine($"\nTitular da Conta: {contaCli.TitularConta}");
        Console.Write("\nInforme o valor do saque: R$");
        double valorSaque = Convert.ToDouble(Console.ReadLine());
        contaCli.Sacar(valorSaque);
        Console.WriteLine("\nSaque realizado com sucesso!");
    }
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void FiltrarSaldo()
{
    Console.Clear();
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else
    {
        string opcao = "s";
        while (opcao != "n")
        {
            Console.Clear();
            Console.Write("Informe o valor que deseja filtrar: R$");
            double valorFiltro = Convert.ToDouble(Console.ReadLine());

            List<ContaBancaria> filtroConta = contas.Where(x => x.Saldo >= valorFiltro).ToList();

            if (filtroConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta corresponde ao filtro");
                Console.WriteLine("\nDeseja fazer uma nova consulta (s/n): ");
                opcao = Console.ReadLine().ToLower().Trim();
            }
            else
            {
                foreach (ContaBancaria c in filtroConta)
                {
                    Console.WriteLine($"\nID da conta: {c.getId}");
                    Console.WriteLine($"Titular da conta: {c.TitularConta}");
                    Console.WriteLine($"Saldo da conta: {c.Saldo.ToString("C2")}");
                }

                Console.WriteLine("\nDeseja fazer uma nova consulta (s/n): ");
                opcao = Console.ReadLine().ToLower().Trim();
            }
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();

    }
}
void SaldoTotal()
{
    Console.Clear();
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else
    {
        double saldoTotal = contas.Sum(x => x.Saldo);
        Console.WriteLine($"\nO saldo total das contas: {saldoTotal.ToString("C2")}");
    }
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}
void BuscarConta() //segundo commit
{
    Console.Clear();
    Console.WriteLine("===== BUSCAR CONTA =====");
    Console.WriteLine("Informe o ID da conta: ");
    int idConta = Convert.ToInt32(Console.ReadLine());
    try
    {
        ContaBancaria contaLoc = contas.First(x => x.getId() == idConta);

        if (contaLoc != null)
        {
            Console.WriteLine($"\nTitular da Conta: {contaLoc.TitularConta}");
            Console.WriteLine($"Saldo: {contaLoc.Saldo.ToString("C2")}");
            Console.WriteLine($"Agência: {contaLoc.Agencia}");

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Conta bancária não localizada.");
    }
    finally
    {
        //Console.WriteLine("Vai passar aqui de qualquer jeito.");
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void Transferir()
{
    Console.Clear();
    Console.Write("Informe o ID da conta de Origem: ");
    int idOrigem = Convert.ToInt32(Console.ReadLine());
    Console.Write("Informe o ID da conta de Destino ");
    int idDestino = Convert.ToInt32(Console.ReadLine());
    
    //validando contas bancárias antes de transferir
    ContaBancaria contaOrigem = contas.First(x => x.getId() == idOrigem);
    
    ContaBancaria contaDestino = contas.First(x => x.getId() == idDestino);
    Console.WriteLine($"\nConta destino: {contaDestino.TitularConta}");

    if (contaOrigem != null && contaDestino != null)
    {
        Console.Write("Informe o valor que deseja transferir: R$");
        double valorTrans = Convert.ToDouble(Console.ReadLine());

        if (contaOrigem.Saldo >= valorTrans)
        {
            contaOrigem.Sacar(valorTrans);
            contaDestino.Depositar(valorTrans);

            Console.WriteLine("\nTransferência realizada com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Saldo insuficiente.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Contas bancárias não localizadas.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}