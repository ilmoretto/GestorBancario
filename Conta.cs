public class ContaBancaria
{
    public int IdConta;
    public int Agencia;
    public int NuConta;
    public string TitularConta;
    public double Saldo;

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