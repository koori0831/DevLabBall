using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private string lobbySceneName;
    [SerializeField] private GameObject clearUI;
    
    //선형보간, 러프는 오면 알려주겠다고 하기.
    public void OnClearUI()
    {
        Time.timeScale = 0;//이것도 가르쳐야함
        clearUI.SetActive(true);//이것도
    }

    public void GoLobbyScene()
    {        
        Time.timeScale = 1;
        SceneManager.LoadScene(lobbySceneName);
    }

    //버튼들 하나하나 세팅해주고 구독처리해서 실행하게 하삼
    public void GoStageScene(int stageNum)
    {
        SceneManager.LoadScene($"stage{stageNum}");
    }
}
