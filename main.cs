/* balkezesek.csv
 0    1    2      3      4
név;első;utolsó;súly;magasság
Jim Abbott;1989-04-08;1999-07-21;200;75
*/
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Player{ 
      public Player(string sor){
          var adatok = sor.Trim().Split(';');
          this.nev      = adatok[0];
          this.elso     = int.Parse(adatok[1].Substring(0,4));
          this.utolso   = int.Parse(adatok[2].Substring(0,4));
          this.suly     = int.Parse(adatok[3]);
          this.magassag = int.Parse(adatok[4]) * 2.54;
          this.utolso_evho  =  adatok[2].Substring(0,7);
      }

      public string nev      { get; set; }
      public int    elso     { get; set; }
      public int    utolso   { get; set; }
      public int    suly     { get; set; }
      public double magassag { get; set; }
      public string utolso_evho { get; set; }
}

class Program {
  public static void Main (string[] args) {
 // 2.
    var f = new StreamReader("balkezesek.csv", Encoding.Default);
    var lista = new List<Player>();
    var elsosor = f.ReadLine();

    while (!f.EndOfStream){
        lista.Add(  new Player(f.ReadLine())  );
    }
    f.Close();

// 3. adatsorok száma
    Console.WriteLine($"3. feladat: {lista.Count}");

// 4. Játékosok, akik 1990-10-ben léptek utoljára pályára
    Console.WriteLine( $"4. feladat:");

    foreach(var sor in lista){
        if (sor.utolso_evho == "1999-10"){
            Console.WriteLine($"        {sor.nev}, {sor.magassag:0.#} cm");
        }
    }
//5.
    Console.WriteLine( $"5. feladat:");
    int ev;
    while(true){
        Console.Write("Kérek egy 1990 és 1999 közötti évszámot!:");
        int.TryParse(Console.ReadLine(), out ev);
        if ((1990 < ev) & (ev < 1999)){
            break;
        }
        else{
            Console.Write("Hibás adat!");
        }
    }
// 6. az adott évben pályára lépett játékosok átlagsúlya 
    var atlagsuly = (
        from sor in lista
        where sor.elso <= ev
        where ev <= sor.utolso
        select sor.suly
        ).Average();
    Console.WriteLine( $"6. feladat: {atlagsuly:0.##} font");
  }
}