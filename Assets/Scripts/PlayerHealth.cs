using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int currentHealth;
    public int numOfHearts = 6;

    // An array of images in which we can reference the heart images
    public Image[] hearts;
    // The image containers for full and empty hearts respectively
    // We can drag our images in from Unity in the inspector
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = numOfHearts;
    }

    void Update() {
        
        if (currentHealth > numOfHearts) {
            currentHealth = numOfHearts;
        }
        
        for (int i = 0; i < hearts.Length; i++) {

            // Determines if we show a full or empty heart
            if (i < currentHealth) {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            // Determines how many heart containers are showing
            if (i < numOfHearts) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            currentHealth--;
        }
    }

}