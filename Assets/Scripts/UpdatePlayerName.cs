using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatePlayerName : MonoBehaviour
{
    public TMP_Text nameTextBox;
    public string TooltipText;

    void Start()
    {
        nameTextBox.text = TooltipText + GlobalSettings.GetPlayerName();
    } 
}
