using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UpgradeItemButton : MonoBehaviour
{
    private float DefaultClickCost;
    private float ClickCostIncreaseAdditionValue;
    private float ClickCostIncreaseMultiplyValue;
    private float MeritMultiply;
    private float MeritAddition;
    [SerializeField] UpgradeItem upgradeItem;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI PriceNumber;

    protected virtual void Start()
    {
        GameManager.Instance.SetUpgradeItemData(upgradeItem.ID, 0);
        SetDefaultValue();
        SetCostNumber(GetClickCost());
        Name.text = upgradeItem.ItemName;
    }

    private void SetDefaultValue()
    {
        DefaultClickCost = upgradeItem.DefaultCost;
        ClickCostIncreaseAdditionValue = upgradeItem.CostIncreaseAdditionValue;
        ClickCostIncreaseMultiplyValue = upgradeItem.CostIncreaseMultiplyValue;
        MeritMultiply = upgradeItem.MeritMultiply;
        MeritAddition = upgradeItem.MeritAddition;
    }

    private void SetCostNumber(float Number)
    {
        PriceNumber.text = Number.ToString();
    }

    protected virtual float ClickCostIncreaseAddition()
    {
        return ClickCostIncreaseAdditionValue;
    }

    protected virtual float ClickCostIncreaseMultiply()
    {
        return ClickCostIncreaseMultiplyValue;
    }

    public float GetClickCost()
    {
        int Time = GameManager.Instance.GetUpgradeItemDataValue(upgradeItem.ID);
        return (DefaultClickCost +
            Time * ClickCostIncreaseAddition()) *
            Mathf.Pow(1 + ClickCostIncreaseMultiply(), Time);
    }

    public virtual void IncreaseMeritStrength()
    {
        GameManager.Instance.SendMeritStrenghIncrease(MeritAddition, MeritMultiply);
    }

    public virtual void CostUpdate()
    {
        SetCostNumber(GetClickCost());
    }
    
}
