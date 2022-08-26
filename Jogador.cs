using ProjectExtends;

namespace Jokenpo {
  public class Jogador {

    public string Nome { get; init; }

    public Rank Rank { get; private set; }

    public int Vitorias { get; private set; }

    public Escolha Escolha { get; private set; }

    public Jogador(string? nome) {
      Nome = string.IsNullOrEmpty(nome) ? "PLAYER 1" : nome.ToUpper();
      Rank = Rank.UNRANKED;
    }
    public Jogador() {
      Nome = "MAQUINA";
      Rank = Rank.IMPLACAVEL;
    }

    public void SubirRank() {
      Vitorias++;

      if(Rank != Rank.IMPLACAVEL)
        Rank++;

      if(Rank == Rank.INICIANTE)
       Extension.Println($" {Nome} AGORA É ##C11[[{Enum.GetName(Rank)}]]##!");

      else if(Rank == Rank.BRABO)
       Extension.Println($" TAPORRAAAAAA O MALUCO {Nome} É ##c10[[{Enum.GetName(Rank)}]]##!");

      else if(Rank == Rank.INSANO)
       Extension.Println($" O POKEMON {Nome} EVOLUIU, QUE ##C04[[{Enum.GetName(Rank)}]]##!");

      else if(Rank == Rank.MONSTRO)
       Extension.Println($" {Nome} GRITA: TA SAINDO DA JAULA O ##C07[[{Enum.GetName(Rank)}]]##! BIIIRRRRRLLLLL");

      else if(Rank == Rank.MESTRE)
       Extension.Println($" {Nome} É O ##C06[[{Enum.GetName(Rank)}]]## DOS MAGOS!");

      else if(Rank == Rank.LENDARIO)
       Extension.Println($" O JOGADOR {Nome} SE TORNOU ##C13[[{Enum.GetName(Rank)}]]##!");

      else
        Extension.Println($" {Nome} ESTÁ ##C10[[{Enum.GetName(Rank)}]]##! E NEM MESMO A ##C09[MAQUINA]## PODE DERROTA-LO");
    }
    
    
    public void ResetarRank() {
      Rank = Rank.UNRANKED;
      Vitorias = 0;
    }
    
    public void Escolher() {
      this.Escolha = Escolha.None;

      if(Nome.Equals("MAQUINA")) {
        Escolha = (Escolha)new Random().Next(1, 4);

      } else {
        bool isvalid = false;
        int resposta = 0;
        int count = 0;
        Extension.Println("\n  ##C15[ESCOLHAS DISPONIVEIS]##: ##C12[[ 1 - PEDRA ]]##     ##C14[[ 2 - PAPEL ]]##     ##C16[[ 3 - TESOURA ]]##");

        while(count < 3) {
          Extension.Print("\n\n ##C15[RESPOSTA]##: ");
          var leitura = Console.ReadLine();

          if(string.IsNullOrEmpty(leitura)) {
            Extension.Print("\n ##C13[ENTRADA INVÁLIDA] ");

          } else if(int.TryParse(leitura, out int result)) {

            if(result >= 0 && result < 4) {
              resposta = result;
              isvalid = true;
              break;
            } else {
              Extension.Print("\n ENTRADA ##C13[INVÁLIDA]## - ENTRADA VALIDA ##C10[[1 - 2 - 3]]## ");
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
