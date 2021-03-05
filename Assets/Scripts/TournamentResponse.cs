using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TournamentResponse
{
    public TournamentData[] data;
    public object links;
    public object meta;

    public override string ToString()
    {
        string res = "";
        foreach(TournamentData tdata in data)
        {
            res += tdata.ToString() + "\n";
        }
        return res;
    }
}
