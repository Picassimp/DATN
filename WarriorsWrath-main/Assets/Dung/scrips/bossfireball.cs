using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossfireball : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speed = 20;
    public float st;
    private float enemyPositionX, enemyPositionY, playerPositionX, playerPositionY;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (speed > 0)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
        Vector2 direction = new Vector2((playerPositionX - enemyPositionX) < 0 ? (playerPositionX - enemyPositionX) + 1 : (playerPositionX - enemyPositionX) - 1, (playerPositionY - enemyPositionY)).normalized;
        rigidbody2D.velocity = direction * 20; // S?a ð?i vector ð? bay ngang
        Destroy(gameObject, 2);
    }
    public void SetVelocity(float value, float _enemyPositionX, float _enemyPositionY, float _playerPositionX, float _playerPositionY, float _st)
    {
        speed = value;
        enemyPositionX = _enemyPositionX;
        enemyPositionY = _enemyPositionY;
        playerPositionX = _playerPositionX;
        playerPositionY = _playerPositionY;
        st = _st;
    }


}