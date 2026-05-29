using Autofac;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Настройка IoC-контейнера.
    /// Здесь регистрируем: какой класс использовать для каждого интерфейса.
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Говорим контейнеру:
            // "Когда кто-то просит IWarehouseContext — давай WarehouseContext"
            // InstancePerLifetimeScope = новый экземпляр для каждой формы
            builder.RegisterType<WarehouseContext>()
                   .As<IWarehouseContext>()
                   .InstancePerLifetimeScope();

            // Регистрируем все формы
            builder.RegisterType<LoginForm>().InstancePerDependency();
            builder.RegisterType<MainForm>().InstancePerDependency();
            builder.RegisterType<CatalogFormAdmin>().InstancePerDependency();
            builder.RegisterType<CatalogFormKlad>().InstancePerDependency();
            builder.RegisterType<HeatMapForm>().InstancePerDependency();
            builder.RegisterType<ItemForm>().InstancePerDependency();
            builder.RegisterType<DeliveryForm>().InstancePerDependency();

            return builder.Build();
        }
    }
}