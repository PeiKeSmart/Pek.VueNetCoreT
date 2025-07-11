using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>菜单基础信息表</summary>
public partial interface ISysMenu
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>菜单名称</summary>
    String Name { get; set; }

    /// <summary>权限配置。JSON格式存储Actions</summary>
    String? Auth { get; set; }

    /// <summary>图标</summary>
    String? Icon { get; set; }

    /// <summary>说明</summary>
    String? Description { get; set; }

    /// <summary>是否启用</summary>
    Boolean Enable { get; set; }

    /// <summary>排序号</summary>
    Int32 OrderNo { get; set; }

    /// <summary>关联表名</summary>
    String? TableName { get; set; }

    /// <summary>父级菜单ID</summary>
    Int32 ParentId { get; set; }

    /// <summary>菜单链接</summary>
    String? Url { get; set; }

    /// <summary>菜单类型：0=PC端，1=移动端</summary>
    String? MenuType { get; set; }

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
