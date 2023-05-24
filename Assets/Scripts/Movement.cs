using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Movement : MonoBehaviour
{
    
    public float speed = 2f;
    public string fileName = "difficulty.txt";
    public List<SpriteRenderer> enemies;
    public List<SpriteRenderer> walls;

    // Start is called before the first frame update
    void Start()
    {
        SetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        RandomMovement();
    }

    void SetSpeed()
    {
        string filePath = Application.persistentDataPath + "/" + fileName;

        using (StreamReader streamReader = File.OpenText(filePath))
        {
            string difficultyString = streamReader.ReadLine();
            speed = float.Parse(difficultyString);
        }
        
    }

    void RandomMovement()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            EnemyScript script = enemies[i].GetComponent<EnemyScript>();
            if (script.directionX == 0)
                enemies[i].transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (script.directionX == 1)
                enemies[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (script.directionY == 0)
                enemies[i].transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (script.directionY == 1)
                enemies[i].transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}
