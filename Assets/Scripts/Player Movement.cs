using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    private int scoreVal = 0;
    public TextMeshProUGUI scoreBox;


    void Update()
    {//moving up and down
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }

        // Moving left and right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, -4f),
            Mathf.Clamp(transform.position.y, -4f, 4f),
            transform.position.z
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            if(collision.GetComponent<ProjectileMove>()!= null)
            {
                print("hit");
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBox.text = "Score: " + scoreVal;
            }
            Destroy(collision.gameObject);
        }
    }
}


