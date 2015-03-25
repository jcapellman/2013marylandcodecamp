using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace jcBENCH2.library {
    public class Benchmark {        
        public Benchmark() { }

        public int Run() {            
            var rnd = new Random();

            return rnd.Next(1, 200);
        }
    }
}
