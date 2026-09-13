using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreTextBox;
    public TMP_Text highscoreTextBox;
    public string LastScoreTooltipText;
    public string HighScoreTooltipText;

    void Start()
    {
        if(scoreTextBox != null) scoreTextBox.text = LastScoreTooltipText + GlobalSettings.GetLastGameScore();
        if(highscoreTextBox != null) highscoreTextBox.text = HighScoreTooltipText + PlayerPrefs.GetFloat("highscore");
    }

    public void UpdateHighscore()
    {
        PlayerPrefs.SetFloat("highscore", GlobalSettings.GetLastGameScore());
        PlayerPrefs.Save();
        highscoreTextBox.text = HighScoreTooltipText + PlayerPrefs.GetFloat("highscore");
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetFloat("highscore", 0f);
        PlayerPrefs.Save();
    }
}
