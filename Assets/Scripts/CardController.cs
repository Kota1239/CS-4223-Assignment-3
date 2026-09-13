using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    bool show = false;
    bool hide = false;
    bool cardShown = false;
    public Sprite cardBack;
    public Sprite cardFace;
    public int cardNumber = 0;
    AudioManager audioManager;

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioManager.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float angleY = gameObject.transform.eulerAngles.y;
        if (show == true) gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 240 * Time.deltaTime);
        if (angleY >89) GetComponent<UnityEngine.UI.Image>().sprite = cardFace;
        if (angleY >= 175) show = false;
        if (hide == true) gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, -240 * Time.deltaTime);
        if (angleY < 91) GetComponent<UnityEngine.UI.Image>().sprite = cardBack;
        if (angleY <= 5) hide = false;
    }

    public void ShowCard()
    {
        audioManager.PlayCardFlipSound();
        show = true;
        cardShown = true;
    }

    public void HideCard()
    {
        audioManager.PlayCardFlipSound();
        hide = true;
        cardShown = false;
    }

    public void ClickCard()
    {
        ShowCard();
        GameController.PassCardSelection(this.gameObject);
        this.GetComponent<Button>().interactable = false;
    }
}
