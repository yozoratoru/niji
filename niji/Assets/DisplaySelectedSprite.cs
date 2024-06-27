using UnityEngine;

public class DisplaySelectedSprite : MonoBehaviour
{
    public Sprite[] sprites;  // 同じスプライトのリスト
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = PlayerPrefs.GetInt("SelectedSpriteIndex", 0);
        spriteRenderer.sprite = sprites[index];
    }
}
