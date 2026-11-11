using UnityEngine;

public class AudioManager : MonoBehaviour // AudioManager oyundaki müzik ve ses efektlerini kontrol etmek için kullandığım script
{
    public static AudioManager instance;// burda instance kullanmamın sebebi diğer scriptlerden AudioManager'e ulaşmak için


    [SerializeField] private AudioSource SFXSource;// ses efektleri için
    [SerializeField] private AudioSource musicSource;// arka plan gibi müzik sesleri için ayrıca serializeField kullandım çünkü inspector'dan kolayca değiştirmek için


    [SerializeField] private AudioClip coinSound;// altınları aldığında çıkan ses efekti
    [SerializeField] private AudioClip bombSound;// mayın patladığında çıkan ses efekti
    [SerializeField] private AudioClip jumpSound;// zıplarken çıkan ses efekti

    [SerializeField] private AudioClip backgroundMusic;

    private void Awake()
    {
        instance = this;// burda this AudioManagerin kendisini temsil ediyor 
    }

    private void Start()//Oyun başladığında arka plan müziğini çalıyor
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;// müziği tekrar tekrar çalması için loop kullandım
        musicSource.Play();
        
    }

    public void PlayCoinSound()// bu fonksiyon para sesi için diğer scriptten geliyor ve playoneshot fonksiyonu ile 1 kerelik çalıyor
    {
        SFXSource.PlayOneShot(coinSound);
    }

    public void PlayBombSound() // bu fonksiyon mayın sesi için diğer scriptten geliyor ve playoneshot fonksiyonu ile 1 kerelik çalıyor
    {
        SFXSource.PlayOneShot(bombSound);
    }
    public void PlayJumpSound()// bu fonksiyon zıplama sesi için diğer scriptten geliyor ve playoneshot fonksiyonu ile 1 kerelik çalıyor
    {
        SFXSource.PlayOneShot(jumpSound);
    }

}