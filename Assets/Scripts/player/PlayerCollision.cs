using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollision : MonoBehaviour
{

    public int score;
    public GameObject[] enemies;
    public GameObject thePlayer;
    public TextMeshProUGUI text;
    AIStateManager enemyScript;
    List<AIStateManager> list = new List<AIStateManager>();

    // Start is called before the first frame update

    void Start()
    {
        foreach (GameObject enemy in enemies)
        {
            list.Add(enemy.GetComponent<AIStateManager>());
        }
    }

    void Update()
    {
        text.text = score.ToString();
    }


    


    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("FUCK");

        if(other.gameObject.tag == "Enemy")
        {
            enemyScript = other.gameObject.GetComponent<AIStateManager>();
            if(enemyScript.powerPell == false && enemyScript.playerCollide == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Destroy(thePlayer);
            }
            if(enemyScript.powerPell == true)
            {
                enemyScript.playerCollide = true;
            }
        
        }
    
        if(other.gameObject.tag == "Pellet")
        {
            foreach (AIStateManager manager in list)
            {
                manager.powerPell = true;
                manager.playerCollide = false;
            }

            Debug.Log("asasdas");
            Destroy(other.gameObject);
        }


        if(other.gameObject.tag == "TicTac")
        {
            Destroy(other.gameObject);
            score += 1;
        }

    }

    void OnTriggerExit(Collider other) {

    }
    
}


