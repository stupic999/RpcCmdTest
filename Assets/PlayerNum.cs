using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNum : NetworkBehaviour
{
    GameObject client;

    PlayerNum playerNum;

    public int Num;
    int clientNum;

    void Start()
    {
        if (isServer)
        {
            CmdChangeName("Server");
            Num = 1;
            clientNum = 1;
        }
        else
        {
            CmdChangeName("Client");
        }
    }

    void Update()
    {
        if (isServer)
        {
            client = GameObject.Find("Client");
            if (client != null)
            {
                clientNum++;
                playerNum = client.GetComponent<PlayerNum>();
                playerNum.Num = clientNum;
                client.transform.name = clientNum.ToString();
                client = null;
            }
        }
    }

    [ClientRpc]
    void RpcChangeName(string name)
    {
        transform.name = name;
    }

    [Command]
    void CmdChangeName(string name)
    {
        RpcChangeName(name);
    }


    //[ClientRpc]
    //void RpcChangeClientName(GameObject gameObject, string name)
    //{
    //    gameObject.name = name;
    //}

    //[Command]
    //void CmdChangeClientName(GameObject gameObject, string name)
    //{
    //    RpcChangeClientName(gameObject, name);
    //}
}



    //[SyncVar]
    //public int playerTotal;
    //[SyncVar]
    //public int playerNum;
    //public Text showSelfNum;
    //List<GameObject> playerCount = new List<GameObject>();
    //GameObject self;

    //private void Start()
    //{
    //    playerCount.Add(self);
    //    CmdSetNum(1);
    //    Debug.Log(playerCount.Count);
    //    Debug.Log(playerTotal);
    //    playerNum = playerTotal;
    //    showSelfNum = GameObject.FindGameObjectWithTag("UI").GetComponent<Text>();
    //    showSelfNum.text = "selfNum = " + playerTotal;
    //}

    //[Command]
    //void CmdAddPlayer(int num)
    //{
    //    RpcAddPlayer(num);
    //}

    //[ClientRpc]
    //void RpcAddPlayer(int num)
    //{
    //    playerTotal +=num;
    //}

    //[Command]
    //void CmdSetNum(int num)
    //{
    //    RpcSetNum(num);
    //}

    //[ClientRpc]
    //void RpcSetNum(int num)
    //{
    //    playerTotal = num;
    //}