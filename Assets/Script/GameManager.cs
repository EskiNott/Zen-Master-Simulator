using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int MaxItemExist = 20;
    [SerializeField] private UpgradeItem InitilizationItem;
    [SerializeField] private UpgradeItemScriptableObjectList UpgradeItemList;
    [SerializeField] private Transform ItemParent;

    [SerializeField] private float Merit;
    [SerializeField] private float MeritStrength = 1;

    [SerializeField] private GameObject Border;

    [SerializeField] private CanvasGroup MeritCountUICG;
    [SerializeField] private CanvasGroup SidebarCanvasGroup;
    [SerializeField] private CanvasGroup StartMenu;
    [SerializeField] private int[] UpgradeItemData; //UpgradeitemID,ClickTime

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
        ArrayInit(ref UpgradeItemData, UpgradeItemList.List.Count);
    }

    public static void ArrayInit<T>(ref T[] Array, int Length)
    {
        Array = new T[Length];
    }

    private void Start()
    {
        //StartCoroutine(InitializeItemSpawn(1f));
        ItemSpawner.Instance.AddSpawnEvent(InitilizationItem);
    }

/*    IEnumerator InitializeItemSpawn(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        ItemSpawner.Instance.AddSpawnEvent(InitilizationItem);
    }*/

    public void SendMeritStrenghIncrease(float Addition = 0,float Multiply = 1)
    {
        MeritStrength += Addition;
        MeritStrength *= 1 + Multiply;
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

    public void SetUpgradeItemData(int key,int value)
    {
        UpgradeItemData[key] = value;
    }

    public int GetUpgradeItemDataValue(int key)
    {
        return UpgradeItemData[key];
    }

    public int[] GetUpgradeItemData()
    {
        return UpgradeItemData;
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

    public static RaycastHit RaycastPhysical()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast((Ray)ray, out hit, float.PositiveInfinity, 3);
        return hit;
    }
}
