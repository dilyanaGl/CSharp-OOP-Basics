
using System;

class PressureProvider : Provider
    {
        public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
        {
            this.EnergyOutput += (50 * this.EnergyOutput) / 100;
        }

        public override string ToString()
        {
            return $"Pressure Provider - {Id}" + Environment.NewLine + base.ToString();
        }
}

