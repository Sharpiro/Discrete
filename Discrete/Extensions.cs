using System;

namespace Discrete
{
    public static class Extensions
    {
        public static Bit[] GetBits(this byte @byte)
        {
            var bitArray = new Bit[8];
            if (@byte == 0) return bitArray;
            var startingPower = (int)Math.Floor(Math.Log(@byte, 2));

            var remainingValue = @byte;
            var listIndex = bitArray.Length - 1 - startingPower;
            checked
            {
                for (var i = startingPower; i >= 0; i--)
                {
                    var powerValue = Math.Pow(2, i);
                    if (powerValue > remainingValue)
                    {
                        bitArray[listIndex] = Bit.Off;
                    }
                    else
                    {
                        bitArray[listIndex] = Bit.On;
                        remainingValue -= (byte)powerValue;
                    }
                    listIndex++;
                }
            }
            return bitArray;
        }
    }
}