using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string playerNamePreference = "Player";

    public static int difficultyPreference = 2;
    public static int cardAmountPreference = 2;

    public static float lastGameScore;

    public static void SetPlayerName(string input)
    {
        playerNamePreference = input;
    }

    public static string GetPlayerName()
    {
        return playerNamePreference;
    }

    public static void SetDifficulty(int input)
    {
        difficultyPreference = input;
    }

    public static int GetDifficulty()
    {
        return difficultyPreference;
    }

    public static void SetCardAmount(int input)
    {
        cardAmountPreference = input;
    }

    public static int GetCardAmount()
    {
        return cardAmountPreference;
    }

    public static void SetLastGameScore(float input)
    {
        lastGameScore = input;
    }

    public static float GetLastGameScore()
    {
        return lastGameScore;
    }
}
