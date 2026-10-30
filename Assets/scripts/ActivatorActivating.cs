using UnityEngine;

public class ActivatorActivating : MonoBehaviour
{
    bool check = false;
    public GameObject toActivate;
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
        }
        check = true;
    }
}
