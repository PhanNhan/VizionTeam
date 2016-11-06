using UnityEngine;
using System.Collections;
using System;

public class AppController : MonoBehaviour {

    [SerializeField] private GameObject imageTarget;
    private Vector3[] sizeOfObject;

    void Start() {
        sizeOfObject = new Vector3[4];
        sizeOfObject[0] = new Vector3(4f, 4f, 2f);
        sizeOfObject[1] = new Vector3(0.0075f, 0.0075f, 0.0075f);
        sizeOfObject[2] = new Vector3(0.03f, 0.03f, 0.03f);
        sizeOfObject[3] = new Vector3(0.0025f, 0.0025f, 0.0025f);

    }

    public void chooseObject() {

        DestroyChildObject();
        string nameChoose = UIButton.current.name;
        GameObject objectChoose = Instantiate(Resources.Load("Prefabs/" + nameChoose)) as GameObject;
        objectChoose.transform.SetParent(imageTarget.transform);
        objectChoose.transform.localPosition = Vector3.zero;
        objectChoose.transform.localScale = SizeOfObject(nameChoose);

    }

    void DestroyChildObject()
    {
        int childCount = imageTarget.transform.childCount;
        Debug.Log(childCount);
        if (childCount >=1)
        {
            for(int i=0; i < childCount; i++ )
                Destroy(imageTarget.transform.GetChild(i).gameObject);
        }  
    }

    Vector3 SizeOfObject(string nameObject) {
        switch (nameObject) {
            case "Clock":
                return sizeOfObject[0];
            case "Sofa":
                return sizeOfObject[1];              
            case "TVStand":
                return sizeOfObject[2];
            case "Bed":
                return sizeOfObject[3];
        }
        return Vector3.one;
    }
}
