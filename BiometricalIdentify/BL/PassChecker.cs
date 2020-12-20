using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BiometricalIdentify
{
    class PassChecker
    {
        private PassingStatistic passingStatistic;

        public PassChecker()
        {
            passingStatistic = new PassingStatistic();
        }
        public PassChecker(String pass)
        {
            passingStatistic = new PassingStatistic();
        }

        public bool passCheck(String pass, User user)
        {
            if (String.IsNullOrEmpty(user.password))
            {
                passingStatistic.increaseTryingAmount();
                passingStatistic.updateInputSpeed(pass.Length);
                return user.authenticateUser(user.login, pass);
            }
            if (!String.IsNullOrEmpty(pass))
            {
                passingStatistic.increaseTryingAmount();
                passingStatistic.updateInputSpeed(pass.Length);
                if (pass.Equals(user.password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool passCheck(String pass, ref byte difficulty, User user)
        {
            difficulty = DifficultyChecker.difficultyCheck(pass);

            if (String.IsNullOrEmpty(user.password))
            {
                passingStatistic.increaseTryingAmount();
                passingStatistic.updateInputSpeed(pass.Length);
                passingStatistic.nextInputOverlays();
                user.password = pass;
                return true;
            }
            else
            {
                if (!String.IsNullOrEmpty(pass))
                {
                    passingStatistic.increaseTryingAmount();
                    passingStatistic.updateInputSpeed(pass.Length);
                    passingStatistic.nextInputOverlays();
                    if (pass.Equals(user.password))
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
