using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.interfaces.mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMapping(Profile configuration);
    }
}
