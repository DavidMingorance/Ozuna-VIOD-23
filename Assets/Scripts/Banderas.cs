using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banderas : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           ChangeSprite();
        }
    }
}
