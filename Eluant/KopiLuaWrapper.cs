//
// KopiLuaWrapper.cs
//
// Authors:
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
using KopiLua;

namespace Eluant
{
    internal static class KopiLuaWrapper
    {
        public static int LUA_REGISTRYINDEX { get { return KopiLua.Lua.LUA_REGISTRYINDEX; } }

        public static int LUA_MULTRET { get { return KopiLua.Lua.LUA_MULTRET; } }

        public static int LUA_GLOBALSINDEX { get { return KopiLua.Lua.LUA_GLOBALSINDEX; } }

        internal static KopiLua.LuaState luaL_newstate()
        {
            return Lua.LuaLNewState();
        }

        internal static void lua_getfield(KopiLua.LuaState state, int idx, string k)
        {
            Lua.LuaGetField(state, idx, k);
        }

        internal static object lua_touserdata(KopiLua.LuaState state, int idx)
        {
            return Lua.LuaToUserData(state, idx);
        }

        internal static void lua_pop(KopiLua.LuaState state, int n)
        {
            Lua.LuaPop(state, n);
        }

        internal static void lua_newtable(KopiLua.LuaState state)
        {
            Lua.LuaNewTable(state);
        }

        internal static void lua_setfield(KopiLua.LuaState state, int idx, string k)
        {
            Lua.LuaSetField(state, idx, k);
        }

        internal static void luaL_openlibs(KopiLua.LuaState state)
        {
            Lua.LuaLOpenLibs(state);
        }

        internal static void lua_pushlightuserdata(KopiLua.LuaState state, object o)
        {
            Lua.LuaPushLightUserData(state, o);
        }

        internal static void luaL_newmetatable(KopiLua.LuaState state, string tname)
        {
            Lua.LuaLNewMetatable(state, tname);
        }

        internal static void lua_pushstring(KopiLua.LuaState state, string s)
        {
            Lua.LuaPushString(state, s);
        }

        internal static void lua_pushcfunction(KopiLua.LuaState state, KopiLua.LuaNativeFunction f)
        {
            Lua.LuaPushCFunction(state, f);
        }

        internal static void lua_settable(KopiLua.LuaState state, int idx)
        {
            Lua.LuaSetTable(state, idx);
        }

        internal static void lua_pushboolean(KopiLua.LuaState state, int b)
        {
            Lua.LuaPushBoolean(state, b);
        }

        internal static void lua_close(KopiLua.LuaState state)
        {
            Lua.LuaClose(state);
        }

        internal static void lua_pushnil(KopiLua.LuaState state)
        {
            Lua.LuaPushNil(state);
        }

        internal static int lua_next(KopiLua.LuaState state, int idx)
        {
            return Lua.LuaNext(state, idx);
        }

        internal static void lua_pushvalue(KopiLua.LuaState state, int idx)
        {
            Lua.LuaPushValue(state, idx);
        }

        internal static int abs_index(KopiLua.LuaState state, int i)
        {
            return Lua.AbsIndex(state, i);
        }

        internal static void lua_insert(KopiLua.LuaState state, int idx)
        {
            Lua.LuaInsert(state, idx);
        }

        internal static void lua_rawgeti(KopiLua.LuaState state, int idx, int n)
        {
            Lua.LuaRawGetI(state, idx, n);
        }

        internal static LuaNative.LuaType lua_type(KopiLua.LuaState state, int idx)
        {
            return (LuaNative.LuaType)Lua.LuaType(state, idx);
        }

        internal static void lua_rawseti(KopiLua.LuaState state, int idx, int n)
        {
            Lua.LuaRawSetI(state, idx, n);
        }

        internal static void lua_remove(KopiLua.LuaState state, int idx)
        {
            Lua.LuaRemove(state, idx);
        }

        internal static int lua_toboolean(KopiLua.LuaState state, int idx)
        {
            return Lua.LuaToBoolean(state, idx);
        }

        internal static double lua_tonumber(KopiLua.LuaState state, int idx)
        {
            return Lua.LuaToNumber(state, idx);
        }

        internal static string lua_tostring(KopiLua.LuaState state, int idx)
        {
            CharPtr cp = Lua.LuaToString(state, idx);

            return cp == null ? null : cp.ToString(cp.chars.Length - 1);
        }

        internal static int lua_gettop(KopiLua.LuaState state)
        {
            return Lua.LuaGetTop(state);
        }

        internal static int lua_getmetatable(KopiLua.LuaState state, int idx)
        {
            return Lua.LuaGetMetatable(state, idx);
        }

        internal static void luaL_getmetatable(KopiLua.LuaState state, string n)
        {
            Lua.LuaLGetMetatable(state, n);
        }

        internal static int lua_rawequal(KopiLua.LuaState state, int index1, int index2)
        {
            return Lua.LuaRawEqual(state, index1, index2);
        }

        internal static void lua_settop(KopiLua.LuaState state, int idx)
        {
            Lua.LuaSetTop(state, idx);
        }

        internal static int luaL_loadbuffer(KopiLua.LuaState state, string buff, int size, string name)
        {
            return Lua.LuaLLoadBuffer(state, buff, (uint)size, name);
        }

        internal static int luaL_loadbuffer(KopiLua.LuaState state, byte[] bytes, int size, string name)
        {
            return Lua.LuaLLoadBuffer(state, bytes, (uint)size, name);
        }

        internal static int lua_checkstack(KopiLua.LuaState state, int size)
        {
            return Lua.LuaCheckStack(state, size);
        }

        internal static int lua_pcall(KopiLua.LuaState state, int nargs, int nresults, int errfunc)
        {
            return Lua.LuaPCall(state, nargs, nresults, errfunc);
        }

        internal static void lua_setmetatable(KopiLua.LuaState state, int idx)
        {
            Lua.LuaSetMetatable(state, idx);
        }

        internal static int lua_upvalueindex(int i)
        {
            return Lua.LuaUpValueIndex(i);
        }

        internal static void lua_pushcclosure(KopiLua.LuaState state, KopiLua.LuaNativeFunction fn, int n)
        {
            Lua.LuaPushCClosure(state, fn, n);
        }

        internal static void lua_gettable(KopiLua.LuaState state, int idx)
        {
            Lua.LuaGetTable(state, idx);
        }

        internal static void lua_pushnumber(KopiLua.LuaState state, double n)
        {
            Lua.LuaPushNumber(state, n);
        }
    }
}
