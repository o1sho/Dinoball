using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int _frame;

    [SerializeField] private float _timeBetweenFrames;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameVisible()
    {
        Invoke(nameof(Animate), 0f);

    }
    private void OnBecameInvisible()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        _frame++;
        if (_frame >= sprites.Length)
        {
            _frame = 0;
        }
        if (_frame >= 0 && _frame < sprites.Length) spriteRenderer.sprite = sprites[_frame];

        Invoke(nameof(Animate), _timeBetweenFrames);
    }
}
