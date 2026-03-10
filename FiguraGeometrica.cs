using System;
using System.Linq;

namespace ExempluClase
{
    public class FiguraGeometrica
    {
        // Data membră privată (vector)
        private int[] dimensiuniLaturi;

        // Proprietăți auto-implemented
        public string Denumire { get; set; }
        public int NrLaturi { get; set; }

        // Proprietate computed pentru Perimetru
        public int Perimetru
        {
            get
            {
                if (dimensiuniLaturi == null) return 0;

                int suma = 0;
                foreach (int d in dimensiuniLaturi)
                    suma += d;

                return suma;
            }
        }

        // Proprietate computed pentru TipFigura
        public string TipFigura
        {
            get
            {
                switch (NrLaturi)
                {
                    case 0: return "Punct";
                    case 1: return "Linie";
                    case 2: return "Unghi";
                    case 3: return "Triunghi";
                    case 4: return "Patrulater";
                    case 5: return "Pentagon";
                    case 6: return "Hexagon";
                    default:
                        return (NrLaturi > 6) ? $"Poligon cu {NrLaturi} laturi" : "Nedefinit";
                }
            }
        }

        public bool EstePoligon => NrLaturi >= 3;

        // Metode pentru manipularea vectorului
        public void SetDimensiuniLaturi(int[] _dimensiuniLaturi)
        {
            if (_dimensiuniLaturi != null)
            {
                dimensiuniLaturi = new int[_dimensiuniLaturi.Length];
                _dimensiuniLaturi.CopyTo(dimensiuniLaturi, 0);
                NrLaturi = _dimensiuniLaturi.Length;
            }
        }

        public int[] GetDimensiuniLaturi()
        {
            return dimensiuniLaturi != null ? (int[])dimensiuniLaturi.Clone() : null;
        }

        // Constructori
        public FiguraGeometrica()
        {
            Denumire = string.Empty;
            NrLaturi = 0;
        }

        public FiguraGeometrica(string _denumire, int _nrLaturi)
        {
            Denumire = _denumire;
            NrLaturi = _nrLaturi;
            dimensiuniLaturi = new int[_nrLaturi];
        }

        // Metoda Info
        public string Info()
        {
            // Verificare denumire vidă
            string numeAfisat = string.IsNullOrWhiteSpace(Denumire) ? "FIGURA NESETATA" : Denumire;

            // Afișare dimensiuni
            string laturiStr = (dimensiuniLaturi != null && dimensiuniLaturi.Length > 0)
                ? string.Join(" ", dimensiuniLaturi)
                : "fără dimensiuni";

            return $"[{numeAfisat}] | Tip: {TipFigura} | Laturi ({NrLaturi}): {laturiStr} | Perimetru: {Perimetru}";
        }
    }
}