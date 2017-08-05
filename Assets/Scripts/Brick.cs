using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private int maxHits;

    // Use this for initialization
    void Start()
    {
        if (this.tag == "Breakable")
            breakableCount++;
        maxHits = hitSprites.Length + 1;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Breakable")
            HandleHits();
    }

    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
            breakableCount--;
            levelManager.BrickDestroyed();
            PlaySmoke();
            Destroy(gameObject);
        }
        else
            LoadSprites();
    }

    void PlaySmoke()
    {
        // In this case Play On Awake should be enabled
        smoke.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
        Instantiate(smoke, this.transform.position, Quaternion.identity);
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Sprite is missing");
    }

    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}