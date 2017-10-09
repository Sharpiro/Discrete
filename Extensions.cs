using System;
using System.Collections.Generic;
using System.Linq;

namespace gates
{
    public static class Extensions
    {
        public static Bit[] ToBits(this byte @byte)
        {
            var startingPower = (byte)Math.Floor(Math.Log(@byte, 2));

            var remainingValue = @byte;
            var list = new Bit[8];
            var listIndex = list.Length - 1 - startingPower;
            checked
            {
                for (var i = startingPower; i >= 0; i--)
                {
                    var powerValue = Math.Pow(2, i);
                    if (powerValue > remainingValue)
                    {
                        list[listIndex] = Bit.Off;
                    }
                    else
                    {
                        list[listIndex] = Bit.On;
                        remainingValue -= (byte)powerValue;
                    }
                    listIndex++;
                }
            }
            return list;
        }
    }
}