using System;
using System.Collections.Generic;
using System.Text;
using Sample.Core.Framework;

namespace Sample.Core.Services
{
    public interface ITextProviderService
    {   
        string GetText(string viewModelName, string key);
    }

    public class TextProviderService : ITextProviderService
    {
        readonly Dictionary<string, Dictionary<string, string>> _resources;
        public TextProviderService()
        {
            var builder = new TextResourceAssembler();
            _resources = builder.GetResources();
        }

        public string GetText(string viewModelName, string key)
        {
            return _resources[viewModelName][key];
        }
    }
}
