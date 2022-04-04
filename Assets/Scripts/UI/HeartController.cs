using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    private Image heartImage;

    void Start()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetRatio(float ratio)
    {
        heartImage.fillAmount = ratio;
    }
}
