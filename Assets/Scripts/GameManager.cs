using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Vector3 playerSpawnPoint;
    enum Mode { QuestMode, BattleMode }//player.controller.NowMode
    [SerializeField]private Mode mode;


    private void Start()
    {
        if(instance == null)
        { 
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this.player.gameObject);
        }
    }
    private void Awake()
    {
        player = Instantiate(player);
        playerSpawnPoint = new Vector3(0.5f, 4.0f, 0);
        player.transform.position = playerSpawnPoint;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //****************************************************************************
        //FOR_TEST, test ���� �ڵ� ���⿡ �߰����ּ���
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (mode == Mode.QuestMode)BattlePhase();
            else if (mode == Mode.BattleMode)QuestPhase();
        }
        //*****************************************************************************
    }
    public void BattlePhase()
    {
        mode = Mode.BattleMode;
        player.controller.BattleMode();
        SceneManager.LoadScene("BattleScene");
        playerSpawnPoint = player.transform.position; 
    }
    public void QuestPhase()
    {
        mode = Mode.QuestMode;
        player.controller.QuestMode();
        SceneManager.LoadScene("DKTest");
        //eventController.playchangeScene
        player.transform.position = playerSpawnPoint;
    }
}