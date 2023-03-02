using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
    private int _health = 3;

    public void Init(Root init)
    {
        _init = init;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("RedTeam") || collision.gameObject.CompareTag("BlueTeam") || collision.gameObject.CompareTag("Enemy")) && _health != 0)
        {
            Destroy(collision.gameObject);
            _health--;
            if (_health == 0)
            {
                _init.DisableShip();
                print("Уничтожен");
            }
            else
            {
                print("Осталось жизней: " + _health);
            }
        }
    }
}
