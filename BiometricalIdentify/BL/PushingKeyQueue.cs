using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BiometricalIdentify
{
    class PushingKeyQueue
    {
        private List<PushingKey> keysStopwatches;
        private List<Stopwatch> overlays;
        private int amountOfOverlaysFstType = 0;
        private int amountOfOverlaysScndType = 0;
        private int amountOfOverlaysThrdType = 0;
        public List<double> holdingTimes;
        public List<double> overlaysTimes;

        public PushingKeyQueue()
        {
            keysStopwatches = new List<PushingKey>();
            overlays = new List<Stopwatch>();
            holdingTimes = new List<double>();
            overlaysTimes = new List<double>();
        }

        public void addNewPushingKey(int keyValue)
        {
            Stopwatch stpwtch = new Stopwatch();
            stpwtch.Start();
            keysStopwatches.Add(new PushingKey(keyValue, stpwtch));
            if (keysStopwatches.Count > 1)
            {
                Stopwatch overlay = new Stopwatch();
                overlay.Start();
                overlays.Add(overlay);
                amountOfOverlaysFstType++;
            }
            else
            {
                if (overlays.Count > 0)
                {
                    overlays[0].Stop();
                    double d = Convert.ToDouble(overlays[0].ElapsedMilliseconds) / 10;
                    overlaysTimes.Add(d);
                    overlays.RemoveAt(0);
                }
            }
        }

        public long getPushingTimeByKeyValue(int keyValue)
        {
            PushingKey pushingKey = null;
            long time = -1;
            foreach (PushingKey pk in keysStopwatches)
            {
                if (pk.getKeyValue() == keyValue)
                {
                    time = pk.stopStopwatchAndGetTime();
                    pushingKey = pk;
                }

            }
            if (pushingKey != null)
            {
                int idx = keysStopwatches.IndexOf(pushingKey);
                if (keysStopwatches.Count > 1)
                {
                    if (overlays.Count > 0)
                    {
                        overlays[0].Stop();
                        double d = -Convert.ToDouble(overlays[0].ElapsedMilliseconds) / 10;
                        overlaysTimes.Add(d);
                        overlays.RemoveAt(0);
                    }
                    if (idx == 0)
                        amountOfOverlaysScndType++;
                    else amountOfOverlaysThrdType++;
                }
                else {
                    Stopwatch overlay = new Stopwatch();
                    overlay.Start();
                    overlays.Add(overlay);
                }
                keysStopwatches.RemoveAt(idx);
            }
            holdingTimes.Add(Convert.ToDouble(time) / 10);
            return time;
        }

        public PushingKey getPushingKeyByKeyValue(int keyValue)
        {
            PushingKey pushingKey = null;
            foreach (PushingKey pk in keysStopwatches)
            {
                if (pk.getKeyValue() == keyValue)
                {
                    pk.stopStopwatch();
                    pushingKey = pk;
                }
            }
            if (pushingKey != null)
            {
                int idx = keysStopwatches.IndexOf(pushingKey);
                if (keysStopwatches.Count > 1)
                {
                    if (idx == 0)
                        amountOfOverlaysScndType++;
                    else amountOfOverlaysThrdType++;
                }
                keysStopwatches.RemoveAt(idx);
            }
            holdingTimes.Add(Convert.ToDouble(pushingKey.getTime()) / 10);
            return pushingKey;
        }

        public List<int> getKeyOverlays() {
            return new List<int> {amountOfOverlaysFstType, 
                                  amountOfOverlaysScndType, 
                                  amountOfOverlaysThrdType};
        }
    }
}
