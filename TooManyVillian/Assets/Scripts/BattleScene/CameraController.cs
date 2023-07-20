using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera; // 메인 카메라
    
    public GroupObject playerGroup; // 플레이어 그룹
    public GameObject battleArea; // 배틀 공간 생성
    public float defaultZoomSize; // 줌아웃할 때 크기, 원래 카메라 크기
    public float targetZoomSize; // 줌인할 때 크기
    public float targetZoomSpeed; // 줌인하는 속도
    private Vector3 Combat; // 
    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if(playerGroup.characterGroup.Count != 0) // 가장 앞에 있는 캐릭터 기준으로 변경
        {
            if(BattleSceneManager.instance.isEngaging)
            {
                ZoomIn();

                if (battleArea.activeSelf == false) // 딱 한번만 위치를 고정시켜 준다. 
                {
                    float x1 = playerGroup.characterGroup[0].transform.position.x;
                    float y1 = playerGroup.characterGroup[0].transform.position.y;

                    Combat = new Vector3(x1, y1 + 6f, -11);
                }

                transform.position = Vector3.Lerp(transform.position, Combat, 2f * Time.deltaTime);

                battleArea.transform.position = Combat; // 배틀 공간도 똑같은 위치로 옮겨준다.
                battleArea.SetActive(true);

            }
            
            else
            {
                ZoomOut();

                if (battleArea.activeSelf == true)
                {
                    battleArea.SetActive(false);
                }
       
                float x1 = playerGroup.characterGroup[0].transform.position.x;

                Vector3 nonCombat = new Vector3(x1, 12.8f, -14);

                transform.position = Vector3.Lerp(transform.position, nonCombat, 2f * Time.deltaTime);

                //카메라를 원래 z축으로 이동
                Vector3 pos = transform.position;
                pos.z = -10f;
                transform.position = pos;
            }
           
        }
      
    }

    private void ZoomIn()
    {
        float smoothZoomSize = Mathf.SmoothDamp(mainCamera.orthographicSize, targetZoomSize,
                                            ref targetZoomSpeed, 0.5f);

        mainCamera.orthographicSize = smoothZoomSize;
    }

    private void ZoomOut()
    {
        float smoothZoomSize = Mathf.SmoothDamp(mainCamera.orthographicSize, defaultZoomSize,
                                            ref targetZoomSpeed, 0.5f);

        mainCamera.orthographicSize = smoothZoomSize;
    }
}