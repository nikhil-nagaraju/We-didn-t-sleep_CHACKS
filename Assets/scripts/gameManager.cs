using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Persistent singleton: HP, inventory, checkpoints, defeated enemies, save/load.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static string NextEnemyName = "Unknown Enemy";

    public const string OverworldScene = "Overworld";
    public const string BattleScene = "BattleScene";

    public int playerHP = 20;
    public int maxHP = 20;
    public int teaCount = 2;

    public bool hasCheckpoint;
    public Vector2 checkpointPos;
    public bool hasReturnPos;
    public Vector2 returnPos;
    public bool cutscenePlayed;
    public HashSet<string> defeated = new HashSet<string>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Boot()
    {
        if (Instance == null)
            new GameObject("GameManager").AddComponent<GameManager>();
    }

    void Awake()
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
