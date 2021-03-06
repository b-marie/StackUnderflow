﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Business;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionService _svc;
        private readonly ResponseService _ressvc;

        public QuestionsController(QuestionService svc, ResponseService ressvc)
        {
            _svc = svc;
            _ressvc = ressvc;
        }

        // GET: api/Questions
        [Authorize]
        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {

            Console.WriteLine("Got into the controller!");
            return _svc.GetAllQuestions();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] int id)
        {
            return Ok(_svc.FindQuestionById(id));
        }

        // POST: api/Questions/5
        [HttpPost("{id}/up")]
        public async Task<IActionResult> UpvoteQuestion([FromBody] int questionId)
        {
            _svc.UpvoteQuestion(questionId);
            return NoContent();
        }
        [HttpPost("{id}/down")]
        public async Task<IActionResult> DownvoteQuestion([FromBody] int questionId)
        {
            _svc.DownvoteQuestion(questionId);
            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            _svc.AddQuestion(question.Text, question.Topic, question.AskedBy);
            return NoContent();
        }
        

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            var question = _svc.FindQuestionById(id);
            _svc.DeleteQuestion(question);
            return Ok(question);
        }

        // GET: api/Questions/5/Responses
        [HttpGet("{id}/Responses")]
        public List<Response> GetQuestionResponses([FromRoute] int id)
        {
            return _ressvc.GetResponsesByQuestionId(id);
        }
    }
}