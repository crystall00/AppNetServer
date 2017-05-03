using AppNetServer;
using System;
using System.Collections;
using System.Collections.Generic;

public class AuftragComparer : IComparer, IComparer<Auftrag>
{
    public int Compare(object expected, object actual)
    {
        var lhs = expected as Auftrag;
        var rhs = actual as Auftrag;
        if (lhs == null || rhs == null) throw new InvalidOperationException();
        return Compare(lhs, rhs);
    }

    public int Compare(Auftrag expected, Auftrag actual)
    {
        int temp;
        return (temp = expected.auftragsNummer.CompareTo(actual.auftragsNummer)) != 0 ? temp : expected.titel.CompareTo(actual.titel);
    }
}