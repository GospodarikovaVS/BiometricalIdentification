using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricalIdentify
{
    class PassingStatistic
    {
        private int tryingAmount;

        //2
        public List<long> inputTimes;
        public List<double> inputSpeeds;
        private double speedsMathExp;
        private double speedsMathExpSqrt;
        private double speedsDispersion;

        //3
        private List<List<long>> timesWithoutHold;

        //4
        private List<List<long>> holdingTimes;

        //5
        private List<List<int>> inputKeyOverlays;

        public PassingStatistic()
        {
            tryingAmount = 0;
            inputTimes = new List<long>();
            inputSpeeds = new List<double>();
            speedsMathExp = 0.0;
            speedsMathExpSqrt = 0.0;
            speedsDispersion = 0.0;
            inputKeyOverlays = new List<List<int>>();
            holdingTimes = new List<List<long>>();
            timesWithoutHold = new List<List<long>>();
        }

        public void increaseTryingAmount()
        {
            tryingAmount++;
        }

        public void increaseInputTime(long time)
        {
            if (inputTimes.Count < tryingAmount)
            {
                inputTimes.Add(0);
            }
            inputTimes[tryingAmount] += time;
        }

        public void updateInputSpeed(int passCount)
        {
            inputSpeeds.Add((double)passCount * 1000 / (double)inputTimes[inputSpeeds.Count]);
            updateMathExpAndDispersion();
        }

        private void updateMathExpAndDispersion()
        {
            speedsMathExp = (inputSpeeds.Last() + speedsMathExp * (inputSpeeds.Count() - 1)) / (inputSpeeds.Count());
            speedsMathExpSqrt = (inputSpeeds.Last() * inputSpeeds.Last() + speedsMathExpSqrt * (inputSpeeds.Count() - 1)) / (inputSpeeds.Count());
            speedsDispersion = speedsMathExpSqrt - speedsMathExp * speedsMathExp;
        }
        public void addInputSpeedTime(long time)
        {
            inputTimes.Add(time);
        }

        public List<double> getInputSpeeds()
        {
            return inputSpeeds;
        }
        public double getInputSpeed()
        {
            return inputSpeeds[tryingAmount - 1];
        }

        public double[] getInputSpeedsAsArray()
        {
            return inputSpeeds.ToArray();
        }

        public void addTimeWithoutHold(long time)
        {
            if (timesWithoutHold.Count <= tryingAmount)
            {
                timesWithoutHold.Add(new List<long>());
            }
            timesWithoutHold[tryingAmount].Add(time);
        }

        public List<List<long>> getCommonTimesWithoutHold()
        {
            return timesWithoutHold;
        }
        public List<long> getCurTimesWithoutHold()
        {
            return timesWithoutHold[tryingAmount - 1];
        }

        public long[] getCurTimesWithoutHoldAsArray()
        {
            return timesWithoutHold[tryingAmount - 1].ToArray();
        }

        public void addHoldingTime(long time)
        {
            if (holdingTimes.Count <= tryingAmount)
            {
                holdingTimes.Add(new List<long>());
            }
            holdingTimes[tryingAmount].Add(time);
        }

        public List<List<long>> getCommonHoldingTimes()
        {
            return holdingTimes;
        }

        public List<long> getCurHoldingTimes()
        {
            return holdingTimes[tryingAmount - 1];
        }

        public long[] getCurHoldingTimesAsArray()
        {
            return holdingTimes[tryingAmount - 1].ToArray();
        }

        public void nextInputOverlays()
        {
            inputKeyOverlays.Add(new List<int> { 0, 0, 0 });
        }

        public void increaseKeyOverlaysFstType()
        {
            inputKeyOverlays[tryingAmount][0]++;
        }

        public void increaseKeyOverlaysSndType()
        {
            inputKeyOverlays[tryingAmount][1]++;
        }

        public void increaseKeyOverlaysThrdType()
        {
            inputKeyOverlays[tryingAmount][2]++;
        }

        public void addKeyOverlays(List<int> amountOverlays)
        {
            if (inputKeyOverlays.Count - 1 < tryingAmount)
                nextInputOverlays();
            inputKeyOverlays[tryingAmount][0] += amountOverlays[0];
            inputKeyOverlays[tryingAmount][1] += amountOverlays[1];
            inputKeyOverlays[tryingAmount][2] += amountOverlays[2];
        }

        public List<int> getLastKeyOverlays()
        {
            return inputKeyOverlays[tryingAmount - 1];
        }

        public int getLastKeyOverlaysFstType()
        {
            return inputKeyOverlays[tryingAmount - 1][0];
        }

        public int getLastKeyOverlaysSndType()
        {
            return inputKeyOverlays[tryingAmount - 1][1];
        }

        public int getLastKeyOverlaysThrdType()
        {
            return inputKeyOverlays[tryingAmount - 1][2];
        }

        public List<List<int>> getKeyOverlays()
        {
            return inputKeyOverlays;
        }

        public double getDispersion()
        {
            return speedsDispersion;
        }

        public double getMathExp()
        {
            return speedsMathExp;
        }

    }
}
