using Jokenpo;

namespace Principal {
  public class Program {

    static void Main(string[] args) {

      Helper.WriteLineColor(ConsoleColor.Magenta, string.Concat(" ", new string('*', 10), " BEM VINDO AO JOKENPO GAME ", new string('*', 10)));
      bool desistir = false;

      Console.Write("\n NOME DO JOGADOR/JOGADORA: ");
      var jogador = new Jogador(Console.ReadLine());
      var maquina = new Jogador();

      while(!desistir) {
        var vencedor = AvaliarJogada(jogador, maquina);

        if(vencedor.Nome.Equals("MAQUINA")) {
          Helper.WriteLineColor(ConsoleColor.Red, $" GAME OVER {jogador.Nome}! ");
          Helper.WriteLineColor(ConsoleColor.Yellow, " VOCÊ PERDEU PORQUE A MAQUINA É IMPLACAVEL!!! ");
          Helper.WriteLineColor(ConsoleColor.Cyan, $" SEU RANK FOI: {jogador.Rank} ");

          Console.Write("\n DIGITE [1] PARA CONTINUAR JOGANDO! ");
          var resposta = Console.ReadLine();
          if(!string.IsNullOrEmpty(resposta)) {

            switch(resposta) {
              case "1":
                jogador.ResetarRank();
                Console.Clear();
                continue;
              default:
                desistir = true;
                break;
            }

          }

        } else {
          Helper.WriteLineColor(ConsoleColor.Magenta, " VOCE GANHOU ESTA PARTIDA ");
          jogador.SubirRank();
        }
      }

      Helper.WriteLineColor(ConsoleColor.Gray, string.Concat("\n ", new string('*', 13), " JOGO ENCERRADO! ", new string('*', 13)));
    }

    static Jogador AvaliarJogada(Jogador player1, Jogador maquina) {
      Jogador retorno;

      while(true) {
        player1.Escolher();
        maquina.Escolher();

        if(Escolha.None == player1.Escolha) {
          Helper.WriteLineColor(ConsoleColor.White, " VOCÊ NÃO JOGOU. DESCANSE E TENTE NOVAMENTE. ");
          return maquina;
        }


        Helper.WriteColor(ConsoleColor.Green, " JOOOOO ");
        Thread.Sleep(1000);
        Helper.WriteColor(ConsoleColor.Blue, "KEEEEENNNNN ");
        Thread.Sleep(1000);
        Helper.WriteLineColor(ConsoleColor.DarkYellow, "POOOOOOOOOOOOOOOOOOOOOO ");
        Thread.Sleep(1000);

        if(player1.Escolha == maquina.Escolha) {
          Helper.WriteLineColor(ConsoleColor.DarkBlue, " TEMOS UM EMPATE! ");
          Helper.WriteColor(ConsoleColor.Yellow, $" {player1.Nome} ESCOLHEU [{player1.Escolha}] ");
          Console.Write(" E ");
          Helper.WriteLineColor(ConsoleColor.Yellow, $" A {maquina.Nome} ESCOLHEU [{player1.Escolha}] ");
          continue;

        } else if((player1.Escolha == Escolha.Jo) && (maquina.Escolha == Escolha.Po)) {
          retorno = player1;

        } else if((player1.Escolha == Escolha.Ken) && (maquina.Escolha == Escolha.Jo)) {
          retorno = player1;

        } else if((player1.Escolha == Escolha.Po) && (maquina.Escolha == Escolha.Ken)) {
          retorno = player1;

        } else {
          retorno = maquina;
        }

        break;
      }

      return retorno;
    }
  }
}








