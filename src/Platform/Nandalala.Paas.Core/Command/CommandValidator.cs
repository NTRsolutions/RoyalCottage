using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nandalala.Paas.Core.Command
{
    public class CommandValidator<TCommand> : ICommandHandler<TCommand> where TCommand : CommandBase
    {
        private readonly IServiceProvider _container;
        private readonly ICommandHandler<TCommand> _handler;

        public CommandValidator(ICommandHandler<TCommand> handler, IServiceProvider container)
        {
            _handler = handler;
            _container = container;
        }

        public void Handle(TCommand command)
        {
            var context = new ValidationContext(command,
                _container, null);

            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(command, context, validationResults, true);
            if (validationResults.Count > 0)
            {
                throw new ValidationException(JsonConvert.SerializeObject(validationResults));
            }

            _handler.Handle(command);
        }
    }
}
