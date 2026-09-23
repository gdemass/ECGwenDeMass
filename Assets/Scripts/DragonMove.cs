using UnityEngine;

public class DragonMove : MonoBehaviour
{
  
  public float speed = 5;
  public bool goingUp = true;

//rat/fireball Timers
private float ratWait = 1;
private float fireballWait = 2;
  private float ratTimer = 0;
private float fireballTimer = 0;

   public GameObject rat; public GameObject fireball;
    void Update()
    {
        //spawnning rats and fireballs
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;
        if(ratTimer > ratWait)
        {//istantiate means spawn
            Instantiate(rat, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWait = Random.Range(1f, 2f);
        }
        if(fireballTimer > fireballWait)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWait = Random.Range(2f, 3f);
        }

        transform.Translate(transform.up * speed * Time.deltaTime);

        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }
        if(transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
