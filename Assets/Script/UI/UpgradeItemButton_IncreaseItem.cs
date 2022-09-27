using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemButton_IncreaseItem : UpgradeItemButton
{
    public void OnButtonClick(UpgradeItem item)
    {
        if (GameManager.Instance.DecreaseMerit(GetClickCost()))
        {
            ItemSpawner.SpawnEvent Event = new(item, this);
            ItemSpawner.Instance.AddSpawnEvent(Event);
            IncreaseMeritStrength();
        }
        else
        {
            Debug.Log("Not enough Merit!");
        }
    }
}
