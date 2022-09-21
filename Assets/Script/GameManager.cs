using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float Merit;
    public TextMeshProUGUI MeritText;
    [SerializeField] private List<GameObject> ItemList;
    private float MeritStrength = 1;
    // Start is called before the first frame update
    void Start()
    {
        Merit = 0;
        ItemList = new();
    }

    // Update is called once per frame
    void Update()
    {
        MeritText.text = "Merit: " + Merit.ToString();
    }

    public float GetMeritStrength()
    {
        return MeritStrength;
    }

    public void ItemListAdd(GameObject go)
    {
        Item i = go.GetComponent<Item>();
        MeritStrength += i.MeritAddition;
        MeritStrength *= i.MeritMultiply;
        ItemList.Add(go);
    }
}
