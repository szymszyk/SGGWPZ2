using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGGWPZ.ViewModels
{
    public class ViewLista
    {
        public string Nazwa;
        //public dynamic Obiekt;
        public List<string> Naglowki;
        public List<string> Wartosci;
        public IEnumerable<dynamic> Obiekty;

        public ViewLista(List<string> naglowki, List<string> wartosci, IEnumerable<dynamic> obiekty, string nazwa)
        {
            Nazwa = nazwa;
            Wartosci = wartosci;
            Naglowki = naglowki;
            Obiekty = obiekty;
        }

        public ViewLista(List<string> naglowki, List<string> wartosci, string nazwa)
        {
            Nazwa = nazwa;
            Wartosci = wartosci;
            Naglowki = naglowki;
        }

        public ViewLista(List<string> naglowki, IEnumerable<dynamic> obiekty, string nazwa)
        {
            Nazwa = nazwa;
            Naglowki = naglowki;
            Obiekty = obiekty;
        }
    }
}
