using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class play : MonoBehaviour
{
    public Text l,hi;
    public Sprite[] allimg;
    public Image allpuzzle;
    string[] ans={"10","25","6","14","128" };
    string[] hint = { "", "", "sum", "box total", "multiplication"};
    
    public Text btnlevelno;
    int levelno ,score=0,maxlevel=0;
    void Start()
    {
        levelno=PlayerPrefs.GetInt("levelno",1);
        maxlevel = PlayerPrefs.GetInt("maxlevel", 0);
        btnlevelno.text = "puzzle "+levelno;
        allpuzzle.sprite = allimg[levelno - 1];
        score = PlayerPrefs.GetInt("score ",0);
        hi.text = "score "+score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void arith(string n)
    {
        l.text += n;
    }
    public void cler()
    {
        if(l.text.Length > 0)
        {
            l.text = l.text.Substring(0, l.text.Length - 1);
        }
    }
    public void submit()
    {
        if (ans[levelno-1]==l.text)
        {
            PlayerPrefs.DeleteKey("skip" + levelno);
            PlayerPrefs.SetInt("levelno",levelno+1);
           
            SceneManager.LoadScene("win");
            if (maxlevel < levelno)
            {
                PlayerPrefs.SetInt("maxlevel",levelno);
            }
            if(levelno+1>maxlevel)
            {
                PlayerPrefs.SetInt("score ", score + 10);
            }
        }
        else
        {
            SceneManager.LoadScene("retry");
        }
        hi.text = "score" + score;

    }
    public void skip()
    {
        PlayerPrefs.SetInt("skip"+levelno,levelno);
        PlayerPrefs.SetInt("levelno",levelno+1);
        SceneManager.LoadScene("play");
    }
    public void btnhint()
    {

    }
}
