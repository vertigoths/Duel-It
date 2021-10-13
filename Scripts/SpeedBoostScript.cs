using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("DisableObject");
    }


    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }
}
