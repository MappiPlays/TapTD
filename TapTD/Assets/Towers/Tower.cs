using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TapTD.Towers
{
    public class Tower : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        public TowerConfig Config;
        [SerializeField]
        private AttackArea attackArea;

        public bool CanBePlaced { get; private set; }

        private Enums.TowerStates state;
        private GameObject bulletPrefab;
        private float damage;
        private float attackDelay;

        private List<Enemy> enemiesInRange = new List<Enemy>();
        private Coroutine aimAndAttackCoroutine;

        private void Start()
        {
            SetState(Enums.TowerStates.Moving);

            if (Config == null)
            {
                Debug.LogError("This Tower has no TowerConfig");
                return;
            }

            GetComponent<SpriteRenderer>().sprite = Config.sprite;
            bulletPrefab = Config.bulletPrefab;
            damage = Config.damage;
            attackDelay = Config.attackDelay;
            attackArea.SetRange(Config.range);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void EnemyEnterRange(Enemy enemy)
        {
            enemiesInRange.Add(enemy);

            aimAndAttackCoroutine ??= StartCoroutine(AimAndAttackCo());
        }

        public void EnemyExitRange(Enemy enemy)
        {
            if (enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (state)
            {
                case Enums.TowerStates.Placed:
                    float clickToCenterDistance = Vector2.Distance(Camera.main.ScreenToWorldPoint(eventData.position), transform.position);
                    if (clickToCenterDistance < .5f)
                        attackArea.ToggleVisibility();
                    break;
                case Enums.TowerStates.Moving:
                    break;
                default:
                    break;
            }
        }

        private IEnumerator AimAndAttackCo()
        {
            Enemy targetEnemy;
            Vector2 towardsEnemy;
            float timer = attackDelay;
            while (enemiesInRange.Count > 0)
            {
                targetEnemy = enemiesInRange[0];
                towardsEnemy = targetEnemy.transform.position - transform.position;
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(towardsEnemy.y, towardsEnemy.x) * Mathf.Rad2Deg - 90);

                if (timer >= attackDelay)
                {
                    Attack(targetEnemy, transform.rotation);
                    timer -= attackDelay;
                }
                timer += Time.deltaTime;
                yield return null;
            }
            aimAndAttackCoroutine = null;
        }

        private void Attack(Enemy target, Quaternion bulletRotation)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, bulletRotation).GetComponent<Bullet>();
            bullet.Setup(damage, target);
        }

        public void SetState(Enums.TowerStates newState)
        {
            state = newState;
            switch (newState)
            {
                case Enums.TowerStates.Moving:
                    EnteredStateMoving();
                    break;
                case Enums.TowerStates.Placed:
                    EnteredStatePlaced();
                    break;
                default:
                    break;
            }
        }

        private void EnteredStateMoving()
        {
            StartCoroutine(MovingCo());
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            attackArea.SetVisibility(true);
            attackArea.Deactivate();
            if (aimAndAttackCoroutine != null)
            {
                StopCoroutine(aimAndAttackCoroutine);
                aimAndAttackCoroutine = null;
            }
        }

        private void EnteredStatePlaced()
        {
            gameObject.layer = LayerMask.NameToLayer("OccupiedArea");
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            attackArea.SetVisibility(false);
            attackArea.Activate();
        }

        private IEnumerator MovingCo()
        {
            Collider2D collider = GetComponent<Collider2D>();
            List<Collider2D> collisions = new();
            ContactFilter2D contactFilter = new();
            contactFilter.SetLayerMask(LayerMask.GetMask("OccupiedArea"));
            while (state == Enums.TowerStates.Moving)
            {
                if (Input.touchCount > 0)
                {
                    List<RaycastResult> results = new();
                    if (!GameManager.Instance.UIManager.IsScreenPositionOnUI(Input.touches[0].position))
                    {
                        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                        transform.position = touchPosition;
                    }
                }

                SetCanBePlaced(collider.OverlapCollider(contactFilter, collisions) <= 0);

                yield return null;
            }
        }

        private void SetCanBePlaced(bool placable)
        {
            CanBePlaced = placable;

            SpriteRenderer attackAreaSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

            if (CanBePlaced)
            {
                attackAreaSpriteRenderer.color = Color.green;
            }
            else
            {
                attackAreaSpriteRenderer.color = Color.red;
            }
        }
    }
}