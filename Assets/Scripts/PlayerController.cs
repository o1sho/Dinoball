using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    private IInputController _inputController;

    private Rigidbody2D _rb;
    private Animator _animator;

    [Header("PLAYER")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isHit;
    [SerializeField] private bool isAlive;
    public AudioSource walkSound;

    [Header("BALL")]
    public float minBounceForceBall;
    public float maxBounceForceBall;


    private void Awake()
    {
        instance = this;

        if (Application.isMobilePlatform)
        {
            MobileInputController mobileInputController = new MobileInputController();
            SetInputController(mobileInputController);
        } else
        {
            KeyboardInputController keyboardInputController = new KeyboardInputController();
            SetInputController(keyboardInputController);
        }
    }

    public void SetInputController(IInputController controller)
    {
        _inputController = controller;
    }

    private void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        isHit= false;
        isAlive= true;
    }

    private void Update()
    {
        Flip();

        _animator.SetBool("isWalk", _rb.velocity.x != 0);
        _animator.SetBool("isHit", isHit);
    }

    private void FixedUpdate()
    {
        if (isHit == false && isAlive == true) Walk();
        if (isHit == true && isAlive == true) StopWalk();
        if (isHit == false && isAlive == false) StopWalk();
    }

    private void Walk()
    {
        _rb.velocity = new Vector2(_inputController.ProcessInput() * moveSpeed, _rb.velocity.y);
    }

    private void StopWalk()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            isHit= true;

            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // —оздаем случайный вектор дл€ направлени€ отскока
            Vector2 randomBounceDirection = new Vector2(Random.Range(-0.45f, 0.45f), Random.Range(0.5f, 1.0f));

            // ѕрименение отскока м€чика с учетом направлени€ и силы
            ballRb.velocity = randomBounceDirection.normalized * Random.Range(minBounceForceBall * TimeController.instance.gameSpeed, maxBounceForceBall * TimeController.instance.gameSpeed);


            float randomPitch = Random.Range(0.9f, 1.1f);
            SoundsController.instance.hitSound.pitch = randomPitch;
            SoundsController.instance.hitSound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(HitController());
            
        }
    }

    private void Flip()
    {
        if (_inputController.ProcessInput() > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (_inputController.ProcessInput() < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private IEnumerator HitController()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        isHit = false;
    }

    public void SetStatusPlayer(bool _isAlive)
    {
        isAlive= _isAlive;
        if (!_isAlive) _animator.Play("Death");  
    }

    public void PlaySoundWalk()
    {
        walkSound.Play();
    }

}
