using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTalk.BLL
{
    public class BLLResult
    {
        public BLLResult()
        {
            IsSuccess = false;
            FieldErrorList = new RuleViolationCollection();
            ErrorMessage = "";
            Model = null;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public object Model
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get;
            set;
        }

        public RuleViolationCollection FieldErrorList
        {
            get;
            set;
        }
    }
}
