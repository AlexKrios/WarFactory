using RoboFactory.General.Audio;
using RoboFactory.General.Expedition;
using RoboFactory.General.Item.Production;
using RoboFactory.General.Item.Products;
using RoboFactory.General.Item.Raw;
using RoboFactory.General.Level;
using RoboFactory.General.Localisation;
using RoboFactory.General.Location;
using RoboFactory.General.Order;
using RoboFactory.General.Unit;
using UnityEngine;
using Zenject;

namespace RoboFactory.DI
{
    [CreateAssetMenu(fileName = "Game", menuName = "Scriptable/General/Settings", order = -1)]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public LocalisationManager.Settings localization;
        public AudioManager.Settings audioData;
        public LevelManager.Settings level;
        public RawManager.Settings raw;
        public ProductsManager.Settings products;
        public LocationManager.Settings locations;
        public UnitsManager.Settings units;
        public ExpeditionManager.Settings expeditions;
        public ProductionManager.Settings productions;
        public OrderManager.Settings order;

        public override void InstallBindings()
        {
            Container.BindInstance(localization);
            Container.BindInstance(audioData);
            Container.BindInstance(level);
            Container.BindInstance(raw);
            Container.BindInstance(products);
            Container.BindInstance(locations);
            Container.BindInstance(units);
            Container.BindInstance(expeditions);
            Container.BindInstance(productions);
            Container.BindInstance(order);
        }
    }
}