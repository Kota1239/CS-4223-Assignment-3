using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    public GameObject playerNameInput;

    public void UpdatePlayerName()
    {
        GlobalSettings.SetPlayerName(playerNameInput.GetComponent<TMP_InputField>().text);
        UnityEngine.Debug.Log(GlobalSettings.GetPlayerName());
    }
}
