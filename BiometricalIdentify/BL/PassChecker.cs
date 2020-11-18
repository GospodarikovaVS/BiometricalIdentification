using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BiometricalIdentify
{
    class PassChecker
    {
        private PassingStatistic passingStatistic;
        private String canonPass;
        private Regex formatMid = new Regex("^[a-zA-Z0-9]+$");       //4
        private Regex formatWeak = new Regex("^[a-zA-Z]+$");         //3
        private Regex formatWeakMid1 = new Regex("^[A-Z0-9]+$");     //2
        private Regex formatWeakMid2 = new Regex("^[a-z0-9]+$");     //2
        private Regex formatWeakest1 = new Regex("^[A-Z]+$");        //1
        private Regex formatWeakest2 = new Regex("^[a-z]+$");        //1

        public PassChecker()
        {
            passingStatistic = new PassingStatistic();
            canonPass = null;
        }
        public PassChecker(String pass)
        {
            passingStatistic = new PassingStatistic();
            this.canonPass = pass;
        }

        public bool passCheck(String pass)
        {
            if (String.IsNullOrEmpty(canonPass))
            {
                passingStatistic.increaseTryingAmount();
                passingStatistic.updateInputSpeed(pass.Length);
                canonPass = pass;
                return true;
            }
            else
            {
                if (!String.IsNullOrEmpty(pass))
                {
                    passingStatistic.increaseTryingAmount();
                    passingStatistic.updateInputSpeed(pass.Length);
                    if (pass.Equals(canonPass))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool passCheck(String pass, ref byte difficulty)
        {
            difficulty = 0;
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

            if (String.IsNullOrEmpty(canonPass))
            {
                passingStatistic.increaseTryingAmount();
                passingStatistic.updateInputSpeed(pass.Length);
                passingStatistic.nextInputOverlays();
                canonPass = pass;
                return true;
            }
            else
            {
                if (!String.IsNullOrEmpty(pass))
                {
                    passingStatistic.increaseTryingAmount();
                    passingStatistic.updateInputSpeed(pass.Length);
                    passingStatistic.nextInputOverlays();
                    if (pass.Equals(canonPass))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void addKeyStatistics(long time) {
            passingStatistic.addHoldingTime(time);
        }

        public void addFullTime(long time) {
            passingStatistic.addInputSpeedTime(time);
        }

        public void addKeyOverlays(List<int> overlays)
        {
            passingStatistic.addKeyOverlays(overlays);
        }

        public List<double> getInputSpeeds() {
            return passingStatistic.getInputSpeeds();
        }
        
        public double getLastInputSpeed()
        {
            return passingStatistic.getInputSpeed();
        }

        public double getDispersion()
        {
            return passingStatistic.getDispersion();
        }

        public double getMathExp() {
            return passingStatistic.getMathExp();
        }

        public List<int> getLastKeyOverlays()
        {
            return passingStatistic.getLastKeyOverlays();
        }

        public int getLastKeyOverlaysFstType()
        {
            return passingStatistic.getLastKeyOverlaysFstType();
        }

        public int getLastKeyOverlaysSndType()
        {
            return passingStatistic.getLastKeyOverlaysSndType();
        }

        public int getLastKeyOverlaysThrdType()
        {
            return passingStatistic.getLastKeyOverlaysThrdType();
        }
    }
}
