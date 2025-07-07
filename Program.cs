/*using System;
using System.Collections.Generic;

namespace SignalMachine
{
    public interface ITest
    {
        void RunTest();
        string GetTestResults();
    }

    public class Signal
    {
        private string name;
        private double[] data;
        private double[] time;

        public string Name => name;
        public double[] Data => data;
        public double[] Time => time;
        public int Count => data.Length;

        public Signal(string name, double[] data, double[] time)
        {
            this.name = name;
            this.data = data;
            this.time = time;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.Write("Data: ");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("(" + data[i].ToString("F2") + ";" + time[i].ToString("F2") + ")  ");
            }
            Console.WriteLine("\n");
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

    public class TestMachineSignalOscillations : ITest
    {
        private string result;
        private string testName;
        private List<Signal> signals = new List<Signal>();
        public static double threshold;

        public TestMachineSignalOscillations(string name)
        {
            testName = name;
            result = "";
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            bool passed = false;
            foreach (Signal signal in signals)
            {
                if (signal != null)
                {
                    for (int i = 1; i < signal.Count; i++)
                    {
                        double diff = Math.Abs(signal.Data[i] - signal.Data[i - 1]);
                        if (diff > threshold)
                        {
                            passed = true;
                            break;
                        }
                    }
                    if (passed) break;
                }
            }
            result = testName + ": " + (passed ? "PASSED" : "FAILED");
        }

        public string GetTestResults()
        {
            return result;
        }
    }

    public class TestMachineSignalNoise : ITest
    {
        private string result;
        private string testName;
        private List<Signal> signals = new List<Signal>();

        public TestMachineSignalNoise(string name)
        {
            testName = name;
            result = "";
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            bool passed = false;
            foreach (Signal signal in signals)
            {
                if (signal != null)
                {
                    double var = signal.GetVariance();
                    foreach (double val in signal.Data)
                    {
                        if (val > var)
                        {
                            passed = true;
                            break;
                        }
                    }
                    if (passed) break;
                }
            }
            result = testName + ": " + (passed ? "PASSED" : "FAILED");
        }

        public string GetTestResults()
        {
            return result;
        }
    }

    public class TestMachines<T> where T : ITest
    {
        private List<T> tests = new List<T>();

        public void AddTest(T test)
        {
            tests.Add(test);
        }

        public void RunTests()
        {
            foreach (T test in tests)
            {
                test.RunTest();
            }
        }

        public void PrintResults()
        {
            foreach (T test in tests)
            {
                Console.WriteLine(test.GetTestResults());
            }
        }
    }

    public static class SignalExtensions
    {
        public static double GetVariance(this Signal signal)
        {
            double[] data = signal.Data;
            int count = signal.Count;

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }
            double mean = sum / count;
            double variance = 0;
            for (int i = 0; i < count; i++)
            {
                variance += (data[i] - mean) * (data[i] - mean);
            }
            return variance / count;
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

            TestMachineSignalOscillations testOsc = new TestMachineSignalOscillations("Oscillation Test");
            TestMachineSignalOscillations.threshold = 1;
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testOsc.AddSignal(s);
            }

            TestMachineSignalNoise testNoise = new TestMachineSignalNoise("Noise Test");
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testNoise.AddSignal(s);
            }

            TestMachines<ITest> tester = new TestMachines<ITest>();
            tester.AddTest(testOsc);
            tester.AddTest(testNoise);

            tester.RunTests();
            tester.PrintResults();
        }
    }
}
*/


/*using System;
using System.Collections.Generic;

namespace SignalMachine
{
    public interface ITest
    {
        void RunTest();
        string GetTestResults();
    }

    public class Signal
    {
        private string name;
        private double[] data;
        private double[] time;

        public string Name => name;
        public double[] Data => data;
        public double[] Time => time;
        public int Count => data.Length;

        public Signal(string name, double[] data, double[] time)
        {
            this.name = name;
            this.data = data;
            this.time = time;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.Write("Data: ");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("(" + data[i].ToString("F2") + ";" + time[i].ToString("F2") + ")  ");
            }
            Console.WriteLine("\n");
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

    public class TestMachineSignalOscillations : ITest
    {
        private List<string> results = new List<string>();
        private string testName;
        public static double threshold;
        private List<Signal> signals = new List<Signal>();

        public TestMachineSignalOscillations(string name)
        {
            testName = name;
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            results.Clear();
            foreach (Signal signal in signals)
            {
                bool passed = false;
                for (int i = 1; i < signal.Count; i++)
                {
                    double diff = Math.Abs(signal.Data[i] - signal.Data[i - 1]);
                    if (diff > threshold)
                    {
                        passed = true;
                        break;
                    }
                }
                results.Add(signal.Name + ": " + (passed ? "PASSED" : "FAILED"));
            }
        }

        public string GetTestResults()
        {
            return testName + " Results:\n" + string.Join("\n", results);
        }
    }

    public class TestMachineSignalNoise : ITest
    {
        private List<string> results = new List<string>();
        private string testName;
        private List<Signal> signals = new List<Signal>();

        public TestMachineSignalNoise(string name)
        {
            testName = name;
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            results.Clear();
            foreach (Signal signal in signals)
            {
                double var = signal.GetVariance();
                bool passed = false;
                foreach (double val in signal.Data)
                {
                    if (val > var)
                    {
                        passed = true;
                        break;
                    }
                }
                results.Add(signal.Name + ": " + (passed ? "PASSED" : "FAILED"));
            }
        }

        public string GetTestResults()
        {
            return testName + " Results:\n" + string.Join("\n", results);
        }
    }

    public class TestMachines<T> where T : ITest
    {
        private List<T> tests = new List<T>();

        public void AddTest(T test)
        {
            tests.Add(test);
        }

        public void RunTests()
        {
            foreach (T test in tests)
            {
                test.RunTest();
            }
        }

        public void PrintResults()
        {
            foreach (T test in tests)
            {
                Console.WriteLine(test.GetTestResults());
            }
        }
    }

    public static class SignalExtensions
    {
        public static double GetVariance(this Signal signal)
        {
            double[] data = signal.Data;
            int count = signal.Count;

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }
            double mean = sum / count;
            double variance = 0;
            for (int i = 0; i < count; i++)
            {
                variance += (data[i] - mean) * (data[i] - mean);
            }
            return variance / count;
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

            TestMachineSignalOscillations testOsc = new TestMachineSignalOscillations("Oscillation Test");
            TestMachineSignalOscillations.threshold = 5;
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testOsc.AddSignal(s);
            }

            TestMachineSignalNoise testNoise = new TestMachineSignalNoise("Noise Test");
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testNoise.AddSignal(s);
            }

            TestMachines<ITest> tester = new TestMachines<ITest>();
            tester.AddTest(testOsc);
            tester.AddTest(testNoise);

            tester.RunTests();
            tester.PrintResults();
        }
    }
}*/





