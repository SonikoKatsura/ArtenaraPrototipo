
using UnityEngine;

public class SCSelectorBtn : MonoBehaviour {

    public void MainMenu() {
        SCManager.instance.LoadScene("MainMenu");
        //AudioManager.instance.PlayMusic("ManiMenu");
    }
    public void Credits() {
        // SCManager.instance.LoadScene("Credits");
        SCManager.instance.LoadScene("Credits");
    }

    public void Exit() {
        Application.Quit();
    }

    public void Intro() {
        SCManager.instance.LoadScene("Intro");
        Debug.Log("Intro");
        //AudioManager.instance.PlayMusic("Intro");
    }
    public void Game() {
        Debug.Log("Game");
        SCManager.instance.LoadScene("Artenara");
        Debug.Log("Game");
    }
}
