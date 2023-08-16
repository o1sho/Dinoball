using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private int timeDelayFall;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // «адаем начальное направление движени€
        StartCoroutine(StartMoveBall());
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
        Vector2 randomPosition = new Vector3(Random.Range(-3.0f, 3.0f), 0f);
        transform.position = randomPosition;

        yield return new WaitForSeconds(timeDelayFall);

        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = Vector2.up * 3.0f;
    }

}
