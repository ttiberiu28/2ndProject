using System;
using System.Collections.Generic;

namespace ndProject {

    class Omnivor : Animal {

        public Omnivor(
            string nume,
            decimal greutate,
            decimal viteza,
            Dimensiune dimensiune) : base(nume,greutate,viteza,dimensiune) {
        }

        public override double Energie() {

            decimal sum1 = 0;//suma greutatii mancarii
            decimal sum2 = 0;//suma energiei mancarii
            double coefG = 0;

            foreach(var x in Stomac) {
                sum1 += x.greutate;// suma greutatii mancarii mancate
                sum2 += x.energie;

                if (x is Planta) {
                    coefG = 0.5;
                } else if(x is Carne) {
                    coefG = -0.5;
                }
            }

            decimal medieG;

            if(Stomac.Count == 0) {
                medieG = 0;
            } else {
                medieG = sum1 / Stomac.Count;
            }

            return 0.35 + (coefG * (double)medieG) + (double)sum2;

        }
    }
}
