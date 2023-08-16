using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private IInputController _inputController;

    private Rigidbody2D _rb;
    private Animator _animator;

    [Header("PLAYER")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isHit;

    [Header("BALL")]
    public float minBounceForceBall;
    public float maxBounceForceBall;
    

    private void Awake()
    {
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
    }

    private void Update()
    {
        Flip();

        _animator.SetBool("isWalk", _rb.velocity.x != 0);
        _animator.SetBool("isHit", isHit);
    }

    private void FixedUpdate()
    {
        if (!isHit) _rb.velocity = new Vector2(_inputController.ProcessInput() * moveSpeed, _rb.velocity.y);
        if (isHit) _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            isHit= true;

            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Вычисление направления отскока мячика в зависимости от точки удара
            Vector2 bounceDirection = collision.contacts[0].point - (Vector2)transform.position;

            // Применение отскока мячика с учетом направления и силы
            ballRb.velocity = bounceDirection.normalized * Random.Range(minBounceForceBall, maxBounceForceBall);
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
        yield return new WaitForSecondsRealtime(0.2f);
        isHit = false;
    }
}
