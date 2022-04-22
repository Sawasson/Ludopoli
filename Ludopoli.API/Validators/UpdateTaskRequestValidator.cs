using FluentValidation;
using Ludopoli.API.DataModels;
using Ludopoli.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludopoli.API.Validators
{
    public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator(ITaskRepository taskRepository)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PriorityId).NotEmpty().Must(id =>
            {
                var priority = taskRepository.GetPriorityList()
                .FirstOrDefault(x => x.Id == id);

                if (priority != null)
                {
                    return true;
                }

                return false;
            }).WithMessage("Please select a valid Priority");

            RuleFor(x => x.StatusId).NotEmpty().Must(id =>
            {
                var status = taskRepository.GetStatusList()
                .FirstOrDefault(x => x.Id == id);

                if (status != null)
                {
                    return true;
                }

                return false;
            }).WithMessage("Please select a valid Status");
        }

    }
}
