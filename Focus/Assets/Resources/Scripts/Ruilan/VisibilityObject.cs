﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisibilityObject : MonoBehaviour {

    [SerializeField] private float timeFade;

    [SerializeField] private float minAlpha;
    private int maxAlpha = 1;

    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private IEnumerator FadeIn()
    {
        Color color = sprite.color;
        while (color.a > minAlpha)
        {
            color.a -= timeFade;
            sprite.color = color;

            yield return new WaitForSeconds(timeFade);
        }

        yield break;
    }

    private IEnumerator FadeOut()
    {
        Color color = sprite.color;
        while (color.a < maxAlpha)
        {
            color.a += timeFade;
            sprite.color = color;

            yield return new WaitForSeconds(timeFade);
        }

        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (string.Compare(collision.gameObject.tag, "Player") == 0)
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }

}
