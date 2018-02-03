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
    public enum CreateTemplateResult
    {
        [Description("操作成功")]
        Success = 1,

        [Description("名称必填")]
        NameRequired = 1001,

        [Description("版本号必填")]
        VersionRequired = 1002,

        [Description("描述必填")]
        DescriptionRequired = 1003,

        [Description("正文必填")]
        BodyRequired = 1004,

        [Description("名称不存在，无法新增版本")]
        TransformNotFound = 2001,

        [Description("版本已存在，无法新增")]
        TemplateVersionExisted = 2002
    }
}
