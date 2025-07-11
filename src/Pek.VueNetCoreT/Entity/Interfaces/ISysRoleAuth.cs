using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>角色权限表</summary>
public partial interface ISysRoleAuth
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔</summary>
    String? AuthValue { get; set; }

    /// <summary>菜单编号</summary>
    Int32 SysMenuId { get; set; }

    /// <summary>角色编号</summary>
    Int32 RoleId { get; set; }

    /// <summary>用户编号</summary>
    Int32 UserId { get; set; }

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
