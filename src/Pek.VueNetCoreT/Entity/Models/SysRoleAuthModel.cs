using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>角色权限表</summary>
public partial class SysRoleAuthModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }

    /// <summary>存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔</summary>
    public String? AuthValue { get; set; }

    /// <summary>菜单编号</summary>
    public Int32 SysMenuId { get; set; }

    /// <summary>角色编号</summary>
    public Int32 RoleId { get; set; }

    /// <summary>用户编号</summary>
    public Int32 UserId { get; set; }

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
    public void Copy(ISysRoleAuth model)
    {
        Id = model.Id;
        AuthValue = model.AuthValue;
        SysMenuId = model.SysMenuId;
        RoleId = model.RoleId;
        UserId = model.UserId;
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
