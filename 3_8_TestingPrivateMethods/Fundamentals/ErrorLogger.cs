using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_8_TestingPrivateMethods.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;
        private Guid _errorId;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write the log to a storage
            // ...

            OnErrorLogged(Guid.NewGuid());
        }
        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}
