using System.Collections;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine.UI;

public class FirebaseController : MonoBehaviour
{
    private DatabaseReference reference;
    private static FirebaseStorage storage;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        storage = FirebaseStorage.DefaultInstance;

        // 1. Obtain Storage reference from firebase url: gs://coolcardgame.appspot.com/Cards/CardBack.png
        StorageReference cardBackReference = storage.GetReferenceFromUrl("gs://coolcardgame.appspot.com/Cards/CardBack.png");

        // 2. Download Resource
        DownloadResource(cardBackReference);
    }

    public static void DownloadResource(StorageReference reference)
    {
        reference.GetBytesAsync(5 * 1024 * 1024).ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted || !task.IsCanceled)
            {
                Debug.Log("Finished downloading!");

                byte[] fileContents = task.Result;

                // 3. Convert byte array to Unity Image
                Texture2D texture = new Texture2D(2917, 3751); //TO FIX
                texture.LoadImage(fileContents);
                Sprite pepsi = Sprite.Create(texture, new Rect(0, 0, texture.width,
                    texture.height), new Vector2(texture.width / 2, texture.height / 2));
                GameObject.Find("CardBack").GetComponent<Image>().sprite = pepsi;
                
            }
            else
            {
                Debug.LogException(task.Exception);
            }
        });
    }


    public static IEnumerator SaveData()
    {
        yield return null;
    }


    public static IEnumerator GetData()
    {
        yield return null;
    }

}





//public static void GetResourceUrl(StorageReference reference)
//{
//    reference.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
//    {
//        if (!task.IsFaulted || !task.IsCanceled)
//        {
//            Debug.Log("Download url: " + task.Result);

//            DownloadResource(reference);

//        }
//        else
//        {
//            Debug.LogException(task.Exception);
//        }
//    });

//}