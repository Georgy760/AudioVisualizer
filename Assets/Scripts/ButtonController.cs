using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   public void EnableObject()
   {
      if (this.gameObject.activeSelf)
      {
         this.gameObject.SetActive(false);
      } else this.gameObject.SetActive(true);
   }
}
