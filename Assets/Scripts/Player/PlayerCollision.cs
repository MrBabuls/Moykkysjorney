using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if (collision.gameObject.tag == "blueEnemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
        if (collision.transform.tag == "Chest")
        {
            Debug.Log("Won!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HeadStomper")
        {
            if(transform.position.y > collision.transform.position.y)
            {
                var enemy = collision.transform.root;
                enemy.GetComponent<SpriteRenderer>().flipY = true;
                enemy.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                enemy.transform.position += movement * Time.deltaTime;
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
                StartCoroutine(KillEnemy(enemy.gameObject));
            }

        }
    }

    IEnumerator KillEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(3);
        Destroy(enemy);
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

}
