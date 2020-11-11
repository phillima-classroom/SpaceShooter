using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    static Text text;
    public static int pont = 0;
    
    // Start is called before the first frame update
    void Start()
    {
      text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setTexto(int pontu) {
        pont += pontu;
        text.text = pont.ToString();
    }
}
