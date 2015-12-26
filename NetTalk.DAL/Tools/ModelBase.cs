using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Objects;
using NetTalk.DAL;

namespace NetTalk.DAL.Model
{
    public class ModelBase
    {
        private NetTalkEntities _api;
        public NetTalkEntities DB
        {
            get { return _api ?? (_api = new NetTalkEntities()); }
            set
            {
                _api = value;
            }
        }
        
        public string SaveError
        {
            get;
            set;
        }

        public int Save()
        {
            int result = -1;
            try
            {
                result = DB.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    SaveError = ex.InnerException.Message;
                else
                    SaveError = ex.Message;
            }
            return result;
        }
    }

    public class ModelBase<TEntity> : ModelBase where TEntity : class
    {
        public ObjectQuery<TEntity> Table => ((IObjectContextAdapter) DB).ObjectContext.CreateObjectSet<TEntity>();

        public IQueryable<TEntity> Find()
        {
            return Table;
        }

        public virtual void Insert(TEntity currentEntity)
        {
            DB.Set<TEntity>().Add(currentEntity);
        }

        public virtual void Delete(TEntity currentEntity)
        {
            DB.Set<TEntity>().Remove(currentEntity);
        }

        public virtual TEntity Find(string key, object value)
        {
            return Table.Where("it." + key + " = @val", new ObjectParameter("val", value)).FirstOrDefault();
        }

        public ObjectQuery<TEntity> Find(string searchKeys, ObjectParameter[] searchValues)
        {
            return !string.IsNullOrEmpty(searchKeys) ? Table.Where(searchKeys, searchValues) : Table;
        }
    }
}
