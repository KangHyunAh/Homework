using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI restartText;
    void Start()
    {
        if(restartText == null)
        {
            Debug.LogError("restart text is null");
        }
    }

    void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }
}
