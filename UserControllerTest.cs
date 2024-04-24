using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using CRUD_application_2.Models;

namespace CRUD_application_2.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController _controller;
        private List<User> _users;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "User 1", Email = "user1@example.com" },
                new User { Id = 2, Name = "User 2", Email = "user2@example.com" }
            };

            UserController.userlist = _users;
            _controller = new UserController();
        }

        [Test]
        public void Create_Post_AddsUser_AndRedirects()
        {
            var newUser = new User { Id = 3, Name = "User 3", Email = "user3@example.com" };
            var result = _controller.Create(newUser) as RedirectToRouteResult;

            Assert.That(UserController.userlist.Contains(newUser));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void Edit_UpdatesUser_AndRedirects()
        {
            var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };
            var result = _controller.Edit(updatedUser.Id, updatedUser) as RedirectToRouteResult;

            var updatedUserInList = UserController.userlist.First(u => u.Id == updatedUser.Id);

            Assert.That(updatedUserInList.Name, Is.EqualTo(updatedUser.Name));
            Assert.That(updatedUserInList.Email, Is.EqualTo(updatedUser.Email));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_RemovesUser_AndRedirects()
        {
            var result = _controller.Delete(1, new FormCollection()) as RedirectToRouteResult;

            Assert.That(!UserController.userlist.Any(u => u.Id == 1));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }
    }
}