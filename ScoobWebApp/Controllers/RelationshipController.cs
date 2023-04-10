using Microsoft.AspNetCore.Mvc;
using ScoobWebApp.Producer;
using X.PagedList;

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
    public async Task<IActionResult> List(int? page,
                                        string currentFilter,
                                        string sortOrder = "Id",
                                        string searchString = "")
    {
        ViewBag.CurrentSort = sortOrder;
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
            page = 1;
        }
        else
            searchString = currentFilter;
        ViewBag.CurrentFilter = searchString;

        IOrderedEnumerable<ScoobRelation> orderedRelation = sortOrder.ToLower() switch
        {
            "name" => relationships.OrderBy(r => r.Name),
            "name_desc" => relationships.OrderByDescending(r => r.Name),
            "gang" => relationships.OrderBy(r => r.Gang.ToString()),
            "gang_desc" => relationships.OrderByDescending(r => r.Gang.ToString()),
            "relationship" => relationships.OrderBy(r => r.Relationship),
            "relationship_desc" => relationships.OrderByDescending(r => r.Relationship),
            "id" => relationships.OrderBy(r => r.Id),
            _ => relationships.OrderByDescending(r => r.Id),
        };

        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var onePageOfRelationships = orderedRelation.ToPagedList(pageNumber, pageSize);
        return View(onePageOfRelationships);
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
