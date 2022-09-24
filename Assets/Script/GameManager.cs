using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float Merit;
    [SerializeField] private float MeritStrength = 1;

    [SerializeField] private List<GameObject> ItemList;

    [SerializeField] private GameObject Border;

    [SerializeField] private CanvasGroup MeritCountUICG;
    [SerializeField] private CanvasGroup SidebarCanvasGroup;
    [SerializeField] private CanvasGroup StartMenu;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        GameInit();
    }

    public void GameInit()
    {
        Merit = 0;
        ItemList = new();
        Border.SetActive(true);
        MeritCountUICG.alpha = 0;
        SidebarCanvasGroup.alpha = 0;
        StartMenu.alpha = 0;
    }

    public void SendMeritStrenghIncrease(float Addition = 0,float Multiply = 1)
    {
        MeritStrength += Addition;
        MeritStrength *= Multiply;
    }

    public float GetMeritStrength()
    {
        return MeritStrength;
    }

    public void IncreaseMerit(float Count)
    {
        Merit += Count;
        UIManager.Instance.SetMeritCountUIText(Merit);
    }

    public bool DecreaseMerit(float Count)
    {
        if (Merit >= Count)
        {
            Merit -= Count;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ItemListAdd(GameObject go)
    {
        ItemList.Add(go);
    }
}
