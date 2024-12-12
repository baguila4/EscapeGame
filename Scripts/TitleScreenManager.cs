using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public Image startButtonImage;
    public Image quitButtonImage; 

    public Sprite startNormal;    
    public Sprite startHover;    
    public Sprite startClicked;    

    public Sprite quitNormal;    
    public Sprite quitHover;      
    public Sprite quitClicked;   

    void Start()
    {
        // Ensure buttons start with their normal sprites
        startButtonImage.sprite = startNormal;
        quitButtonImage.sprite = quitNormal;
    }

    public void OnStartHover()
    {
        startButtonImage.sprite = startHover;
    }

    public void OnStartClick()
    {
        startButtonImage.sprite = startClicked;
        SceneManager.LoadScene("Levil1"); 
    }

    public void OnStartExit()
    {
        startButtonImage.sprite = startNormal;
    }

    public void OnQuitHover()
    {
        quitButtonImage.sprite = quitHover;
    }

    public void OnQuitClick()
    {
        quitButtonImage.sprite = quitClicked;
        Application.Quit(); // Closes the application
    }

    public void OnQuitExit()
    {
        quitButtonImage.sprite = quitNormal;
    }
}
