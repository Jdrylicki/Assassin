using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public User user;
    private List<string> list = new List<string>();
    public GameObject AddPlayerInputField;
    public GameObject SearchPlayerInputField;
    public GameObject UsernameInputField;
    public TMP_Text PlayerAddedTxt;
    public TMP_Text TargetTxt;

   

    public void Start()
    {
        LoadPlayer();
    }

    #region Managing Player Data Methods

    public void SaveUser()
    {
        user.Username = UsernameInputField.GetComponent<TMP_InputField>().text;
        SaveSystem.SavePlayer(user);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        user.Username = data.username;
        UsernameInputField.GetComponent<TMP_InputField>().text = user.Username;
    }

    #endregion

    public void addPlayer()
    {  
        //takes inputted name and sets it to player
       string player = AddPlayerInputField.GetComponent<TMP_InputField>().text;
        //adds player to a list
       list.Add(player);
        //displays that player is added
       PlayerAddedTxt.GetComponent<TMP_Text>().text = list[list.Count -1] + " was added to the game!";
       AddPlayerInputField.GetComponent<TMP_InputField>().text = "";
    }
    #region Creating Game Methods

    public void Shuffle()
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void Search()
    {
        
        //gets inputted name 
        string searcher = SearchPlayerInputField.GetComponent<TMP_InputField>().text.ToLower();
        int index;
        //finds the searcher's index
      
        index = list.FindIndex(x => x.ToLower().Equals(searcher));
        //if name doesn't exist 
        if (index == -1)
        {
            TargetTxt.GetComponent<TMP_Text>().text = "Searched name doesn't exist, try again.";
        }
        else
        {
            //gives the player below them on the list as their target
            int targetIndex = index + 1;
            //checks if searcher is at the bottom of the list, if so make the target the player at the top of the list
            if (targetIndex == list.Count)
            {
                targetIndex = 0;
            }
            //shows target and clears name from search bar
            TargetTxt.GetComponent<TMP_Text>().text = "Target Player: " + list[targetIndex];
            SearchPlayerInputField.GetComponent<TMP_InputField>().text = "";
        }
        
    }

    #endregion

}
