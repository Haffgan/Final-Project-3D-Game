using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip gameOver, hurt, attack, winning, upgrade, dead, walk;
    static AudioSource audioScr;

    void Start()
    {
        gameOver = Resources.Load<AudioClip>("gameOver");
        hurt = Resources.Load<AudioClip>("Hurt");
        attack = Resources.Load<AudioClip>("attack");
        winning = Resources.Load<AudioClip>("winning");
        upgrade = Resources.Load<AudioClip>("upgrade");
        dead = Resources.Load<AudioClip>("Dead");
        walk = Resources.Load<AudioClip>("walk");
        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gameOver":
                audioScr.PlayOneShot(gameOver);
                break;
            case "Hurt":
                audioScr.PlayOneShot(hurt);
                break;
            case "attack":
                audioScr.PlayOneShot(attack);
                break;
            case "winning":
                audioScr.PlayOneShot(winning);
                break;
            case "upgrade":
                audioScr.PlayOneShot(upgrade);
                break;
            case "Dead":
                audioScr.PlayOneShot(dead);
                break;
            case "walk":
                audioScr.PlayOneShot(walk);
                break;
        }
    }
}
