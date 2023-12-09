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
        // �⺻ ��ȭ ����Ʈ�� ������
        NoneTalk();

        // Quest Talk
        talkData.Add(10 + 1000, new string[] {  "�ߵѷ� �þ�? :0",
                                                "�� �������� ������ �־� :4" ,
                                                "������ Angel�� �˷��ٰž�!!:2"});
        talkData.Add(11 + 1000, new string[] {  "Angel���� �� ���þ�?:0",
                                                "���ʿ� �����ž� :4" });

        /*talkData.Add(11 + 2000, new string[] {  "Gm ���� ���� �����?:0",
                                                "�� �̵����� ������ ...:4" ,
                                                "Shaman Variant ���� �ɾ����!!:2"});*/

        talkData.Add(20 + 1000, new string[] { "Shaman Variant ������ �� :0" });
        /*  talkData.Add(20 + 2000, new string[] { "���� �̾߱� ������:0" });
          talkData.Add(20 + 3000, new string[] { "Gm���� �����ҵ�...:4" });
          talkData.Add(21 + 2000, new string[] { "Gm���� �����ҵ�...:0" });*/


        talkData.Add(30 + 1000, new string[] { "������ ����Ʈ�� ����:0" });
        talkData.Add(31 + 2000, new string[] { "Gm���� �����ҵ�...:0" });

        talkData.Add(40 + 1000, new string[] { "1.A ������, 2.B ������" });

        talkData.Add(50 + 1000, new string[] { "1.A ������ �����:0" });
        talkData.Add(51 + 1000, new string[] { "����Ʈ ����� �ѱ�:0" });

        talkData.Add(60 + 1000, new string[] { "2.B ������ �����:1" });

        talkData.Add(70 + 1000, new string[] { "70����Ʈ ����:0" });
        talkData.Add(80 + 1000, new string[] { "80����Ʈ ����:0" });


        NonePortait();
    }


    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (talkData.ContainsKey(id - id % 10))
            { // ������ ���� ����Ǵ� ��簡 ������ -> �⺻��縦 �����´�
                return GetTalk(id - id % 10, talkIndex);
            }
            else
            {  // �ش� ����Ʈ ���� ���� ��簡 ���� �� -> �� ó�� ��縦 �����´�
                return GetTalk(id - id % 100, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length) { return null; }
        else { return talkData[id][talkIndex]; }
    }

    void NoneTalk()
    {
        // Talk Data
        // Npc Gm: 1000, Angel: 2000
        // Box: 100 , Desk: 200
        talkData.Add(1000, new string[] {   "�ȳ�? :0",
                                            "�� ���� ó�� �Ա���? :4" ,
                                            "�ѹ� �ѷ���������:1"});
        talkData.Add(2000, new string[] {   "�ȳ� �ϳ�? :0",
                                            "�� ���� ó�� �Ա���? :4",
                                            "Gm�� ã�� ���� �͵� ������ �ʴٳ�?:1"});

        talkData.Add(100, new string[] { "���� ����ִ� ���ڴ�" });
        talkData.Add(600, new string[] { "�ѹ� ����� ���� â�̴�",
                                         "�� ����â�� 1�� ������ �������"});
    }

    void NonePortait()
    {
        // ���� ���� (�ٲ�� �̹���)
        // 0: Normal, 1: Speak, 2: Happy, 3: Angry, 4:...., 5:....
        portaitData.Add(1000 + 0, portaitArr[0]);
        portaitData.Add(1000 + 1, portaitArr[1]);
        portaitData.Add(1000 + 2, portaitArr[2]);
        portaitData.Add(1000 + 3, portaitArr[3]);
        portaitData.Add(1000 + 4, portaitArr[4]);
        portaitData.Add(1000 + 5, portaitArr[5]);
        portaitData.Add(2000 + 0, portaitArr[6]);
        portaitData.Add(2000 + 1, portaitArr[7]);
        portaitData.Add(2000 + 2, portaitArr[8]);
        portaitData.Add(2000 + 3, portaitArr[9]);
        portaitData.Add(2000 + 4, portaitArr[10]);
        portaitData.Add(2000 + 5, portaitArr[11]);
        portaitData.Add(3000 + 0, portaitArr[12]);
        portaitData.Add(3000 + 1, portaitArr[13]);
        portaitData.Add(3000 + 2, portaitArr[14]);
        portaitData.Add(3000 + 3, portaitArr[15]);
        portaitData.Add(3000 + 4, portaitArr[16]);
        portaitData.Add(3000 + 5, portaitArr[17]);
    }

    public Sprite GetPortait(int id, int portraitIndex)
    {
        return portaitData[id + portraitIndex];
    }
}