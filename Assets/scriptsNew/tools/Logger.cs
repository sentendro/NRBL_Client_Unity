using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Logger
{
    public static int KEY_UNIT_MAKE = 1, KEY_UNIT_MANAGE = 2;
    public static string[] keyMessage = new string[] { "", "KEY_UNIT_MAKE", "KEY_UNIT_MANAGE" };

    public static void Log(int key, string message)
    {
        Debug.Log(string.Format("[{0}] {1}", keyMessage[key], message));
    }
}