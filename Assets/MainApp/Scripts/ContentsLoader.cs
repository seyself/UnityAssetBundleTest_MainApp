using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ContentsLoader : MonoBehaviour
{
    string url = "http://192.168.11.15:8000/SubContents/OSX/subcontents";

    void Start()
    {
        StartCoroutine(GetContents());
    }

    IEnumerator GetContents()
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                GameObject contents = bundle.LoadAsset<GameObject>("SubContents");
                Instantiate(contents, transform);
            }
            else
            {
                Debug.Log(uwr.error);
            }
        }
    }
}
