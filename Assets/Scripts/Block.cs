using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparkleVFX;

    [SerializeField] Sprite[] hitSprites;
    


    Level level;
    GameSession gameStatus;

    [SerializeField] int takenDamage;

    private void Start()
    {
        CountBlocks();
    }

    private void CountBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (tag == "Breakable")
            level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
            BlockHit();
        

    }

    private void BlockHit()
    {
        takenDamage++;
        AudioSource.PlayClipAtPoint(audioClip, transform.position);

        int hitPoints = hitSprites.Length + 1;

        if (takenDamage >= hitPoints)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[takenDamage - 1];
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        level.BlockDestroyed();
        TriggerSparklesVFX();
        Destroy(gameObject);
        
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles,blockSparkleVFX.GetComponent<ParticleSystem>().main.duration + 0.1f);
    }
}