using System;
using System.Collections.Generic;

namespace SignalMachine
{
    public interface ITest
    {
        void RunTest();
        string GetTestResults();
    }

    public class Signal
    {
        private string name;
        private double[] data;
        private double[] time;

        public string Name => name;
        public double[] Data => data;
        public double[] Time => time;
        public int Count => data.Length;

        public Signal(string name, double[] data, double[] time)
        {
            this.name = name;
            this.data = data;
            this.time = time;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.Write("Data: ");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("(" + data[i].ToString("F2") + ";" + time[i].ToString("F2") + ")  ");
            }
            Console.WriteLine("\n");
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

    public class TestMachineSignalOscillations : ITest
    {
        private List<string> results = new List<string>();
        private string testName;
        public static double threshold;
        private List<Signal> signals = new List<Signal>();

        public TestMachineSignalOscillations(string name)
        {
            testName = name;
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            results.Clear();
            foreach (Signal signal in signals)
            {
                bool passed = false;
                for (int i = 1; i < signal.Count; i++)
                {
                    double diff = Math.Abs(signal.Data[i] - signal.Data[i - 1]);
                    if (diff > threshold)
                    {
                        passed = true;
                        break;
                    }
                }
                results.Add(signal.Name + ": " + (passed ? "PASSED" : "FAILED"));
            }
        }

        public string GetTestResults()
        {
            return testName + " Results:\n" + string.Join("\n", results);
        }
    }

    public class TestMachineSignalNoise : ITest
    {
        private List<string> results = new List<string>();
        private string testName;
        private List<Signal> signals = new List<Signal>();

        public TestMachineSignalNoise(string name)
        {
            testName = name;
        }

        public void AddSignal(Signal signal)
        {
            signals.Add(signal);
        }

        public void RunTest()
        {
            results.Clear();
            foreach (Signal signal in signals)
            {
                double var = signal.GetVariance();
                bool passed = false;
                foreach (double val in signal.Data)
                {
                    if (Math.Abs(val) > Math.Sqrt(var)) // modificare pentru rezultate mai variate
                    {
                        passed = true;
                        break;
                    }
                }
                results.Add(signal.Name + ": " + (passed ? "PASSED" : "FAILED"));
            }
        }

        public string GetTestResults()
        {
            return testName + " Results:\n" + string.Join("\n", results);
        }
    }

    public class TestMachines<T> where T : ITest
    {
        private List<T> tests = new List<T>();

        public void AddTest(T test)
        {
            tests.Add(test);
        }

        public void RunTests()
        {
            foreach (T test in tests)
            {
                test.RunTest();
            }
        }

        public void PrintResults()
        {
            foreach (T test in tests)
            {
                Console.WriteLine(test.GetTestResults());
            }
        }
    }

    public static class SignalExtensions
    {
        public static double GetVariance(this Signal signal)
        {
            double[] data = signal.Data;
            int count = signal.Count;

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }
            double mean = sum / count;
            double variance = 0;
            for (int i = 0; i < count; i++)
            {
                variance += (data[i] - mean) * (data[i] - mean);
            }
            return variance / count;
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

                // Alternăm semnale cu oscilații mari și mici
                double baseValue = random.NextDouble() * 5;
                for (int j = 0; j < 7; j++)
                {
                    if (i % 2 == 0) // semnal cu variație mică
                        data[j] = baseValue + random.NextDouble();
                    else // semnal cu variație mai mare
                        data[j] = baseValue + (random.NextDouble() * 10 - 5);

                    time[j] = j;
                }

                Signal signal = new Signal("Signal" + i, data, time);
                machine.AddSignal(signal);
            }

            Console.WriteLine("Raw signals: ");
            machine.PrintInfo();

            TestMachineSignalOscillations testOsc = new TestMachineSignalOscillations("Oscillation Test");
            TestMachineSignalOscillations.threshold = 1.5;
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testOsc.AddSignal(s);
            }

            TestMachineSignalNoise testNoise = new TestMachineSignalNoise("Noise Test");
            foreach (Signal s in machine.Signals)
            {
                if (s != null) testNoise.AddSignal(s);
            }

            TestMachines<ITest> tester = new TestMachines<ITest>();
            tester.AddTest(testOsc);
            tester.AddTest(testNoise);

            tester.RunTests();
            tester.PrintResults();
        }
    }
}