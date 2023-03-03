using UnityEngine;
using Asteroids.Model;
using System;

public class PresentersFactory : MonoBehaviour
{
    public GameObject _nloTemplateRed;

    public GameObject _nloTemplateBlue;

    public GameObject[] spawnPosition;

    private int randPosition;

    [SerializeField] private Camera _camera;
    [SerializeField] private Presenter _laserGunBulletTemplate;
    [SerializeField] private Presenter _defaultGunBulletTemplate;
    [SerializeField] private Presenter _asteroidTemplate;
    [SerializeField] private Presenter _asteroidPartTemplate;

    private int teamSelection = 0;

    public void CreateBullet(Bullet bullet)
    {
        if(bullet is LaserGunBullet)
            CreatePresenter(_laserGunBulletTemplate, bullet);
        else
            CreatePresenter(_defaultGunBulletTemplate, bullet);
    }

    public void CreateAsteroidParts(AsteroidPresenter asteroid)
    {
        for (int i = 0; i < 4; i++)
            CreatePresenter(_asteroidPartTemplate, asteroid.Model.CreatePart());
    }

    public void CreateNlo(Nlo nlo)
    {
        teamSelection++;
        randPosition = UnityEngine.Random.Range(0, spawnPosition.Length);
        if (teamSelection % 2 == 0)
        {
            Instantiate(_nloTemplateRed, spawnPosition[randPosition].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_nloTemplateBlue, spawnPosition[randPosition].transform.position, Quaternion.identity);
        }
    }

    public void CreateAsteroid(Asteroid asteroid)
    {
        AsteroidPresenter presenter = CreatePresenter(_asteroidTemplate, asteroid) as AsteroidPresenter;
        presenter.Init(this);
    }

    private Presenter CreatePresenter(Presenter template, Transformable model)
    {
        Presenter presenter = Instantiate(template);
        presenter.Init(model, _camera);

        return presenter;
    }
}
