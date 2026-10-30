using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivatorActivating : MonoBehaviour
{
    bool check = false;
    public GameObject toActivate;
    public string puzzleID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (check == false)
        {
            toActivate.SetActive(true);
            StaticClasses.toCollect--;
            StaticClasses.puzzleID = puzzleID;
            SceneManager.LoadScene("puzzle", LoadSceneMode.Additive);
        }
        check = true;
    }
}
