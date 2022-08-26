namespace Jokenpo {
  public class Jogador {

    public string Nome { get; init; }
    public Rank Rank { get; private set; }
    public Escolha Escolha { get; private set; }

    public Jogador(string? nome) {
      Nome = string.IsNullOrEmpty(nome) ? "PLAYER 1" : nome.ToUpper();
      Rank = Rank.UNRANKED;
    }
    public Jogador() {
      Nome = "MAQUINA";
      Rank = Rank.LENDARIO;
    }

    public void SubirRank() {
      Rank++;
      if(Rank == Rank.INICIANTE)
        Helper.WriteLineColor(ConsoleColor.Green, $" {Nome} AGORA É [{Enum.GetName(Rank)}]!");

      else if(Rank == Rank.BRABO)
        Helper.WriteLineColor(ConsoleColor.Blue, $" TAPORRA O MALUCO É [{Enum.GetName(Rank)}]!");

      else if(Rank == Rank.INSANO)
        Helper.WriteLineColor(ConsoleColor.DarkCyan, $" O POKEMON {Nome} EVOLUIU PARA [{Enum.GetName(Rank)}]!");

      else if(Rank == Rank.MONSTRO)
        Helper.WriteLineColor(ConsoleColor.DarkYellow, $" TA SAINDO DA JAULA O [{Enum.GetName(Rank)}]! BIIIRRRRRLLLLL");

      else if(Rank == Rank.MESTRE)
        Helper.WriteLineColor(ConsoleColor.DarkMagenta, $" {Nome} É O [{Enum.GetName(Rank)}] DOS MAGOS!");

      else if(Rank == Rank.LENDARIO)
        Helper.WriteLineColor(ConsoleColor.Red, $" {Nome} É IMPLACAVEL E AGORA SE TORNOU [{Enum.GetName(Rank)}]!");
    }
    
    public void ResetarRank() => Rank = Rank.UNRANKED;
    
    public void Escolher() {
      this.Escolha = Escolha.None;

      if(Nome.Equals("MAQUINA")) {
        Escolha = (Escolha)new Random().Next(1, 4);

      } else {
        bool isvalid = false;
        int resposta = 0;
        int count = 0;
        Helper.WriteColor(ConsoleColor.Yellow, "\n  ESCOLHAS DISPONIVEIS: ");
        Helper.WriteColor(ConsoleColor.Gray, "[ 1 - JO ]    ");
        Helper.WriteColor(ConsoleColor.Cyan, "[ 2 - KEN ]    ");
        Helper.WriteColor(ConsoleColor.Blue, "[ 3 - PO ]");

        while(count < 3) {
          Helper.WriteColor(ConsoleColor.Yellow, "\n\n RESPOSTA: ");
          var leitura = Console.ReadLine();

          if(string.IsNullOrEmpty(leitura)) {
            Helper.WriteColor(ConsoleColor.Red, "\n ENTRADA INVÁLIDA ");

          } else if(int.TryParse(leitura, out int result)) {

            if(result >= 0 && result < 4) {
              resposta = result;
              isvalid = true;
              break;
            } else {
              Helper.WriteColor(ConsoleColor.Red, "\n ENTRADA INVÁLIDA - ENTRADA VALIDA [1 - 2 - 3] ");
            }
          }

          count++;
        }
        if(!isvalid)
          resposta = 0;

        Escolha = (Escolha)resposta;
      }
    }
  }
}
