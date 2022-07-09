using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBottan : MonoBehaviour
{
    public GameObject Title;
    public GameObject Difficlut;
    public void OnClickStartButton()
   {
       Title.SetActive(false);
       Difficlut.SetActive(true);
   }
    
}
