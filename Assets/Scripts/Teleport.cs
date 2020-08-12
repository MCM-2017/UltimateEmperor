using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public bool teleportGuiEnable = false;
    public GameObject TeleportUI;

    private void Start()
    {
    }
    private void Update()
    {
        if (teleportGuiEnable && Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        else if (teleportGuiEnable && Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //col.transform.position = new Vector3(60, 42, 11);
        if (col.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3)
            {
                teleportGuiEnable = true;
                TeleportUI.SetActive(true);

            }
            else if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3); // Sample Scene
                //col.transform.position = new Vector3(60, 42, 11);
                //player.transform.position = new Vector3(60, 42, 11);
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            teleportGuiEnable = false;
            TeleportUI.SetActive(false);
        }
    }
}