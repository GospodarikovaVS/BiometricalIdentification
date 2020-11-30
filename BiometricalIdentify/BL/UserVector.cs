using System;
using System.Collections.Generic;

namespace BiometricalIdentify
{
    class UserVector
    {
        public static double[] GetUserVector(int N, List<double> pressingTime, List<double> timeBetweenPressing)
        {
            if (pressingTime.Count != 0 && timeBetweenPressing.Count != 0)
            {
                var haarMatrix = HaarMatrix();
                var discretizedFunction = DiscretizedStepFunction(pressingTime, timeBetweenPressing);
                return MatrixVectorMultiplication(haarMatrix, discretizedFunction);
            }
            else {
                return new double[1];
			}
        }
        private static Func<double, double>[] HaarVector(int N)
        {
            if (N < 0)
                throw new Exception("Wrong parametr N given");
            Func<double, double>[] haarVector = new Func<double, double>[N];
            haarVector[0] = (double t) => 1;

            int log = Convert.ToInt32(Math.Floor(Math.Log(N, 2)));
            int pow = 1;
            for (int r = 0, count = 1; r < log; r++)
            {
                for (int m = 1; m <= pow; m++, count++)
                {
                    haarVector[count] = (double t) => haar(pow, m, t);
                }
                pow *= 2;
            }

            return haarVector;
        }
        private static double haar(int pow, int m, double t)
        {
            if (t < 0 || t >= 1)
                throw new Exception("Wrong time t parametr");
            double temp = ((double)m - 0.5) / pow;
            if (t >= ((double)(m - 1)) / pow && t < temp)
            {
                return Math.Sqrt(pow);
            }
            else if (t >= temp && t < (double)m / pow)
            {
                return -Math.Sqrt(pow);
            }
            return 0;
        }
        private static double[] MatrixVectorMultiplication(double[,] matrix, List<int> vector)
        {
            double[] result = new double[vector.Count];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                result[r] = 0;
                for (int c = 0; c < matrix.GetLength(1); c++)
                    result[r] += matrix[r, c] * vector[c];
            }
            return result;
        }
        private static StepFunction GetStepFunction(List<double> press, List<double> between)
        {
            const int A = 1;
            StepFunction sf = new StepFunction();
            double x = 0;

            for (int i = 0; i < press.Count; i++)
            {
            }

            return sf;
        }
        private static List<int> DiscretizedStepFunction(List<double> pressing, List<double> between)
        {
            int range = 0;
            int index = 0;

            double x1 = 0;
            double x2 = 0;

            List<double> tau = between;
            List<double> press = pressing;

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            List<int> list0 = new List<int>();

            int count = tau.Count;
            for (int i = 0; i < count; i++)
            {
                range += Convert.ToInt32(tau[i] + press[i]);
                index = i;
            }
            range += Convert.ToInt32(press[index + 1]);

            for (int i = 0; i < count; i++)
            {
                if (tau[i] < 0)
                {
                    x1 += press[i] + tau[i];
                    x2 = x1 - tau[i];
                    list2.Add(Convert.ToInt32(x1));
                    list2.Add(Convert.ToInt32(x2));
                }
                else
                {
                    x1 += press[i] + tau[i];
                }
            }

            x2 = 0;
            x1 = 0;

            for (int i = 0; i < count; i++)
            {
                if (tau[i] > 0)
                {
                    x2 += press[i] + tau[i];
                    x1 = x2 - tau[i];
                    list0.Add(Convert.ToInt32(x1));
                    list0.Add(Convert.ToInt32(x2));
                }
                else
                {
                    x2 += press[i] + tau[i];
                }
            }

            int rangestep = range / 8;
            int step = range / 8;
            List<int> vector = new List<int>();

            int c0 = list0.Count;
            int c2 = list2.Count;

            bool isadded = false;

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < c0; k += 2)
                {
                    if (step > list0[k] && step < list0[k + 1])
                    {
                        vector.Add(0);
                        isadded = true;
                    }
                }

                if (!isadded)
                {
                    for (int k = 0; k < c2; k += 2)
                    {
                        if (step > list2[k] && step < list2[k + 1])
                        {
                            vector.Add(2);
                            isadded = true;
                        }
                    }
                }

                if (!isadded)
                    vector.Add(1);

                step += rangestep;
                isadded = false;
            }

            return vector;
        }

        private static double[,] HaarMatrix()
        {
            return new double[,] {
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, -1, -1, -1, -1 },
                { Math.Sqrt(2), Math.Sqrt(2), -Math.Sqrt(2), -Math.Sqrt(2), 0, 0, 0, 0 },
                { 0, 0, 0, 0, Math.Sqrt(2), Math.Sqrt(2), -Math.Sqrt(2), -Math.Sqrt(2) },
                { 2, -2, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 2, -2, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 2, -2, 0, 0},
                { 0, 0, 0, 0, 0, 0, 2, -2 }
            };
        }
    }

}

   