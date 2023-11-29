using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    PlayerController playerController;
    DialogueManager dialogueM;


    [Header("�̸� â")]
    [SerializeField] GameObject go_npcName;
    [SerializeField] Text txt_TargetName;

    string npcChildName = "Quset";
    bool isContact = false;

    [Header("Npc ���� ���� Ȯ��")]
    public bool npcInter;
    public static bool isCollide = false;

    // Npc �ν�
    public GameObject trigObject;
    // Npc ��ȣ �ۿ� �������� Ȯ�� �ϴ� ��
    GameObject ChildQ;

    void Start()
    {
        dialogueM = FindObjectOfType<DialogueManager>();
    }


    void CheckObject()
    {
        if (trigObject != null)
        { // �ν� �ϸ�
            Contact();
        }
        else
        { 
            // �ν� �� �ϸ�
            NotContact();
        }
    }

    private void Contact()
    {
        if (trigObject.transform.CompareTag("Interaction"))
        {
            txt_TargetName.text = trigObject.transform.GetComponent<InteractionType>().GetName();
            if (!isContact)
            {
                isContact = true;
                InteractionEvent tempEvent = trigObject.transform.GetComponent<InteractionEvent>();
                if(tempEvent != null)
                {
                    dialogueM.ShowDialogue(tempEvent.GetDialogues());

                }
                else
                {
                    Debug.Log("null");
                }
            } 
        }
        else
        {
            NotContact();
        }
    }

    private void NotContact()
    {
        if (isContact)
        {
            isContact = false;
        }
    }


    public void SettingUI(bool p_flag)
    {
        go_npcName.SetActive(p_flag);
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        // interaction�� tag�� ������ ��ü�� �浹�� �۵�
        if (collision.gameObject.tag == "Interaction")
        {
            CheckObject();

            if (trigObject == null)
            {
                npcInter = true;

                Transform parentObject = collision.gameObject.transform.parent.parent;
                if (parentObject != null)
                {
                    trigObject = parentObject.gameObject;
                    ChildQ = trigObject.transform.Find(npcChildName).gameObject;
                    ChildQ.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
        {
            if (trigObject != null)
            {
                npcInter = false;
                trigObject = null;
                ChildQ.SetActive(false);
                ChildQ = null;
                Debug.Log("Npc ���� ����");
            }
        }
    }
}
