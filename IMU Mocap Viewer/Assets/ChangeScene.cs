using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void ChangeToScene()
    {
        // var scene = SceneManager.GetSceneByName(sceneName);
        //
        // if (scene.IsValid() == false)
        // {
        //     throw new System.Exception($"Scene '{sceneName}' is not valid or does not exist.");
        // }
        
        LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
        
        SceneManager.LoadScene(sceneName, parameters);
    }
}
