using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoSingleton<ItemSpawner>
{
    private Queue<UpgradeItem> SpawnQueue;
    [SerializeField] private Transform SpawnerTrans;
    [SerializeField] private Transform SpawnParent;

    private void Start()
    {
        SpawnQueue = new();
    }

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (SpawnQueue.Count > 0)
        {
            UpgradeItem iScriptableObject = SpawnQueue.Dequeue();
            GameObject go = Instantiate(iScriptableObject.ItemPrefab, SpawnerTrans.position, SpawnerTrans.rotation, SpawnParent);
            Item iScript = go.GetComponent<Item>();
            iScript.ID = iScriptableObject.ID;
            GameManager.Instance.MaxItemCheck();
        }
    }

    public void AddSpawnEvent(UpgradeItem item)
    {
        if(item != null)
        SpawnQueue.Enqueue(item);
    }
}
