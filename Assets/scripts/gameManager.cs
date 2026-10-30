using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public TMP_Text label;
    public TMP_Text tocollect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StaticClasses.timeLeft = 120;
        StaticClasses.toCollect = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //updating label:
        
        if (StaticClasses.timeLeft <= 0f) blackout();
        if(StaticClasses.toCollect <= 0f) congrats();
        StaticClasses.timeLeft -= Time.deltaTime;
        label.text = $"Time remaining: {(int)((int)StaticClasses.timeLeft / 60)}:{(int)StaticClasses.timeLeft % 60}";
        tocollect.text = $"To collect: {StaticClasses.toCollect}";

    }

    void blackout() {
       // Debug.Log("Blackout! Skill Issue!");
        SceneManager.LoadSceneAsync("Blackout");
    }

    void congrats()
    {
        // Debug.Log("Congratulations! Power is back")
        SceneManager.LoadSceneAsync("Congratulations");
    }
}
