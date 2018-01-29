using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public MutationSelection mutationSelect;
    public MutationPanel mutationPanel;

    public Text healthText;



	// Use this for initialization
	void Start () {
        OnGameStart();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = PlayerTest.player.GetComponent<Health>().currentHealth.ToString();
	}


    public void OnGameStart()
    {
        transform.Find("StartScreen").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        transform.Find("GameOver").gameObject.SetActive(true);
    }
    public void toggleMutationSelect()
    {
        if (mutationSelect.gameObject.activeSelf == false)
        {
            mutationSelect.gameObject.SetActive(true);
            mutationSelect.updateOptions();
        }
        else
        {
            mutationSelect.gameObject.SetActive(false);
        }
    }

    
}
