using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>用户扩展表</summary>
public partial interface IUserEx
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }
    #endregion
}
