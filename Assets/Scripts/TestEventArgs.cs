using LFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TestEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(TestEventArgs).GetHashCode();

    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    public string message;
}

