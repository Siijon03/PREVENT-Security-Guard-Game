using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Results_Displayer : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;

    // Score System Establishment
    public int points_Score;
    public TextMeshPro scoreText;

    public GameObject shinyBadge;
    public GameObject badEndingSlip;


    void Start()
    {

        scoreText.gameObject.SetActive(true);

        shinyBadge.SetActive(false);
        badEndingSlip.SetActive(false);

        scoreText.text = "Your Score: " + points_Score.ToString();

        LoadScore();
    }



    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Starting Screen");
            Debug.Log("Loading");
        }
        // Check if score exceeds threshold and reset if necessary
        //LoadScore();
    }

    public void GoodEnding()
    {

        shinyBadge.SetActive(true);

    }

    public void BadEnding()
    {

        badEndingSlip.SetActive(true);

    }

    //Basic Function to Decrease Player Score.
    public void DecreaseScore()
    {
        scoreText.text = "Your Score: ";
        points_Score--;
        Debug.Log("Your Score: " + points_Score);
        SaveScore();
    }

    //Basic Function to Increment Player Score.
    public void IncrementScore()
    {
        scoreText.text = "Your Score: ";
        points_Score++;
        Debug.Log("Your Score: " + points_Score);
        SaveScore();
    }

    //This is to save current Player Score and Set it in between Levels/Scenes.
    private void SaveScore()
    {

        PlayerPrefs.SetInt("Player Score", points_Score);
        PlayerPrefs.Save();
        Debug.Log("Set Score of: " + points_Score);
    }

    public void ResetScore()
    {
        points_Score = 1;
        GetPlayerScore();
    }

    //Retrieve the Player Score.
    public int GetPlayerScore()
    {
        SaveScore();
        return points_Score;
    }

    //This Loads the Points by getting the int. 
    public void LoadScore()
    {
        //0 is used in case a Player Prefs Integer Count is not found.
        points_Score = PlayerPrefs.GetInt("Player Score", 0);
        Debug.Log("Loaded Score of: " + points_Score + "(This is Done within the Load Score Function.)");

        if (points_Score == 5)
        {
            GoodEnding();       
        }

        if (points_Score < 5)
        {
            BadEnding();
        }
    }

    public void OnApplicationQuit()
    {

    }

}
