using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeItemButton_PermissionItem : UpgradeItemButton
{
    public GameObject[] NextLevelItems;

    protected override void Start()
    {
        base.Start();
    }

    public void OnButtonClick()
    {
        if (GameManager.Instance.DecreaseMerit(GetClickCost()))
        {
            ActiveNextLevel();
        }
        else
        {
            Debug.Log("Not enough Merit!");
        }
    }
    private void ActiveNextLevel()
    {
        if(NextLevelItems.Length > 0)
        {
            foreach(GameObject item in NextLevelItems)
            {
                item.SetActive(true);
            }
        }
        else
        {
            Debug.Log("NextLevel Empty");
        }
        gameObject.SetActive(false);
    }
}
