using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricalIdentify
{
    class Interval
    {
        private double value;
        private double from;
        private double to;

        public Interval(double from, double to, double value)
        {
            this.from = from;
            this.to = to;
            this.value = value;
        }

        public double Value()
        {
            return value;
        }

        public double From()
        {
            return from;
        }

        public double To()
        {
            return to;
        }
    }

    class StepFunction
    {
        private List<Interval> intervals;

        public StepFunction()
        {
            intervals = new List<Interval>();
        }

        public void AddInterval(double from, double to, double value)
        {
            Interval interval = new Interval(from, to, value);
            intervals.Add(interval);
        }

        public double GetValue(double x)
        {
            foreach (var i in intervals)
            {
                if (x <= i.To())
                    return i.Value();
            }
            return -1;
        }

        public double GetMaxX()
        {
            return intervals[intervals.Count - 1].To();
        }
    }
}
