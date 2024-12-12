using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public Image restartButtonImage; 
    public Image quitButtonImage; 

    public Sprite restartNormal; 
    public Sprite restartHover; 
    public Sprite restartClicked; 

    public Sprite quitNormal; 
    public Sprite quitHover; 
    public Sprite quitClicked; 

    private void Start()
    {
        restartButtonImage.sprite = restartNormal;
        quitButtonImage.sprite = quitNormal;
    }

    public void OnRestartHover()
    {
        restartButtonImage.sprite = restartHover;
    }

    public void OnRestartClick()
    {
        restartButtonImage.sprite = restartClicked;
        SceneManager.LoadScene("TitleScreen"); 
    }

    public void OnRestartExit()
    {
        restartButtonImage.sprite = restartNormal;
    }

    public void OnQuitHover()
    {
        quitButtonImage.sprite = quitHover;
    }

    public void OnQuitClick()
    {
        quitButtonImage.sprite = quitClicked;
        Application.Quit(); // Quit the application
    }

    public void OnQuitExit()
    {
        quitButtonImage.sprite = quitNormal;
    }
}
