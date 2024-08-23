//Screen Sound
using System.ComponentModel;
using System.Runtime;
using System.Xml.Linq;

string Msg = "Boas vindas ao Screen Sound";

//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"};  
Dictionary<string, List<int>> bandaRegistradas = new Dictionary<string, List<int>>();
bandaRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandaRegistradas.Add("The Beatles", new List<int>());


void ExibirLogo()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(Msg);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 - Para registrar uma Banda");
    Console.WriteLine("Digite 2 - Para mosntrar todas as bandas");
    Console.WriteLine("Digite 3 - Para avaliar uma banda");
    Console.WriteLine("Digite 4 - Para exibir a média de uma banda");
    Console.WriteLine("Digite 0 - Para sair");

    Console.Write("\nDigite a sua Opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda(); 
            break;
        case 2: MostrarBandasRegistradas(); 
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: CalculoMediaBanda();
            break;
        case 0: Console.WriteLine("Voce escolheu a opção: " + opcaoEscolhida);
            break;
        default: Console.WriteLine("Opção Invalida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!!!");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    //for (int i = 0; i<listasDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listasDasBandas[i]}");
    //}
    foreach (string banda in bandaRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para retornar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '-');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

// ...

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandaRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandaRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void CalculoMediaBanda()
{
    //limpar a tela
    //exibir o titulo da opção 4
    //perguntar o nome da banda que deseja exibir a media de anvaliação
    //consultar se abanda esta inserida no dicionario da aplicação
    //se sim > realizar o calculo da media e exibir o resultado
    //se não > retornar ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Nota Média das Bandas");
    Console.Write("Qual banda você quer saber a média: ");
    string bandaMedia = Console.ReadLine()!;
    if (bandaRegistradas.ContainsKey(bandaMedia))
    {
        List<int> notasDaBanda = bandaRegistradas [bandaMedia];
        Console.WriteLine($"\nA média da banda {bandaMedia} é {notasDaBanda.Average()} .");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaMedia} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}


ExibirMenu();