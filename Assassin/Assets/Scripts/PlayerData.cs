using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public string username;
    
    public PlayerData (User user)
    {
        username = user.Username;
    }
   
      
}
