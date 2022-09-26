using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemSpawner : MonoSingleton<ItemSpawner>
{
    private Queue<UpgradeItem> SpawnQueue;
    [SerializeField] private Transform SpawnerTrans;
    [SerializeField] private Transform SpawnParent;

    protected override void Awake()
    {
        base.Awake();
        SpawnQueue = new();
    }

    void Update()
    {
        Spawn();
    }

    private void Clear()
    {
        foreach(Transform item in SpawnParent)
        {
            Destroy(item.gameObject);
        }
    }

    public void ItemObjectReset()
    {
        Clear();
    }

    private void ItemObjectSpawn()
    {
        
    }

    private void Spawn()
    {
        if (SpawnQueue.Count > 0)
        {
            UpgradeItem upgradeItem = SpawnQueue.Dequeue();
            GameManager.Instance.SetUpgradeItemData(upgradeItem.ID, GameManager.Instance.GetUpgradeItemDataValue(upgradeItem.ID) + 1);
            GameObject go = Instantiate(upgradeItem.ItemPrefab, SpawnerTrans.position, SpawnerTrans.rotation, SpawnParent);
            Item item = go.GetComponent<Item>();
            item.ID = upgradeItem.ID;
            GameManager.Instance.MaxItemCheck();
        }
    }

    public void AddSpawnEvent(UpgradeItem item)
    {
        if(item != null)
        SpawnQueue.Enqueue(item);
    }
}
