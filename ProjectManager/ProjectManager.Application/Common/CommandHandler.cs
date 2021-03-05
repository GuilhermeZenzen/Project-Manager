using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ProjectManager.Application.Interfaces;

namespace ProjectManager.Application.Common
{
    public class CommandHandler
    {
        protected IUnitOfWork _unitOfWork;

        public CommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    }
}
