using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ItemSpawner : MonoSingleton<ItemSpawner>
{
    private Queue<SpawnEvent> SpawnQueue;
    [SerializeField] private Transform SpawnerTrans;
    [SerializeField] private Transform SpawnParent;
    [SerializeField] private UpgradeItemScriptableObjectList ItemList;

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
        int ItemCount = 0;
        int[] ItemObjectsDuplicate = (int[])GameManager.Instance.GetUpgradeItemData().Clone();
        foreach(int item in ItemObjectsDuplicate)
        {
            ItemCount += item;
        }
        if (ItemCount > GameManager.Instance.MaxItemExist)
        {
            int Max = GameManager.Instance.MaxItemExist;
            for(int i = 0; i < Max;)
            {
                int index = UnityEngine.Random.Range(0, ItemObjectsDuplicate.Length);
                if (ItemObjectsDuplicate[index] > 0)
                {
                    ItemObjectsDuplicate[index]--;
                    AddSpawnEvent(index);
                    i++;
                }
            }
        }
        else
        {

        }
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

    public void AddSpawnEvent(int ID)
    {
        if (ItemList.List[ID] != null)
        {
            SpawnQueue.Enqueue(new SpawnEvent(ItemList.List[ID]));
        }
    }

    public void AddSpawnEvent(UpgradeItem item, UpgradeItemButton button = null)
    {
        if (item != null)
        {
            SpawnQueue.Enqueue(new SpawnEvent(item, button));
        }
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
