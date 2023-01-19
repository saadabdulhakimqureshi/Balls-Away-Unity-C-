using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Score : MonoBehaviour {

    // Start is called before the first frame update
    public float score;
    public int high;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI highScore;
    public string fileName;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject restartMenu;

void Start()
    {
        fileName = "score.txt";
        score = 0;
        high = LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.activeSelf == false && restartMenu.activeSelf == false)
        {
            score += Time.deltaTime;
            timer.text = Mathf.RoundToInt(score).ToString();
        }
        highScore.text = high.ToString();
        SetHighScore();
    }

    void SetHighScore()
    {
        if (Mathf.RoundToInt(score) > high)
        {
            high = Mathf.RoundToInt(score);
            string filePath = Application.persistentDataPath + "/" + fileName;
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                streamWriter.WriteLine(high);
            }
        }
    }

    int LoadScore()
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string scoreString = streamReader.ReadLine();
                
                return(int.Parse(scoreString));
            }
        }
        else
        {
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                streamWriter.WriteLine(0);
            }
            return 0;
        }
    }
}
