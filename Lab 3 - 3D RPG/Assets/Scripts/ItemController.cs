using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class ItemController : MonoBehaviour, Interactable
    {
        [SerializeField] private float _radius;
        public float InteractRadius => _radius;

        [SerializeField] private Canvas canvas;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text alert;

        public void Interact()
        {
            Time.timeScale = 0;

            alert.text = "New gun";

            button.onClick.AddListener(OnClickInteract);

            canvas.gameObject.SetActive(true);
        }

        private void OnClickInteract()
        {
            Time.timeScale = 1;
            canvas.gameObject.SetActive(false);

            button.onClick.RemoveListener(OnClickInteract);

            Destroy(gameObject);
        }
    }
}
