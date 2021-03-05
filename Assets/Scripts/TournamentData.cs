using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TournamentData 
{
    public string type;
    public string id;
    public TournamentDataAttribute attributes;

    public override string ToString()
    {
        return id + " " + attributes.createdAt;
    }
}
[System.Serializable]
public class TournamentDataAttribute
{
   public string createdAt;
}
