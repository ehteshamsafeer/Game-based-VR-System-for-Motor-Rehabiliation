using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionReference PauseGame;
    GameObject xrOrigin;

    string gameLevel;
    string gameName;
    private void Start()
    {
        xrOrigin = GameObject.FindWithTag("Player");
    }
    public void LoadGame()
    {
        Destroy(xrOrigin);
        SceneManager.LoadScene(gameName, LoadSceneMode.Single);
    }
    public void SetgameName(string buttoninputname)
    {

        gameName = buttoninputname;
        PlayerPrefs.SetString("Game Name", gameName);
    }
    public void SetgameLevel(string buttoninputname)
    {
        gameLevel = buttoninputname;
        PlayerPrefs.SetString("Game Level", gameLevel);
    }
    private void OnEnable()
    {
        PauseGame.action.started += GamePaused;
    }
    private void OnDisable()
    {
        PauseGame.action.started -= GamePaused;
    }
    private void GamePaused(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
