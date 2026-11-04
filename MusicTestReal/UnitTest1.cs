using RESTMusic.Models;
namespace MusicTestReal
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAllecords()
        {
            // Arrange
            var repository = new RecordsRepositoryList();
            // Act
            var records = repository.GetAll();
            // Assert
            Assert.Equal(3, records.Count);

        }

        [Fact]
        public void TestGetRecordById()
        {
            // Arrange
            var repository = new RecordsRepositoryList();
            // Act
            var record = repository.GetRecordById(1);
            // Assert
            Assert.NotNull(record);
            Assert.Equal("Record 1", record.Title);
        }

        [Fact]
        public void TestAddRecord()
        {
            // Arrange
            var repository = new RecordsRepositoryList();
            var newRecord = new RESTMusic.Models.Record { Id = 4, Title = "Record 4", Artist = "Artist 4" };
            // Act
            repository.AddRecord(newRecord);
            var records = repository.GetAll();
            // Assert
            Assert.Equal(4, records.Count);
            Assert.Contains(records, r => r.Id == 4 && r.Title == "Record 4");
        }

        [Fact]
        public void TestUpdateRecord()
        {
            // Arrange
            var repository = new RecordsRepositoryList();
            var updatedRecord = new RESTMusic.Models.Record { Id = 1, Title = "Updated Record 1", Artist = "Updated Artist 1" };
            // Act
            repository.UpdateById(1, updatedRecord);
            var record = repository.GetRecordById(1);
            // Assert
            Assert.NotNull(record);
            Assert.Equal("Updated Record 1", record.Title);
            Assert.Equal("Updated Artist 1", record.Artist);
        }

        [Fact]
        public void TestDeleteRecord()
        {
            // Arrange
            var repository = new RecordsRepositoryList();
            // Act
            repository.DeleteById(1);
            var records = repository.GetAll();
            // Assert
            Assert.Equal(2, records.Count);
            Assert.DoesNotContain(records, r => r.Id == 1);
        }
    }
}

