using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _cache;

        public CommentsController(ICommentsService commentsService, IMapper mapper, IMemoryCache cache)
        {
            _commentsService = commentsService;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCommentById(int id)
        {
            var comment = await _commentsService.GetCommentById(id);
            if (comment == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(comment.UserId, User))
                return Forbid();
            var commentDto = _mapper.Map<Comments, CommentsReadDto>(comment);
            return Ok(commentDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetCommentsByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();
            var comments = await _commentsService.GetCommentsByUserId(userId);
            var commentsDto = _mapper.Map<List<Comments>,List<CommentsReadDto>>(comments);
            return Ok(commentsDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("products/{productId}")]
        public async Task<ActionResult> GetCommentsByProduct(int productId)
        {
            var comments = await _commentsService.GetCommentsByProductId(productId);
            var commentsDto = _mapper.Map<List<Comments>, List<CommentsReadDto>>(comments);
            return Ok(commentsDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentsCreateDto commentCreateDto)
        {
            if (!Extensions.IsCurrentUser(commentCreateDto.UserId, User))
                return Forbid();
            var comment = _mapper.Map<CommentsCreateDto,Comments>(commentCreateDto);
            var response = await _commentsService.AddComment(comment);
            var commentDto = _mapper.Map<Comments, CommentsReadDto>(response);
            string cacheKey = "product" + comment.UserId;
            _cache.Remove(cacheKey);
            return Ok(commentDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult> EditComment(CommentsUpdateDto commentsUpdateDto)
        {
            var existingComment = await _commentsService.GetCommentById(commentsUpdateDto.Id);
            if (existingComment == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(existingComment.UserId, User))
                return Forbid();
            var comment = _mapper.Map(commentsUpdateDto, existingComment);
            await _commentsService.EditComment(comment, commentsUpdateDto.Id);
            var commentDto = _mapper.Map<CommentsUpdateDto>(comment);
            string cacheKey = "product" + comment.UserId;
            _cache.Remove(cacheKey);
            return Ok(commentDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _commentsService.GetCommentById(id);
            if(comment == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(comment.UserId, User) && !User.IsInRole("ADMIN"))
                return Forbid();
            await _commentsService.DeleteComment(comment);
            var commentDto = _mapper.Map<CommentsUpdateDto>(comment);
            string cacheKey = "product" + comment.UserId;
            _cache.Remove(cacheKey);
            return Ok(commentDto);
        }

    }
}
