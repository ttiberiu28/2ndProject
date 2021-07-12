using System;
using System.Collections.Generic;

namespace ndProject {

    class Erbivor : Animal{

        public Erbivor(string nume,
                       decimal greutate,
                       decimal viteza,
                       Dimensiune dimensiune) : base(nume,greutate,viteza,dimensiune) {
        }


        public override void Mananca(Mancare m) {

            //check for type of m
            if(m is Planta) {
                base.Mananca(m);
            } else {
                Console.WriteLine("Animal can only eat plants");
            }

        }

        public override double Energie() {

            decimal sum1 = 0;//suma greutatii mancarii
            decimal sum2 = 0;//suma energiei mancarii

            foreach(var x in Stomac) {
                sum1 += x.greutate;// suma greutatii mancarii mancate
                sum2 += x.energie;
            }

            //Console.WriteLine(Stomac.Count);

            decimal medieG;

            if(Stomac.Count == 0) {
                medieG = 0;
            } else {
                medieG = sum1 / Stomac.Count;
            }

            return 0.5 + 1 / 3 * (double)medieG + (double)sum2;

        }
    }
}
