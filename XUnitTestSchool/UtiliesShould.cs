using School_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestSchool
{
    public class UtiliesShould
    {
        [Fact]
        public void ValidateOrderEntityByName()
        {
            //Arrange
            //Utilies utilities = new Utilies();
            var listEntity = new List<Student>();

            //Act
            listEntity.Add(new Student
            {
                Id = 1,
                Name = "Zeo",
                LastName = "Lugo",
                Email = "zoelugo@gmail.com",
                Phone = "8715195272"
            });
            listEntity.Add(new Student
            {
                Id = 2,
                Name = "Alex",
                LastName = "Lopez",
                Email = "alelopez@gmail.com",
                Phone = "8715195272"
            });
            var result = Utilies.OrderEntityByName(listEntity).ToList();

            //Assert
            Assert.Equal("Alex", result.First().Name);
        }
    }
}
