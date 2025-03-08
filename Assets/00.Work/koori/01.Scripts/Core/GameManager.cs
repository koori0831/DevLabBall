using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject clearUI, defeatUI;
    
    //선형보간, 러프는 오면 알려주겠다고 하기.
    public void OnClearUI()
    {
        Time.timeScale = 0;//이것도 가르쳐야함
        clearUI.SetActive(true);//이것도
    }
    public void OnDefeatUI()
    {
        Time.timeScale = 0;//이것도 가르쳐야함
        defeatUI.SetActive(true);//이것도
    }

    public void ChangeScene(string SceneName)
    {        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
