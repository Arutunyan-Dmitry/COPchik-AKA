using Unity;
using Unity.Lifetime;
using UniversityBusinessLogic.BusinessLogic;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.StorageContracts;
using UniversityDatabaseImplement.Implements;

namespace UniversityWinFormsApp
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IStudentStorage, StudentStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IHandBookStorage, HandBookStorage>(new
            HierarchicalLifetimeManager());

            currentContainer.RegisterType<IStudentLogic, StudentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IHandBookLogic, HandBookLogic>(new
            HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}