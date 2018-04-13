using System;

public class UnixTimeConverter
{
    public static int GetTicksCount()
    {
        var curTime = Environment.TickCount * 0.001f;
        if (curTime < 0) curTime += Int32.MaxValue * 0.001f;
        return (int)curTime;
    }

    public static int GetSystemNowUnixTime()
    {
        return CovertToUnixTime(DateTime.Now);
    }

    public static DateTime ConvertToDateTime(int unixTime)
    {
        return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTime);
    }

    public static int CovertToUnixTime(DateTime date)
    {
        TimeSpan diff = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return (int)Math.Floor(diff.TotalSeconds);
    }
}
