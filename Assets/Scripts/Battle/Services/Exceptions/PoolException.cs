using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work2.Battle.Services.Exceptions
{

    [Serializable]
    public class PoolException : Exception
    {
        public PoolException() { }
        public PoolException(string message) : base(message) { }
        public PoolException(string message, Exception inner) : base(message, inner) { }
        protected PoolException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
