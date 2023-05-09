using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpMenu : MonoBehaviour
{
    public GameObject powerUpMenuUI;
    public ScriptableBuff[] buffList;
    public ScriptableBuff[] debuffList;

    void Start()
    {
        powerUpMenuUI.SetActive(false);
    }

	private void OnEnable()
	{
        //TimeManager.OnHourChanged += TimeCheck;
	}

	private void OnDisable()
	{
        //TimeManager.OnHourChanged -= TimeCheck;
	}

    private void TimeCheck()
	{
        if (TimeManager.Hour == GameVariables.dayModeHour)
            LaunchMenu();
	}

    public void LaunchMenu()
	{
        Time.timeScale = 0f;
        CreateSelectableBuffs();
        
        powerUpMenuUI.SetActive(true);
	}

    private void CreateSelectableBuffs()
	{
        GameObject topLeft = powerUpMenuUI.transform.Find("Top Left Button").gameObject;
        GameObject topRight = powerUpMenuUI.transform.Find("Top Right Button").gameObject;
        GameObject bottomLeft = powerUpMenuUI.transform.Find("Bottom Left Button").gameObject;
        GameObject bottomRight = powerUpMenuUI.transform.Find("Bottom Right Button").gameObject;

        ApplyBuffToButton(topLeft, buffList[0]);
        ApplyBuffToButton(topRight, buffList[1]); 
        ApplyDebuffToButton(bottomLeft, debuffList[0]);
        ApplyDebuffToButton(bottomRight, debuffList[1]);
	}

    private void ApplyBuffToButton(GameObject selectable, ScriptableBuff buff)
	{
        selectable.GetComponent<Image>().sprite = buff.icon;
        selectable.GetComponentInChildren<TextMeshProUGUI>().text = buff.displayString;
        selectable.GetComponent<Button>().onClick.RemoveAllListeners();
        selectable.GetComponent<Button>().onClick.AddListener(delegate { ApplyBuffToPlayer(buff); });
    }

    private void ApplyDebuffToButton(GameObject selectable, ScriptableBuff buff)
	{
        selectable.GetComponent<Image>().sprite = buff.icon;
        selectable.GetComponentInChildren<TextMeshProUGUI>().text = buff.displayString;
        selectable.GetComponent<Button>().onClick.RemoveAllListeners();
        selectable.GetComponent<Button>().onClick.AddListener(delegate { ApplyBuffToGoose(buff); });
    }

    private void ApplyBuffToPlayer(ScriptableBuff buff)
	{
        Attributes attr = GameObject.FindWithTag("Player").transform.GetComponent<PlayerAttributes>();
        attr.AddTimedBuff(buff.InitTimedBuff(attr));
        CloseMenu();
	}
    private void ApplyBuffToGoose(ScriptableBuff buff)
    {
        Attributes attr = GameObject.FindWithTag("Player").transform.GetComponent<GooseAttributes>();
        attr.AddTimedBuff(buff.InitTimedBuff(attr));    
        CloseMenu();
    }

    private void CloseMenu()
	{
        Time.timeScale = 1f;
        powerUpMenuUI.SetActive(false);
    }
}
