using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BiometricalIdentify
{
    static class DifficultyChecker
    {
        static private Regex formatMid = new Regex("^[a-zA-Z0-9]+$");       //4
        static private Regex formatWeak = new Regex("^[a-zA-Z]+$");         //3
        static private Regex formatWeakMid1 = new Regex("^[A-Z0-9]+$");     //2
        static private Regex formatWeakMid2 = new Regex("^[a-z0-9]+$");     //2
        static private Regex formatWeakest1 = new Regex("^[A-Z]+$");        //1
        static private Regex formatWeakest2 = new Regex("^[a-z]+$");        //1

        static public byte difficultyCheck(string pass)
        {
            byte difficulty = 0;
            if (!String.IsNullOrEmpty(pass))
            {
                if (formatWeakest1.IsMatch(pass)
                    || formatWeakest2.IsMatch(pass))
                    difficulty += 1;
                else if (formatWeakMid1.IsMatch(pass)
                    || formatWeakMid2.IsMatch(pass)) difficulty += 2;
                else if (formatWeak.IsMatch(pass)) difficulty += 3;
                else if (formatMid.IsMatch(pass)) difficulty += 4;
                else difficulty += 5;

                if (pass.Length < 4) difficulty += 1;
                else if (pass.Length < 8) difficulty += 3;
                else difficulty += 5;
            }
            return difficulty;
        }
    }
}
