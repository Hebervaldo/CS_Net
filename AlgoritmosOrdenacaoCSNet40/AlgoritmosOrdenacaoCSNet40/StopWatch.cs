using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmosOrdenacaoCSNet40
{
    public class StopWatch
    {
        private long start = 0;
        private long elapsedTime = 0;
        private long stop = 0;

        public StopWatch()
        {
            Start();
        }

        public void Start()
        {
            start = System.DateTime.Now.Ticks;
            stop = start;
        }

        public void Stop()
        {
            stop = System.DateTime.Now.Ticks;
        }

        public void Reset()
        {
            Start();
        }

        /**
        * Return elapsed time (in seconds) since this object was created.
        */
        public long Elapsed()
        {
            return System.Convert.ToInt64(ElapsedMiliSegundos() / 1000.0);
        }

        public long ElapsedMiliSegundos()
        {
            return System.Convert.ToInt64((new System.TimeSpan(stop - start)).Ticks / 10000);
        }

        public System.TimeSpan ElapsedDate()
        {
            return new System.TimeSpan((long)ElapsedMiliSegundos());
        }
    }
}
