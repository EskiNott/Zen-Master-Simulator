using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int Merit;
    public TextMeshProUGUI MeritText;
    // Start is called before the first frame update
    void Start()
    {
        Merit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MeritText.text = "Merit: " + Merit.ToString();
    }

}
