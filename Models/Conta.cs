namespace TransasoesBancarias.Models
{
    public class Conta
    {
        public int ContaId { get;  private set;}
        public int NumConta { get;  private set;}
        public string Nome { get;  private set;}
        public double Saldo { get;  private set;}

        public Conta(int _id, int nConta, string nome, double saldo)
        {
            ContaId = _id;
            NumConta = nConta;
            Nome = nome;
            Saldo = saldo;
        }
        public Conta()
        {}
        public bool Decrementa_Saldo(double montante)
        {
            if (montante >= this.Saldo || montante < 0)
                return false;

            this.Saldo -= montante;
            return true;
        }

        public bool Incrementa_Saldo(double montante)
        {
            if (montante < 0)
                return false;

            this.Saldo += montante;
            return true;
        }
        
    }
}
