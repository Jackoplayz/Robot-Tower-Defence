using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactor : MonoBehaviour
{
    public Text reactorHealthText;
    public int health;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        reactorHealthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //when reactor gets destroyed a game over screen pops up to restart the game
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health -= 1;
            collision.GetComponent<Enemy>().Death();
                
            reactorHealthText.text = health.ToString();
        }


    }
}
