using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Soccer : MonoBehaviour {
	
	//gameobject visible in the inspector
	public GameObject soccerBall;
	
	//variables not visible in the inspector
	public static bool gameOver;
	public static bool startMenu;

	public Text CountText;
	public Text WinText;
	public Text LostText;
	
	GameObject GameOverMenu;
	GameObject StartMenu;
	
	GameObject Score;
	GameObject BestScore;
	GameObject timeObject;

	GameObject Count;
	
	public static int score;
	float time;

	public static int count;

	Transform spawnpoint;
	
	void Start(){
	//normal timescale
	Time.timeScale = 1f;
	
	//set score 0 and time 60
	score = 0;
	time = 30f;

	count = 5;

		
	//search for the menu objects
	StartMenu = GameObject.Find("Start menu");
	GameOverMenu = GameObject.Find("Game over menu");
	Score = GameObject.Find("Score");
	timeObject = GameObject.Find("time left");
	BestScore = GameObject.Find("Best");

	Count = GameObject.Find ("Count");
	
	//find ball spawner
	spawnpoint = GameObject.Find("spawnpoint").transform;
		
	//show best score on best score object using UI text
	BestScore.GetComponent<UnityEngine.UI.Text>().text = "Mejor: " + PlayerPrefs.GetInt("Best(soccer)");
		
	//set objects true/false
	Score.SetActive(false);
	startMenu = true;
	gameOver = false;
	StartMenu.SetActive(true);
	GameOverMenu.SetActive(false);

	Count.SetActive (false);
	}
	
	void Update(){
	//if the game is playing, show score and time
	if(!gameOver && !startMenu){
	Score.GetComponent<UnityEngine.UI.Text>().text = "" + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "" + time.ToString("f1");
	time -= Time.deltaTime;
	}
	
	//game is over after 60 seconds
	if(time <= 0){
	gameOver = true;
	GameOverMenu.SetActive(true);
	
	//save highscore
	if(score > PlayerPrefs.GetInt("Best(soccer)")){
	PlayerPrefs.SetInt("Best(soccer)", score);	
	}
	}
	//if we are game over, display score and don't display time
	if(gameOver){
	Score.GetComponent<UnityEngine.UI.Text>().text = "Puntaje: " + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "";
	}

	setCounText();
			
	}
	
	//add soccerball at spawner position
	public void spawnBall(){
	if(!gameOver){
	Instantiate(soccerBall, spawnpoint.position, spawnpoint.rotation);	
	}
	}
	
	public void startGame(){
	//start game and spawn the first ball
	StartMenu.SetActive(false);
	BestScore.SetActive(false);
	startMenu = false;
	Score.SetActive(true);
	spawnBall();
	Count.SetActive (true);
	}
	
	public void quitGame(){
	//quit app
	Application.Quit();
	}
	
	public void restartGame(){
		//restart this scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void setCounText()
	{
		System.Diagnostics.Debug.WriteLine("Cuenta: "+Soccer.count);
		CountText.text = "Restan: " + count.ToString();
		if (Soccer.count <= 0) 
		{
			WinText.text = "Ganaste";
			//gameOver = true;
			//GameOverMenu.SetActive(true);
		}
		else
		{
			WinText.text = "Seguí Participando";
		}
	}


}
