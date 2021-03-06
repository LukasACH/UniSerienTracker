﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSerienTracker
{
    class Serie
    {
        public string name;
        public double mxPt;
        public double erPt;

        public Serie(string name, int mxPt, double erPt)
        {
            this.name = name;
            this.mxPt = mxPt;
            this.erPt = erPt;
        }
    }

    class Vorlesung
    {
        private string name = "";
        public double testat = 0;

        List<Serie> serien = new List<Serie>();

        public Vorlesung(string name)
        {
            this.name = name;
        }

        public void AddSerie(string name, int mxPt, double erPt)
        {
            serien.Add(new Serie(name, mxPt, erPt));
        }

        public string[] GetNameVonSerien()
        {
            string[] nameSerien = new string[serien.Count];
            int i = 0;
            foreach (Serie s in serien)
            {
                nameSerien[i] = s.name;
                i++;
            }
            return nameSerien;
        }

        public void RemoveSerie(string name)
        {
            serien.RemoveAt(GetNameVonSerien().ToList().IndexOf(name));
        }

        public double GetPercentage()
        {
            double max = 0;
            double got = 0;
            double percantage = 0;
            foreach (Serie s in serien)
            {
                max += s.mxPt;
                got += s.erPt;
            }
            try
            {
                percantage = (got / max);
            }
            catch (OverflowException e)
            {
                percantage = 0;
            }
            return percantage;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
