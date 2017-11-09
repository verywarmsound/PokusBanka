using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokusBanka
{
    // Třída představuje datový záznam s informacemi o bankovním účtu.
    // Umožňuje provádět operace měnící zůstatek na účtu.
    public class Ucet
    {
        public string Majitel { get; set; }
        public float Zustatek { get; set; } = 0; // využití property initializeru - není nutné nastavovat výchozí hodnotu v konstruktoru
        public float Kontokorent { get; set; } = 0;

        public Ucet(string m)
        {
            Majitel = m;
        }

        public Ucet(string m, float z, float k)
        {
            Majitel = m;
            Zustatek = z;
            Kontokorent = k;
        }

        // přebití metody ToString(), aby zobrazovala v textové podobě souhrnné informace o účtu
        public override string ToString()
        {
            return "Majitel " + Majitel + " má na účtu zůstatek " + Zustatek
                + " Kč a disponibilní částku " + DisponibilniCastka() + " Kč.";
        }

        // metoda pro výpočet disponibilní částky (pokud máme kontokorent, lze jít se zůstatkem do mínusu až do jeho výše)
        public float DisponibilniCastka()
        {
            return Zustatek + Kontokorent;
        }

        // vkládání na účet - pouze kladné nenulové částky
        public void Vloz(float c)
        {
            if (c > 0)  // vkládáme kladnou částku
                Zustatek += c;
            else  // nula nebo záporné číslo způsobí vyhození výjimky
                throw new NonPositiveNumberException("Částka musí být větší než nula!");
        }

        // výběr z účtu - pouze kladné nenulové částky
        public void Vyber(float c)
        {
            if (c <= 0) // nula nebo zápor vyhodí výjimku
                throw new NonPositiveNumberException("Částka musí být větší než nula!");
            else
                if (c > DisponibilniCastka())  // nelze vybrat částku větší než disponibilní -> vyhodí výjimku
                throw new BalanceViolationException("Nelze vybrat částku vyšší než je disponibilní!");
            else // provedeme snížení zůstatku o vybíranou částku
            Zustatek -= c;
        }
    }
}
