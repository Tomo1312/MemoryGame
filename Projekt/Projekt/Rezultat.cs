using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Rezultat
    {
        public int Score { get; set; }

        public int High { get; set; }
        public Rezultat(int _score, int _High)
        {
            Score = _score;
            High = _High;
        }

        public void spremiRez()
        {
            if (Score > High)
            {
                Properties.Settings.Default.HighScore =Score;
                Properties.Settings.Default.Save();
            }

        }

    }
}
