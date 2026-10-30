using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        SceneManager.UnloadSceneAsync(active);
    }

    public void Failure()
    {
        // Intentionally empty
    }
}
