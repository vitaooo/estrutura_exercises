
const int tam = 5;
aluno[] vetor = new aluno[tam];

int Hash(int ch)
{
    return (ch % tam);
}

void InsereLinear(int n, string nm, string e, ref int qc)
{
    int pos = Hash(n);
    while (vetor[pos].nota != 0)
    {
        pos++;
        pos = pos % tam;
        qc++;
    }

    vetor[pos].nota = n;
    vetor[pos].nome = nm;
    vetor[pos].email = e;
}

int RecuperaLinear(int n)
{
    int pos = Hash(n);
    int qtd = 0;
    while (vetor[pos].nota != n && qtd <= tam)
    {
        qtd++;
        pos++;
        pos = pos % tam;
    }
    if (qtd < tam)
        return pos;
    else
        return -1;

}

void Inicializar()
{
    for (int i = 0; i < tam; i++)
    {
        vetor[i] = new aluno();
    }
}


// Main
Inicializar();
string op = "0";
int qtdCo1 = 0;
while (op != "4")
{
    Console.Clear();
    Console.WriteLine("MENU");
    Console.WriteLine();
    Console.WriteLine("1 - Inserir");
    Console.WriteLine();
    Console.WriteLine("2 - Recuperar");
    Console.WriteLine();
    Console.WriteLine("3 - informar");
    Console.WriteLine();
    Console.WriteLine("4 - sair");
    Console.WriteLine();
    op = Console.ReadLine();
    if (op == "1")
    {
        Console.WriteLine();
        Console.Write("Nota: ");
        int nota = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        InsereLinear(nota, nome, email, ref qtdCo1);
    }
    else if (op == "2")
    {
        Console.Write("Nota: ");
        int nota = Convert.ToInt32(Console.ReadLine());
        int pos = RecuperaLinear(nota);
        if (pos == -1)
        {
            Console.WriteLine("Não encontrou!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Nome: " + vetor[pos].nome);
            Console.WriteLine("Email: " + vetor[pos].email);
            Console.WriteLine();
        }

    } else if (op == "3")
        Console.WriteLine("Quantidade de colisões: " + qtdCo1);

        Console.ReadKey();
}



class aluno
{
    public int nota;
    public string nome, email;
}