using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope.Tests
{
    public class ModelsAndEnumsTests
    {
        //Проверка целостности данных и значений перечислений
        [Fact]
        public void Roles_AdminHasValue1()
        {
            Assert.Equal(1, (int)Roles.Админ);
        }
        [Fact]
        public void Roles_WarehousemanHasValue2()
        {
            Assert.Equal(2, (int)Roles.Кладовщик);
        }
        [Fact]
        public void MeasurementUnits_PieceHasValue1()
        {
            Assert.Equal(1, (int)MeasurementUnits.Шт);
        }
        [Fact]
        public void ClientTypes_YurLico_HasValue1()
        {
            Assert.Equal(1, (int)ClientTypes.Юр_лицо);
        }
        //тесты моделей
        [Fact]
        public void Item_CreateNew_ShouldHaveEmptyGuid()
        {
            var item = new Item();
            Assert.Equal(Guid.Empty, item.ProductID);
        }
        [Fact]
        public void Item_SetProperties_ShouldStoreValues()
        {
            var item = new Item
            {
                ProductName = "Тест парфюма",
                Price = 5000m,
                Quantity = 10,
                ExpDate = DateTime.Now.AddDays(30),
                Units = MeasurementUnits.Шт
            };
            Assert.Equal("Тест парфюма", item.ProductName);
            Assert.Equal(5000m, item.Price);
            Assert.Equal(10, item.Quantity);
            Assert.Equal(MeasurementUnits.Шт, item.Units);
        }
        [Fact]
        public void Category_CreateNew_ShouldHaveEmptySubCategories()
        {
            var category = new Category();
            Assert.NotNull(category.SubCategories);
            Assert.Empty(category.SubCategories);
        }
        [Fact]
        public void User_PasswordShouldBeStoredAsString()
        {
            var user = new User
            {
                Surname = "Иванов",
                Name = "Иван",
                Password = "hashed_password_here"
            };
            Assert.Equal("hashed_password_here", user.Password);
        }
        [Fact]
        public void ShipmentComposition_QuantityShouldBePositive()
        {
            var comp = new ShipmentComposition
            {
                Quantity = 5
            };
            Assert.True(comp.Quantity > 0);
        }
        [Fact]
        public void MeasurementUnits_MlHasValue2()
        {
            Assert.Equal(2, (int)MeasurementUnits.Мл);
        }
        [Fact]
        public void MeasurementUnits_GrHasValue3()
        {
            Assert.Equal(3, (int)MeasurementUnits.Гр);
        }
        [Fact]
        public void ClientTypes_IPHasValue2()
        {
            Assert.Equal(2, (int)ClientTypes.ИП);
        }
        [Fact]
        public void ClientTypes_FizLicoHasValue3()
        {
            Assert.Equal(3, (int)ClientTypes.Физ_лицо);
        }
        [Fact]
        public void Client_CreateNew_HasEmptyShipments()
        {
            var client = new Client();
            Assert.NotNull(client.Shipments);
            Assert.Empty(client.Shipments);
        }
        [Fact]
        public void Shipment_CreateNew_HasEmptyCompositions()
        {
            var shipment = new Shipment();
            Assert.NotNull(shipment.ShipmentCompositions);
            Assert.Empty(shipment.ShipmentCompositions);
        }
        [Fact]
        public void HistoryChange_CreateNew_HasValidProperties()
        {
            var history = new HistoryChange
            {
                HistoryID = Guid.NewGuid(),
                ProductID = Guid.NewGuid(),
                UserID = Guid.NewGuid(),
                ActionType = "Create",
                Details = "Тест",
                ActionDate = DateTime.Now
            };
            Assert.NotEqual(Guid.Empty, history.HistoryID);
            Assert.Equal("Create", history.ActionType);
        }
    }
}