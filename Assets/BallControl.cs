using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
     // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;
    // Untuk mengakses informasi titik asal lintasan

    // Rigidbody 2D bola
    private Rigidbody2D rigidbody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    private float initialForceX = 10;
    private float initialForceY = 10;
    // Start is called before the first frame update


     // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
     // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    

      // Untuk mengakses informasi titik asal lintasan
    
    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidbody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float randomInitialForceY = Random.Range(-initialForceY, initialForceY);

        int direction = Random.Range(0, 2);

        if (direction < 1.0f)
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(-initialForceX, randomInitialForceY), 10.0f);
        }
        else
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(initialForceX, randomInitialForceY), 10.0f);
        }
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    void Start()
    {
        trajectoryOrigin = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
 
        // Mulai game
        RestartGame();
    }
    

    
}
