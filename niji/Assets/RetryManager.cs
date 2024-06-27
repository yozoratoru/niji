using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    public void Retry()
    {
        // SampleSceneに移動する
        SceneManager.LoadScene("SampleScene");
    }
}