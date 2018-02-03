using Savory.Repository.TransformDB.Entity;
using Savory.TransformPortal.Api.Result;
using Savory.TransformPortal.Api.Vo;
using Savory.TransformPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Savory.TransformPortal.Api.Controllers
{
    public class TransformController : ApiController
    {

        [HttpPost]
        public List<TransformVo> Items()
        {
            List<TransformVo> returnValue = null;

            List<TransformEntity> entityList = null;
            using (var savoryTransformDBContext = new SavoryTransformDBContext())
            {
                entityList = (from transform in savoryTransformDBContext.Transform where transform.DataStatus == 1 select transform).ToList();
            }

            if (entityList != null && entityList.Count > 0)
            {
                returnValue = new List<TransformVo>();
                foreach (var entity in entityList)
                {
                    var transformVo = ToVo(entity);

                    returnValue.Add(transformVo);
                }
            }

            return returnValue;
        }

        [HttpPost]
        public TransformVo item(string transformId)
        {
            TransformVo returnValue = null;

            TransformEntity entity = null;
            using (var context = new SavoryTransformDBContext())
            {
                entity = (from transform in context.Transform where transform.Name.Equals(transformId, StringComparison.OrdinalIgnoreCase) select transform).FirstOrDefault();
            }

            if (entity != null)
            {
                returnValue = ToVo(entity);
            }

            return returnValue;
        }

        [HttpPost]
        public JsonResultModel Create(TransformVo transform)
        {
            JsonResultModel response = new JsonResultModel();

            CreateTransformResult returnValue = RealCreateTransform(transform);

            response.Status = (int)returnValue;
            response.Message = EnumExtension.GetDescription(returnValue);

            return response;
        }

        private CreateTransformResult RealCreateTransform(TransformVo transform)
        {
            if (string.IsNullOrEmpty(transform.Name))
            {
                return CreateTransformResult.NameRequired;
            }

            if (string.IsNullOrEmpty(transform.Title))
            {
                return CreateTransformResult.TitleRequired;
            }

            if (string.IsNullOrEmpty(transform.Description))
            {
                return CreateTransformResult.DescriptionRequired;
            }

            using (var context = new SavoryTransformDBContext())
            {
                var existingTransform = context.Transform.FirstOrDefault(v => v.Name.Equals(transform.Name, StringComparison.OrdinalIgnoreCase) && v.DataStatus == 1);

                if (existingTransform != null)
                {
                    return CreateTransformResult.NameExisted;
                }

                var transformEntity = new TransformEntity();
                transformEntity.Name = transform.Name;
                transformEntity.Title = transform.Title;
                transformEntity.Description = transform.Description;
                transformEntity.DataStatus = 1;
                transformEntity.CreateUser = "zhang";
                transformEntity.CreateTime = DateTime.Now;
                transformEntity.LastUpdateUser = "zhang";
                transformEntity.LastUpdateTime = DateTime.Now;
                context.Transform.Add(transformEntity);

                context.SaveChanges();
            }

            return CreateTransformResult.Success;
        }

        private TransformVo ToVo(TransformEntity entity)
        {
            TransformVo transoformVo = null;

            if (entity != null)
            {
                transoformVo = new TransformVo();

                transoformVo.Id = entity.Id;
                transoformVo.Name = entity.Name;
                transoformVo.Title = entity.Title;
                transoformVo.Description = entity.Description;
                transoformVo.DataStatus = entity.DataStatus;
                transoformVo.CreateUser = entity.CreateUser;
                transoformVo.LastUpdateUser = entity.LastUpdateUser;
                transoformVo.CreateTime = entity.CreateTime;
                transoformVo.LastUpdateTime = entity.LastUpdateTime;
            }

            return transoformVo;
        }
    }
}
