using Jokenpo;
using ProjectExtends;

namespace Principal {
  public class Program {

    static void Main(string[] args) {
      Extension.Println($"{string.Concat(" ", new string('*', 10), " ##C07[BEM]## ##C02[VINDO]## AO ##c03[JOKENPO]## ##c04[GAME]## ", new string('*', 10))}");
      bool desistir = false;

      Extension.Print("\n ##C15[NOME DO JOGADOR/JOGADORA]##: ");
      var jogador = new Jogador(Console.ReadLine());
      var maquina = new Jogador();

      while(!desistir) {
        var vencedor = AvaliarJogada(jogador, maquina);

        if(vencedor.Nome.Equals("MAQUINA")) {
          Extension.Println($" ##C13[GAME OVER]## ##c11[{jogador.Nome}]##! ");
          Extension.Println($" {jogador.Nome} ESCOLHEU ##C14[{jogador.Escolha}]## E A MAQUINA ESCOLHEU ##c11[{maquina.Escolha}]##! ");
          Extension.Println(" VOCÊ PERDEU PORQUE A MAQUINA É ##C13[IMPLACAVEL]##!!! ");
          Extension.Println($" SEU RANK MAXIMO FOI: ##C12[[{jogador.Rank}]]## COM UM TOTAL DE ##C12[{jogador.Vitorias}]## VITORIAS!");

          Extension.Print("\n ##C15[DIGITE [1] PARA CONTINUAR JOGANDO]##: ");
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
          Extension.Println(" ##C14[VOCE GANHOU ESTA PARTIDA]## ");
          jogador.SubirRank();
        }
      }

      Extension.Println($"{string.Concat(" ", new string('*', 13), " ##C07[JOGO ENCERRADO]##! ", new string('*', 13))}");
    }

    static Jogador AvaliarJogada(Jogador player1, Jogador maquina) {
      Jogador retorno;

      while(true) {
        player1.Escolher();
        maquina.Escolher();

        if(Escolha.None == player1.Escolha) {
          Extension.Println(" ##C16[VOCÊ NÃO JOGOU. DESCANSE E TENTE NOVAMENTE]##. ");
          return maquina;
        }


        Extension.Print(" ##C11[JOOOOO...]## ");
        Thread.Sleep(1500);
        Extension.Print("##C10[KEEEEEEEENNNNNNN...]##");
        Thread.Sleep(1500);
        Extension.Println("##C07[POOOOOOOOOOOOOOOOOOOOOO]##!");
        Thread.Sleep(500);

        if(player1.Escolha == maquina.Escolha) {
          Extension.Println(" ##C02[TEMOS UM EMPATE]##! ");
          Extension.Println($" ##C15[{player1.Nome}]## ESCOLHEU ##C03[[{player1.Escolha}]]## E ##C15[{maquina.Nome}]## ESCOLHEU ##C03[[{maquina.Escolha}]]##");
          continue;

        } else if((player1.Escolha == Escolha.PEDRA) && (maquina.Escolha == Escolha.TESOURA)) {
          retorno = player1;

        } else if((player1.Escolha == Escolha.PAPEL) && (maquina.Escolha == Escolha.PEDRA)) {
          retorno = player1;

        } else if((player1.Escolha == Escolha.TESOURA) && (maquina.Escolha == Escolha.PAPEL)) {
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








