using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_testovi
{
    [TestClass]
    public class StudentskiDomTest
    {
        [TestMethod]
        //Ima mjesta u sobi, pronadjeno u prvoj petlji, pa je slobodna soba pronadjena i student je dodan u sobu
        public void Put1() 
        {
            Spol sp = Enum.GetName(typeof(Spol), 0);
            LicniPodaci data = new LicniPodaci("OvojeIme1", "OvojePrezime1", "OvojeMjestorodjenja1", "ovoJe@mail1.com", "slika1", "2303999152552", sp, new DateTime(1995, 03, 22));
            Student st = new Student("ovoJeuser1", "ovoJePass1", data, new List<string>() { "Sarajevo" }, Skolovanje school);
            Soba s;
            s.IsprazniSobu();
            UpisUDom(st, 1, false);
            Assert.AreEqual(s.Count, 1);
        }

        [TestMethod]
        //Nije nadjena soba za studenta prvom petljom, fleksibilnost je false pa se baca izuzetak
        public void Put2()
        {
            Spol sp = Enum.GetName(typeof(Spol), 0);
            LicniPodaci data = new LicniPodaci("OvojeIme2", "OvojePrezime2", "OvojeMjestorodjenja2", "ovoJe@mail1.com", "slika2", "2303999152552", sp, new DateTime(1995, 03, 22));
            Student st = new Student("ovoJeuser1", "ovoJePass1", data, new List<string>() { "Sarajevo" }, Skolovanje school);
            try
            {
                UpisUDom(st, 5, false);
                Assert.fail();
            }
            catch (Exception) { throw; }
        }

        [TestMethod]
        //Nije nadjena soba za studenta prvom petljom, fleksibilnost je true pa se druogm petljom opet trazi soba, ali zbog takve strukture motode ovaj slucaj ce uvijek bacat izuzetak
        public void Put3()
        {
            Spol sp = Enum.GetName(typeof(Spol), 0);
            LicniPodaci data = new LicniPodaci("OvojeIme3", "OvojePrezime3", "OvojeMjestorodjenja3", "ovoJe@mail1.com", "slika3", "2303999152552", sp, new DateTime(1995, 03, 22));
            Student st = new Student("ovoJeuser3", "ovoJePass3", data, new List<string>() { "Sarajevo" }, Skolovanje school);
            Soba s;
            s.IsprazniSobu();
            try
            {
                UpisUDom(st, 2, true);
                Assert.fail();
            }
            catch (Exception) { throw; }
        }
    }
}