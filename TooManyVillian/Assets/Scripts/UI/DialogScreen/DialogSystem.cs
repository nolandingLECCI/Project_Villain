// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class DialogSystem : MonoBehaviour
// {
//     [SerializeField]
//     private int branch;
//     [SerializeField]
//     private Dialog dialogDB;
//     [SerializeField]
//     private Speaker[] speakers;
//     [SerializeField]
//     private DialogData[] dialogs;

//     private bool isAutoStart = true;
//     private bool isFirst = true;
//     private int currentDialogIndex = -1;
//     private int currentSpeakerIndex = 0;
//     private float typingSpeed = 0.1f;
//     private bool isTypingEffect = false;
//     private void Awake()
//     {
//         int idx = 0;
//         for(int i = 0 ; i < dialogDB.DialogDB.Count; ++i)
//         {
//             if(dialogDB.DialogDB[i].branch == branch)
//             {
//                 dialogs[idx].speakerIndex = dialogDB.DialogDB[i].speakerIdx;
//                 dialogs[idx].name = dialogDB.DialogDB[i].name;
//                 dialogs[idx].dialog = dialogDB.DialogDB[i].dialog;
//                 idx++;
//             }
//         }
//         Setup();
//     }
//     private void Setup()
//     {
//         for(int i = 0 ; i < speakers.Length ; ++i)
//         {
//             SetActiveObjects(speakers[i] , false);
//             speakers[i].spriteRenderer.gameObject.SetActive(true);
//         }
//     }
//     public bool UpdateDialog()
//     {
//         if(isFirst == true)
//         {
//             Setup();
//             if(isAutoStart) SetNextDialog();
//             isFirst = false;
//         }
//         if(Input.GetMouseButtonDown(0))
//         {
//             if(isTypingEffect == true)
//             {
//                 isTypingEffect = false;
//                 StopCoroutine("OnTypingText");
//                 speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog;
//                 speakers[currentSpeakerIndex].objectArrow.SetActive(true);

//                 return false;
//             }
//             if(dialogs.Length > currentDialogIndex + 1)
//             {
//                 SetNextDialog();
//             }
//             else
//             {
//                 for(int i = 0 ; i < speakers.Length ; ++i)
//                 {
//                     SetActiveObjects(speakers[i] , false);
//                     speakers[i].spriteRenderer.gameObject.SetActive(false);
//                 }
//                 return true;
//             }
//         }
//         return false;
//     }
//     private void SetNextDialog()
//     {
//         SetActiveObjects(speakers[currentSpeakerIndex], false);

//         currentDialogIndex++;
        
//         currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

//         SetActiveObjects(speakers[currentSpeakerIndex], true);

//         speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

//         //speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog;
//         StartCoroutine("OnTypingText");

//     }
//     private void SetActiveObjects(Speaker speaker, bool visible)
//     {
//         speaker.imageDialog.gameObject.SetActive(visible);
//         speaker.textName.gameObject.SetActive(visible);
//         speaker.textDialog.gameObject.SetActive(visible);

//         speaker.objectArrow.SetActive(false);

//         Color color = speaker.spriteRenderer.color;
//         color.a = visible == true ? 1: 0.2f;
//         speaker.spriteRenderer.color = color;
//     }

//     private IEnumerator OnTypingText()
//     {
//         int idx = 0;

//         isTypingEffect = true;

//         while(idx < dialogs[currentDialogIndex].dialog.Length)
//         {
//             speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog.Substring(0,idx);
//             idx++;

//             yield return new WaitForSeconds(typingSpeed);
//         }

//         isTypingEffect = false;

//         speakers[currentSpeakerIndex].objectArrow.SetActive(true);
//     }
// }

// [System.Serializable]
// public struct Speaker
// {
//     public SpriteRenderer spriteRenderer;
//     public Image imageDialog;
//     public TextMeshProUGUI textName;
//     public TextMeshProUGUI textDialog;
//     public GameObject objectArrow;
// }
// [System.Serializable]
// public struct DialogData
// {
//     public int speakerIndex;
//     public string name;
//     [TextArea(3,5)]
//     public string dialog;
// }
