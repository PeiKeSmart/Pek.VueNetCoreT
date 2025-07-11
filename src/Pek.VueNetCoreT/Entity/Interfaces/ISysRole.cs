using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>系统角色表</summary>
public partial interface ISysRole
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>菜单名称</summary>
    String Name { get; set; }

    /// <summary>部门名称</summary>
    String? DeptName { get; set; }

    /// <summary>部门编号</summary>
    Int32 DeptId { get; set; }

    /// <summary>是否启用</summary>
    Boolean Enable { get; set; }

    /// <summary>排序号</summary>
    Int32 OrderNo { get; set; }

    /// <summary>父级角色ID</summary>
    Int32 ParentId { get; set; }

    /// <summary>删除该角色的用户（软删除标记）</summary>
    String? DeleteBy { get; set; }

    /// <summary>创建者</summary>
    String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    DateTime CreateTime { get; set; }

    /// <summary>创建地址</summary>
    String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    DateTime UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    String? UpdateIP { get; set; }
    #endregion
}
