using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NoAssignedException : NullReferenceException
{
    public NoAssignedException(string varName) : base("변수가 할당되지 않음 : " + varName)
    {

    }
}