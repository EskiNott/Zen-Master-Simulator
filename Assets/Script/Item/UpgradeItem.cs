using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / UpgradeItem")]
public class UpgradeItem : ScriptableObject
{
    public int ID;
    public int MeritAddition;
    public float MeritMultiply;
    public GameObject ItemPrefab;

    public UpgradeItem()
    {
        ID = -1;
        MeritAddition = 0;
        MeritMultiply = 1.0f;
    }
}
