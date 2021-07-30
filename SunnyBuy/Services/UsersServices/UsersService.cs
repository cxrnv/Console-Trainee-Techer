using SunnyBuy.Entitities;
using SunnyBuy.Entitities.DB;
using SunnyBuy.Services.UsersServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SunnyBuy.Services.UsersServices
{
    public class UsersService
    {
        UserDB user = new UserDB();
        CartEntitie cart = new CartEntitie();

        public List<ListModel> GetUsers(int userid)
        {
            return user.UsersList()
                .Where(a => a.UserId == userid)
                .Select(c => new ListModel
                {
                    UserId = c.UserId,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Cpf = c.Cpf,
                    Phone = c.Phone
                })
                .ToList();
        }

        public bool PostUser(int userid)
        {
            var model = new PostModel();

            model.UserId = userid;
            model.Name = "";
            model.Email = " ";
            model.Address = " ";

            return user.PostUserEntity(model);
        }

        public List<ListModel> ShowUsersCart()
        {
            var carts = cart.CartsList()
                                .Where(a => !a.Deleted)
                                .Select(b => new
                                {
                                    b.CartId,
                                    b.UserId
                                })
                                .ToList();

            var users = user.UsersList()
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

            return users;
        }

    }
}
