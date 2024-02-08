using UnityEngine;

namespace TapTD.Towers
{
    public class AttackArea : MonoBehaviour
    {
        [SerializeField]
        private Collider2D rangeTrigger;

        private Tower tower;
        private bool isVisible;

        private void Awake()
        {
            tower = GetComponentInParent<Tower>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy"))
                return;

            tower.EnemyEnterRange(collision.gameObject.GetComponent<Enemy>());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy"))
                return;

            tower.EnemyExitRange(collision.gameObject.GetComponent<Enemy>());
        }

        public void SetVisibility(bool visible)
        {
            if (isVisible != visible)
            {
                ToggleVisibility();
            }
        }

        public void ToggleVisibility()
        {
            isVisible = !isVisible;
            GetComponent<SpriteRenderer>().enabled = isVisible;
            //GetComponent<LineRenderer>().enabled = isVisible;
        }

        public void Deactivate()
        {
            rangeTrigger.enabled = false;
        }

        public void Activate()
        {
            rangeTrigger.enabled = true;
        }

        public void SetRange(float range)
        {
            gameObject.transform.localScale = new Vector3 (2 * range, 2 * range, 1);
        }
    }
}