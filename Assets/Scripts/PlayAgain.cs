using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] Button playAgainButton;

    public void Start()
    {
        // Set the selected UI element to the play again button
        EventSystem.current.SetSelectedGameObject(playAgainButton.gameObject);

        // Retrieve player name
        string name_of_player = ReadName.playerName; // Assuming ReadName is a class that holds the player name
        Debug.Log("Player Name: " + name_of_player);

        // Retrieve the total time when the game ends
        OnLastSceneComplete(name_of_player);


    }

    public void OnLastSceneComplete(string playerName)
    {
        // Stop the timer and get the total time
        string totalTime = TimerManager.instance.StopTimer();
        string endTime = System.DateTime.Now.ToString("HH.MM.ss");

        // Display both player name and total time
        Debug.Log($"Player: {playerName}, Total Time: {totalTime}, End Time: {endTime}");
        // string tofb = playerName + " " + totalTime;
        firebaseInsert.fbAdd("player_name", playerName);
        firebaseInsert.fbAdd("time_taken", totalTime);
        firebaseInsert.fbAdd("end_time", endTime);

    }

    public void NewGameLoader()
    {
        // Load the first scene to start a new game
        Debug.Log("FirebaseReload");
        SceneManager.LoadScene("Start Scene", LoadSceneMode.Single);
    }
}
