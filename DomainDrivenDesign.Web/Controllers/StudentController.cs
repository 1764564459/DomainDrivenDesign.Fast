using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDrivenDesign.Application.Interface;
using DomainDrivenDesign.Application.ViewModel;
using DomainDrivenDesign.Domain.Commands.Student;
using DomainDrivenDesign.Domain.Core.Command;
using DomainDrivenDesign.Domain.Core.NotificationHandler;
using DomainDrivenDesign.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentAppService _sevice;
        CommandBase _command;

        DomainNotificationHandler _notify;
        public StudentController(IStudentAppService service,INotificationHandler<DomainNotification> notify)
        {
            _sevice = service;
            _notify = (DomainNotificationHandler)notify;
        }

        public IActionResult Add(StudentViewModel input)
        {
            //_command =
            //    new RegisterStudentCommand(input.Name, input.Email, input.Phone, input.BirthDate);
            //if (!_command.IsVaild())
            //{
            //    _command.ValidationResult.
            //    List<string> _err = new List<string>();
            //    foreach (var err in _command.ValidationResult.Errors)
            //    {
            //        _err.Add(err.ErrorMessage);
            //    }

            //    return Ok(new {_err });
            //}
            _sevice.Register(input);

            var notify = _notify.GetNotify();
            if (notify.Any())
            {
                foreach (var item in notify)
                {
                        //item.Value
                }
            }

            return Ok();
        }

        public IActionResult Remove([FromQuery] Guid Id)
        {
            _command = new RemoveStudentCommand(Id);
            if (!_command.IsVaild())
            {
                List<string> _err = new List<string>();
                foreach (var err in _command.ValidationResult.Errors)
                {
                    _err.Add(err.ErrorMessage);
                }

                return Ok(_err);
            }

            _sevice.Remove(Id);
            return Ok();
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            var _data = _sevice.GetAll();
            return Ok(new { data=_data});
        }
    }
}