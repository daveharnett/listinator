using ListinatorDomain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Listinator.Controllers
{
    [ApiController]
    public class ListController : ControllerBase
    {
        private IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        [Route("api/List")]
        public ActionResult<IEnumerable<ListSummaryDto>> Get()
        {
            var result = _listService.GetLists();
            return Ok(result);
        }

        [Route("api/List/{id}")]
        [HttpGet]
        public ActionResult<ListDto> Get(Guid id)
        {
            var result = _listService.GetList(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [Route("api/List/Count")]
        [HttpGet]
        public ActionResult GetCounts()
        {
            var result = _listService.GetCounts();
            return Ok(result);
        }

        [Route("api/List/{id}")]
        [HttpPost]
        public ActionResult PostItem(Guid id, [FromBody] string text)
        {
            var result = _listService.AddItem(id, text);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
