using MorningStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class CMDExecutor
{
    [CommandInfo("Test1",new object[] { "1"})]
    public static void Test1(string value1)
    {
        Debug.LogWarning(value1);
    }

    [CommandInfo("Test2", new object[] { "1","2" })]
    public static void Test2(string value1, string value2)
    {
        Debug.LogWarning(value1 + "," + value2);
    }
}

