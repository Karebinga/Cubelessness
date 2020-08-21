using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    private float _count; 
    private TextMeshProUGUI _countHolder;

    void Update()
    {
        _count = (int) 1f / Time.deltaTime;
        _countHolder = gameObject.GetComponent<TextMeshProUGUI>();
        _countHolder.text = (Mathf.Round(_count)).ToString();
    }
}
