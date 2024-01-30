using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class SetPlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerAction playerAction; 
    public void SetPlayerDataAction()
    {
        
        PlayerData.SetAction(playerAction);
    }
}
