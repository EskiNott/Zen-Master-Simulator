using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemSpawner : MonoSingleton<ItemSpawner>
{
    private Queue<SpawnEvent> SpawnQueue;
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
            SpawnEvent Event = SpawnQueue.Dequeue();
            GameManager.Instance.SetUpgradeItemData(Event.item.ID, GameManager.Instance.GetUpgradeItemDataValue(Event.item.ID) + 1);
            GameObject go = Instantiate(Event.item.ItemPrefab, SpawnerTrans.position, SpawnerTrans.rotation, SpawnParent);
            Item item = go.GetComponent<Item>();
            item.ID = Event.item.ID;
            if (Event.Button != null)
            {
                Event.Button.CostUpdate();
            }
            GameManager.Instance.MaxItemCheck();
        }
    }

    public void AddSpawnEvent(SpawnEvent Event)
    {
        if(Event.item != null)
        SpawnQueue.Enqueue(Event);
    }

    public class SpawnEvent
    {
        public UpgradeItem item;
        public UpgradeItemButton Button;
        public SpawnEvent(UpgradeItem i, UpgradeItemButton button = null)
        {
            this.item = i;
            Button = button;
        }
    }
}
