using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Logger
{
    public static int KEY_UNIT_MAKE = 1, KEY_UNIT_MANAGE = 2, KEY_KEYPAD_STATUS = 3;
    public static string[] keyMessage = new string[] { "", "KEY_UNIT_MAKE", "KEY_UNIT_MANAGE", "키패드" };

    public static void Log(int key, string message)
    {
        Debug.Log(string.Format("[{0}] {1}", keyMessage[key], message));
    }

    public static void Log(string key, params object[] args)
    {
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < args.Length; i++)
        {
            sb.Append(args[i]);

            if(i != args.Length - 1)
            {
                sb.Append("-");
            }
        }        

        Debug.Log(string.Format("[{0}] {1}", key, sb.ToString()));
    }

    public static void LogTable(string key, params object[] args)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < args.Length; i += 2)
        {
            sb.Append(args[i]);
            sb.Append(":");
            sb.Append(args[i + 1]);

            if (i != args.Length - 1)
            {
                sb.Append(",");
            }
        }

        Debug.Log(string.Format("[{0}] {1}", key, sb.ToString()));
    }
}