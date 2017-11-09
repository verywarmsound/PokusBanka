using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokusBanka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokusBanka.Tests
{
    // testová třída pro třídu Ucet
    [TestClass()]
    public class UcetTests
    {
        // metoda testující správnou funkci metody Ucet.DisponibilniCastka() - zadáváme korektní hodnoty a ověřujeme výsledek proti očekávanému
        [TestMethod()]
        public void DisponibilniCastkaTest_ZustatekAKontokorent_VraciSoucetZustatekAKontokorent()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 10000, 5000);
            float ocekavano = 15000;
            // act
            float vysledek = u.DisponibilniCastka();
            // assert
            Assert.AreEqual(ocekavano, vysledek);
        }

        [TestMethod()]
        public void VlozTest_VkladamKladnouCastku_NavysiSeZustatek()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vkladano = 10000;
            float ocekavano = 25000;
            // act
            u.Vloz(vkladano);
            float vysledek = u.Zustatek;
            // assert
            Assert.AreEqual(ocekavano, vysledek);
        }

        // metoda ověřující vyhození výjimky - navozujeme chybový stav
        // stačí volat metodu, ve které má dojít k vyhození výjimky - není nutná žádná aserce
        [TestMethod]
        [ExpectedException(typeof(NonPositiveNumberException))]
        public void VlozTest_VkladamNulu_HaziNonPositiveNumberException()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vkladano = 0;
            // act
            u.Vloz(vkladano);
        }

        [TestMethod]
        [ExpectedException(typeof(NonPositiveNumberException))]
        public void VlozTest_VkladamZapornouCastku_HaziNonPositiveNumberException()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vkladano = -10000;
            // act
            u.Vloz(vkladano);
        }


        [TestMethod()]
        public void VyberTest_KladnaCastkaMensiNezDisponibilni_SniziSeZustatek()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vybrano = 10000;
            float ocekavano = 5000;
            // act
            u.Vyber(vybrano);
            float vysledek = u.Zustatek;
            // assert
            Assert.AreEqual(ocekavano, vysledek);
        }

        [TestMethod]
        [ExpectedException(typeof(NonPositiveNumberException))]
        public void VyberTest_VybiramZapornouCastku_HaziNonPositiveNumberException()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vybrano = -10000;
            // act
            u.Vyber(vybrano);
        }

        [TestMethod]
        [ExpectedException(typeof(NonPositiveNumberException))]
        public void VyberTest_VybiramNulu_HaziNonPositiveNumberException()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vybrano = 0;
            // act
            u.Vyber(vybrano);
        }

        [TestMethod]
        [ExpectedException(typeof(BalanceViolationException))]
        public void VyberTest_VybiramVetsiNezDisponibilniCastku_HaziBalanceViolationException()
        {
            // arrange
            Ucet u = new Ucet("Test Case", 15000, 0);
            float vybrano = 20000;
            // act
            u.Vyber(vybrano);
        }

    }
}