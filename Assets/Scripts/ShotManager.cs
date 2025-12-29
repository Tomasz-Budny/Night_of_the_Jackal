using Assets.Scripts.Architecture;
using Assets.Scripts.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class ShotManager : SingletonInstance<ShotManager>
    {
        public GraphicRaycaster shotAreaRaycaster;
        public AudioSource sniperRifleAudioSource;

        public int shotsCount = 0;

        private bool shotFirstTime = false;

        public event Action OnShotFirstTime;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                ShotTarget();

                PointerEventData data = new PointerEventData(EventSystem.current);
                data.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                if (shotAreaRaycaster != null) shotAreaRaycaster.Raycast(data, results);

                if(results.Count > 0 && !shotFirstTime)
                {
                    shotFirstTime = true;
                    OnShotFirstTime?.Invoke();
                    MusicManager.Instance.StopMusic();
                    MusicManager.Instance.PlayPanicMusic();
                }

                if(results.Count > 0)
                {
                    shotsCount++;
                    PlaySniperRifleSound();
                }
            }
        }

        private void ShotTarget()
        {
            if (Camera.main == null)
            {
                Debug.LogError("Brak kamery z tagiem MainCamera!");
                return;
            }

            // Zamiana pozycji myszy na punkt w świecie 2D
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            // Raycast 2D z tego punktu
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Trafiony obiekt 2D: " + hit.collider.name);

                var target = hit.collider.GetComponent<TargetHitHandler>();
                if (target != null)
                {
                    target.OnGetHit();
                }
                else
                {
                    Debug.Log("Brak TargetHitHandler na obiekcie: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Nic nie trafione w 2D raycastem.");
            }
        }

        private void PlaySniperRifleSound()
        {
            sniperRifleAudioSource.Play();
        }
    }
}
