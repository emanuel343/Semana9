using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryLose : MonoBehaviour
{
    static public VictoryLose instance;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject lose;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            lose = GameObject.FindGameObjectWithTag("Lose");
            victory = GameObject.FindGameObjectWithTag("Victory");
            SceneManager.sceneLoaded += OnSceneLoaded;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Victory()
    {
        if(SceneManager.GetActiveScene().name == "Nivel1")
        {
            Controller.gameJoltController.CheckTrophieLvl(1);
        }
        else if(SceneManager.GetActiveScene().name == "Nivel2")
        {
            Controller.gameJoltController.CheckTrophieLvl(2);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        victory.SetActive(true);
    }

    public void Lose()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lose.SetActive(true);
    }

    public void LoadScene(string name)
    {
        victory.SetActive(false);
        lose.SetActive(false);
        SceneManager.LoadScene(name);
    }
    
    public void Trophies()
    {
        Controller.gameJoltController.ShowTrophies();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(victory != null)
        victory.SetActive(false);

        if(lose != null)
        lose.SetActive(false);
    }
}
