using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_Memory
{
    public class Partie
    {
        private int nbrTour;
        private bool isOngoing;
        private bool tourjoueurA;

        public Partie(int unNbrTour, bool unOngoing, bool unTourJoueurA)
        {
            unNbrTour = NbrTour;
            unOngoing = IsOngoing;
            unTourJoueurA = TourjoueurA;
        }

        public int NbrTour { get => nbrTour; set => nbrTour = value; }
        public bool IsOngoing { get => isOngoing; set => isOngoing = value; }
        public bool TourjoueurA { get => tourjoueurA; set => tourjoueurA = value; }
    }
}
