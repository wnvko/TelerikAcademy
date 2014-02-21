namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private readonly string manufacturer;
        private readonly string model;
        private decimal price;
        private Owner owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        private static GSM iPhone4S = new GSM("Apple", "iPhone 4s", 500m,
            "Bill", "Gates", "Li-Po", 200, 14, BatteryType.LiIon, 3.5, 14);

        // Constructors
        public GSM(string manufacturer, string model)
        {
            if (manufacturer.Length < 2 || !Char.IsLetter(manufacturer[0]))
            {
                throw new ArgumentException("Unacceptable manufacturer name (less than two chars or do not start with letter).");
            }

            this.manufacturer = manufacturer;

            if (model.Length < 2 || !Char.IsLetter(model[0]))
            {
                throw new ArgumentException("Unacceptable model name (less than two chars or do not start with letter).");
            }
            this.model = model;
            this.owner = new Owner();
            this.battery = new Battery();
            this.display = new Display();
            callHistory = new List<Call>();
        }

        public GSM(string manufacturer, string model, string ownerFirstName, string ownerSecondName)
            : this(manufacturer, model)
        {
            this.owner.FirstName = ownerFirstName;
            this.owner.SecondName = ownerSecondName;
        }

        public GSM(string manufacturer, string model, decimal price, string ownerFirstName, string ownerSecondName,
            string batteryModel, int batteryHoursIdle, int batteryHoursTalk,
            BatteryType batteryType, double displaySize, int displayNumberOfColors)
            : this(manufacturer, model, ownerFirstName, ownerSecondName)
        {
            this.Price = price;
            this.battery.Model = batteryModel;
            this.battery.HoursIdle = batteryHoursIdle;
            this.battery.HoursTalk = batteryHoursTalk;
            this.display.Size = displaySize;
            this.display.NumberOfColors = displayNumberOfColors;
        }

        // Properties
        public string Manufacturer
        {
            get { return this.manufacturer; }
        }

        public string Model
        {
            get { return this.model; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Input phone price less than 0.");
                }

                this.price = value;
            }
        }

        public string OwnerFirstName
        {
            get { return this.owner.FirstName; }
            set { this.owner.FirstName = value; }
        }

        public string OwnerSecondName
        {
            get { return this.owner.SecondName; }
            set { this.owner.SecondName = value; }
        }

        public string BatteryModel
        {
            get { return this.battery.Model; }
            set { this.battery.Model = value; }
        }

        public int BatteryHoursIdle
        {
            get { return this.battery.HoursIdle; }
            set { this.battery.HoursIdle = value; }
        }

        public int BatteryHoursTalk
        {
            get { return this.battery.HoursTalk; }
            set { this.battery.HoursTalk = value; }
        }

        public BatteryType BatteryType
        {
            get { return this.battery.BatteryType; }
            set { this.battery.BatteryType = value; }
        }

        public double DisplaySize
        {
            get { return this.display.Size; }
            set { this.display.Size = value; }
        }

        public int DisplayNumberOfColors
        {
            get { return this.display.NumberOfColors; }
            set { this.display.NumberOfColors = value; }
        }

        public static GSM IPhone4s
        {
            get { return iPhone4S; }
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }

        // Methods
        public void AddCall(DateTime callDate, string calledNumber, int callDuration)
        {
            this.callHistory.Add(new Call(callDate, calledNumber, callDuration));
        }

        public void RemoveCall(int callID)
        {
            if (callID >= this.CallHistory.Count)
            {
                throw new ArgumentException("Invalid call ID number input.");
            }

            this.CallHistory.RemoveAt(callID);
        }

        public decimal CallPriceCalculate(decimal pricePerMinute)
        {
            decimal totalPrice = 0m;
            foreach (var call in this.CallHistory)
            {
                totalPrice += pricePerMinute * call.CallDuration / 60;
            }

            return totalPrice;
        }

        public void ClearCallsHistory()
        {
            this.CallHistory.Clear();
        }
        public override string ToString()
        {
            StringBuilder mobilePhoneInformation = new StringBuilder();

            mobilePhoneInformation.Append(String.Format("Manufacturer: {0,12}\n", manufacturer));
            mobilePhoneInformation.Append(String.Format("Model: {0,19}\n", model));
            mobilePhoneInformation.Append(String.Format("Owner: {0} {1}", owner.FirstName, owner.SecondName));

            return mobilePhoneInformation.ToString();
        }
    }
}