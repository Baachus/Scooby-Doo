using Microsoft.AspNetCore.Mvc;
using ScoobyRelationship.Data;
using ScoobyRelationship.Repository;

namespace ScoobyRelationship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationshipController : ControllerBase
    {
        private readonly IRelationshipRepository relationshipRepository;

        public RelationshipController(IRelationshipRepository relationshipRepository)
        {
            this.relationshipRepository = relationshipRepository;
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to return all of the relationships of Scooby-Doo and the Gang.
        ***/
        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult<List<ScoobRelation>> GetScoobyRelations()
        {
            return relationshipRepository.GetAllRelationships();
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to return a relationship of Scooby-Doo and the Gang by their ID.
        ***/
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public ScoobRelation GetScoobyRelationById(int id)
        {
            return relationshipRepository.GetRelationshipById(id);
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to return a relationship of Scooby-Doo and the Gang by their Name.
        ***/
        [HttpGet]
        [Route("/[controller]/[action]/{name}")]
        public ScoobRelation GetScoobyRelationByName(string name)
        {
            return relationshipRepository.GetRelationshipByName(name);
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to add a relationship of Scooby-Doo and the Gang.
        ***/
        [HttpPost]
        [Route("/[controller]/[action]")]
        public ScoobRelation AddScoobyRelation(ScoobRelation relationship)
        {
            return relationshipRepository.AddRelationship(relationship);
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to update a relationship of Scooby-Doo and the Gang.
        ***/
        [HttpPut]
        [Route("/[controller]/[action]")]
        public ScoobRelation UpdateScoobyRelation(ScoobRelation relationship)
        {
            return relationshipRepository.UpdateRelationship(relationship);
        }

        /***
        * Created: 1/10/2023
        * Author: Robert Chapin
        * This is a simple method to delete a relationship of Scooby-Doo and the Gang.
        ***/
        [HttpDelete]
        [Route("/[controller]/[action]/{id}")]
        public void DeleteScoobyRelation(int id)
        {
            relationshipRepository.DeleteRelationship(id);
        }
    }
}