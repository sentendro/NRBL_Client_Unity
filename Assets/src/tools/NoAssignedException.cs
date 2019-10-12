using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NoAssignedException : NullReferenceException
{
    public NoAssignedException(string varName) : base("변수가 할당되지 않음 : " + varName)
    {

    }

    public NoAssignedException(object parent, string varName) : base(string.Format("변수가 할당되지 않음 : {0}.{1}", parent.GetType(), varName))
    {

    }

    public NoAssignedException(object parent, Type type) : base(string.Format("변수가 할당되지 않음 : {0}.{1}", parent.GetType(), type))
    {
    }
}