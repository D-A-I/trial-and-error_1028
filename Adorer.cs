using System;
using Microsoft.Extensions.Configuration;
// using trial_and_error_1022;
using trial_and_error_1028.kurumi;

namespace trial_and_error_1028
{
    public interface IAdorer
    {
        Tasks Find();
    }

    /// <summary>
    /// kurumiを愛でる者
    /// </summary>
    public class Adorer : IAdorer
    {
        IConfigurationRoot _configuration;
        public Adorer(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public Tasks Find()
        {
            return new Tasks();
        }
    }
}