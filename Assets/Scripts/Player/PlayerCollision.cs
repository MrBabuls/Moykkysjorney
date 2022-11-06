using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CinemachineVirtualCamera camera;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            AudioManager.instance.Play("PlayerDeath");
            if (HealthManager.health <= 0)
            {
                PlayerDeathEffect();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if (collision.gameObject.tag == "blueEnemy")
        {
            HealthManager.health--;
            AudioManager.instance.Play("PlayerDeath");
            if (HealthManager.health <= 0)
            {
                PlayerDeathEffect();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if (collision.gameObject.tag == "KillZone")
        {
            HealthManager.health -= HealthManager.health;
            AudioManager.instance.Play("PlayerDeath");
                PlayerDeathEffect();
            
        }
    }

    public void PlayerDeathEffect()
    {
        camera.Follow = null;
        this.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        this.gameObject.transform.position += movement * Time.deltaTime;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;

        PlayerManager.isGameOver = true;
        AudioManager.instance.Play("GameOver");
        StartCoroutine(KillEnemy(gameObject));
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
                AudioManager.instance.Play("EnemyDeath");
                StartCoroutine(KillEnemy(enemy.gameObject));
            }

        }

        if (collision.gameObject.tag == "Chest")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Open", true);
            PlayerManager.Winner = true;
            AudioManager.instance.Play("Win");
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
