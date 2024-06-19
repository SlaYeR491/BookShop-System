using BookShop.API.Dtos;
using BookShop.API.Mapping;
using BookShop.Data;
using BookShop.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoomsController(IRoomServices roomService,
        IRoomDetailServices detailsServices,
        ICustomerRoomServices customerRoomServices,
        Mapper<Room, RoomDto> roommapper,
        Mapper<CustomerRoom, CustomerRoomDto> custroommapper,
        Mapper<RoomDetail, RoomDetailsDto> roomdetmapper) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> CreateRoom(RoomDto roomDto)
        {
            var Exist = await roomService.AddAsync(roommapper.Map(roomDto));
            if (Exist == null) return BadRequest();
            return Ok(roommapper.Map(Exist));
        }
        [HttpGet]
        public async Task<ActionResult> SearchRoom(string BookTitle)
        {
            var room = await roomService.SearchAsync(BookTitle);
            if (room == null)
                return NotFound();
            return Ok(roommapper.Map(room));
        }
        [HttpPost]
        public async Task<ActionResult> JoinRoom(CustomerRoomDto roomDto)
        {
            var done = await customerRoomServices.JoinAsync(custroommapper.Map(roomDto));
            if (done == null)
                return BadRequest();
            return Ok(custroommapper.Map(done));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDetailsDto>>?> LoadChat(int RoomId)
        {
            var details = await detailsServices.LoadChatAsync(RoomId);
            return Ok(details.Select(roomdetmapper.Map));
        }
        [HttpPost]
        public async Task<ActionResult> SendMessage(RoomDetailsDto detailsDto)
        {
            var detail = await detailsServices.SendMessageAsync(roomdetmapper.Map(detailsDto));
            return Ok(roomdetmapper.Map(detail));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMessage(int msgId)
        {
            var detail = await detailsServices.DeleteMessageAsync(msgId);
            return Ok(roomdetmapper.Map(detail));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMessage(RoomDetailsDto detailsDto)
        {
            var msg = await detailsServices.UpdateMessageAsync(roomdetmapper.Map(detailsDto));
            return Ok(roomdetmapper.Map(msg));
        }
    }
}
