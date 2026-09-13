using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreferenceMenuController : MonoBehaviour
{
    public TMP_Dropdown difficultySelector;
    public TMP_Dropdown cardAmountSelector;

    void Start()
    {
        difficultySelector.value = GlobalSettings.GetDifficulty();
        cardAmountSelector.value = GlobalSettings.GetCardAmount();
    }

    public void SetDifficulty()
    {
        GlobalSettings.SetDifficulty(difficultySelector.value);
    }

    public void SetCardAmount()
    {
        GlobalSettings.SetCardAmount(cardAmountSelector.value);
    }
}
