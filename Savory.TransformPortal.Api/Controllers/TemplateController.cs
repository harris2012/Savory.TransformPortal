using Savory.Repository.TransformDB.Entity;
using Savory.TransformPortal.Api.Result;
using Savory.TransformPortal.Api.Vo;
using Savory.TransformPortal.Repository;
using Savory.TransformService.Contract;
using Savory.TransformService.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Savory.TransformPortal.Api.Controllers
{
    public class TemplateController : ApiController
    {
        [HttpPost]
        public List<TemplateVo> Items(string name)
        {
            List<TemplateVo> returnValue = null;

            List<TemplateEntity> entityList = null;
            using (var context = new SavoryTransformDBContext())
            {
                entityList = (from template in context.Template
                              where template.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                              where template.DataStatus == 1
                              select template).ToList();
            }

            if (entityList != null && entityList.Count > 0)
            {
                returnValue = new List<TemplateVo>();
                foreach (var entity in entityList)
                {
                    var transformVo = ToVo(entity);

                    returnValue.Add(transformVo);
                }
            }

            return returnValue;
        }

        [HttpPost]
        public TemplateVo item(string name, string version)
        {
            TemplateVo returnValue = null;

            TemplateEntity entity = null;
            using (var context = new SavoryTransformDBContext())
            {
                entity = (from template in context.Template
                          where template.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                          where template.Version.Equals(version, StringComparison.OrdinalIgnoreCase)
                          where template.DataStatus == 1
                          select template).FirstOrDefault();
            }

            if (entity != null)
            {
                returnValue = ToVo(entity);
            }

            return returnValue;
        }

        [HttpPost]
        public JsonResultModel Create(TemplateVo template)
        {
            CreateTemplateResult returnValue = RealCreateTransform(template);

            JsonResultModel response = new JsonResultModel();
            response.Status = (int)returnValue;
            response.Message = EnumExtension.GetDescription(returnValue);

            return response;
        }

        private CreateTemplateResult RealCreateTransform(TemplateVo template)
        {
            if (string.IsNullOrEmpty(template.Name))
            {
                return CreateTemplateResult.NameRequired;
            }

            if (string.IsNullOrEmpty(template.Version))
            {
                return CreateTemplateResult.VersionRequired;
            }

            if (string.IsNullOrEmpty(template.Description))
            {
                return CreateTemplateResult.DescriptionRequired;
            }

            if (string.IsNullOrEmpty(template.Body))
            {
                return CreateTemplateResult.BodyRequired;
            }

            using (var context = new SavoryTransformDBContext())
            {
                var existingTransform = context.Transform.FirstOrDefault(v => v.Name.Equals(template.Name, StringComparison.OrdinalIgnoreCase) && v.DataStatus == 1);
                if (existingTransform == null)
                {
                    return CreateTemplateResult.TransformNotFound;
                }

                var existingTemplate = context.Template.FirstOrDefault(v => v.Name.Equals(template.Name, StringComparison.OrdinalIgnoreCase) &&
                    v.Version.Equals(template.Version, StringComparison.OrdinalIgnoreCase) &&
                    v.DataStatus == 1);
                if (existingTemplate != null)
                {
                    return CreateTemplateResult.TemplateVersionExisted;
                }

                var templateEntity = new TemplateEntity();
                templateEntity.Name = template.Name;
                templateEntity.Version = template.Version;
                templateEntity.Body = template.Body;
                templateEntity.Extension = template.Extension;
                templateEntity.ItemJsonValue = template.ItemJsonValue;
                templateEntity.Description = template.Description;
                templateEntity.DataStatus = 1;
                templateEntity.CreateUser = "zhang";
                templateEntity.CreateTime = DateTime.Now;
                templateEntity.LastUpdateUser = "zhang";
                templateEntity.LastUpdateTime = DateTime.Now;
                context.Template.Add(templateEntity);

                context.SaveChanges();
            }

            return CreateTemplateResult.Success;
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="templateBody"></param>
        /// <param name="itemJsonValue"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResultModel Preview(TemplateVo template)
        {
            if (string.IsNullOrEmpty(template.Body))
            {
                return new JsonResultModel { Message = "模版必传" };
            }

            var client = new TransformServiceClient();
            var response = client.Preview(template.Body, template.Extension, template.ItemJsonValue);

            if (response.PreviewStatus != (int)PreviewStatus.Success)
            {
                return new JsonResultModel { Data = response };
            }

            return new JsonResultModel { Status = 1, Data = response.Output };
        }

        private TemplateVo ToVo(TemplateEntity entity)
        {
            TemplateVo templateVo = null;

            if (entity != null)
            {
                templateVo = new TemplateVo();

                templateVo.Id = entity.Id;
                templateVo.Name = entity.Name;
                templateVo.Version = entity.Version;
                templateVo.Description = entity.Description;
                templateVo.Body = entity.Body;
                templateVo.ItemJsonValue = entity.ItemJsonValue;
                templateVo.DataStatus = entity.DataStatus;
                templateVo.CreateUser = entity.CreateUser;
                templateVo.LastUpdateUser = entity.LastUpdateUser;
                templateVo.CreateTime = entity.CreateTime;
                templateVo.LastUpdateTime = entity.LastUpdateTime;
            }

            return templateVo;
        }
    }
}
