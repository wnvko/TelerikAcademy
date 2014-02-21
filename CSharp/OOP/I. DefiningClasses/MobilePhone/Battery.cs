namespace MobilePhone
{
    using System;

    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }

    internal class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;

        // Constructors
        internal Battery()
        {
        }

        internal Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
            : this()
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        // Properties
        internal string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Unacceptable battery model name lenght (less than two chars).");
                }

                this.model = value;
            }
        }

        internal int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong battery idle time input. Battery idle time must be more than 0.");
                }

                this.hoursIdle = value;
            }
        }

        internal int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong battery talk time input. Battery talk time must be more than 0.");
                }

                this.hoursTalk = value;
            }
        }

        internal BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                if (value.ToString() != "LiIon" && value.ToString() != "NiMH" && value.ToString() != "NiCd")
                {
                    throw new ArgumentException("Wrong battery type input. Battery type value can be LiIon, NiMH or NiCd");
                }

                this.batteryType = value;
            }
        }
    }
}