using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Net5.Areas.Test.Controllers.NuclearTest.ReqModel
{
    /// <summary>
    /// Greetings
    /// </summary>
    public class Greetings
    {
        /// <summary>
        /// Your name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Some message
        /// </summary>
        public string GreetingMessage { get; set; }
        /// <summary>
        /// Nodes
        /// </summary>
        public ICollection<Greetings> Children { get; set; }

        public override string ToString()
        {
            return $"{GreetingMessage ?? "Hello"}, {Name}.";
        }
    }
}
