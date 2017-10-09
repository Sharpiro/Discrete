using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Discrete
{
    public struct Bit
    {
        private int _value;

        public static Bit On => new Bit(1);
        public static Bit Off => new Bit(0);

        public Bit(int value) => _value = value;

        public static IEnumerable<Bit> FourBitAdd(Bit[] aBits, Bit[] bBits)
        {

            Debug.Assert(aBits.Length == bBits.Length);

            var list = new List<Bit>();
            Bit cIn = Off;
            var fullAddResult = (Sum: Off, Carry: Off);
            for (var i = aBits.Length - 1; i >= 0; i--)
            {
                fullAddResult = aBits[i].FullAdd(bBits[i], cIn);
                list.Add(fullAddResult.Sum);
                cIn = fullAddResult.Carry;
            }
            list.Add(fullAddResult.Carry);
            list.Reverse();
            return list;
        }

        public (Bit Sum, Bit Carry) FullAdd(Bit y, Bit c)
        {
            var firstHalfAddResult = HalfAdd(y);
            var secondHalfAddResult = firstHalfAddResult.Sum.HalfAdd(c);
            var carry = firstHalfAddResult.Carry | secondHalfAddResult.Carry;
            return (secondHalfAddResult.Sum, carry);
        }

        public (Bit Sum, Bit Carry) HalfAdd(Bit y)
        {
            var sum = Xor(y);
            var carry = this & y;
            return (sum, carry);
        }

        public Bit And(Bit y)
        {
            return _value == On._value && y == On;
        }

        public Bit Or(Bit y)
        {
            return _value == On._value || y == On;
        }

        public Bit Nand(Bit y)
        {
            return !And(y);
        }

        public Bit Nor(Bit y)
        {
            return !Or(y);
        }

        public Bit Xnor(Bit y)
        {
            return !Xor(y);
        }

        public Bit Xor(Bit y)
        {
            if (And(y)) return Off;
            return Or(y);
        }

        public void ChangeValue()
        {
            _value = _value == 0 ? 1 : 0;
        }

        public static explicit operator int(Bit bit)
        {
            return bit._value;
        }

        public static explicit operator Bit(int number)
        {
            if (number != 0 && number != 1) throw new ArgumentOutOfRangeException(nameof(number), "Must be a 0 or a 1");
            return new Bit(number);
        }

        //public static implicit operator int(Bit bit)
        //{
        //    Conversions++;
        //    return bit._value;
        //}

        //public static implicit operator Bit(int number)
        //{
        //    if (number != 0 && number != 1) throw new ArgumentOutOfRangeException(nameof(number), "Must be a 0 or a 1");
        //    Conversions++;
        //    return new Bit(number);
        //}

        public static implicit operator bool(Bit bit)
        {
            return Convert.ToBoolean(bit._value);
        }

        public static implicit operator Bit(bool boolean)
        {
            return new Bit(Convert.ToInt32(boolean));
        }

        //public static explicit operator bool(Bit bit)
        //{
        //    return Convert.ToBoolean(bit._value);
        //}

        //public static explicit operator Bit(bool boolean)
        //{
        //    return new Bit(Convert.ToInt32(boolean));
        //}

        public override bool Equals(object obj) => obj.GetHashCode() == _value.GetHashCode();
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public static bool operator ==(Bit x, Bit y) => x._value == y._value;
        public static bool operator !=(Bit x, Bit y) => x._value != y._value;
        public static Bit operator &(Bit c1, Bit c2) => c1.And(c2);
        public static Bit operator |(Bit c1, Bit c2) => c1.Or(c2);
    }
}