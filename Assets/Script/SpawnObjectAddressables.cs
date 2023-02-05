using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObjectAddressables : MonoBehaviour
{
    // Allows to get the asset without getting the path address.
    [SerializeField] AssetReference assetReference;

    // Loading of assets from addressables using Async Operation Handle
    private void Update()
    {
        //Press spacebar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Find and load the asset from its reference.
            assetReference.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    // spawn asset if the load is successful
                    Instantiate(asyncOperationHandle.Result);
                }
                else
                {
                    Debug.Log("Failed to load Asset.");
                }
            };
        }
    }
}
