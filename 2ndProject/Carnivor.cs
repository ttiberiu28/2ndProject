using System;
using System.Collections.Generic;

namespace ndProject {

    class Carnivor : Animal {


        public Carnivor(
            string nume,
            decimal greutate,
            decimal viteza,
            Dimensiune dimensiune) : base(nume,greutate,viteza,dimensiune) {

        }

        public override void Mananca(Mancare m) {

            //check for type of m
            if(m is Carne)  {
                base.Mananca(m);
            } else {
                Console.WriteLine("Animal can only eat meat");
            }
            
        }

        public override double Energie() {

            decimal sum1 = 0;//suma greutatii mancarii
            decimal sum2 = 0;//suma energiei mancarii

            foreach(var x in Stomac) {

                sum1 += x.greutate;// suma greutatii mancarii mancate
                sum2 += x.energie;//suma energiei

                //Console.WriteLine(sum1);
                //Console.WriteLine(sum2);
            }

            decimal medieG;

            if(Stomac.Count == 0) {
                medieG = 0;
            } else {
                medieG = sum1 / Stomac.Count;
            }

            
            return 0.2 - 0.2 * (double)medieG + (double)sum2;

        }

    }
}
