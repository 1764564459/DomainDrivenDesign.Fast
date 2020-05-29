using DomainDrivenDesign.Application.Interface;
using DomainDrivenDesign.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DomainDrivenDesign.Domain.Core.Bus;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Domain.Models;
using DomainDrivenDesign.Domain.Commands.Student;

namespace DomainDrivenDesign.Application.Service
{
    public class StudentAppService : IStudentAppService
    {
        IStudentRepository _context;
        IMapper _mapper;
        IMediatorHandler _mediator;
        public StudentAppService(IStudentRepository context,IMapper mapper,IMediatorHandler mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(_context.GetAll());
        }


        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_context.GetById(id));
        }

        public void Register(StudentViewModel customerViewModel)
        {
            //_context.Add(_mapper.Map<Student>(customerViewModel));
            var _command = _mapper.Map<RegisterStudentCommand>(customerViewModel);
            _mediator.SendCommand(_command);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
        }

        public void Update(StudentViewModel customerViewModel)
        {
            _context.Update(_mapper.Map<Student>(customerViewModel));
        }
    }
}
