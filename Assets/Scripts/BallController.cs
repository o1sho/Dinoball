using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private int timeDelayFall;

    [SerializeField] private int startForceSpeed;

    [SerializeField] private float correctionGravityScale;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // «адаем начальное направление движени€
        StartCoroutine(StartMoveBall());
    }

    private void FixedUpdate()
    {
        _rb.gravityScale = TimeController.instance.gameSpeed * correctionGravityScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreController.instance.ScoreUp();
        }
    }

    private IEnumerator StartMoveBall()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Vector2 randomPosition = new Vector3(Random.Range(-2.0f, 2.0f), 0f);
        transform.position = randomPosition;

        yield return new WaitForSeconds(timeDelayFall);

        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = Vector2.up * startForceSpeed;
    }

}
