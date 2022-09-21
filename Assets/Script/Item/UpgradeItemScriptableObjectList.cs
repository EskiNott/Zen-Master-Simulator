using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/List/UpgradeItem")]
public class UpgradeItemScriptableObjectList : ScriptableObject
{
    public List<UpgradeItem> List;
}
