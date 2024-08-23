public class Me
{
    private string Name; 
    private byte Idade; 
    private float Salario;
    private char Inicial;
    private bool Ativo;

    public string name
    {
        get { return Name; }
        set 
        {
            if (value.Length > 1 && value.Length < 30)
                Name = value;
            else
                Console.WriteLine("Nome inválido.");
        }
    }

    public byte idade
    {
        get { return Idade; }
        set
        {
            if (value > 0 && value < 100)
                Idade = value;
            else
                Console.WriteLine("Idade inválida.");
        }
    }

    public float salario
    {
        get { return Salario; }
        set
        {
            if (value >= 0)
                Salario = value;
            else
                Console.WriteLine("Salário não pode ser negativo.");
        }
    }

    public char inicial
    {
        get { return Inicial; }
        set
        {
            if (char.IsLetter(value))
                Inicial = value;
            else
                Console.WriteLine("Inicial deve ser uma letra.");
        }
    }

    public bool ativo
    {
        get { return Ativo; }
        set { Ativo = value; }
    }
}
