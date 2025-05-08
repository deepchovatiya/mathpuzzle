using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    int levelno = 1,maxlevl=0;
    public Button[] allbutton= null;
   public Sprite tick;

    // Start is called before the first frame update
    void Start()
    {
        levelno = PlayerPrefs.GetInt("levelno",1);
        maxlevl = PlayerPrefs.GetInt("maxlevel",0);
        print(levelno);
        print(maxlevl);
        for(int i = 0;i<levelno;i++)
        {
            allbutton[i].interactable = true;
            allbutton[i].GetComponentInChildren<Text>().text=(i+1).ToString();
            if(i<maxlevl)
            {
                if (PlayerPrefs.HasKey("skip"+(i+1)))
                {
                    allbutton[i].GetComponentInChildren<Image>().sprite = null;
                }
                else
                {
                    allbutton[i].GetComponentInChildren<Image>().sprite = tick;
                }
            }
            else
            {
                allbutton[i].GetComponentInChildren<Image>().sprite = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnlevel(int no)
    {
        PlayerPrefs.SetInt("levelno", no);
        SceneManager.LoadScene("play");
    }
}
