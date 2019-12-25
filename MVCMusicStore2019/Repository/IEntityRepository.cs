using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Repository
{
    public interface IEntityRepository<T> where T:class,new()
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void AddAndSave(T entity);
        void Edit(T entity);
        T GetSingleById(Guid id);//根据一条ID选择匹配记录
        bool Delete(Guid id);//根据ID删除一条记录
        IQueryable<T1> GetRelevance<T1>();//获取关联类数据集
        T1 GetSingleRelevance<T1>(Guid id);
    }
}
