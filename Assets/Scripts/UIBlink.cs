using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIBlink : MonoBehaviour
    {
        [SerializeField] private Sprite firstSprite;
        [SerializeField] private Sprite secondSprite;
        [SerializeField] private Image image;
        public void Start()
        {
            StartCoroutine(Blink());
        }

        private IEnumerator Blink()
        {
            yield return new WaitForSeconds(0.1f);
            if (image.sprite == firstSprite)
                image.sprite = secondSprite;
            else
                image.sprite = firstSprite;
            StartCoroutine(Blink());
        }
    }
}