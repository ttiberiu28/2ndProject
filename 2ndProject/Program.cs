using System;
using System.Collections.Generic;

namespace ndProject {


    class MainClass {

        enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca }

         static Animal CreeazaAnimal
            (TipAnimal tip,
             string nume,
             decimal greutate,
             Dimensiune dim,
             decimal viteza) {

            Animal a = null;

            if(tip == TipAnimal.Lup || tip == TipAnimal.Pisica) {
                Carnivor c = new Carnivor(nume,greutate,viteza,dim);
                a = c;

            }else if(tip == TipAnimal.Oaie || tip == TipAnimal.Vaca) {
                Erbivor e = new Erbivor(nume,greutate,viteza,dim);
                a = e;

            }else if (tip == TipAnimal.Urs || tip == TipAnimal.Veverita) {
                Omnivor o = new Omnivor(nume,greutate,viteza,dim);
                a = o;
            }

            return a;
         }

        public static void Main(string[] args) {


            Dimensiune dimensiuneL = new Dimensiune();//new struct
            Dimensiune dimensiuneO = new Dimensiune();//new struct
            Dimensiune dimensiuneU = new Dimensiune();//new struct

            dimensiuneL.lungime = 2;
            dimensiuneL.latime = 0.5M;
            dimensiuneL.inaltime = 1;

            dimensiuneO.lungime = 1.5M;
            dimensiuneO.latime = 0.5M;
            dimensiuneO.inaltime = 1;

            dimensiuneL.lungime = 3;
            dimensiuneL.latime = 1.5M;
            dimensiuneL.inaltime = 2;

            Carnivor lup = new Carnivor("Jon",70,80,dimensiuneL);
            Erbivor oaie = new Erbivor("Tim",25,15,dimensiuneO);
            Omnivor urs = new Omnivor("Cassey",250,30,dimensiuneU);

            Planta salata = new Planta(0.01M, 0.01M);
            Carne sunca = new Carne(0.5M, 0.05M);

            //functia .Mananca() e ok optimizata
            lup.Mananca(sunca);
            lup.Mananca(sunca);

            oaie.Mananca(salata);
            oaie.Mananca(salata);
            oaie.Mananca(salata);

            urs.Mananca(sunca);
            urs.Mananca(salata);
            urs.Mananca(salata);
            urs.Mananca(salata);

            //sa ma mai uit pe alearga
            lup.Alearga(200);
            oaie.Alearga(200);
            urs.Alearga(200);


            Console.WriteLine("S-au creat " + Animal.Contor + " animale");

            Console.WriteLine(lup);

            //create list and generate random values from enum

            List<Animal> l = new List<Animal>();

            Random random = new Random();//creez o variabila rnadom
            Type type = typeof(TipAnimal);

            Array valori = type.GetEnumValues();
            //pun valorile enumului intr un array
            Dimensiune dimens;

            for(int i = 0; i < 10; i++) {

                int idx = random.Next(valori.Length);//iterez prin array
                TipAnimal valoare = (TipAnimal)valori.GetValue(idx);

                decimal greutate = random.Next(10,200);
                decimal viteza = random.Next(20,100);

                //genereate doubles between (x <-> y)
                double lungime = random.NextDouble() * (3 - 0.2) + 0.2;
                double latime = random.NextDouble() * (1.5 - 0.1) + 0.1;
                double inaltime = random.NextDouble() * (2 - 0.4) + 0.4;

                dimens.lungime = (decimal)lungime;
                dimens.latime = (decimal)latime;
                dimens.inaltime = (decimal)inaltime;
                

                Animal a =
                    MainClass.CreeazaAnimal(valoare,"Animal",greutate,dimens,viteza);

                l.Add(a);
            }

            //initialize counters

            int pCount = 0;
            int cCount = 0;
            int mCount = 0;

            foreach(Animal x in l) {

                int r = random.Next(0,2);

                if(x is Carnivor) {
                    ((Carnivor)x).Mananca(sunca);
                    cCount++;
                }else if(x is Erbivor) {
                    ((Erbivor)x).Mananca(salata);
                    pCount++;
                }else if(x is Omnivor) {
                    if(r == 0) {
                        x.Mananca(salata);
                        mCount++;
                    } else {
                        x.Mananca(sunca);
                        mCount++;
                    }
                    
                }
            }

            //doar pt cele 10 instantiate in lista
            Console.WriteLine("Animale care mananca carne: " + cCount);
            Console.WriteLine("Animale care mananca plante: " + pCount);
            Console.WriteLine("Animale care mananca mancaree: " + mCount);
           
        }
    }
}
