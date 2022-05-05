using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using OnlineStore.Data;
using OnlineStore.Models.ViewModel;

namespace OnlineStore.Controllers
{
    public class AdminController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("admin/products")]
        public IActionResult AdminProducts()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = unit
                    .UserRepository
                    .Get(x => x.Email == User.Identity.Name, includeProperties: "Role")
                    .FirstOrDefault();
                if (user.Role.Name != "Administrator")
                    return RedirectToAction("Index", "Home");

                var products = unit.ProductRepository.Get(includeProperties: "CreatorUser").ToList();

                AdminProducts model = new AdminProducts()
                {
                    Products = products
                };
                return View("Products", model);

            }
            return RedirectToAction("Index", "Home");
        }
        [Route("admin/users")]
        public IActionResult AdminUsers()
        {
            var users = unit.UserRepository.Get(includeProperties: "Role").ToList();

            var index = users.FirstOrDefault(x => x.Email == User.Identity.Name);
            users.Remove(index);

            var admins = users.Where(x => x.Role.Name == "Administrator").ToList();
            var moderators = users.Where(x => x.Role.Name == "Moderator").ToList();
            var simple = users.Where(x => x.Role.Name == "SimpleUser").ToList();

            AdminUsers model = new AdminUsers()
            {
                Users = simple,
                Admins = admins,
                Moderators = moderators
            };
            return View("Users", model);
        }
        [Authorize]
        public IActionResult UserPurchases(int id)
        {
            //var users = unit.UserRepository.Get(includeProperties: "Role").ToList();
            //var index = users.FirstOrDefault(x => x.Email == User.Identity.Name);
            
            var purchases = unit
                .PurchaseRepository
                .Get(x => x.UserId == id, includeProperties: "PurchaseProducts.Product")
                .OrderByDescending(x => x.CreationTime);
            var model = new UserPurchasesViewModel
            {
                Purchases = purchases
            };
            return View(model);
        }
    }
}