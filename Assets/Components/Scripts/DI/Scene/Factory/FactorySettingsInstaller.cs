using RoboFactory.Factory.Menu;
using RoboFactory.Factory.Menu.Conversion;
using RoboFactory.Factory.Menu.Expedition;
using RoboFactory.Factory.Menu.Order;
using RoboFactory.Factory.Menu.Production;
using RoboFactory.Factory.Menu.Settings;
using RoboFactory.Factory.Menu.Storage;
using UnityEngine;
using Zenject;

namespace RoboFactory.DI
{
    [CreateAssetMenu(menuName = "Scriptable/Factory/Settings", order = 1)]
    public class FactorySettingsInstaller : ScriptableObjectInstaller<FactorySettingsInstaller>
    {
        public SettingsMenuFactory.Settings settingsMenu;
        public ProductionMenuFactory.Settings productionMenu;
        public StorageMenuFactory.Settings storageMenu;
        public ConversionMenuFactory.Settings conversionMenu;
        public OrderMenuFactory.Settings orderMenu;
        public UnitsMenuFactory.Settings unitsMenu;
        public ExpeditionMenuFactory.Settings expeditionMenu;

        public override void InstallBindings()
        {
            Container.BindInstance(settingsMenu);
            Container.BindInstance(productionMenu);
            Container.BindInstance(storageMenu);
            Container.BindInstance(conversionMenu);
            Container.BindInstance(orderMenu);
            Container.BindInstance(unitsMenu);
            Container.BindInstance(expeditionMenu);
        }
    }
}