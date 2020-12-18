using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class DataProvider
    {
        #region Korisnik
        static public void DodajKorisnika(Korisnik korisnik)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Korisniks.Add(korisnik);
                cnt.SaveChanges();
            }
        }

        static public List<Korisnik> GetKorisnike()
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Korisniks.ToList();
            }
        }

        static public void IzbrisiKorisnika(Korisnik korisnik)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Korisniks.Remove(korisnik);
                cnt.SaveChanges();
            }
        }

        static public int IzmeniKorisnika(Korisnik korisnik)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {

                Korisnik tmp = cnt.Korisniks.Where(x => x.ID_Korisnika == korisnik.ID_Korisnika).FirstOrDefault();
                tmp.Korisnicko_Ime = korisnik.Korisnicko_Ime;
                tmp.Ime_Prezime = korisnik.Ime_Prezime;
                tmp.Pozicija = korisnik.Pozicija;
                tmp.Sifra = korisnik.Sifra;
                return cnt.SaveChanges();

            }
        }

        #endregion

        #region Ulaz 

        static public void DodajUlaz(Ulaz ulaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Ulazs.Add(ulaz);
                cnt.SaveChanges();
            }
        }

        static public List<string> GetReg()
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                List<String> a = new List<String>();
                foreach (Ulaz u in cnt.Ulazs)
                {
                    a.Add(u.RegistracioniBroj);
                        
                }
                return a;
            }
        }


        static public Ulaz GetUlaz(string regbr)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Ulazs.Where(x => x.RegistracioniBroj == regbr).FirstOrDefault();
            }
        }

        static public List<Ulaz> GetUlaze() 
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Ulazs.ToList(); 
            } 
        }

        static public void IzbrisiUlaz(Ulaz ulaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Ulazs.Attach(ulaz);
                cnt.Ulazs.Remove(ulaz);
                cnt.SaveChanges();
            }
        }

        static public int IzmeniUlaz(Ulaz ulaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {

                Ulaz tmp = cnt.Ulazs.Where(x => x.ID_Ulaz == ulaz.ID_Ulaz).FirstOrDefault();
                tmp.RegistracioniBroj = ulaz.RegistracioniBroj;
                tmp.Vreme_Ulaska = ulaz.Vreme_Ulaska;
                return cnt.SaveChanges();

            }
        }
        #endregion

        #region Izlaz

        static public void DodajIzlaz(Izlaz izlaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Izlazs.Add(izlaz);
                cnt.SaveChanges();
            }
        }

        static public Izlaz GetIzlaz(string regbr)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Izlazs.Where(x => x.Registracioni_Broj == regbr).FirstOrDefault();
            }
        }

        static public void IzbrisiIzlaz(Izlaz izlaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Izlazs.Attach(izlaz);
                cnt.Izlazs.Remove(izlaz);
                cnt.SaveChanges();
            }
        }

        static public int IzmeniIzlaz(Izlaz izlaz)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {

                Izlaz tmp = cnt.Izlazs.Where(x => x.ID_Izlaz == izlaz.ID_Izlaz).FirstOrDefault();
                tmp.Registracioni_Broj = izlaz.Registracioni_Broj;
                tmp.Vreme_Izlaska = izlaz.Vreme_Izlaska;
                return cnt.SaveChanges();

            }
        }
        #endregion

        #region Evidencija

        static public void DodajEvidenciju(Evidencija evi)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Evidencijas.Add(evi);
                cnt.SaveChanges();
            }
        }

        static public List<Evidencija> GetEvidencije()
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Evidencijas.ToList();
            }
        }

        static public Evidencija getEvidencija(string regBr) {

            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                return cnt.Evidencijas.Where(x => x.Registracioni_Broj == regBr).FirstOrDefault();
            }
        }

        static public void IzbrisiEvidenciju(Evidencija evi)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {
                cnt.Evidencijas.Remove(evi);
                cnt.SaveChanges();
            }
        }

        static public int IzmeniEvidenciju(Evidencija evi)
        {
            using (ParkingBazaEntities cnt = new ParkingBazaEntities())
            {

                Evidencija tmp = cnt.Evidencijas.Where(x => x.ID_Evidencije == evi.ID_Evidencije).FirstOrDefault();
                tmp.Registracioni_Broj = evi.Registracioni_Broj;
                tmp.Vreme_Izlaska = evi.Vreme_Izlaska;
                tmp.Vreme_Ulaska = evi.Vreme_Ulaska;
                
                tmp.Racun = evi.Racun;
                return cnt.SaveChanges();

            }
        }
        #endregion

        static public bool admin;
        static public void setAdmin(bool a) { admin = a; }
        static  public bool getAdmin() { return admin; }

        static public bool radnik;
        static public void setRadnik(bool a) { radnik = a; }
        static public bool getRadnik() { return radnik; }
    }
}
