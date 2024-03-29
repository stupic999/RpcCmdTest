﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CMD : NetworkBehaviour
{
    public int value;
    public Text NumText;

    private void Start()
    {
        NumText = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        NumText.text = "value " + value;
    }

    public void Update()
    {
        NumText = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        NumText.text = "value " + value;
        if (Input.GetMouseButtonDown(0))
        {
            CmdAddNum(1);
        }
    }

    [Command]
    void CmdAddNum(int num)
    {
        RpcAddNum(num);
    }

    [ClientRpc]
    void RpcAddNum(int num)
    {
        value += num;
    }
}
