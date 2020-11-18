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
        private int amountOfOverlaysFstType = 0;
        private int amountOfOverlaysScndType = 0;
        private int amountOfOverlaysThrdType = 0;

        public PushingKeyQueue()
        {
            keysStopwatches = new List<PushingKey>();
        }

        public void addNewPushingKey(int keyValue)
        {
            Stopwatch stpwtch = new Stopwatch();
            stpwtch.Start();
            keysStopwatches.Add(new PushingKey(keyValue, stpwtch));
            if (keysStopwatches.Count > 1) {
                amountOfOverlaysFstType++;
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
                if(keysStopwatches.Count > 1)
                {
                    if (idx == 0)
                        amountOfOverlaysScndType++;
                    else amountOfOverlaysThrdType++;
                }
                keysStopwatches.RemoveAt(idx);
            }
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
            return pushingKey;
        }

        public List<int> getKeyOverlays() {
            return new List<int> {amountOfOverlaysFstType, 
                                  amountOfOverlaysScndType, 
                                  amountOfOverlaysThrdType};
        }
    }
}
