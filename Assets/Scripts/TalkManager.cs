using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portaitData;
    public Sprite[] portaitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portaitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    private void GenerateData()
    {
        // Talk
        talkData.Add(1000, new string[] { "�ȳ�? :0", "�� ���� ó�� �Ա���? :4" });

        talkData.Add(2000, new string[] { "�ȳ� �ϳ�? :0", "�� ���� ó�� �Ա���? :4" });

        talkData.Add(100, new string[] { "����� �������ڴ�" });
        talkData.Add(200, new string[] {"������ ����� ������ �ִ� å���̴�"});

        //Sprite Gm
        portaitData.Add(1000 + 0, portaitArr[0]);
        portaitData.Add(1000 + 1, portaitArr[1]);
        portaitData.Add(1000 + 2, portaitArr[2]);
        portaitData.Add(1000 + 3, portaitArr[3]);
        portaitData.Add(1000 + 4, portaitArr[4]);
        portaitData.Add(2000 + 5, portaitArr[5]);
        portaitData.Add(2000 + 0, portaitArr[6]);
        portaitData.Add(2000 + 1, portaitArr[7]);
        portaitData.Add(2000 + 2, portaitArr[8]);
        portaitData.Add(2000 + 3, portaitArr[9]);
        portaitData.Add(2000 + 4, portaitArr[10]);
    }


    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex]; 
        }
    }

    public Sprite GetPortait(int id, int portraitIndex)
    {
        return portaitData[id + portraitIndex];
    }
}
