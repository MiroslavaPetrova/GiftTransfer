using GiftSystem.Data;
using GiftSystem.Models;
using GiftSystem.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace GiftSystem.Controllers
{
    public class GiftsController : Controller
    {
        private readonly GiftSystemDbContext context;

        public GiftsController(GiftSystemDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(GiftsCreateInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var gift = new Gift
            {
                Id = inputModel.Id,
                Credits = inputModel.Credits,
                Sender = inputModel.Sender,
                // Beneficiary = inputModel.Beneficiary.PhoneNumber   =>  automapper matches it perfectly fine
                //gift.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value => SenderId
            };
            gift.Sender.Credits -= gift.Beneficiary.Credits;

            this.context.Gifts.Add(gift);
            this.context.SaveChanges();

            //return this.Redirect("/Transfers/My"); 
            return this.View();
        }
    }
}