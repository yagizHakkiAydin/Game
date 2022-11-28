using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{






    [SerializeField] Text loadingText;


    private float myDegree = 0.0f;



    [SerializeField] private float rotateSpeed = 1.0f;

    [SerializeField] private float orbitalRadius = 200.0f;

    [SerializeField] Transform light;


    private void UpdateLightPosition()
    {
        myDegree += 1.0f * rotateSpeed;
        myDegree %= 360.0f;

        light.localPosition = new Vector3( orbitalRadius*Mathf.Sin( myDegree*Mathf.Deg2Rad ) , orbitalRadius*Mathf.Cos( myDegree*Mathf.Deg2Rad ) , 1.0f );


    }


    private void UpdateLightRotation()
    {
        light.rotation = Quaternion.Euler(0 , 0, (360-myDegree) );
    }




    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateLoadingText();
        this.loadingTextInterval++;
        this.loadingTextInterval %= 100;
        UpdateLightPosition();
        UpdateLightRotation();
    }






    private int loadingTextInterval = 0;
    private void UpdateLoadingText()
    {
        Debug.Log(loadingTextInterval);
        if(loadingTextInterval >= 75)
        {
            loadingText.text = "   Loading...";
        }
        else if(loadingTextInterval >= 50)
        {
            loadingText.text = "  Loading..";
        }
        else if(loadingTextInterval >= 25)
        {
            loadingText.text = " Loading.";
        }
        else if(loadingTextInterval >= 0)
        {
            loadingText.text = "Loading";
        }
    }
}
