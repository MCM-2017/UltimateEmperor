using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerControl : MonoBehaviour
{
    public static GlobalPlayerControl instance;
    public bool guiEnable = false;
    public int goldAmount = 999;
    public int woodAmount = 999;
    public int stoneAmount = 999;
    public int level = 0;
    public int health = 100;
    public int maxHealth = 100;
    void Start()
    {

    }
    private void OnGUI()
    {
        if (guiEnable)
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.fontSize = 25;
            myStyle.normal.textColor = Color.black;
            GUI.Label(new Rect(Screen.width - 265, Screen.height - 888, 300, 30), goldAmount.ToString(), myStyle);
            GUI.Label(new Rect(Screen.width - 150, Screen.height - 888, 300, 30), stoneAmount.ToString(), myStyle);
            GUI.Label(new Rect(Screen.width - 55, Screen.height - 888, 300, 30), woodAmount.ToString(), myStyle);
        }
    }
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
