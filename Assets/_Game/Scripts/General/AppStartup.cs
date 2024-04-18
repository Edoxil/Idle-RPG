using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleRPG
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private int _firstSceneIndex = 1;
        [SerializeField] private float _logoDemonstrationDuration = 3f;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_logoDemonstrationDuration);
            SceneManager.LoadScene(_firstSceneIndex);
        }
    }
}
