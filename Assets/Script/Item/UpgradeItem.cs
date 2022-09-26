using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / UpgradeItem")]
public class UpgradeItem : ScriptableObject
{
    public int ID;
    public string ItemName;
    public GameObject ItemPrefab;
    public float MeritMultiply;
    public float MeritAddition;
    public float DefaultCost;
    public float CostIncreaseAdditionValue;
    public float CostIncreaseMultiplyValue;

    public UpgradeItem()
    {
        ID = -1;
        MeritMultiply = 0;
        MeritAddition = 0;
        DefaultCost = 0;
        CostIncreaseAdditionValue = 0;
        CostIncreaseMultiplyValue = 0;
    }
}
