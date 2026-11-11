using System;
using UnityEngine;
using unitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneController : MonoBehaviour//SceneController scriptini sahne geçişlerini kontrol etmek için kullandım
{
    public void NextScene()//bir sonraki sahneye geçmek için kullandım ayrıca sahne geçişlerini unitySceneManager ile kontrol ediyorum
    {
        int currentSceneIndex = unitySceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;// bir sonraki sahne indexini bulmak için kullandım 1-2-3 diye level mantığı kullandım

        if (nextSceneIndex < unitySceneManager.sceneCountInBuildSettings)//build settingsteki sahne sayısından küçükse bir sonraki sahneye geçmesini sağlıyorum
        {
            unitySceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Oyun bitti! Başka bir bölüm yok.");
        }
    }

    public void RestartScene()// sahneyi yeniden başlatmak için kullandım ayrıca sahne geçişlerini unitySceneManager ile kontrol ediyorum
    {
        int currentSceneIndex = unitySceneManager.GetActiveScene().buildIndex;
        unitySceneManager.LoadScene(currentSceneIndex);
    }

    internal void LoadNextScene()
    {
        NextScene();
    }
}