using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_NpcTalk;

    [SerializeField] Text txt_Name;
    [SerializeField] Text txt_Dialogue;

    Dialogue[] dialogues;
    bool isDialogue = false; // ��ȭ���̸� true
    bool isNext = false; // Ư�� Ű �Է� ���

    [Header("�ؽ�Ʈ ��� ������")]
    [SerializeField] float textDelay;

    int lineCount = 0;
    int contextCount = 0;// ��� ī��Ʈ


    InteractionController IControll;

    void Start()
    {
        IControll = FindObjectOfType<InteractionController>();    
    }
    void Update()
    {
        if (isDialogue){
            if (isNext){
                if (Input.GetKeyDown(KeyCode.Space)){
                    isNext = false;
                    txt_Dialogue.text = "";

                    if (++contextCount< dialogues[lineCount].contexts.Length) {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;
                        if (++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }    
    }

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        IControll.SettingUI(false);
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        IControll.SettingUI(true);
        SettingUI(false);
    }

    IEnumerator TypeWriter()
    {
        SettingUI(true);
    
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("`", ",");
                
        txt_Name.text = dialogues[lineCount].name;
        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }        
        isNext = true;
        yield return null;
    }

    void SettingUI(bool p_flag)
    {
        go_NpcTalk.SetActive(p_flag);
    }
}
