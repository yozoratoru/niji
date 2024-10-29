using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CustomSpriteLoader : MonoBehaviour
{
    public string folderPath = "Sprites"; // スプライトが保存されているフォルダーのパス
    private Sprite displayedSprite;
    private Dictionary<string, List<Button>> answerButtons;

    public Button redButton; // 赤ボタン
    public Button blueButton; // 青ボタン
    public Button yellowButton; // 黄色ボタン
    public Button greenButton; // 緑ボタン
    public Button purpleButton; // 紫ボタン
    public Button blackButton; // 黒ボタン
    public Button whiteButton; // 白ボタン

    private bool isTargetSpriteDisplayed = false;
    private Dictionary<string, bool> buttonPressed;

    void Start()
    {
        // ボタンのイベントリスナーを設定
        redButton.onClick.AddListener(() => OnButtonPressed("red"));
        blueButton.onClick.AddListener(() => OnButtonPressed("blue"));
        yellowButton.onClick.AddListener(() => OnButtonPressed("yellow"));
        greenButton.onClick.AddListener(() => OnButtonPressed("green"));
        purpleButton.onClick.AddListener(() => OnButtonPressed("purple"));
        blackButton.onClick.AddListener(() => OnButtonPressed("black"));
        whiteButton.onClick.AddListener(() => OnButtonPressed("white"));

        // 答えの色を設定
        answerButtons = new Dictionary<string, List<Button>>()
        {
            { "akakiao", new List<Button> { redButton, yellowButton, blueButton } },
            { "akakiku", new List<Button> { redButton, yellowButton, blackButton } },
            { "kukisi", new List<Button> { blackButton, yellowButton, whiteButton } },
            { "nijiniji", new List<Button> { greenButton, yellowButton, redButton } }
        };

        // ボタン押下状態を初期化
        buttonPressed = new Dictionary<string, bool>()
        {
            { "red", false },
            { "blue", false },
            { "yellow", false },
            { "green", false },
            { "purple", false },
            { "black", false },
            { "white", false }
        };

        // Resourcesフォルダー内のスプライトを全て読み込み
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);

        if (sprites.Length > 0)
        {
            // ランダムにスプライトを選択
            int randomIndex = Random.Range(0, sprites.Length);
            displayedSprite = sprites[randomIndex];

            // 現在のオブジェクトのSpriteRendererにスプライトを設定
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = displayedSprite;
            }
            else
            {
                // もしSpriteRendererが存在しない場合、UIのImageコンポーネントに設定
                Image image = GetComponent<Image>();
                if (image != null)
                {
                    image.sprite = displayedSprite;
                }
            }

            // 表示されたスプライトが目標のスプライトか確認
            isTargetSpriteDisplayed = answerButtons.ContainsKey(displayedSprite.name);

            // スプライトを3秒間表示するコルーチンを開始
            StartCoroutine(SwitchSceneAfterDelay(3.0f));
        }
        else
        {
            Debug.LogWarning("指定されたフォルダ内にスプライトが見つかりませんでした。");
        }
    }

    IEnumerator SwitchSceneAfterDelay(float delay)
    {
        // 指定された時間待機
        yield return new WaitForSeconds(delay);

        // 次のシーンをロード（デモ用の仮のシーン名）
        SceneManager.LoadScene("NextScene");
    }

    void OnButtonPressed(string color)
    {
        buttonPressed[color] = true;
        CheckClearCondition();
    }

    void CheckClearCondition()
    {
        if (!isTargetSpriteDisplayed)
            return;

        List<Button> requiredButtons = answerButtons[displayedSprite.name];
        bool allPressed = true;

        foreach (Button button in requiredButtons)
        {
            string color = button.name.Replace("Button", "").ToLower();
            if (!buttonPressed[color])
            {
                allPressed = false;
                break;
            }
        }

        if (allPressed)
        {
            Debug.Log("クリア！");
            // クリア処理を実行（例：クリア画面に移行）
            SceneManager.LoadScene("ClearScene");
        }
    }
}
