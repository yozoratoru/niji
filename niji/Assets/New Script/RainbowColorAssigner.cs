using System.Collections.Generic;
using UnityEngine;

public class RainbowColorAssigner : MonoBehaviour
{
    // インスペクターで虹のスプライト数を指定
    [SerializeField] private int numberOfColors = 7;
    [SerializeField] private List<SpriteRenderer> rainbowSprites = new List<SpriteRenderer>();

    private List<Color> rainbowColors = new List<Color>
    {
        Color.red,          // 赤
        new Color(1f, 0.5f, 0f), // 橙
        Color.yellow,       // 黄
        Color.green,        // 緑
        Color.blue,         // 青
        new Color(0.29f, 0f, 0.51f), // 藍
        new Color(0.58f, 0f, 0.83f)  // 紫
    };

    private void Start()
    {
        AssignRainbowColors();
    }

    private void AssignRainbowColors()
    {
        // 色の数が足りなければエラー
        if (numberOfColors > rainbowColors.Count)
        {
            Debug.LogError("虹の個数が7色を超えています。numberOfColorsを減らしてください。");
            return;
        }

        // 使用する色のリストをシャッフルし、選択
        List<Color> availableColors = new List<Color>(rainbowColors);
        for (int i = 0; i < numberOfColors; i++)
        {
            // ランダムで色を選択し、重複しないように削除
            int randomIndex = Random.Range(0, availableColors.Count);
            Color selectedColor = availableColors[randomIndex];
            availableColors.RemoveAt(randomIndex);

            // スプライトに色を設定
            if (i < rainbowSprites.Count)
            {
                rainbowSprites[i].color = selectedColor;
            }
        }
    }
}
