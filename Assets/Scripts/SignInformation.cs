using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInformation : MonoBehaviour
{
    [TextArea]
    public string Message;
    public bool guiEnable = false;
    public int height = 0;
    public int width = 0;
    public int textHeight = 0;
    public int textWidth = 0;
    [SerializeField] public Texture image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        if (guiEnable)
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.fontSize = 20;
            myStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, width, height), image);
            GUI.Label(new Rect(textWidth,textHeight, textWidth, textHeight), Message, myStyle);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guiEnable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guiEnable = false;
        }
    }
}
