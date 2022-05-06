using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;
        public CommentsController(ICommentsService commentsService, IMapper mapper)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCommentById(int id)
        {
            var comment = await _commentsService.GetCommentById(id);
            return Ok(comment);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetCommentByUser(int userId)
        {
            var comments = await _commentsService.GetCommentsByUserId(userId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentsCreateDto commentCreateDto)
        {
            var comment = _mapper.Map<CommentsCreateDto,Comments>(commentCreateDto);
            var response = await _commentsService.AddComment(comment);
            var responseDto = _mapper.Map<Comments,CommentsCreateDto>(response);
            return Ok(responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditComment(int id, CommentsUpdateDto commentsUpdateDto)
        {
            var existingComment = await _commentsService.GetCommentById(id);
            if (existingComment == null)
                return NotFound();
            var comment = _mapper.Map(commentsUpdateDto, existingComment);
            await _commentsService.EditComment(comment, id);
            var commentDto = _mapper.Map<CommentsUpdateDto>(comment);
            return Ok(commentDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _commentsService.DeleteComment(id);
            var commentDto = _mapper.Map<CommentsUpdateDto>(comment);
            return Ok(commentDto);
        }

    }
}
