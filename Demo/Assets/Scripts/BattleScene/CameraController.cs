using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GroupObject playerGroup;

    void Start()
    {
        //AT = A.transform;
    }

    void Update()
    {
        if(playerGroup.characterGroup[0] != null)
        {
            float x1 = playerGroup.characterGroup[0].transform.position.x;

            Vector3 a = new Vector3(x1, 8.3f, -14);

            transform.position = Vector3.Lerp(transform.position, a, 2f * Time.deltaTime);

            //카메라를 원래 z축으로 이동
            Vector3 pos = transform.position;
            pos.z = -10f;
            transform.position = pos;
        }
      
    }
}

