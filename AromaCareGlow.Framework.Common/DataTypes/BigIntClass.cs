//------------------------------------------------------------------------------ 
// <copyright file="BigIntClass.cs" company="AromaCareGlow LLC">
//     Copyright (c) AromaCareGlow LLC.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System;

namespace AromaCareGlow.Framework.Common.DataTypes
{
    /// <summary>
    ///		This class is inherited from iconvertible class.
    ///		It implements additional methods for int64 base data type.
    /// </summary>
    [Serializable]
    public class BigIntClass : IConvertible
    {
        #region Member Variables

        /// <summary>
        ///		Current value of object
        /// </summary>
        public Int64 Value;

        #endregion

        #region Constructors

        /// <summary>
        ///		Default constructor, It initialize member variables.
        /// </summary>
        public BigIntClass()
        {
            this.Value = 0;
        }

        /// <summary>
        ///		Constructor accepts a big int value and assign to member variable
        /// </summary>
        /// <param name="v">
        ///		Int32 value for initialize member variable
        /// </param>
        public BigIntClass(Int64 v)
        {
            this.Value = v;
        }

        /// <summary>
        ///		Constructor accepts a int value and assign to member variable
        /// </summary>
        /// <param name="v">
        ///		Integer value for initialize member variable
        /// </param>
        public BigIntClass(int v)
        {
            this.Value = v;
        }

        /// <summary>
        ///		Constructor accepts a big decimal value and assign to member variable
        /// </summary>
        /// <param name="v">
        ///		Decimal value for initialize member variable
        /// </param>
        public BigIntClass(decimal v)
        {
            this.Value = (Int64)v;
        }

        #endregion

        #region Base Class Methods

        /// <summary>
        ///		Convert to to string and  return that value
        /// </summary>
        /// <returns>
        ///		String
        /// </returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        ///		Determines whether given object is equal to current value of class
        /// </summary>
        /// <param name="obj">
        ///		The System.Object to compare with current system.object
        /// </param>
        /// <returns>
        ///		Returns the result of comparison
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Int64))
            {
                return this.Value == (Int64)obj;
            }
            return this.Value == ((BigIntClass)obj).Value;
        }

        /// <summary>
        ///		Get Hash Code for this instance
        /// </summary>
        /// <returns>
        ///		An Integer value that contains hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        ///		Add one with current value
        /// </summary>
        /// <param name="c">
        ///		Current value
        /// </param>
        /// <returns>
        ///		Int 64 value
        /// </returns>
        public static BigIntClass operator ++(BigIntClass c)
        {
            c.Value++;
            return c;
        }

        /// <summary>
        ///		Substracts one from current value
        /// </summary>
        /// <param name="c">
        ///		Value to be substratcted
        /// </param>
        /// <returns>
        ///		Int 64
        /// </returns>
        public static BigIntClass operator --(BigIntClass c)
        {
            c.Value--;
            return c;
        }

        /// <summary>
        ///		Checks Equality
        /// </summary>
        /// <param name="c">
        ///		A bigint class object to  compare with next parameter of method.
        /// </param>
        /// <param name="i"></param>
        ///		An System.Int64 object compare with first parameter of method.
        /// <returns>
        ///		True if equal else false
        /// </returns>
        public static bool operator ==(BigIntClass c, Int64 i)
        {
            return c.Value == i;
        }

        /// <summary>
        ///		Checks Equality
        /// </summary>
        /// <param name="c">
        ///		A bigint class object to  compare with next parameter of method.
        /// </param>
        /// <param name="i"></param>
        ///		An System.int object compare with first parameter of method.
        /// <returns>
        ///		True if equal else false
        /// </returns>
        public static bool operator ==(BigIntClass c, int i)
        {
            return c.Value == i;
        }

        /// <summary>
        ///		Checks NonEquality
        /// </summary>
        /// <param name="c"></param>
        ///		A bigint class object to  compare with next parameter of method.
        /// <param name="i">
        ///		An System.Int64 object compare with first parameter of method.
        /// </param>
        /// <returns>
        ///		True if equal else false
        /// </returns>
        public static bool operator !=(BigIntClass c, Int64 i)
        {
            return c.Value != i;
        }

        /// <summary>
        ///		Checks NonEquality
        /// </summary>
        /// <param name="c"></param>
        ///		A bigint class object to  compare with next parameter of method.
        /// <param name="i">
        ///		An System.Int object compare with first parameter of method.
        /// </param>
        /// <returns>
        ///		True if equal else false
        /// </returns>
        public static bool operator !=(BigIntClass c, int i)
        {
            return c.Value != i;
        }

        /// <summary>
        ///		Convert big int  to int
        /// </summary>
        /// <param name="c">
        ///		Object to convert.
        /// </param>
        /// <returns>
        ///		Converted result.
        /// </returns>
        public static implicit operator int(BigIntClass c)
        {
            return (int)c.Value;
        }

        /// <summary>
        ///		Convert big int to int 64 
        /// </summary>
        /// <param name="c">
        ///		Object to convert.
        /// </param>
        /// <returns>
        ///		Converted Result.
        /// </returns>
        public static implicit operator Int64(BigIntClass c)
        {
            return c.Value;
        }

        /// <summary>
        ///		Convert int64 to BigInt Class
        /// </summary>
        /// <param name="i">
        ///		Object to convert.
        /// </param>
        /// <returns>
        ///		Retruns new big int class
        /// </returns>
        public static implicit operator BigIntClass(Int64 i)
        {
            return new BigIntClass(i);
        }

        /// <summary>
        ///		A general type representing a reference or value.
        /// </summary>
        /// <returns>
        ///		A System.TypeCode object
        /// </returns>
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

        #endregion
    }
}