using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpo {
  public enum Rank {
    UNRANKED,
    INICIANTE,
    BRABO,
    INSANO,
    MONSTRO,
    MESTRE,
    LENDARIO
    
  }

  public enum Escolha {
    None = 0,
    Jo = 1,
    Ken = 2,
    Po = 3
  }

  public static class Helper {
    public static void WriteColor(ConsoleColor font, string message) {
      Console.ForegroundColor = font;
      Console.Write(message);
      Console.ResetColor();
    }

    public static void WriteLineColor(ConsoleColor font, string message) {
      Console.ForegroundColor = font;
      Console.WriteLine(message);
      Console.ResetColor();
    }
  }
}
