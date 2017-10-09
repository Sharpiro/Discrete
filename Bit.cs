using System;

namespace gates
{
    public struct Bit
    {
        private int _value;

        public static int Conversions { get; private set; }
        public static int Instances { get; private set; }

        public static Bit On => new Bit(1);
        public static Bit Off => new Bit(0);

        public Bit(int value)
        {
            _value = value;
            Instances++;
        }

        public void ChangeValue()
        {
            _value = _value == 0 ? 1 : 0;
        }

        // public static explicit operator int(Bit bit)
        // {
        //     Conversions++;
        //     return bit._value;
        // }

        // public static explicit operator Bit(int number)
        // {
        //     if (number != 0 && number != 1) throw new ArgumentOutOfRangeException(nameof(number), "Must be a 0 or a 1");
        //     Conversions++;
        //     return new Bit(number);
        // }

        public static implicit operator int(Bit bit)
        {
            Conversions++;
            return bit._value;
        }

        public static implicit operator Bit(int number)
        {
            if (number != 0 && number != 1) throw new ArgumentOutOfRangeException(nameof(number), "Must be a 0 or a 1");
            Conversions++;
            return new Bit(number);
        }

        public static implicit operator bool(Bit bit)
        {
            Conversions++;
            return Convert.ToBoolean(bit._value);
        }

        public static implicit operator Bit(bool boolean)
        {
            Conversions++;
            return new Bit(Convert.ToInt32(boolean));
        }

        public override bool Equals(object obj) => obj.GetHashCode() == _value.GetHashCode();
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public static bool operator ==(Bit x, Bit y) => x._value == y._value;
        public static bool operator !=(Bit x, Bit y) => x._value != y._value;
    }
}