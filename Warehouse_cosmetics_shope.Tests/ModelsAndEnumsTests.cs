using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;

namespace Warehouse_cosmetics_shope.Tests
{
    public class ModelsAndEnumsTests
    {
        // Проверка целостности данных и значений перечислений
        [Fact]
        public void Roles_AdminHasValue1()
        {
            Assert.Equal(1, (int)Roles.Admin);
        }

        [Fact]
        public void Roles_StorekeeperHasValue2()
        {
            Assert.Equal(2, (int)Roles.Storekeeper);
        }

        [Fact]
        public void MeasurementUnits_PieceHasValue1()
        {
            Assert.Equal(1, (int)MeasurementUnits.Piece);
        }

        [Fact]
        public void MeasurementUnits_MilliliterHasValue2()
        {
            Assert.Equal(2, (int)MeasurementUnits.Milliliter);
        }

        [Fact]
        public void MeasurementUnits_GramHasValue3()
        {
            Assert.Equal(3, (int)MeasurementUnits.Gram);
        }

        [Fact]
        public void ClientTypes_LegalEntityHasValue1()
        {
            Assert.Equal(1, (int)ClientTypes.LegalEntity);
        }

        [Fact]
        public void ClientTypes_IndividualEntrepreneurHasValue2()
        {
            Assert.Equal(2, (int)ClientTypes.IndividualEntrepreneur);
        }

        [Fact]
        public void ClientTypes_IndividualHasValue3()
        {
            Assert.Equal(3, (int)ClientTypes.Individual);
        }

        // Тесты моделей
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
                SellPrice = 5000m,
                Quantity = 10,
                ExpDate = DateTime.Now.AddDays(30),
                Units = MeasurementUnits.Piece
            };
            Assert.Equal("Тест парфюма", item.ProductName);
            Assert.Equal(5000m, item.SellPrice);
            Assert.Equal(10, item.Quantity);
            Assert.Equal(MeasurementUnits.Piece, item.Units);
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
                Patronymic = "Иванович",
                Password = "hashed_password_here",
                Role = Roles.Storekeeper
            };
            Assert.Equal("hashed_password_here", user.Password);
        }

        [Fact]
        public void ShipmentComposition_QuantityShouldBePositive()
        {
            var comp = new ShipmentComposition
            {
                Quantity = 5,
                ShipmentID = Guid.NewGuid(),
                ProductID = Guid.NewGuid()
            };
            Assert.True(comp.Quantity > 0);
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
    }
}