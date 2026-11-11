using UnityEngine;

public class LevelExit : MonoBehaviour//bu scripti bitiş kapısına geldiğinde yeterli puan varmı yokmu kontrol etmesi için yaptım
{
    [SerializeField] private int requiredScore = 50;//bölümü geçmek için gerekli puan 

    [SerializeField] private ScoreManager scoreManager;//burda scoreManager scriptine bağladım
    [SerializeField] private SceneController sceneController;//burda sceneController scriptine bağladım

    private void OnTriggerEnter(Collider other)//burda oyuncunun bitiş kapına geldiğinde puanına göre kontrol edip bölümü geçiriyorum
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ScoreManager: " + scoreManager);
            if (scoreManager.GetScore() >= requiredScore)
            {
                Debug.Log("Yeterli paranız var seviyeyi geçtiniz!");
                sceneController.NextScene();//puanı yeterli olduğu için bir sonraki bölüme atıyo
            }
            
            else
            {
                Debug.Log("Yeterli paranız yok, Yeniden deneyin!");
            }
        }
    }
}
        
    
