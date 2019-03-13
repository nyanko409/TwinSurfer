using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Menu Groups")]
    public GameObject mainMenu;
    public GameObject resultMenu;
    public GameObject ingameOverlay;

    [Header("UI Text")]
    public Text scoreText;
    public Text ingameText;

    [Header("Audio")]
    public AudioClip mainBgm;
    public AudioClip ingameBgm;
    public AudioClip btnClick;
    public AudioClip playerExplosion;

    [HideInInspector] public bool isPlaying;
    SpawnPlayer spawnPlayer;
    SpawnObstacle spawnObstacle;
    SerializeScore serScore;
    SoundManager soundManager;
    CanvasGroup mainAlpha;
    CanvasGroup ingameAlpha;
    float score;
    float animTime;

    void Start()
    {
        // init variables
        spawnPlayer = GetComponent<SpawnPlayer>();
        spawnObstacle = GetComponent<SpawnObstacle>();
        serScore = GetComponent<SerializeScore>();
        mainAlpha = mainMenu.GetComponent<CanvasGroup>();
        ingameAlpha = ingameOverlay.GetComponent<CanvasGroup>();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();

        // set playing flag to false
        isPlaying = false;

        // play main bgm
        soundManager.PlayBgm(mainBgm);

        // load and set top 3 scores
        serScore.LoadScore();
        serScore.SetScoreText();
    }

    void Update()
    {
        // make enter start the game
        if(!isPlaying && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (mainMenu.activeSelf)
                StartGame(true);
            else
                StartGame();
        }

        if (isPlaying)
        {
            // fade out main menu
            if(mainAlpha.alpha <= 0.0f)
            {
                mainMenu.SetActive(false);
            }
            else
            {
                mainAlpha.alpha -= Time.deltaTime * 3;
            }

            // fade in score text
            ingameAlpha.alpha += Time.deltaTime * 2;


            // add score (seconds survived)
            score += Time.deltaTime;

            // update ingame text
            ingameText.text = Mathf.RoundToInt(score) + " seconds";

            // trigger animation every 10 sec
            if (score >= animTime)
            {
                ingameText.GetComponent<Animator>().SetTrigger("Blob");
                animTime += 10.0f;
            }
        }
    }

    // player lost the game, show result screen
    public void LostGame()
    {
        // prevent calling twice
        if (!isPlaying) return;

        // set flag back to false
        isPlaying = false;

        // stop spawning obstacles
        spawnObstacle.StopSpawn();

        // play audioclip
        soundManager.PlaySfx(playerExplosion, 0.3f);

        // change menu to result screen
        resultMenu.SetActive(true);
        ingameOverlay.SetActive(false);

        // display scores
        scoreText.text = Mathf.RoundToInt(score).ToString() + " seconds";
        serScore.UpdateScore(Mathf.RoundToInt(score));
    }

    // display main menu, called from result screen
    public void ShowMainMenu()
    {
        // play button sfx
        soundManager.PlaySfx(btnClick, .5f);

        // play main bgm
        soundManager.PlayBgm(mainBgm, .5f);

        // change menu to main menu
        resultMenu.SetActive(false);
        mainMenu.SetActive(true);
        mainAlpha.alpha = 1.0f;
    }

    // start the game
    public void StartGame(bool fromMainMenu = false)
    {
        // init score and flag
        isPlaying = true;
        score = 0.0f;
        animTime = 9.5f;

        // play button sfx
        soundManager.PlaySfx(btnClick, .5f);

        // play ingame bgm
        if(fromMainMenu)
            soundManager.PlayBgm(ingameBgm, .5f);

        // spawn player and start spawning obstacles
        spawnPlayer.Spawn();
        spawnObstacle.StartSpawn();

        // change menu to ingame
        resultMenu.SetActive(false);
        ingameOverlay.SetActive(true);
        ingameAlpha.alpha = 0.0f;
    }

    // quit game
    public void QuitGame()
    {
        // play button sfx
        soundManager.PlaySfx(btnClick, .5f);

        // quit game
        Application.Quit();
    }

    // return score
    public float GetScore()
    {
        return score;
    }
}
