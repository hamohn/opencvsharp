using System;

namespace OpenCvSharp.DebuggerVisualizers.GridVisualizer
{
    [Serializable]
    public class Element : Tuple<double, double, double, double>
    {
        public static int DisplayChannel { get; set; }

        public Element(double item0, double item1 = 0, double item2 = 0, double item3 = 0)
            : base(item0, item1, item2, item3)
        {
        }

        public static implicit operator Element(double val) => new(val);

        public double this[int i]
        {
            get
            {
                return i switch
                {
                    0 => Item1,
                    1 => Item2,
                    2 => Item3,
                    3 => Item4,
                    _ => throw new ArgumentOutOfRangeException(nameof(i)),
                };
            }
        }

        public override string ToString()
        {
            if (DisplayChannel == 0)
                return $"{Item1}, {Item2}, {Item3}, {Item4}";
            else
                return $"{this[DisplayChannel - 1]}";
        }
    }
}
