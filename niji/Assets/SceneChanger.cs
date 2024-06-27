using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float delay = 1f;  // シーン遷移の遅延時間

    void Start()
    {
        // 指定された遅延時間後に次のシーンに移動
        Invoke("ChangeScene", delay);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("kaitou");
    }
}
