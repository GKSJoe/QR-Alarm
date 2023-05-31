using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Alarm
{
    public class AlarmMaker
    {
        private DateTime alarmTime;
        private bool isOn;
        private bool isSnooze;
        private int volume;
        private int alarmTone;
        private int alarmType;

        public AlarmMaker(DateTime alarmTime, bool isOn=true, bool isSnooze=false, int volume=100, int alarmTone=0, int alarmType=0)
        {
            this.alarmTime = alarmTime;
        }
    }
}