using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BiometricalIdentify
{
    class PushingKey
    {
        private Stopwatch stopwatch;
        private int keyValue;

        public PushingKey(int keyValue) {
            stopwatch = new Stopwatch();
            this.keyValue = keyValue;
        }
        public PushingKey(int keyValue, Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
            this.keyValue = keyValue;
        }

        public Stopwatch getStopwatch() {
            return stopwatch;
        }
        public long getTime()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        public int getKeyValue() {
            return keyValue;
        }

        public void setStopwatch(Stopwatch stopwatch) {
            this.stopwatch = stopwatch;
        }

        public void setKeyValue(int keyValue) {
            this.keyValue = keyValue;
        }

        public void startStopwatch() {
            stopwatch.Start();        
        }

        public void stopStopwatch() {
            stopwatch.Stop();
        }
        public long stopStopwatchAndGetTime()
        {
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long getStopwatchTime() {
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
