using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DungeonTyper.Logic;
using System.Web;
using Moq;
using DungeonTyper.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using DungeonTyper.DAL;

namespace DungeonTyper.Logic.UnitTests
{
    [TestClass]
    public class CharacterCreationTests
    {
        //[TestMethod]
        //public void CharacterCreationTest()
        //{
        //    var mockRepo = new Mock<ICharacterDataAccess>();
        //    mockRepo.Setup(x => x.)
        //    ICharacterDataAccess characterDataAccess = new CharacterDataAccess();
        //    IProgressLoader = new ProgressLoader();
        //    progressLoader.Load();

        //    Assert.IsTrue(gameStateHandler.GetState() == GameState.CharCreation);
        //}
        //var mockRepo = new Mock<ICharacter>();
        //mockRepo.Setup(x => x.Alive(company)).Returns(true);

        //var companyObject = new Company(mockRepo.Object);
        //var retrnData = companyObject.InsertCompany(company);
    }
}
