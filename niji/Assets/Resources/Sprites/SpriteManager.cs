using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    public Image displayImage;

    // スプライト名と対応する色のマッピング
    private readonly Dictionary<string, List<string>> spriteColorMap = new Dictionary<string, List<string>>
    {
        { "akakiao", new List<string> { "red", "yellow", "blue" } },
        { "akakiku", new List<string> { "red", "yellow", "black" } },
        { "kukisi", new List<string> { "black", "yellow", "white" } },
        { "nijiniji", new List<string> { "green", "yellow", "red" } }
    };

    private Sprite[] sprites;
    private Sprite selectedSprite;

    void Start()
    {
        // Resourcesフォルダからスプライトをロード
        sprites = Resources.LoadAll<Sprite>("Sprites");

        // ランダムにスプライトを選択
        selectedSprite = sprites[Random.Range(0, sprites.Length)];

        // スプライトを表示
        displayImage.sprite = selectedSprite;

        // 選択されたスプライトの名前を保存（次のシーンでも参照できるように）
        PlayerPrefs.SetString("SelectedSprite", selectedSprite.name);

        // デバッグログで選択されたスプライトと色の対応を表示（必要に応じて）
        Debug.Log($"Selected Sprite: {selectedSprite.name}, Colors: {string.Join(", ", spriteColorMap[selectedSprite.name])}");
    }

    public void OnNextSceneButtonClicked()
    {
        // 次のシーンに移動
        SceneManager.LoadScene("NextSceneName");
    }
}
