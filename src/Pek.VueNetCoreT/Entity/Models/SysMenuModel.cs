using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>菜单基础信息表</summary>
public partial class SysMenuModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }

    /// <summary>菜单名称</summary>
    public String Name { get; set; } = null!;

    /// <summary>权限配置。JSON格式存储Actions</summary>
    public String? Auth { get; set; }

    /// <summary>图标</summary>
    public String? Icon { get; set; }

    /// <summary>说明</summary>
    public String? Description { get; set; }

    /// <summary>是否启用</summary>
    public Boolean Enable { get; set; }

    /// <summary>排序号</summary>
    public Int32 OrderNo { get; set; }

    /// <summary>关联表名</summary>
    public String? TableName { get; set; }

    /// <summary>父级菜单ID</summary>
    public Int32 ParentId { get; set; }

    /// <summary>菜单链接</summary>
    public String? Url { get; set; }

    /// <summary>菜单类型：0=PC端，1=移动端</summary>
    public String? MenuType { get; set; }

    /// <summary>创建者</summary>
    public String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    public Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    public DateTime CreateTime { get; set; }

    /// <summary>创建地址</summary>
    public String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    public String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    public Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    public String? UpdateIP { get; set; }
    #endregion

    #region 拷贝
    /// <summary>拷贝模型对象</summary>
    /// <param name="model">模型</param>
    public void Copy(ISysMenu model)
    {
        Id = model.Id;
        Name = model.Name;
        Auth = model.Auth;
        Icon = model.Icon;
        Description = model.Description;
        Enable = model.Enable;
        OrderNo = model.OrderNo;
        TableName = model.TableName;
        ParentId = model.ParentId;
        Url = model.Url;
        MenuType = model.MenuType;
        CreateUser = model.CreateUser;
        CreateUserID = model.CreateUserID;
        CreateTime = model.CreateTime;
        CreateIP = model.CreateIP;
        UpdateUser = model.UpdateUser;
        UpdateUserID = model.UpdateUserID;
        UpdateTime = model.UpdateTime;
        UpdateIP = model.UpdateIP;
    }
    #endregion
}
