using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Transform ItemParent;
    public int MaxItemExist = 20;

    [SerializeField] private float Merit;
    [SerializeField] private float MeritStrength = 1;

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
            UIManager.Instance.SetMeritCountUIText(Merit);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MaxItemCheck()
    {
        if(ItemParent.childCount > MaxItemExist)
        {
            for(int i = 0;i< ItemParent.childCount - MaxItemExist; i++)
            {
                Destroy(ItemParent.GetChild(1).gameObject);
            }
        }
    }

    public static bool IsChildHasParent(Transform child, Transform endPoint,Transform target)
    {
        bool found = false;
        Transform test = child;
        if (test == target)
        {
            found = true;
        }
        else
        {
            while (test != null && endPoint != null && test != endPoint)
            {
                if(test == target)
                {
                    found = true;
                    break;
                }
                else
                {
                    test = test.parent;
                }
            }
        }
        return found;
    }
}
