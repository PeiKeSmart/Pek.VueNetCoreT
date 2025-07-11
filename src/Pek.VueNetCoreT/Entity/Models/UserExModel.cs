using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>用户扩展表</summary>
public partial class UserExModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }
    #endregion

    #region 拷贝
    /// <summary>拷贝模型对象</summary>
    /// <param name="model">模型</param>
    public void Copy(IUserEx model)
    {
        Id = model.Id;
    }
    #endregion
}
