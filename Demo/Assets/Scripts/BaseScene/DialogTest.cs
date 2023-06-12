using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem01;
    
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

        yield return new WaitForSeconds(2);
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
