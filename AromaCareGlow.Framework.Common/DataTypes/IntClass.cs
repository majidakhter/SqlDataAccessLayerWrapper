//------------------------------------------------------------------------------ 
// <copyright file="IntClass.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System;

namespace AromaCareGlow.Framework.Common.DataTypes
{
    /// <summary>
    ///     Object class value type int.
    /// </summary>
    [Serializable]
    public class IntClass : IConvertible
    {
        public int Value;

        public IntClass()
        {
            this.Value = 0;
        }

        public IntClass(int v)
        {
            this.Value = v;
        }

        public IntClass(decimal v)
        {
            this.Value = (int)v;
        }

        public IntClass(Int64 v)
        {
            this.Value = (int)v;
        }

        public IntClass(UInt64 v)
        {
            this.Value = (int)v;
        }


        public override string ToString()
        {
            return Value.ToString();
        }



        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(int))
            {
                return this.Value == (int)obj;
            }
            return this.Value == ((IntClass)obj).Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static IntClass operator ++(IntClass c)
        {
            c.Value++;
            return c;
        }

        public static IntClass operator --(IntClass c)
        {
            c.Value--;
            return c;
        }

        public static bool operator ==(IntClass c, int i)
        {
            return c.Value == i;
        }

        public static bool operator !=(IntClass c, int i)
        {
            return c.Value != i;
        }

        public static implicit operator int(IntClass c)
        {
            return c.Value;
        }

        public static implicit operator IntClass(int i)
        {
            return new IntClass(i);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(Value, provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(Value, provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(Value, provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(Value, provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(Value, provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(Value, provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(Value, provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(Value, provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(Value, provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(Value, provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(Value, provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(Value, conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(Value, provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(Value, provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(Value, provider);
        }

    }
}

   





