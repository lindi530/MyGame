using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private Button host;
    [SerializeField] private Button server;
    [SerializeField] private Button client;

    private void Start()
    {
        host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            SwitchUI();
        });
        server.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            SwitchUI();
        });
        client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            SwitchUI();
        });
    }

    private void SwitchUI()
    {
        startUI.SetActive(false);
    }
}
