using System.Linq;
using SunnyBuy.Entitities.DB;
using System.Collections.Generic;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Services.UsersServices
{
    public class UserService
    {
        UserDB users = new UserDB();
        CartDB cart = new CartDB();

        public List<ListModel> GetUsers(string cpf)
        {
            return users.UsersList()
                .Where(a => a.Cpf == cpf)
                .Select(c => new ListModel
                {
                    UserId = c.UserId,
                    Cpf = c.Cpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone
                })
                .ToList();
        }

        public bool Login(string email)
        {
            if (users.UsersList()
                 .Any(e => e.Email == email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PostUser(ListModel model)
        {
            return users.PostUserEntity(model);
        }

        public List<ListModel> ShowUsersCart()
        {
            var carts = cart.CartsListDB()
                                .Where(a => !a.Deleted)
                                .Select(b => new
                                {
                                    b.CartId,
                                    b.UserId
                                })
                                .ToList();

            var users_cart = users.UsersList()
                .Where(a => carts.Any(c => c.UserId == a.UserId))
                .Select(b => new ListModel
                {
                    UserId = b.UserId,
                    Name = b.Name,
                    Email = b.Email,
                    Address = b.Address,
                    Cpf = b.Cpf,
                    Phone = b.Phone
                }
                ).ToList();

            foreach (var item in carts)
            {
                var cart = carts.Find(a => a.UserId == item.UserId);
            }

            return users_cart;
        }
    }
}
