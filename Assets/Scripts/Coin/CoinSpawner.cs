using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _poolCapacity = 1;
    [SerializeField] private int _poolMaxSize = 1;

    private Camera _mainCamera;
    private ObjectPool<Coin> _pool;
 
    private Vector2 _pointRightUp;
    private Vector2 _pointLeftDown;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _pointLeftDown = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _pointRightUp = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        _pool = new ObjectPool<Coin>(
            createFunc: () => CreateFunc(),
            actionOnGet: (coin) => ActionOnGet(coin),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => ActionOnDestroy(coin),
            collectionCheck: false,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void FixedUpdate()
    {
        if (_pool.CountActive <= _poolCapacity)
        {
            _pool.Get();
        }
    }

    private Coin CreateFunc()
    {
        Coin coin = Instantiate(_coinPrefab);

        coin.HaveTaken += ActionOnRelease;

        return coin;
    }

    private void ActionOnGet(Coin coin)
    {
        coin.transform.position = SelectionSpawnPoint();
        coin.gameObject.SetActive(true);
    }

    private Vector2 SelectionSpawnPoint()
    {
        float pointX = Random.Range(_pointLeftDown.x, _pointRightUp.x);
        float pointY = Random.Range(_pointLeftDown.y, _pointRightUp.y);

       return new Vector2(pointX, pointY);
    }

    private void ActionOnRelease(Coin coin)
    {
        _pool.Release(coin);
    }

    private void ActionOnDestroy(Coin coin)
    {
        coin.HaveTaken -= ActionOnRelease;
        
        Destroy(coin);
    }
}
