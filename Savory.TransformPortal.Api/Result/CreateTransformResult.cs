using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TransformPortal.Api.Result
{
    /// <summary>
    /// 创建模版返回状态码
    /// </summary>
    public enum CreateTransformResult
    {
        [Description("操作成功")]
        Success = 1,

        [Description("名称必填")]
        NameRequired = 1001,

        [Description("标题必填")]
        TitleRequired = 1002,

        [Description("描述必填")]
        DescriptionRequired = 1003,

        [Description("名称已存在，不能重复添加")]
        NameExisted = 2001
    }
}
