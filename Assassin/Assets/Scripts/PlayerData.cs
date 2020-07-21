using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public GameObject Username;
    void Start()
    {
        Username.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("UserName");
    }
    public void save()
    {
        PlayerPrefs.DeleteKey("UserName");
        PlayerPrefs.SetString("UserName", Username.GetComponent<TMP_InputField>().text);
        
    }
      
}
