
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Computers;

//namespace Computers
//{

//    public class OldHardDrive
//    {

//        bool isInRaid;
//        int hardDrivesInRaid;
//        int capacity;
//        Dictionary<int, string> data;

//        List<OldHardDrive> hds;
//        internal OldHardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
//        {
//            this.isInRaid = isInRaid;
//            this.hardDrivesInRaid = hardDrivesInRaid;

//            this.capacity = capacity;
//            this.data = new Dictionary<int, string>(capacity);

//            this.hds = new List<OldHardDrive>();
//        }

//        internal OldHardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, List<OldHardDrive> hardDrives)
//        {
//            this.isInRaid = isInRaid;
//            this.hardDrivesInRaid = hardDrivesInRaid;
//            this.capacity = capacity;
//            this.data = (Dictionary<int, string>)new Dictionary<int, string>(capacity);
//            this.hds = new List<OldHardDrive>();
//            this.hds = hardDrives;
//        }

//        public int Capacity
//        {
//            get
//            {
//                if (isInRaid)
//                {
//                    if (!this.hds.Any())
//                    {
//                        return 0;
//                    }

//                    return this.hds.First().Capacity;
//                }

//                else
//                {
//                    return this.capacity;
//                }
//            }
//        }

//        public void SaveData(int address, string newData)
//        {
//            if (isInRaid)
//            {
//                foreach (var hardDrive in this.hds)
//                {
//                    hardDrive.SaveData(address, newData);
//                }
//            }
//            else
//            {
//                this.data[address] = newData;
//            }
//        }

//        string LoadData(int address)
//        {
//            if (isInRaid)
//            {
//                if (!this.hds.Any())
//                {
//                    throw new OutOfMemoryException("No hard drive in the RAID array!");
//                }

//                return this.hds.First().LoadData(address);
//            }
//            else if (true)
//            {
//                return this.data[address];
//            }
//        }
//    }
//}