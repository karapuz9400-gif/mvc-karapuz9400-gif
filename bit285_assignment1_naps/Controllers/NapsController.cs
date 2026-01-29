using Microsoft.AspNetCore.Mvc;
using bit285_assignment1_naps.Models;

namespace bit285_assignment1_naps.Controllers
{
    public class NapsController : Controller
    {
        private readonly bit285_assignment1_naps.Models.PasswordSuggestion _passwordSuggestion;

        public NapsController(bit285_assignment1_naps.Models.PasswordSuggestion passwordSuggestion)
        {
            _passwordSuggestion = passwordSuggestion;
        }
        [HttpGet]
        public IActionResult AccountInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AccountInfo(User user)
        {
            // Post the user data to the next step (PasswordInfo)
            return View("PasswordInfo", user);
        }

        [HttpGet]
        public IActionResult PasswordInfo(User user)
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult PasswordInfoPost(User user)
        {
            if (user == null)
            {
                user = new User();
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = _passwordSuggestion.GeneratePassword(user);
                ModelState.Remove(nameof(user.Password));
            }

            return View("SelectPassword", user);
        }

        [HttpGet]
        public IActionResult SelectPassword(User user)
        {
            if (user == null)
            {
                user = new User();
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = _passwordSuggestion.GeneratePassword(user);
                ModelState.Remove(nameof(user.Password));
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult SelectPasswordPost(User user)
        {
            if (user == null)
            {
                user = new User();
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = _passwordSuggestion.GeneratePassword(user);
                ModelState.Remove(nameof(user.Password));
            }

            return View("ConfirmAccount", user);
        }

        [HttpGet]
        public IActionResult ConfirmAccount(User user)
        {
            return View(user);
        }

        [HttpGet]
        public IActionResult Login(User user)
        {
            if (user == null) user = new User();

            // ensure password field is blank for user to type
            user.Password = string.Empty;
            ModelState.Remove(nameof(user.Password));

            return View(user);
        }

        [HttpPost]
        public IActionResult LoginPost(Microsoft.AspNetCore.Http.IFormCollection form)
        {
            // This demo does not implement authentication; simply show Login view again
            var model = new User { EmailAddress = form["EmailAddress"].ToString() };
            return View("Login", model);
        }
    }
}
