using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public TMP_Text introText;
    public Image introImage;

    public string[] texts;
    public Sprite[] images;

    private int pressCount = 0;

    void Start()
    {
        introText.text = texts[pressCount];
        introImage.sprite = images[pressCount];
    }
    public void OnNextButtonPressed()
    {
        pressCount++;

        if (pressCount >= texts.Length)
        {
            SceneManager.LoadScene("SampleScene");
            return;
        }

        introText.text = texts[pressCount];

        if (pressCount < images.Length && images[pressCount] != null)
        {
            introImage.sprite = images[pressCount];
        }
    }

    public void OnSkipButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
}


