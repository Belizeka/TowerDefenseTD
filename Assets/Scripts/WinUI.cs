using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinUI : MonoBehaviour
{
    public Text RoundsText;
    public Text PointsText;

    private void OnEnable()
    {
        RoundsText.text = "Rounds: " + Player.Rounds.ToString();
        PointsText.text = "Points: " + Player.Points.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
