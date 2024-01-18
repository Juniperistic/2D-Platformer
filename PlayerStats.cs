using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;

    public int coinsCollected = 0;

    public bool isImmune = false;
    public float immunityDuration = 1.5f;
    private float immunityTime = 0f;

    private float flickerDuration = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;

    public bool isDead = false;
    private float deadTimeElapsed = 0f;

    private GameObject HUDCamera;
    private GameObject HUDSprite;

    public ParticleSystem particleHitLeft;
    public ParticleSystem particleHitRight;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        HUDCamera = GameObject.FindGameObjectWithTag("HUDCamera");
        HUDSprite = GameObject.FindGameObjectWithTag("HUDScore");

        if(SceneManager.GetActiveScene().buildIndex != Constants.SCENE_LEVEL_1)
        {
            coinsCollected = PlayerPrefs.GetInt(Constants.PREF_COINS);
            HUDSprite.GetComponent<CoinCounter>().value = coinsCollected;
        }

        PlayerPrefs.SetInt(Constants.PREF_CURRENT_LEVEL, SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if(isImmune)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;

            immunityTime += Time.deltaTime;
            if(immunityTime >= immunityDuration)
            {
                isImmune = false;
                spriteRenderer.enabled = true;
                Debug.Log("Immunity has ended.");
            }
        }
            if(isDead)
        {
            deadTimeElapsed += Time.deltaTime;

            if(deadTimeElapsed >= 2.0f)
            {
                SceneManager.LoadScene(Constants.SCENE_GAME_OVER);
            }
        }
    }
    public void CollectCoin(int coinValue)
    {
        coinsCollected += coinValue;
        HUDSprite.GetComponent<CoinCounter>().value = coinsCollected;

    }

    public void TakeDamage(int damage, bool playHitReaction)
    {
        if (!isImmune && !isDead)
        {
            health -= damage; //health = health - damage;
            Debug.Log("Player Health: " + health.ToString());
            HUDCamera.GetComponent<GUIGame>().UpdateHealth(health);

            if (health <= 0)
            {
                health = 0;
                PlayerIsDead();
            }
            else if (playHitReaction)
            {
                Debug.Log("Hit reaction called.");
                PlayHitReaction();
            }
        }
    }


    void PlayHitReaction()
    {
        isImmune = true;
        immunityTime = 0f;
        
        gameObject.GetComponent<Animator>().SetTrigger("Damage");

        PlayerController controller = gameObject.GetComponent<PlayerController>();
        controller.PlayDamageAudio();

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (controller.isFacingRight == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 400));
            //this.particleHitLeft.Play();
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 400));
            //this.particleHitRight.Play();
        }

    }

    void SpriteFlicker()
    {
        if(flickerTime < flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            flickerTime = 0;
        }
    }

    void PlayerIsDead()
    {
        isDead = true;
        gameObject.GetComponent<Animator>().SetTrigger("Damage");

        PlayerController controller = gameObject.GetComponent<PlayerController>();
        controller.enabled = false;
        controller.PlayDamageAudio();

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if(controller.isFacingRight)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 400));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 400));
        }
    }
}
