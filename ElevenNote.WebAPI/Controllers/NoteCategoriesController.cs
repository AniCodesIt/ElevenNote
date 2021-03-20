using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;


namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteCategoriesController : ApiController
    {
        private CategoriesService CategoriesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoriesService = new CategoriesService(userId);
            return categoriesService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            CategoriesService categoriesService = CategoriesService();
            var categories = categoriesService.GetCategories();
            return Ok(categories);
        }
        [HttpPost]
        public IHttpActionResult Post(NoteCategoriesCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CategoriesService();

            if (!service.AddCategoriesToNote(model))
                return InternalServerError();

            return Ok();
        }    
       [HttpDelete]
        public IHttpActionResult Delete(NoteCategoriesEdit model)
        {
            var service = CategoriesService();

            if (!service.DeleteCategoriesFromNote(model))
                return InternalServerError();

            return Ok();
        }
    }
}