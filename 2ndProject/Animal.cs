using System;
using System.Collections;
using System.Collections.Generic;

namespace ndProject {

    public struct Dimensiune {
        public decimal lungime;
        public decimal latime;
        public decimal inaltime;
    }

    abstract class Animal {

        public string nume;
        private decimal greutate; 
        private decimal viteza;

        private List<Mancare> stomac = new List<Mancare>();

        public List<Mancare> Stomac {
            get { return stomac; }
            set { stomac = value; }
        }
 

        //generate struct
        Dimensiune dimensiune;//private default

        //constructor
        private static int contor = 0;

        public static int Contor {//static in order to access it
            get { return contor; }
            set { contor = value; }
        }

        protected Animal(
            string nume,
            decimal greutate,
            decimal viteza,
            Dimensiune dimensiune) {

            contor++;
            this.nume = nume;
            this.greutate = greutate;
            this.viteza = viteza;
            this.dimensiune = dimensiune;
        }

        protected Animal() {

        }

        public virtual void Mananca(Mancare m) {
            //in order to override i use virtual

            if(m.greutate < (decimal)0.125 * this.greutate) {

                stomac.Add(m);
                Console.WriteLine("mananca");
            }
        }

        public abstract double Energie();// will return energy

        public void Alearga(decimal distanta) {
            
            double energie = Energie();// se apeleaza energie
            decimal timp = 0;

            decimal divider = this.viteza / (decimal)energie;


            if(divider == 0) {
                timp = 0;
            } else {
                timp = distanta / divider;
            }         

            Console.WriteLine("parcurge in " + timp + " secunde");
        }

        public override string ToString() {

            return "\n tip animal: "
                + GetType()
                + "\n nume: "
                + nume
                + "\n greutate: "
                + greutate
                + "kg"
                + "\n dimensiuni: "
                + dimensiune.lungime
                + " "
                + dimensiune.latime
                + " "
                + dimensiune.inaltime
                + "(lungime latime inaltime)"
                + "\n viteza: "
                + viteza
                + "m/s";
        }
    }
}
