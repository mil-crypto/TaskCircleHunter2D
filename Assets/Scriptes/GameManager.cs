using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Text _coinsText;
    [SerializeField] private int _countOfCoins,_countOfThorns;
    [SerializeField] private float _groundRadius = 0.3f;
    [SerializeField] private LayerMask _groundMask;
    public GameObject coin;
    public GameObject thorn;

    private void Start()
    {
            _gameOverPanel.SetActive(false);
            _winPanel.SetActive(false);

        for (var i = 0; i <= _countOfCoins; i++)
        {
            var randomX = Random.Range(-10, 10);
            var randomY = Random.Range(-4, 4);

            var isTrue = Physics2D.OverlapCircle(new Vector2(randomX, randomY), _groundRadius, _groundMask);
            if (!isTrue)
            {
                Instantiate(coin, new Vector2(randomX, randomY), Quaternion.identity);
            }
        }

        for (var i = 0; i <= _countOfThorns; i++)
        {
            var randomX = Random.Range(-10, 10);
            var randomY = Random.Range(-4, 4);

            var isTrue = Physics2D.OverlapCircle(new Vector2(randomX, randomY), _groundRadius, _groundMask);
            if (!isTrue)
            {
                Instantiate(thorn, new Vector2(randomX, randomY), Quaternion.identity);
            }
        }
    }
    void Update()
    {
        _coinsText.text = Coin.coins.ToString();
        if (Coin.coins >= _countOfCoins)
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (Thorn.isPlayerDead)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Thorn.isPlayerDead = false;
        Coin.coins = 0;
        _gameOverPanel.SetActive(false);
        _winPanel.SetActive(false);
    }
}
