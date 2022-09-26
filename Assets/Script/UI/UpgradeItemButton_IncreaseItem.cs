using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemButton_IncreaseItem : UpgradeItemButton
{
    private void Update()
    {
        CostUpdate();
    }

    public void OnButtonClick(UpgradeItem item)
    {
        if (GameManager.Instance.DecreaseMerit(GetClickCost()))
        {
            ItemSpawner.Instance.AddSpawnEvent(item);
            IncreaseMeritStrength();
        }
        else
        {
            Debug.Log("Not enough Merit!");
        }
    }
}
