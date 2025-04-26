public class ContaBancaria
{
    public int IdConta;
    public int Agencia;
    public int NuConta;
    public string TitularConta;
    public double Saldo;

    public ContaBancaria(int IdConta, int Agencia, int NuConta, string TitularConta, double Saldo)
    {
        this.IdConta = IdConta;
        this.Agencia = Agencia;
        this.NuConta = NuConta;
        this.TitularConta = TitularConta;
        this.Saldo = Saldo;
    }

    public void Depositar(double valorDep)
    {
        if (valorDep > 0)
        {
            Saldo += valorDep;
        }
        else
        {
            Console.WriteLine("Valor inválido!");
        }
    }

    public void Sacar(double valorSaque)
    {
        if (valorSaque > 0 && valorSaque <= Saldo)
        {
            Saldo -= valorSaque;
        }
        else
        {
            Console.WriteLine("Valor inválido ou saldo insuficiente.");
        }
    }

}