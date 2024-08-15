using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TileBoard board;
    [SerializeField] private CanvasGroup gameOver;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hiscoreText;
    [SerializeField] private List<GameObject> popups;
    private GameObject canvas;
    public bool waiting=true;

    public int score;
    public int Score => score;
    public int biggestTileIndex = 0;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(CheckScenes());
    }

    IEnumerator CheckScenes(){
        string lastScene="null";
        while(true){
            yield return null;
            Scene activeScene = SceneManager.GetActiveScene();
            //Debug.Log("lastscene "+lastScene);
            //Debug.Log("activeScene "+activeScene.name);
            if(activeScene.name == lastScene)continue;
            lastScene=activeScene.name;
            if(activeScene.name == "2048"){
                NewGame();
            }
        }
    }  

    public void NewGame()
    {
        Debug.Log("new game");
        canvas = GameObject.Find("Canvas");
        board= canvas.transform.Find("Board").gameObject.GetComponent<TileBoard>();
        gameOver = canvas.transform.Find("Board").gameObject.transform.Find("Game Over").gameObject.GetComponent<CanvasGroup>();
        GameManager.Instance.waiting=false;
        GameManager.Instance.biggestTileIndex=0;
        // reset score
        //SetScore(0);
        //hiscoreText.text = LoadHiscore().ToString();

        // hide game over screen
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        // update board state
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        //scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore) {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }

    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }

    public void ManageNewBiggestTile(int __biggestTileIndex){
        Debug.Log("New biggest tile: " + __biggestTileIndex);
        int popupIndex = (int)(Mathf.Log(__biggestTileIndex) / Mathf.Log(2)) - 1;
        //Debug.Log("Popup index: " + popupIndex);
        if(Settings.ispopup){
            GameObject newPopup = Instantiate(popups[popupIndex], canvas.transform);
            newPopup.name = "Popup";
        }
        else{
            waiting=false;
        }
    }
}
