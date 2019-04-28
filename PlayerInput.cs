using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using Proyecto26;



public class PlayerInput : MonoBehaviour {

    private GameObject held;
    private GameObject LeftHand;
    private GameObject RightHand;
    private Items items;
    private float timerA;
    private float timerB;
    private float timerDrop;
    private int index;
    public List<string> itemList;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Use this for initialization
    void Start()
    {
        GameObject myHand;
        LeftHand = GameObject.FindGameObjectWithTag("LeftGrabber");

        RightHand = GameObject.FindGameObjectWithTag("RightGrabber");

        RetrieveFromDatabase();
        items = new Items();
        index = 0;

        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scene");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    private void RetrieveFromDatabase()
    {
        itemList.Clear();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vrshopping-80222.firebaseio.com/");

        
        FirebaseDatabase.DefaultInstance
      .GetReference("Cart")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              for (int i = 0; i < snapshot.ChildrenCount; i++)
              {
                  string child = i.ToString();
                  string foundValue = snapshot.Child(child).Value.ToString();
                  itemList.Add(foundValue);
                  // Do something with snapshot...
              }
          }
      });

    }
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time - timer);
        AInput();

        BInput();
        GripInput();
        KeyFobTrigger();
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            RetrieveFromDatabase();
        }
    }

    private void AInput()
    {

        if (Time.time - timerA >= 1f && (OVRInput.Get(OVRInput.Button.One) || Input.GetKey("a")))
        {
            if (index > itemList.Count)
            {
                return;
            }
            //Debug.Log("te000");
            timerA = Time.time;
            int key;
            if (!int.TryParse(itemList[index], out key))
            {
                key = -1;
            }

            if (key != -1)
            {
                if (key <= items.ItemCount())
                {
                    //Debug.Log("Key" + key);
                    string item = items.GetItem(key);
                    GameObject gameObject = Resources.Load(item) as GameObject;
                    if (gameObject)
                    {
                        //Debug.Log(items.GetItem(key));
                        GameObject newObject = Instantiate(gameObject) as GameObject;
                        
                        newObject.transform.position = RightHand.transform.position;
                    }
                }
                else
                {
                    Debug.Log("Index " + key + " out of range");
                }

            }
           
        }
        
    }

    private void BInput()
    {
        if (Time.time - timerB >= 1f && OVRInput.Get(OVRInput.Button.Two))
        {
            timerB = Time.time;
            index++;
            if (index >= itemList.Count)
            {
                index = 0;
            }
        }
    }

    private void GripInput()
    {

        if ( OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("2ndhandButton");
            Collider[] colliders = Physics.OverlapSphere(RightHand.transform.position, 0.1f);

            foreach (var item in colliders)
            {
                if (item.gameObject.layer == 8)
                {
                    Debug.Log("item not held");
                    held = item.transform.parent.gameObject;
                    Rigidbody rigidbody = held.GetComponent<Rigidbody>();
                    if (rigidbody.useGravity) { rigidbody.useGravity = false; }
                    if (!rigidbody.isKinematic) { rigidbody.isKinematic = true; }
                    rigidbody.rotation = LeftHand.transform.rotation;
                    rigidbody.position = LeftHand.transform.position;
                    //held.transform.parent.transform.position = Vector3.Lerp(held.transform.parent.transform.position, RightHand.transform.position, 0.01f);
                   // held.transform.parent.transform.rotation = RightHand.transform.rotation;
                }
            }


        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("primaryhandButton");
            Collider[] colliders = Physics.OverlapSphere(RightHand.transform.position, 0.1f);

            foreach (var item in colliders)
            {
                if (item.gameObject.layer == 8)
                {
                    Debug.Log("item not held");
                    held = item.transform.parent.gameObject;
                    Rigidbody rigidbody = held.GetComponent<Rigidbody>();
                    if (rigidbody.useGravity) { rigidbody.useGravity = false; }
                    if (!rigidbody.isKinematic) { rigidbody.isKinematic = true; }
                    rigidbody.rotation = LeftHand.transform.rotation;
                    rigidbody.position = LeftHand.transform.position;
                    //held.transform.parent.transform.position = Vector3.Lerp(held.transform.parent.transform.position, RightHand.transform.position, 0.01f);
                    // held.transform.parent.transform.rotation = RightHand.transform.rotation;
                }
            }


        }
        else if (held)
        {
            //Debug.Log("item was held");
            Rigidbody rigidbody = held.GetComponent<Rigidbody>();
            if (!rigidbody.useGravity) { rigidbody.useGravity = true; }
            if (rigidbody.isKinematic) { rigidbody.isKinematic = false; }
            held = null;
        }
    }

    private void KeyFobTrigger()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("PrimaryIndexTrigger");
            if (held && held.name == "carKey" && scenePaths.Length > 0)
            {
                Debug.Log("Scene Change");
                Application.LoadLevel("SampleScene");
                //SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
            }
        }
    }
}
