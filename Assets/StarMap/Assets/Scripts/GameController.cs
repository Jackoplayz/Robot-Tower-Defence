using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject headQuarters;
    public Ship spaceShip;
    List<GameObject> stars = new List<GameObject>();
    public float minStarSpacing = 1;
    public GameObject starPrefab;
    public static GameController instance;
    public float minX, maxX, minY, maxY;
    public int starsAmount = 5;
    Star currentStar;
    public float shipYOffset;
    public float shipYOffsetHeadquarters;
    public float shipXOffsetHeadquarters;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        CreateNewGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveToStar(Star star)
    {
        //Debug.Log($"Moving to star at {star.gameObject.transform.position}");
        spaceShip.transform.position = new Vector3(star.transform.position.x,star.transform.position.y + shipYOffset, spaceShip.transform.position.z) ;
        currentStar = star;

    }

    public void MoveToHeadquarters()
    {
            spaceShip.transform.position = new Vector3(headQuarters.transform.position.x + shipXOffsetHeadquarters, headQuarters.transform.position.y + shipYOffsetHeadquarters, spaceShip.transform.position.z);
        currentStar = null;
    }


    void CreateNewGame()
    {
        //how many stars
        //where the ship spawns 
        //where are the stars
        //how many planets per star
        //reset any player progress

        for (int i = 0; i < starsAmount; i++)
        {

            int safety = 1000;
            int whileCounter = 0;
            Vector3 position = Vector3.zero;
            while (whileCounter < safety)
            {

                //Get a random position
                //Check that that position is valid

                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                position = new Vector3(randomX, randomY, -1);

                float dist = Vector3.Distance(position, headQuarters.transform.position);
                if (dist < minStarSpacing) continue;
                //Check that that position is valid
                bool positionIsValid = true;
                for (int j = 0; j < stars.Count; j++)
                {
                    dist = Vector3.Distance(position, stars[j].transform.position);

                    if (dist < minStarSpacing)
                    {
                        positionIsValid = false;
                        break;
                    }
                }
                if (positionIsValid)
                {
                    break;
                }

                //If it is valid, break the loop  
                // break;
                whileCounter++;
            }

            if (safety == whileCounter)
            {
                //Debug.Log("The safety was hit while spawning stars");
                break;
            }

            if (safety == whileCounter) Debug.Log("The safety was hit while spawning stars");


            //Getting the valid position


            //Spawning the actual star
            var star = Instantiate(starPrefab, position, Quaternion.identity);
            stars.Add(star);

        }
        MoveToHeadquarters();
    }
    
    public int ReturnStarIndex()
    {
        return stars.IndexOf(currentStar.gameObject);
    }

}
