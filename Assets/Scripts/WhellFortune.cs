using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhellFortune : MonoBehaviour
{
    private int numberOfTurns;
    private int whatWeWin;

    private float speed;

    private bool canWeTurn;

    public Text winningText;

    public Text[] texts;

    private int score;

    public AudioSource myAudioSourse;

    void Start()
    {
        canWeTurn = true;

        int[] array = new int[8];
        for(int i = 0; i < array.Length; ++i)
        {
            bool isUnique;
            do
            {
                array[i] = Random.Range(100, 10000) * 100;
                isUnique = true;
                for (int j = 0; j < i; ++j)
                {
                    if (array[i] == array[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
            while (!isUnique);
            // Debug.Log(array[i]);
        }
     
        for (int i = 0; i < texts.Length; i++)
        {
            //texts[i].text = Random.Range(1, 10).ToString();
            texts[i].text = array[i].ToString();
        }

        score = PlayerPrefs.GetInt("Score", score);
    }

    
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space) && canWeTurn == true)
        //{
        //    StartCoroutine(TurnTheWheel());
        //}

        PlayerPrefs.SetInt("Score", score);
        winningText.text = "Score: " + score.ToString();
    }

    public void Spin()
    {
        if(canWeTurn == true)
        {
            StartCoroutine(TurnTheWheel());
        }

        
    }


    private IEnumerator TurnTheWheel()
    {
        canWeTurn = false;

        if (canWeTurn == false)
        {
            myAudioSourse.Play();
        }

        numberOfTurns = Random.Range(40, 60);
        speed = 0.01f;

        for(int i = 0; i < numberOfTurns; i++)
        {
            transform.Rotate(0, 0, 22.5f);
            if(i > Mathf.RoundToInt(numberOfTurns * 0.5f))
            {
                speed = 0.02f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.7f))
            {
                speed = 0.07f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.9f))
            {
                speed = 0.1f;
            }
            yield return new WaitForSeconds(speed);
        }

        if(Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (whatWeWin)
        {
            case 0:
                score += int.Parse(texts[0].text);
                winningText.text = score.ToString();
                //winningText.text = text1.text + " желтый";
                break;
            case 45:
                score += int.Parse(texts[1].text);
                winningText.text = score.ToString();
                //winningText.text = text2.text + " зелёный";
                break;
            case 90:
                score += int.Parse(texts[2].text);
                winningText.text = score.ToString();
                //winningText.text = text3.text + " голубой";
                break;
            case 135:
                score += int.Parse(texts[3].text);
                winningText.text = score.ToString();
                //winningText.text = text4.text + " синий";
                break;
            case 180:
                score += int.Parse(texts[4].text);
                winningText.text = score.ToString();
                //winningText.text = text5.text + " фиолетовый";
                break;
            case 225:
                score += int.Parse(texts[5].text);
                winningText.text = score.ToString();
                //winningText.text = text6.text + " розовый";
                break;
            case 270:
                score += int.Parse(texts[6].text);
                winningText.text = score.ToString();
                //winningText.text = text7.text + " красный";
                break;
            case 315:
                score += int.Parse(texts[7].text);
                winningText.text = score.ToString();
                //winningText.text = text8.text + " оранжевый";
                break;
        }

        canWeTurn = true;

        if (canWeTurn == true)
        {
            myAudioSourse.Stop();
        }

        
    }
}
