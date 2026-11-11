using UnityEngine;
using TMPro;
using System;


public class ScoreManager : MonoBehaviour//ScoreManager scriptini oyuncunun puanını kontrol etmek için kullandım ayrıca puanını arttırmak ve azaltmak için kullandım
{
    public static ScoreManager instance;//diper scriptlerden ScoreManager scriptine bağlamak için kullandım
    [SerializeField] private SceneController sceneController;//burda sceneController scriptine bağladım
    [SerializeField] private ScoreManager scoreManager;//burda scoreManager scriptine bağladım
    [SerializeField] private TextMeshProUGUI scoreText;//burda scoreText ile scoreManager scriptine bağladım ve puanı ekranda göstermek için kullandım
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Start()//Oyun başladığında puanı ekranda göstermek için kullandım başlangıçta puan 0 olduğu için ekranda 0 gösteriyor
    {
        UpdateScoreUI();

    }


    public void AddScore(int amount)//bu fonksiyon oyuncunun puanını arttırmak için kullandım ayrıca puanı ekranda göstermek için UpdateScoreUI fonksiyonunu kullanıyorum 
    {
        score += amount;
        Debug.Log("PARA EKLENDİ: " + score);
        UpdateScoreUI();
    }

    public void RemoveScore(int amount)//bu fonksiyon oyuncunun puanını azaltmak için kullandım ayrıca puanı ekranda göstermek için UpdateScoreUI fonksiyonunu kullanıyorum
    {
        score -= amount;
        
        if (score < 0)
        {
            score = 0;
        }

        UpdateScoreUI(); 

    }

    public int GetScore()//bu fonksiyon oyuncunun puanını almak için kullandım ayrıca puanı ekranda göstermek için UpdateScoreUI fonksiyonunu kullanıyorum
    {

        return score;
    
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        
    }
}