using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public CanvasGroup canvasgroup;

    [SerializeField] private float timeToFade =1f;

    public bool fadingOut = false;
    public bool fadingIn = false;

    void Start()
    {
        canvasgroup.alpha = 1f;
    }
    void Update()
    {
        if(fadingOut)
        {
            if(canvasgroup.alpha < 1f)
            {
                canvasgroup.alpha += timeToFade * Time.deltaTime;
                if(canvasgroup.alpha >= 1)
                {
                    fadingOut = false;
                }
            }
        }
        if(fadingIn)
        {
            if(canvasgroup.alpha >= 0f)
            {
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if(canvasgroup.alpha == 0)
                {
                    fadingIn = false;
                }
            }
        }
    }


}
