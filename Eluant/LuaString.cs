//
// LuaString.cs
//
// Author:
//       Chris Howie <me@chrishowie.com>
//       Dirk Weltz <web@weltz-online.de>
//       Brice Clocher <contact@cybisoft.net>
//
// Copyright (c) 2013 Chris Howie
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace Eluant
{
    #if USE_KOPILUA
        using LuaApi = KopiLuaWrapper;
    #else
        using LuaApi = LuaNative;
    #endif
    
    public sealed class LuaString : LuaValueType,
        IEquatable<LuaString>, IEquatable<string>,
        IComparable, IComparable<LuaString>, IComparable<string>
    {
        public string Value { get; private set; }

        public LuaString(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }

            Value = value;
        }

        public override bool ToBoolean()
        {
            return true;
        }

        public override double? ToNumber()
        {
            double number;
            if (double.TryParse(Value, out number)) {
                return number;
            }

            return null;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(LuaValue other)
        {
            return Equals(other as LuaString);
        }

        internal override void Push(LuaRuntime runtime)
        {
#if USE_KOPILUA
			LuaApi.lua_pushstring(runtime.LuaState, Value);
#else
			LuaApi.lua_pushlstring(runtime.LuaState, Value, new UIntPtr((ulong)Value.Length)); 
#endif
        }

#if USE_KOPILUA
		public static implicit operator LuaString(KopiLua.CharPtr cp)
		{
			return cp == null ? null : new LuaString(cp.ToString());
		} 
#endif

        public static implicit operator LuaString(string v)
        {
            return v == null ? null : new LuaString(v);
        }

        public static implicit operator string(LuaString s)
        {
            return object.ReferenceEquals(s, null) ? null : s.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LuaString);
        }

        public bool Equals(LuaString obj)
        {
            if (object.ReferenceEquals(obj, this)) { return true; }
            if (object.ReferenceEquals(obj, null)) { return false; }

            return obj.Value == Value;
        }

        public bool Equals(string obj)
        {
            if (obj == null) { return false; }

            return obj == Value;
        }

        // No (LuaString, LuaString) overload.  With implicit conversion to string, that creates ambiguity.

        public static bool operator==(LuaString a, string b)
        {
            return (string)a == b;
        }

        public static bool operator!=(LuaString a, string b)
        {
            return !(a == b);
        }

//        public static bool operator==(string a, LuaString b)
//        {
//            return a == (string)b;
//        }
//
//        public static bool operator!=(string a, LuaString b)
//        {
//            return !(a == b);
//        }

        public int CompareTo(LuaString s)
        {
            return CompareTo(object.ReferenceEquals(s, null) ? null : s.Value);
        }

        public int CompareTo(string s)
        {
            return Value.CompareTo(s);
        }

        public int CompareTo(object o)
        {
            var luaString = o as LuaString;
            if (!object.ReferenceEquals(luaString, null)) { return CompareTo(luaString); }

            var str = o as string;
            if (str != null) { return CompareTo(str); }

            throw new ArgumentException("Must be a LuaString or a String.", "o");
        }
    }
}

