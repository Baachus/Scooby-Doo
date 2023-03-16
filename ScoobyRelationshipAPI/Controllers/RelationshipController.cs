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

        /// <summary>
        /// This is a method to return all of the relationships of Scooby-Doo and the Gang.
        /// </summary>
        /// <returns>All ScoobRelations in the database as a list of ScoobRelations</returns>
        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult<List<ScoobRelation>> GetScoobyRelations()
        {
            return relationshipRepository.GetAllRelationships();
        }

        /// <summary>
        /// This is a method to return a relationship of Scooby-Doo and the Gang by their ID.
        /// </summary>
        /// <param name="id">ID to identify which relationship to retrieve</param>
        /// <returns>ScoobRelation that matches the ID provided</returns>
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public ScoobRelation GetScoobyRelationById(int id)
        {
            return relationshipRepository.GetRelationshipById(id);
        }

        /// <summary>
        /// This is a method to return a relationship of Scooby-Doo and the Gang by their Name.
        /// </summary>
        /// <param name="name">Name to identify which relationship to retrieve</param>
        /// <returns>ScoobRelation that matches the name provided</returns>
        [HttpGet]
        [Route("/[controller]/[action]/{name}")]
        public ScoobRelation GetScoobyRelationByName(string name)
        {
            return relationshipRepository.GetRelationshipByName(name);
        }

        /// <summary>
        /// This is a method to add a relationship of Scooby-Doo and the Gang.
        /// </summary>
        /// <param name="relationship">ScoobRelation that is to be added to the database</param>
        /// <returns>ScoobRelation that was added</returns>
        [HttpPost]
        [Route("/[controller]/[action]")]
        public ScoobRelation AddScoobyRelation(ScoobRelation relationship)
        {
            return relationshipRepository.AddRelationship(relationship);
        }

        /// <summary>
        /// This is a method to update a relationship of Scooby-Doo and the Gang.
        /// </summary>
        /// <param name="relationship">ScoobRelation that is to be updated</param>
        /// <returns>ScoobRelation that was updated</returns>
        [HttpPut]
        [Route("/[controller]/[action]")]
        public ScoobRelation UpdateScoobyRelation(ScoobRelation relationship)
        {
            return relationshipRepository.UpdateRelationship(relationship);
        }

        /// <summary>
        /// This is a method to delete a relationship of Scooby-Doo and the Gang.
        /// </summary>
        /// <param name="id">ID of the relationship to be deleted</param>
        [HttpDelete]
        [Route("/[controller]/[action]/{id}")]
        public void DeleteScoobyRelationById(int id)
        {
            relationshipRepository.DeleteScoobyRelationById(id);
        }

        /// <summary>
        /// This is a method to delete a relationship of Scooby-Doo and the Gang.
        /// </summary>
        /// <param name="name">Name of the relationship to be deleted</param>
        [HttpDelete]
        [Route("/[controller]/[action]/{name}")]
        public void DeleteScoobyRelationByName(string name)
        {
            relationshipRepository.DeleteRelationshipByName(name);
        }
    }
}