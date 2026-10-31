using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class puzzleManager : MonoBehaviour
{
    public TMP_Text btn1, btn2, heading;
    public GameObject camera1, camera2;
    public AudioSource audioSource;
    public AudioClip success, fail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public IEnumerator PlayAndWait(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            yield break;

        audioSource.clip = clip;
        audioSource.Play();

        // Wait while the source is still playing.
        // Note: isPlaying becomes false if the source is paused, so we also
        // check the application focus state to avoid returning early.
        while (audioSource.isPlaying)
            yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private FirstPersonController player;
    private bool prevCameraCanMove;
    private bool prevPlayerCanMove;

    private void OnEnable()
    {
        

        // The controller lives in the base scene, so find it at runtime
        player = FindAnyObjectByType<FirstPersonController>();
        if (player != null)
        {
            prevCameraCanMove = player.cameraCanMove;
            prevPlayerCanMove = player.playerCanMove;
            player.cameraCanMove = false;   // stop mouse look
            player.playerCanMove = false;   // optional: freeze movement
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        switch(StaticClasses.puzzleID)
        {
            case "puzzle1":
                camera1.SetActive(true);
                camera2.SetActive(false);
                btn1.text = "Give money";
                btn2.text = "Threaten";
                heading.text = "Convince the farmer to donate sell his land";
                break;
            case "puzzle2":
                camera1.SetActive(false);
                camera2.SetActive(true);
                btn1.text = "Pay money";
                btn2.text = "Threaten";
                heading.text = "Convince the contractor to sponsor the project";
                break;
        }
    }

    private void OnDisable()
    {
        

        // Hand control back to the player (if it still exists)
        if (player != null)
        {
            player.cameraCanMove = prevCameraCanMove;
            player.playerCanMove = prevPlayerCanMove;
            if (player.lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void Success()
    {
        Scene active = gameObject.scene;
        PlayAndWait(success);
        SceneManager.UnloadSceneAsync(active);
    }

    public void Failure()
    {
        // Intentionally empty
        audioSource.PlayOneShot(fail);
    }
}
