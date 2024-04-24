using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    /// <summary>
    /// Controller for handling user-related actions.
    /// </summary>
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        /// <summary>
        /// Displays a list of all users.
        /// </summary>
        public ActionResult Index()
        {
            return View(userlist);
        }

        /// <summary>
        /// Displays details for a specific user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Displays the user creation form.
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// Displays the user edit form.
        /// </summary>
        /// <param name="id">The ID of the user to edit.</param>
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="user">The updated user information.</param>
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return HttpNotFound();
                }
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Update other properties as needed
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// Displays the user deletion confirmation form.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <param name="collection">The form collection.</param>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
