using application.interfaces.paging;
using System;
using System.Text;

namespace application.cqrs._base
{
    public class CommandResponseBase : ICommandResponse
    {
        public CommandResponseBase(string entity, object id)
        {
            Entity = entity;
            ID = id;
        }

        public object ID { get; }

        public string Entity { get; }


    }
}
