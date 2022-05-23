using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;
    public static int totalTooth;
    private Image HealthBar;
    public float CurrentHealth;
    private float playerHealth;
    //playerHealth'i PlayerScript'den al
    [SerializeField] private float MaxHealth = 100f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        HealthBar = GetComponent<Image>();
    }

    private void Update()
    {
        CurrentHealth = playerHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tooth"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            totalTooth++;
            _text.text = totalTooth.ToString();
        }
    }
}
