using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private SpriteRenderer _sprite;
    private bool isGameOver;
    private float gameOverCount = 2f;
    
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _canvasGroup.alpha = 1;
        GameEvent.OnGameStartEvent += OnGameStart;
        GameEvent.OnGameOverEvent += OnGameOver;
    }
    
    void Update()
    {
        if(isGameOver)
        {
            gameOverCount -= Time.deltaTime;
        }
        
        if(gameOverCount <= 0)
        {
            OnGameOver();
            gameOverCount = 2f;
        }
    }

    void OnDestroy()
    {
        GameEvent.OnGameStartEvent -= OnGameStart;
        GameEvent.OnGameOverEvent -= OnGameOver;
    }

    private void OnGameStart()
    {
        isGameOver = false;
        _sprite.enabled = false;
        _canvasGroup.alpha = 0;
    }
   
    private void OnGameOver()
    {
        isGameOver = true;
        if(gameOverCount <= 0)
        {
            _sprite.enabled = true;
            _canvasGroup.alpha = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}