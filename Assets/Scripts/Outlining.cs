using UnityEngine;

namespace cakeslice{
    public class Outlining : MonoBehaviour
    {
        public Outline oL;

        private void Start()
        {
            oL = GetComponent<Outline>();
        }

        private void OnMouseEnter()
        {
            oL.eraseRenderer = false;
        }

        private void OnMouseExit()
        {
            oL.eraseRenderer = true;
        }
    }
}