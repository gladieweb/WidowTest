using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentElement : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text idText;
    [SerializeField]
    private UnityEngine.UI.Text dateText;

    public void Initialize(TournamentData data)
    {
        idText.text = data.id;
        dateText.text = data.attributes.createdAt;
    }
}
