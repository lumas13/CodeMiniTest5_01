using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController01 : MonoBehaviour
{
    public Animator playerAni;
    public GameObject EnergyCounter;
    public GameObject Timer;
    public float playerMoveSpeed;

    int energyCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.levelTime > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * playerMoveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAni.SetBool("isRunning", true);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * playerMoveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAni.SetBool("isRunning", true);

            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                playerAni.SetBool("isRunning", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * playerMoveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                playerAni.SetBool("isRunning", true);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * playerMoveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAni.SetBool("isRunning", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerAni.SetBool("isRunning", false);
            }

            if (energyCount < 0)
            {
                GameManager.instance.LoseScene();
            }

            if (energyCount >= 50)
            {
                GameManager.instance.WinScene();
            }
        }
        else
        {
            GameManager.instance.LoseScene();
        }

        EnergyCounter.GetComponent<Text>().text = "Energy: " + energyCount;
        Timer.GetComponent<Text>().text = "Timer: " + (int)GameManager.instance.levelTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AddEnergy"))
        {
            //Debug.Log("Touch");
            energyCount += 5;
            GameManager.instance.AddTime();
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("MinusEnergy"))
        {
            //Debug.Log("Touch2");
            energyCount -= 25;
            Destroy(collision.gameObject);
        }

    }
}
