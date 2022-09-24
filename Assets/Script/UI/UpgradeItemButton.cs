using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeItemButton : MonoBehaviour
{
    public float DefaultClickCost;
    private int Time_Multiply;
    private int Time_Addition;
    public float MeritMultiply;
    public float MeritAddition;
    [SerializeField] UpgradeItem upgradeItem;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI PriceNumber;

    public UpgradeItemButton()
    {
        DefaultClickCost = 1;
        Time_Addition = 0;
        Time_Multiply = 0;
        MeritMultiply = 1;
        MeritAddition = 0;
    }

    protected virtual void Start()
    {
        SetCostNumber(GetClickCost());
        Name.text = upgradeItem.ItemName;
    }

    private void SetCostNumber(float Number)
    {
        PriceNumber.text = Number.ToString();
    }

    protected virtual float ClickCostIncreaseAddition()
    {
        return 0;
    }

    protected virtual float ClickCostIncreaseMultiply()
    {
        return 0.5f;
    }

    public float GetClickCost()
    {
        return (DefaultClickCost +
            Time_Addition * ClickCostIncreaseAddition()) *
            Time_Multiply > 0 ? 
            Time_Multiply * ClickCostIncreaseMultiply() : 1;
    }

    public virtual void IncreaseMeritStrength()
    {
        GameManager.Instance.SendMeritStrenghIncrease(MeritAddition, MeritMultiply);
    }

    public virtual void CostIncrease()
    {
        Time_Addition++;
        Time_Multiply++;
        SetCostNumber(GetClickCost());
    }
    
}
