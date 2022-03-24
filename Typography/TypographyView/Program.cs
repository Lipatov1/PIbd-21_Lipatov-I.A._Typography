using TypographyBusinessLogic.OfficePackage.Implements;
using TypographyContracts.BusinessLogicsContracts;
using TypographyBusinessLogic.BusinessLogics;
using TypographyBusinessLogic.OfficePackage;
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
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrintedLogic, PrintedLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}