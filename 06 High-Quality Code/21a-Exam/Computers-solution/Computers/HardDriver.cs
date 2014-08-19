namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDriver
    {
        private int capacity;
        private IList<HardDriver> raidHdds;
        private Dictionary<int, string> noRaidHdd;

        public HardDriver(int capacity)
            : this(capacity, null)
        {
        }

        public HardDriver(IList<HardDriver> hardDrives)
            : this(0, hardDrives)
        {
        }

        public HardDriver(int capacity, IList<HardDriver> hardDrives)
        {
            this.Capacity = capacity;
            this.raidHdds = hardDrives;
            this.noRaidHdd = new Dictionary<int, string>(capacity);
        }

        public int Capacity
        {
            get
            {
                if (this.IsInRaid)
                {
                    if (!this.raidHdds.Any())
                    {
                        return 0;
                    }

                    return this.raidHdds.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }

            private set
            {
                this.capacity = value;
            }
        }

        private bool IsInRaid
        {
            get
            {
                return this.Capacity == 0 && this.raidHdds != null;
            }
        }

        public void SaveData(int addr, string newData)
        {
            if (this.IsInRaid)
            {
                foreach (var hardDrive in this.raidHdds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.noRaidHdd[addr] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.IsInRaid)
            {
                if (!this.raidHdds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.raidHdds.First().LoadData(address);
            }
            else
            {
                return this.noRaidHdd[address];
            }
        }
    }
}
