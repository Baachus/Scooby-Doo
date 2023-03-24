using Microsoft.AspNetCore.Mvc;
using ScoobWebApp.Producer;

namespace ScoobWebApp.Controllers;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sortOrder">the column that should be sorted by in the relationship table.
    /// This defaults to ID in Ascending order</param>
    /// <returns></returns>
    public async Task<IActionResult> List(string sortOrder="Id", string searchString = "")
    {
        ViewBag.IdSortParam = sortOrder == "Id" ? "Id_desc" : "Id";
        ViewBag.NameSortParam = sortOrder == "Name" ? "Name_desc" : "Name";
        ViewBag.GangSortParam = sortOrder == "Gang" ? "Gang_desc" : "Gang";
        ViewBag.RelationshipSortParam = sortOrder == "Relationship" ? "Relationship_desc" : "Relationship";

        IEnumerable<ScoobRelation> relationships = await relationshipUtil.GetRelationship();
        
        searchString = searchString.ToLower();

        if (!String.IsNullOrEmpty(searchString))
        {
            relationships = relationships.Where(s =>
                s.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                || s.Gang.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                || s.Relationship.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        IOrderedEnumerable<ScoobRelation> orderedRelation;

        switch (sortOrder.ToLower())
        {
            case "name":
                orderedRelation = relationships.OrderBy(r => r.Name);
                break;
            case "name_desc":
                orderedRelation = relationships.OrderByDescending(r => r.Name);
                break;
            case "gang":
                orderedRelation = relationships.OrderBy(r => r.Gang.ToString());
                break;
            case "gang_desc":
                orderedRelation = relationships.OrderByDescending(r => r.Gang.ToString());
                break;
            case "relationship":
                orderedRelation = relationships.OrderBy(r => r.Relationship);
                break;
            case "relationship_desc":
                orderedRelation = relationships.OrderByDescending(r => r.Relationship);
                break;
            case "id":
                orderedRelation = relationships.OrderBy(r => r.Id);
                break;
            case "id_desc":
            default:
                orderedRelation = relationships.OrderByDescending(r => r.Id);
                break;
        }
        return View(orderedRelation);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ScoobRelation relation)
    {
        await relationshipUtil.CreateRelationship(relation);
        return RedirectToAction("List");
    }

    public async Task<IActionResult> Delete(int id)
    {
        return View(await relationshipUtil.GetRelationshipById(id));
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

    public async Task<IActionResult> Details(int id)
    {
        return View(await relationshipUtil.GetRelationshipById(id));
    }
}
