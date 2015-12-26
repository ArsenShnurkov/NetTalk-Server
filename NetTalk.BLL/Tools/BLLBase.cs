using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NetTalk.BLL
{
    [DataObject]
    public class BLLBase<TEntity> where TEntity : class
    {
        protected NetTalk.DAL.Model.ModelBase<TEntity> BaseApi { get; set; }
        public string Key { get; set; }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual List<TEntity> List(string DefaultSort, DynamicSearch.ConditionList Search, string Sort, int PageIndex, int PageSize)
        {
            if (string.IsNullOrEmpty(Sort))
                Sort = DefaultSort;

            return BaseApi.Find(Search.GetString(), Search.GetParam())
                 .OrderBy(Sort.EntitySort()).Skip(PageIndex * PageSize).Take(PageSize).ToList();
        }

        public virtual int ListCount(DynamicSearch.ConditionList Search)
        {
            return BaseApi.Find(Search.GetString(), Search.GetParam()).Count();
        }

        public virtual TEntity Find(Guid value)
        {
            return BaseApi.Find(Key, value);
        }

        public virtual BLLResult Delete(string idList)
        {
            List<Guid> ids = idList.ToGuidArray();
            foreach (Guid g in ids)
            {
                BaseApi.Delete(BaseApi.Find(Key, g));
            }
            BLLResult res = new BLLResult();
            res.IsSuccess = (BaseApi.Save() > 0);
            res.ErrorMessage = BaseApi.SaveError;

            return res;
        }
    }
}
