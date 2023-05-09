using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private PowerUpMenu PowerUpMenu;
	public static GameManager Instance;
	public GameState State;

	private void Awake()
	{
		Instance = this;
	}

	public enum GameState
	{
		StartMenu,
		DayMode,
		NightMode,
		EndScreen
	}

	public void UpdateGameState(GameState newState)
	{
		State = newState;

		switch(newState)
		{
			case GameState.StartMenu:
				//do something
				break;
			case GameState.DayMode:
				//add another townsfolk or two
				//power up menu 
				//give goose ai default buffs
				break;
			case GameState.NightMode:
				//disable third person movement
				//enable goose movement controller
				//townsfolk panic mode
				break;
			case GameState.EndScreen:
				//score and gameover menu
				break;
			default:
				break;
		}

	}

	// Start is called before the first frame update
	void Start()
    {
		PowerUpMenu = GetComponent<PowerUpMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnEnable()
	{
		TimeManager.OnHourChanged += TimeCheck;
	}

	private void OnDisable()
	{
		TimeManager.OnHourChanged -= TimeCheck;
	}

	private void TimeCheck()
	{
		if (TimeManager.Hour == GameVariables.dayModeHour)
			PowerUpMenu.LaunchMenu();
	}
}
