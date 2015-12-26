using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace NetTalk.DAL
{
    public static class DALTools
    {
        public static ObjectQuery<T> FindIn<T>(this ObjectQuery<T> input, string SearchKeys, ObjectParameter[] Params)
        {
            if (!string.IsNullOrEmpty(SearchKeys))
                return input.Where(SearchKeys, Params);
            else
                return input;
        }
    }
}
