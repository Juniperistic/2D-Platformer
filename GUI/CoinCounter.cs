using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int displayValue = -1;

    public Sprite[] spriteDigits;

    public int value = 0;
    public float spacing = 0.4f;

    public SpriteRenderer[] renderers;

    void Update()
    {
        if (displayValue != value)
        {
            string digits = value.ToString();
            renderers = GetComponentsInChildren<SpriteRenderer>();
            int numRenderers = renderers.Length;

            if (numRenderers < digits.Length)
            {
                while (numRenderers < digits.Length)
                {
                    GameObject spr = new GameObject();
                    spr.AddComponent<SpriteRenderer>();
                    spr.transform.parent = transform;
                    spr.transform.localPosition = new Vector3(numRenderers * spacing, 0.0f, 0.0f);
                    spr.layer = 5;

                    numRenderers++;
                }

                renderers = GetComponentsInChildren<SpriteRenderer>();
            }
            else if (numRenderers > digits.Length)
            {
                while (numRenderers > digits.Length)
                {
                    renderers[numRenderers - 1].sprite = null;
                    numRenderers--;
                }
            }

            int rendererIndex = 0;
            foreach (char digit in digits)
            {
                int spriteIndex = int.Parse(digit.ToString());
                Debug.Log("RendererIndex: " + rendererIndex);
                renderers[rendererIndex].sprite = spriteDigits[spriteIndex];
                rendererIndex++;
            }
            displayValue = value;
        }
    }
}
