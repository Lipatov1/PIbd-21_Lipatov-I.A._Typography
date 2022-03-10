using TypographyContracts.BusinessLogicsContracts;
using TypographyBusinessLogic.BusinessLogics;
using TypographyContracts.StoragesContracts;
using TypographyDatabaseImplement.Implements;
using TypographyFileImplement;
using System.Windows.Forms;
using Unity.Lifetime;
using System;
using Unity;

namespace TypographyView {
    static class Program {
        private static IUnityContainer container = null;

        public static IUnityContainer Container {
            get {
                if (container == null) {
                    container = BuildUnityContainer();
                }

                return container;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
            FileDataListSingleton.GetInstance().Save();
        }

        private static IUnityContainer BuildUnityContainer() {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrintedStorage, PrintedStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseStorage, WarehouseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrintedLogic, PrintedLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseLogic, WarehouseLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}