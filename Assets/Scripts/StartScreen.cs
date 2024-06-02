using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public float speed = .5f;
    public float height = .5f;

    private bool isAnimating = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartAnimation();
    }

    private void OnDisable()
    {
        StopAnimation();
    }

    private void StartAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(SpriteAnimation());
            StartCoroutine(FlapBird());
        }
    }

    private void StopAnimation()
    {
        if (isAnimating)
        {
            isAnimating = false;
            StopAllCoroutines();
            spriteRenderer.sprite = sprites[0];
        }
    }

    private IEnumerator SpriteAnimation()
    {
        while (isAnimating)
        {
            yield return new WaitForSeconds(0.15f);
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private IEnumerator FlapBird()
    {
        while (isAnimating)
        {
            float newY = Mathf.PingPong(Time.time * speed, 1f) * 3.5f;
            transform.position = new Vector2(4f, (newY * height));
            yield return null;
        }
    }
}
