using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;

    // ����Ʈ �Ҷ� ��Ÿ ���� ��� ���� �� Object
    public GameObject[] questObject;
    [Header("UI on/off")]
    public GameObject textBg;
    public GameObject btnBg;
    public Button[] questButton;
    public bool choice = false;
    public int btnChoicNum = 0;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("Shaman ������ ����"
                                        , new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("Gm������ ����"
                                        , new int[] { 3000, 1000 }));
        questList.Add(30, new QuestData("���� ����Ʈ!"
                                        , new int[] { 1000, 1000 }));
        questList.Add(40, new QuestData("���� ����Ʈ!"
                                        , new int[] { 1000, 1000 }));
        questList.Add(50, new QuestData("���� ����Ʈ!"
                                       , new int[] { 1000, 1000 }));
        questList.Add(60, new QuestData("���� ����Ʈ!"
                                       , new int[] { 1000, 1000 }));
        questList.Add(70, new QuestData("���� ����Ʈ!"
                               , new int[] { 1000, 1000 }));
        questList.Add(80, new QuestData("���� ����Ʈ!"
                       , new int[] { 1000, 1000 }));

        questList.Add(90, new QuestData("����Ʈ Ŭ����!", new int[] { 0 }));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        // ��ȭ �Ϸ� + ���� ����Ʈ
        if (questActionIndex == questList[questId].npcId.Length && !choice)
        {
            NextQuest();
        }
        else if(choice)
        {
            ChoiceQuest(btnChoicNum==0?1:btnChoicNum);
        }

        // ����Ʈ Ȱ��ȭ �� Ȱ��ȭ �Ǿ�� �Ұ�
        ControlObject();

        // ����Ʈ �̸� ��� 
        return questList[questId].questName;
    }

    public string CheckQuest()// ����Ʈ �̸� ��� 
    { return questList[questId].questName; }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ChoiceQuest(int number)
    {
        questId += 10*number;
        questActionIndex = 0;
        //ChoiceUISet(false); 
    }

    public void ChoiceUISet(bool p_flag)
    {
        textBg.gameObject.SetActive(!p_flag);
        btnBg.gameObject.SetActive(p_flag);
        choice = p_flag;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    questObject[0].SetActive(false);
                }
                break;
            case 30:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceUISet(true);
                }
                break;
            case 40:
                ChoiceUISet(true); 
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceUISet(false);
                }
                break;
            case 50:
                ChoiceUISet(false);

                break;
            case 60:
                ChoiceUISet(false);
                break;

        }
    }
}