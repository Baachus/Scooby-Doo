using Microsoft.AspNetCore.Mvc;
using ScoobWebApp.Producer;

namespace ScoobWebApp.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IRelationshipUtil relationshipUtil;

        public RelationshipController(IRelationshipUtil relationshipUtil)
        {
            this.relationshipUtil = relationshipUtil;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await relationshipUtil.GetRelationship());
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await relationshipUtil.GetRelationshipById(id));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await relationshipUtil.GetRelationshipById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Create(ScoobRelation relation)
        {
            await relationshipUtil.CreateRelationship(relation);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await relationshipUtil.GetRelationshipById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ScoobRelation relation)
        {
            await relationshipUtil.EditRelationship(relation);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ScoobRelation relation)
        {
            try
            {
                await relationshipUtil.DeleteRelationship(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
