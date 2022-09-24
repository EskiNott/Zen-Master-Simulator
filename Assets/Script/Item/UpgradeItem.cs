using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / UpgradeItem")]
public class UpgradeItem : ScriptableObject
{
    public int ID;
    public string ItemName;
    public GameObject ItemPrefab;

    public UpgradeItem()
    {
        ID = -1;
    }
}
