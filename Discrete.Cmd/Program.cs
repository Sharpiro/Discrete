﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Discrete.Cmd
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Bit x = 1;
            // Bit y = 1;
            // WriteLine($"Conversions = {Bit.Conversions}");
            // WriteLine($"Instances = {Bit.Instances}");
            byte x = 4;
            byte y = 3;
            var xBits = x.GetBits();
            var yBits = y.GetBits();

            //FourBitAdd(xBits, yBits);
            // var bitsString = string.Join(string.Empty, bits.Select(b => b.ToString()));
            // var @decimal = Convert.ToInt32(bitsString, 2);
            // Console.WriteLine($"{bitsString.Length}: {bitsString}");
            // Console.WriteLine(@decimal);
            // var aBits = new Bit[] { 0, 1, 1 };
            // var bBits = new Bit[] { 1, 1, 0 };
            // FourBitAdd(aBits, bBits);
            // var cases = new[] { (0, 0), (0, 1), (1, 0), (1, 1) };
            // PrintResult(cases, AndGate);
            // PrintResult(cases, OrGate);
            // PrintResult(cases, XorGate);
            // PrintResult(cases, NandGate);
            // PrintResult(cases, NorGate);

        }

        //private static IEnumerable<Bit> FourBitAdd(Bit[] aBits, Bit[] bBits)
        //{

        //    Debug.Assert(aBits.Length == bBits.Length);

        //    var list = new List<Bit>();
        //    Bit cIn = 0;
        //    (Bit Sum, Bit Carry) fullAddResult = (0, 0);
        //    for (var i = aBits.Length - 1; i >= 0; i--)
        //    {
        //        fullAddResult = FullAdd(aBits[i], bBits[i], cIn);
        //        list.Add(fullAddResult.Sum);
        //        cIn = fullAddResult.Carry;
        //    }
        //    list.Add(fullAddResult.Carry);
        //    list.Reverse();
        //    return list;
        //    // var temp = $"{secondFullAdd.Carry}{secondFullAdd.Sum}{firstFullAdd.Sum}";
        //    //var temp = string.Join(string.Empty, list);
        //    //var @decimal = Convert.ToInt32(temp, 2);
        //    //Console.WriteLine(@decimal);
        //}

        //private static (Bit Sum, Bit Carry) FullAdd(Bit x, Bit y, Bit c)
        //{
        //    var firstHalfAddResult = HalfAdd(x, y);
        //    var secondHalfAddResult = HalfAdd(firstHalfAddResult.Sum, c);
        //    var carry = Or(firstHalfAddResult.Carry, secondHalfAddResult.Carry);
        //    return (secondHalfAddResult.Sum, carry);
        //}

        //private static (Bit Sum, Bit Carry) HalfAdd(Bit x, Bit y)
        //{
        //    var sum = Xor(x, y);
        //    var carry = And(x, y);
        //    return (sum, carry);
        //}

        //private static Bit And(Bit x, Bit y)
        //{
        //    return x == Bit.On && y == Bit.On;
        //}

        //private static Bit Or(Bit x, Bit y)
        //{
        //    return x == Bit.On || y == Bit.On;
        //}

        //private static Bit Nand(Bit x, Bit y)
        //{
        //    return !And(x, y);
        //}

        //private static Bit Nor(Bit x, Bit y)
        //{
        //    return !Or(x, y);
        //}

        //private static Bit Xor(Bit x, Bit y)
        //{
        //    if (And(x, y)) return Bit.Off;
        //    return Or(x, y);
        //}

        //private static void PrintResult(IEnumerable<(Bit, Bit)> @cases, Func<Bit, Bit, Bit> func)
        //{
        //    foreach (var @case in cases)
        //    {
        //        WriteLine(func(@case.Item1, @case.Item2));
        //    }
        //}

        //private static void Write(Bit bit) => Console.Write(bit.ToString());
        //private static void WriteLine(Bit bit) => Console.WriteLine(bit.ToString());
    }
}