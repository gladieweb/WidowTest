using System.Linq.Expressions;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TournamentsPanel : MonoBehaviour
{
    public const string PubgServerUri = "https://api.pubg.com";
    public const string TournamentQuery = "/tournaments";
    private const string apikey= "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5MjI1NTAyMC01ZjYwLTAxMzktN2YzNi02OTViZWI4NzEwZGQiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE0ODk0MjA0LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InRlc3RfMDEifQ.ZcXi_TOsc9k-Rbu9_D4Bqpif2TqSviqzZct-rePSTxk";
    
    public GameObject TournamentElementPrefab;
    public Transform container;

    //just for testing purposes.
    public TextAsset test;
    
    // Start is called before the first frame update
    void Start()
    {
#if DEBUG
{
        string response = test.text;
        HandleResponse(response);
}
#else
{
        StartCoroutine(GetTournamentsFromServer());
}
#endif
    }

    private void SpawnTournamentElements(TournamentData[] data)
    {
        for(int i = 0 ; i < data.Length ; i++)
        {
            GameObject go = GameObject.Instantiate(TournamentElementPrefab, container);
            TournamentElement element = go.GetComponent<TournamentElement>();
            element.Initialize(data[i]);
        }
    }

    // Update is called once per frame
    public void HandleResponse(string response)
    {
        TournamentResponse tournamentResponse = JsonUtility.FromJson<TournamentResponse>(response);
        SpawnTournamentElements(tournamentResponse.data);
    }

    IEnumerator GetTournamentsFromServer()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(PubgServerUri + TournamentQuery);
        webRequest.SetRequestHeader("Authorization", $"Bearer {apikey}");
        webRequest.SetRequestHeader("Accept", "application/vnd.api+json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            UnityEngine.Debug.Log( "Error: " + webRequest.error);
        }
        else
        {
            string result = webRequest.downloadHandler.text;
            HandleResponse(result);
        }
    }
}
