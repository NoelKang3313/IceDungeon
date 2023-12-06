using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public static InteractionController instance;
    public GManager gManager;
    
    [Header("�̸� â")]
    public GameObject go_npcTalk;
    public GameObject go_npcTalkImg;
    [SerializeField] Text txt_TargetName;
    [SerializeField] Text txt_TargetTalk;

    string npcChildName = "Quset";


    [Header("Npc ���� ���� Ȯ��")]
    public bool npcInter = false;

    // Npc �ν�
    public GameObject trigObject;
    // Npc ��ȣ �ۿ� �������� Ȯ�� �ϴ� ��
    GameObject ChildQ;

    public void SettingUI(bool p_flag)
    {
        go_npcTalk.SetActive(p_flag);
        go_npcTalkImg.SetActive(p_flag);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&& npcInter == true)
        {
            Action();
        }
    }
    

    public void Action()
    {
        SettingUI(npcInter);
        gManager.Action(trigObject);
    }

    /// <summary>
    /// interaction�� tag�� ������ ��ü�� collision �浹�� �۵�
    /// trigObject �� �浹�� Npc�� gameObject�� �ν��� ��
    /// ChildQ�� gameObject�� �̹��� ���� �����ͼ� �۾�
    /// </summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
        {
            if (trigObject == null)
            {
                npcInter = true;
                Transform toq = collision.gameObject.transform.parent.parent;

                if (toq!=null)  
                {
                    trigObject = toq.gameObject;

                    ChildQ = toq.Find(npcChildName).gameObject;
                    ChildQ.SetActive(true);
                }
                else
                {
                    Debug.Log("not toq:" + toq);
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
        {
            if (trigObject != null && npcInter == true)
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
