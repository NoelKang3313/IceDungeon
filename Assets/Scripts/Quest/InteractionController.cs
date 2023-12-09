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
<<<<<<< Updated upstream
    public GManager gManager;
=======
    public EventManager eventManager;
>>>>>>> Stashed changes
    
    [Header("Npc ���� ���� Ȯ��")]
    public bool isNpcInter = false;
    public bool isPlayerInter = false;
    public bool isChest = false;
    // Npc �ν�
    public GameObject trigObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Action(); 
        }
    }

    private void Awake()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    public void Action()
    {
        eventManager.Action(trigObject);
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
                isNpcInter = true;
                Transform toq = collision.gameObject.transform.parent;

                if (toq!=null)  
                {
                    trigObject = toq.gameObject;
                }
                else
                {
                    Debug.Log("not toq:" + toq);
                }
            }
        }
        else if (collision.gameObject.tag == "PlayerTrigger")
        {
            if (trigObject == null)
            {
                isPlayerInter = true;

                trigObject = collision.gameObject;
            }
        }
        else if(collision.gameObject.tag == "chest")
        {
            if (trigObject == null)
            {
                isChest = true;

                trigObject = collision.gameObject;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
        {
            if (trigObject != null && isNpcInter == true)
            {
                isNpcInter = false;
                trigObject = null;
                Debug.Log("Npc ���� ����");
            }
        }
        else if (collision.gameObject.tag == "PlayerTrigger")
        {
            if (trigObject != null && isPlayerInter == true)
            {
                isPlayerInter = false;
                Destroy(trigObject);
            }
        }
        else if (collision.gameObject.tag == "chest")
        {
            if (trigObject != null && isChest == true)
            {
                isPlayerInter = false;
                trigObject = null;
            }
        }

    }
}
