using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Commands.Student;
using DomainDrivenDesign.Domain.Core.Bus;
using DomainDrivenDesign.Domain.Events.Student;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Domain.Models;
using MediatR;

namespace DomainDrivenDesign.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,IRequestHandler<RegisterStudentCommand,Unit>,IRequestHandler<UpdateStudentCommand,Unit>,IRequestHandler<RemoveStudentCommand,Unit>
    {
        IUnitOfWork _unit;
        IMediatorHandler _mediator;
        IStudentRepository _context;
        
        public StudentCommandHandler(IUnitOfWork unit,IMediatorHandler mediator,IStudentRepository context):base(unit,mediator)
        {
            _context = context;
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsVaild())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            var _address = new Address(request.Province, request.City, request.County, request.Street);
            var _student =
                new Student(request.Name, request.Email, request.Phone, request.BirthDate,
                    _address);

            _context.Add(_student);
            //保存
            if (SaveChanges())
            {
                _mediator.RaiseEvent(new RegisterStudentEvent(request.Id, request.Name,request.Email, request.BirthDate,
                    request.Phone));
            }

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Unit());

        }

        public Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Unit());

        }
    }
}
