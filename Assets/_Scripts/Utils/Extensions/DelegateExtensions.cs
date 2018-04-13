using System;

public static class DelegateExtensions
{
    public static void SafeInvoke(this Action _this)
    {
        if (_this != null) _this.Invoke();
    }


    public static void SafeInvoke<T>(this Action<T> _this, T param0)
    {
        if (_this != null) _this.Invoke(param0);
    }


    public static void SafeInvoke<T1, T2>(this Action<T1, T2> _this, T1 param0, T2 param1)
    {
        if (_this != null) _this.Invoke(param0, param1);
    }


    public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> _this, T1 param0, T2 param1, T3 param3)
    {
        if (_this != null) _this.Invoke(param0, param1, param3);
    }
}

