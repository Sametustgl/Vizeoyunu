using UnityEngine;

public class PlayerController : MonoBehaviour// oyuncunun temel hareketlerini kontrol etmek için aynı zamanda para ve mayın etkileşimlerini kontrol eder
{
    [SerializeField] private float moveSpeed = 10f;//oyuncunun hareket hızı serializeField ile inspector'dan kolayca değiştirmek için
    [SerializeField] private float jumpForce = 5f;// oyuncunun zıplama gücü serializeField ile inspector'dan kolayca değiştirmek için

    private Rigidbody rb;//oyuncunun fizik etkileşimlerini kontrol etmek için rigidbody componentini kullanıyorum
    private bool isGrounded = false;// oyuncunun yerde olup olmadığını kontrol etmek için kullandım

    private float horizontal;// oyuncunun x eksenindeki hareketini kontrol etmek için kullandım sağ ve sol olarak
    private float vertical;// oyuncunun z eksenindeki hareketini kontrol etmek için kullandım ileri ve geri olarak

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();// oyuncunun rigidbody componentini buluyoruz
    }

    private void Update()//klavyeden gelen inputları kontrol etmek için kullandım ayrıca zıplama kontrolünü de burda yaptım
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//boşluk tuşuna bastığında oyuncu yerdeyse zıplamasını sağlar
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()// rigidbody componenti ile hareket ettiriyorum
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        direction = direction.normalized;

        rb.AddForce(direction * moveSpeed);
    }

    private void Jump()//rigidbody componenti ile zıplamasını sağlıyorum ayrıca zıplama sesini çalıyorum
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isGrounded = false;//havada tekrar zıplamasını engellemek için 

        Debug.Log("Zipladin!");

        AudioManager.instance.PlayJumpSound();

    }
   
    private void OnCollisionEnter(Collision collision)//çarpışma olduğunda oyuncunun yerde olup olmadığını kontrol etmek için kullandım
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Yerdesin!");
        }
    }
    private void OnTriggerEnter(Collider other)// oyuncu para veya mayın ile çarpıştığında puanını arttırmak ve azaltmak için kullandım ve ses efektlerini çalıyor
    {
        if (other.CompareTag("Coin"))
        {
            ScoreManager.instance.AddScore(10);

            AudioManager.instance.PlayCoinSound();

            Debug.Log("Silinen nesne: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb")) 
        { 
            ScoreManager.instance.RemoveScore(5);

            AudioManager.instance.PlayBombSound();

            Debug.Log("Silinen nesne: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}