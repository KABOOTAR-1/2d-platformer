using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Sc;
    void Start()
    {
        Sc= GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        Sc.text = "Score :" + Tags.score;   
    }
}
