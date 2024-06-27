using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public Button redButton;
    public Button blueButton;
    public Button yellowButton;
    public Button greenButton;
    public Button purpleButton;
    public Button blackButton;
    public Button whiteButton;

    private string selectedSpriteName;
    private Dictionary<string, List<string>> correctColorsMap = new Dictionary<string, List<string>>
    {
        { "akakiao", new List<string> { "red", "yellow", "blue" } },
        { "akakiku", new List<string> { "red", "yellow", "black" } },
        { "kukisi", new List<string> { "black", "yellow", "white" } },
        { "nijiniji", new List<string> { "green", "yellow", "red" } }
    };

    private int correctCount = 0;    // 正解のカウンター
    private int incorrectCount = 0;  // 不正解のカウンター

    void Start()
    {
        // 前のシーンで選択されたスプライトの名前を取得
        selectedSpriteName = PlayerPrefs.GetString("SelectedSprite");

        // ボタンのクリックイベントを設定
        redButton.onClick.AddListener(() => OnButtonClicked("red"));
        blueButton.onClick.AddListener(() => OnButtonClicked("blue"));
        yellowButton.onClick.AddListener(() => OnButtonClicked("yellow"));
        greenButton.onClick.AddListener(() => OnButtonClicked("green"));
        purpleButton.onClick.AddListener(() => OnButtonClicked("purple"));
        blackButton.onClick.AddListener(() => OnButtonClicked("black"));
        whiteButton.onClick.AddListener(() => OnButtonClicked("white"));
    }

    void OnButtonClicked(string color)
    {
        if (IsCorrectColor(color))
        {
            Debug.Log("Correct!");
            correctCount++; // 正解カウンターをインクリメント

            // 正解が3回連続で出た場合
            if (correctCount == 3)
            {
                Debug.Log("Moving to next scene...");
                SceneManager.LoadScene("kuria");
            }
        }
        else
        {
            Debug.Log("Incorrect!");
            incorrectCount++; // 不正解カウンターをインクリメント

            // 不正解が3回連続で出た場合
            if (incorrectCount == 3)
            {
                Debug.Log("Moving to retry scene...");
                SceneManager.LoadScene("a");
            }
        }
    }

    bool IsCorrectColor(string color)
    {
        // 選択されたスプライト名に対応する正しい色のリストを取得
        List<string> correctColors = correctColorsMap[selectedSpriteName];

        // 正しい色のリストに含まれているかどうかを判断
        return correctColors.Contains(color);
    }
}
