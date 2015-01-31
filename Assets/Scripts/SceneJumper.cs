using UnityEngine;
using System.Collections;

public class SceneJumper : MonoBehaviour {
    
    public void ChangeScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenReaderBoard()
    {

    }
}
