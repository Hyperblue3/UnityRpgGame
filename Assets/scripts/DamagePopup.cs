using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{


    public static DamagePopup Create(Vector3 position, float damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);   

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    private TextMeshPro textMesh;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    
    public void Setup(float damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }
}
  