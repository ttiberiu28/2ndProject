using System;

namespace ndProject {

    abstract class Mancare {

        public decimal greutate;
        public decimal energie;


        public Mancare() { }

        public Mancare(decimal greutate, decimal energie) {

            this.greutate = greutate;
            this.energie = energie;
            
        }
    }
}
