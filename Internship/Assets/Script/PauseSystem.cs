using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public void Pause() => Time.timeScale = 0f;
    public void Resume() => Time.timeScale = 1f;
    public void Quit() => Application.Quit();
    public void MainMenu() => SceneManager.LoadScene(0);
}
