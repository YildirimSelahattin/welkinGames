using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpro;

    private void Awake()
    {
        _tmpro.text = Score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tooth"))
        {
            Destroy(other.gameObject);
            Score.totalScore++;
            _tmpro.text = Score.totalScore.ToString();
        }
    }
}
