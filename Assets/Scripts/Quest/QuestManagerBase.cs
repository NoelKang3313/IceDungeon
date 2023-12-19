using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManagerBase : MonoBehaviour
{
    protected int questId;
    protected int questActionIndex;
    protected Dictionary<int, QuestData> questList;

    public virtual int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public virtual string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        // ��ȭ �Ϸ� + ���� ����Ʈ
        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }

        // ����Ʈ Ȱ��ȭ �� Ȱ��ȭ�Ǿ�� �� ��
        ControlObject();

        // ����Ʈ �̸� ��� 
        return questList[questId].questName;
    }

    public virtual string CheckQuest()
    {
        return questList[questId].questName;
    }

    protected virtual void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    protected abstract void ControlObject();
}
