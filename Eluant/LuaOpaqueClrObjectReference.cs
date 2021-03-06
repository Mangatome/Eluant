//
// LuaOpaqueClrObjectReference.cs
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

    public sealed class LuaOpaqueClrObjectReference : LuaLightUserdata
    {
        public LuaOpaqueClrObjectReference(LuaRuntime runtime, int reference) : base(runtime, reference) { }

        public override bool ToBoolean()
        {
            return ClrObject != null;
        }

        public override double? ToNumber()
        {
            return null;
        }

        public override string ToString()
        {
            return "[LuaOpaqueClrObjectReference]";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            cachedClrObject = null;
        }

        private bool isClrObjectCached = false;
        private object cachedClrObject = null;

        public object ClrObject
        {
            get {
                CheckDisposed();

                if (!isClrObjectCached) {
                    Runtime.Push(this);
                    cachedClrObject = Runtime.GetOpaqueClrObject(-1);
                    LuaApi.lua_pop(Runtime.LuaState, 1);

                    isClrObjectCached = true;
                }

                return cachedClrObject;
            }
        }

        new public LuaWeakReference<LuaOpaqueClrObjectReference> CreateWeakReference()
        {
            CheckDisposed();

            return Runtime.CreateWeakReference(this);
        }
    }
}

