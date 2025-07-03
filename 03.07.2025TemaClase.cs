using System;

namespace SignalMachine
{
    public class Signal
    {
        private string name;
        private double[] data;
        private double[] time;
        private int count;
        private static int recordsNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public double[] Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Signal(string n, double[] d, double[] t)
        {
            name = n;
            data = d;
            time = t;
            count = d.Length;
            recordsNumber++;
        }

        public void CleanNoise()
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i] < 0)
                {
                    data[i] = 0;
                }
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.Write("Data: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write("(" + data[i].ToString("F2") + ";" + time[i].ToString("F2") + ")  ");
            }
            Console.WriteLine();

            Console.WriteLine("\n");
        }

        public double[] GetData(double startTime, double endTime)
        {
            int resultSize = 0;
            for (int i = 0; i < count; i++)
            {
                if (time[i] >= startTime && time[i] <= endTime)
                {
                    resultSize++;
                }
            }

            double[] result = new double[resultSize];
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                if (time[i] >= startTime && time[i] <= endTime)
                {
                    result[index++] = data[i];
                }
            }

            return result;
        }

        public static Signal Merge(Signal s1, Signal s2)
        {
            int totalCount = s1.Count + s2.Count;
            double[] mergedData = new double[totalCount];
            double[] mergedTime = new double[totalCount];

            int index = 0;
            for (int i = 0; i < s1.Count; i++)
            {
                mergedData[index] = s1.Data[i];
                mergedTime[index] = s1.Time[i];
                index++;
            }
            for (int i = 0; i < s2.Count; i++)
            {
                mergedData[index] = s2.Data[i];
                mergedTime[index] = s2.Time[i];
                index++;
            }

            for (int i = 0; i < totalCount - 1; i++)
            {
                for (int j = i + 1; j < totalCount; j++)
                {
                    if (mergedTime[i] > mergedTime[j])
                    {
                        double tempData = mergedData[i];
                        double tempTime = mergedTime[i];

                        mergedData[i] = mergedData[j];
                        mergedTime[i] = mergedTime[j];

                        mergedData[j] = tempData;
                        mergedTime[j] = tempTime;
                    }
                }
            }

            return new Signal("MergedSignal", mergedData, mergedTime);
        }

        public static int GetRecordsNumber()
        {
            return recordsNumber;
        }
    }

    public class Machine
    {
        private string name;
        private Signal[] signals = new Signal[MAX_SIGNALS];
        private int currentSignalIndex = 0;
        private const int MAX_SIGNALS = 10;

        public Signal[] Signals
        {
            get { return signals; }
        }

        public Machine(string machineName)
        {
            name = machineName;
        }

        public void AddSignal(Signal signal)
        {
            if (currentSignalIndex < MAX_SIGNALS)
            {
                signals[currentSignalIndex++] = signal;
            }
        }

        public void ChangeSignal(int index, Signal signal)
        {
            if (index >= 0 && index < currentSignalIndex)
            {
                signals[index] = signal;
            }
        }

        public Signal GetMaxSignal(double timeValue)
        {
            Signal maxSignal = null;
            double max = double.MinValue;

            for (int i = 0; i < currentSignalIndex; i++)
            {
                Signal signal = signals[i];
                for (int j = 0; j < signal.Count; j++)
                {
                    if (signal.Time[j] >= timeValue - 1 && signal.Time[j] <= timeValue + 1)
                    {
                        if (signal.Data[j] > max)
                        {
                            max = signal.Data[j];
                            maxSignal = signal;
                        }
                    }
                }
            }

            return maxSignal;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Machine: " + name);
            Console.WriteLine("Signals:");
            for (int i = 0; i < currentSignalIndex; i++)
            {
                if (signals[i] != null)
                {
                    signals[i].PrintInfo();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Machine machine = new Machine("My Machine");
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                double[] data = new double[7];
                double[] time = new double[7];

                for (int j = 0; j < 7; j++)
                {
                    data[j] = random.NextDouble() * 20 - 10;
                    time[j] = random.NextDouble() + j;
                }

                Signal signal = new Signal("Signal" + i, data, time);
                machine.AddSignal(signal);
            }

            Console.WriteLine("Raw signals: ");
            machine.PrintInfo();

            Console.WriteLine();
            Signal mergedSignal = Signal.Merge(machine.Signals[0], machine.Signals[1]);
            mergedSignal.PrintInfo();

            Console.WriteLine();
            Console.WriteLine("Clean signals: ");
            foreach (Signal signal in machine.Signals)
            {
                if (signal != null)
                {
                    signal.CleanNoise();
                }
            }
            machine.PrintInfo();

            Console.WriteLine();
            Console.WriteLine("The signal with the highest value in time [4,6]: ");
            Signal maxSignal = machine.GetMaxSignal(5);
            maxSignal.PrintInfo();
        }
    }
}
