using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class firebaseInsert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public static void fbAdd(string variable_name, string variable_value)
    {
        Debug.Log("Firebase:" + variable_name + ":" + variable_value);
    }
}