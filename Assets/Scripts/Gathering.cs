using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Gathering : MonoBehaviour
{
    public GameObject GatheringObject;
    public bool canGathering = false;
    public PlayerMovement playerMovement;
    public float GatheringTime = 0f;


    private string resourceType = "";
    public float startGatheringTime = 0f;

    public Vector3 GatheringPosition;
    private bool gatheringGuiEnable = false;
    public Animator animator;

    public GameObject WoodTool;
    public GameObject StoneTool;

    public GameObject Character;

    public GameObject rightClickMouseIcon;
    public Sprite rightClickMouseIconOne;
    public Sprite rightClickMouseIconTwo;


    public PlayerInfo pi;

    float t = 0f;
    float increment = 0.02f;
    // Start is called before the first frame update
    void Start()
    {   
       WoodTool.SetActive(false);
       StoneTool.SetActive(false);
}

    // Update is called once per frame

    private void getResources()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {   
            playerMovement.canMove = false;
            
            if (resourceType =="Wood")
            {
                Vector3 targetPosition = GatheringObject.transform.position;
                targetPosition.y = Character.transform.position.y;
                Character.transform.LookAt(targetPosition);
                WoodTool.SetActive(true);
                animator.SetBool("woodCutting", true);

                startGatheringTime += Time.deltaTime;
                if (startGatheringTime >= GatheringTime)
                {
                    canGathering = false;
                    gatheringGuiEnable = false;
                    GlobalPlayerControl.instance.woodAmount += 3;
                    Destroy(GatheringObject.gameObject);
                    startGatheringTime = 0f;

                    animator.SetBool("woodCutting", false);
                    WoodTool.SetActive(false);
                    playerMovement.canMove = true;
                }
                else
                {

                    Debug.Log(Time.deltaTime);
                }
            }
            else
            {
                StoneTool.SetActive(true);
                animator.SetBool("stoneCutting", true);

                startGatheringTime += Time.deltaTime;
                if (startGatheringTime >= GatheringTime)
                {
                    GlobalPlayerControl.instance.stoneAmount += 3;
                    startGatheringTime = 0f;
                }
            }
        }else  if (Input.GetKeyUp(KeyCode.Mouse1)&& resourceType == "Stone")
        {
            startGatheringTime = 0f;
            animator.SetBool("stoneCutting", false);
            playerMovement.canMove = true;
            StoneTool.SetActive(false);
        }else if (Input.GetKeyUp(KeyCode.Mouse1) && resourceType == "Wood")
        {
            startGatheringTime = 0f;
            animator.SetBool("woodCutting", false);
            playerMovement.canMove = true;
            WoodTool.SetActive(false);
        }
    }
    void Update()
    {
        if (canGathering)
        {
            getResources();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wood"))
        {
            canGathering = true;
            gatheringGuiEnable = true;
            GatheringObject = other.transform.gameObject;
            GatheringTime = 3.0f;
            resourceType = "Wood";
        }else if (other.gameObject.CompareTag("Stone"))
        {
            canGathering = true;
            gatheringGuiEnable = true;
            GatheringObject = other.transform.gameObject;
            GatheringTime = 2.0f;
            resourceType = "Stone";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            resourceType = "";
            canGathering = false;
            gatheringGuiEnable = false;
            Debug.Log("Wood Exited");
        }
        else if (other.gameObject.CompareTag("Stone"))
        {
            resourceType = "";
            canGathering = false;
            gatheringGuiEnable = false;
            Debug.Log("Stone Exited");
        }
    }
    private void OnGUI()
    {   if (gatheringGuiEnable)
        {
            rightClickMouseIcon.SetActive(true);
            StartCoroutine("RightClick");
        }
        else
        {
            StopCoroutine("RightClick");
            rightClickMouseIcon.SetActive(false);
        }
    }
    IEnumerator RightClick()
    {   while (true)
        {
            while (t < 2)
            {

                rightClickMouseIcon.GetComponent<Image>().sprite = rightClickMouseIconTwo;
                t += increment;
                yield return new WaitForSeconds(increment);
            }

            t = 0.0f;
            while (t < 2)
            {

                rightClickMouseIcon.GetComponent<Image>().sprite = rightClickMouseIconOne;
                t += increment;
                yield return new WaitForSeconds(increment);
            }
            t = 0.0f;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
