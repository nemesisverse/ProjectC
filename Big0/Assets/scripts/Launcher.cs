using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;

    public GameObject loadingScreen;
    public TMP_Text loadingText;
    public GameObject menuButtons;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        CloseMenu();
        loadingScreen.SetActive(true);
;
        loadingText.text = "Connecting To Network";

        PhotonNetwork.ConnectUsingSettings();
    }

    void CloseMenu()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        

        PhotonNetwork.JoinLobby();
        loadingText.text = "Joining Lobby...";
    }

    public override void OnJoinedLobby()
    {
        CloseMenu();
        menuButtons.SetActive(true);   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
