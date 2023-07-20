using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private FadeScript fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.fadingIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
